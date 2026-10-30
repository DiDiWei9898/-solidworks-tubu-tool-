using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace WindowsFormsApplication5
{
    /// <summary>审核调用结果：Report 非空即成功；失败时 Error 说明原因。</summary>
    public class AIReviewResult
    {
        public string Report;
        public string Error;
    }

    /// <summary>
    /// AI 图纸审核：把 SolidWorks 提取的图纸结构化上下文发送给大模型 API（默认 DeepSeek，OpenAI 兼容），
    /// 返回全面审核报告。MVP 阶段不依赖 YOLO / OCR；后续 YOLO 检测结果可追加进上下文。
    /// </summary>
    public static class AIDrawingReviewer
    {
        private const string SystemPrompt =
            "你是一位资深的机械制图审核工程师，熟悉 GB 国标制图规范与赢合科技工程图模板规范（标题栏必填：图号/名称/材料(仅机加图)/物料编码/设计/设计日期；" +
            "建议项：审核/批准/工艺审核及对应日期、重量、机型、表面处理、外形尺寸、热处理、精密等级、图纸版本、变更说明等）。" +
            "你会收到一份从 SolidWorks 工程图提取的结构化数据（JSON），包含：图纸与图幅、视图（名称/类型/比例/引用模型）、" +
            "全部标注与注解（文本/位置/字高）、标题栏属性及当前值、规则检查已发现的问题清单。" +
            "请对图纸做全面审核（标注错误 + 格式规范），要求：\n" +
            "1. 只依据提供的数据判断，禁止臆造数据中不存在的标注或问题；不确定的写『需人工复核』；\n" +
            "2. 输出格式：先【总体评价】（2~3 句）；再【问题清单】，每条按「严重度(错误/警告/提示) | 类别 | 位置 | 问题描述 | 修改建议」；最后【改进建议】要点；\n" +
            "3. 规则检查已发现的问题可以归纳引用，但不要逐条复述；重点补充规则检查发现不了的（如标注逻辑矛盾、可能漏标的关键尺寸、比例与图幅不匹配、标题栏信息相互矛盾等）；\n" +
            "4. 使用简体中文，简洁专业。";

    /// <summary>
    /// 视觉通道提示词：模型同时看到「图纸截图」与「结构化数据」，做看图 + 数据联合审核。
    /// </summary>
    private const string VisionSystemPrompt =
        "你是一位资深的机械制图审核工程师，熟悉 GB 国标制图规范与赢合科技工程图模板规范（标题栏必填：图号/名称/材料(仅机加图)/物料编码/设计/设计日期；" +
        "建议项：审核/批准/工艺审核及对应日期、重量、机型、表面处理、外形尺寸、热处理、精密等级、图纸版本、变更说明等）。" +
        "你会同时收到一张工程图纸截图和一份从 SolidWorks 提取的结构化数据（JSON，含图幅/视图/标注与注解/标题栏属性/规则检查问题清单）。" +
        "请结合图片与数据做全面审核（标注错误 + 格式规范），要求：\n" +
        "1. 图片用于核对可见的标注与格式问题（标注重叠/越界/字号/位置/遗漏等），数据用于核对标题栏、视图比例等结构化信息；两者一致时交叉确认，矛盾时以图片为准并注明；\n" +
        "2. 只依据图片中实际可见和 JSON 中实际存在的信息判断，禁止臆造；看不清或不确定的写『需人工复核』；\n" +
        "3. 输出格式：先【总体评价】（2~3 句）；再【问题清单】，每条按「严重度(错误/警告/提示) | 类别 | 位置 | 问题描述 | 修改建议」；最后【改进建议】要点；\n" +
        "4. 使用简体中文，简洁专业。";

    /// <summary>
    /// 调用大模型 API 审核图纸。成功时 Report 返回报告文本；失败时 Error 给出原因。
    /// </summary>
    public static async Task<AIReviewResult> ReviewAsync(AIConfig cfg, string contextJson)
    {
        try
        {
            var messages = new List<object>
            {
                new Dictionary<string, object> { { "role", "system" }, { "content", SystemPrompt } },
                new Dictionary<string, object> { { "role", "user" }, { "content", contextJson } }
            };
            var req = new Dictionary<string, object>
            {
                { "model", cfg.Model },
                { "temperature", 0.3 },
                { "max_tokens", cfg.MaxTokens },
                { "messages", messages }
            };
            string body = new JavaScriptSerializer().Serialize(req);

            using (var client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(cfg.TimeoutSeconds);
                var httpReq = new HttpRequestMessage(HttpMethod.Post, cfg.BaseUrl.TrimEnd('/') + "/chat/completions");
                httpReq.Headers.Add("Authorization", "Bearer " + cfg.ApiKey);
                httpReq.Content = new StringContent(body, Encoding.UTF8, "application/json");

                HttpResponseMessage resp = await client.SendAsync(httpReq).ConfigureAwait(false);
                string respBody = await resp.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (!resp.IsSuccessStatusCode)
                {
                    return new AIReviewResult { Error = "大模型 API 返回 " + (int)resp.StatusCode + "：" + Truncate(respBody, 300) };
                }

                string content = ExtractContent(respBody);
                if (content == null)
                {
                    return new AIReviewResult { Error = "大模型 API 返回结构无法解析：" + Truncate(respBody, 300) };
                }
                return new AIReviewResult { Report = content };
            }
        }
        catch (Exception ex)
        {
            return new AIReviewResult { Error = "调用大模型 API 失败：" + ex.Message };
        }
    }

    /// <summary>
    /// 视觉通道审核：把图纸 PNG（base64 data URL）连同结构化 JSON 一起发送给支持视觉的大模型，
    /// 做「看图 + 数据」联合审核。使用 VisionBaseUrl / VisionApiKey / VisionModel 配置。
    /// </summary>
    public static async Task<AIReviewResult> ReviewWithVisionAsync(AIConfig cfg, string contextJson, string imagePath)
    {
        try
        {
            if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
            {
                return new AIReviewResult { Error = "图纸图片不存在，无法进行视觉审核（图片导出失败）。" };
            }
            long size = new FileInfo(imagePath).Length;
            if (size <= 0 || size > 10 * 1024 * 1024)
            {
                return new AIReviewResult { Error = "图纸图片大小异常（" + size + " 字节），视觉模型不支持。请重新导出后重试。" };
            }

            string b64 = Convert.ToBase64String(File.ReadAllBytes(imagePath));
            string dataUrl = "data:image/png;base64," + b64;

            var textPart = new Dictionary<string, object>
            {
                { "type", "text" },
                { "text", contextJson
                    + "\n\n【补充说明】以上是从 SolidWorks 工程图提取的结构化数据。随消息附带图纸截图（PNG），"
                    + "请结合图片核对标注与格式问题：标注重叠/越界/字高/位置/遗漏、标题栏填写是否完整一致、视图比例与图幅是否匹配等。"
                    + "图片可能与实际打印效果存在轻微缩放，判断尺寸数值以结构化数据为准，判断视觉问题（重叠/越界/对齐/字大小）以图片为准。" }
            };
            var imagePart = new Dictionary<string, object>
            {
                { "type", "image_url" },
                { "image_url", new Dictionary<string, object> { { "url", dataUrl } } }
            };

            var messages = new List<object>
            {
                new Dictionary<string, object> { { "role", "system" }, { "content", VisionSystemPrompt } },
                new Dictionary<string, object> { { "role", "user" }, { "content", new object[] { textPart, imagePart } } }
            };
            var req = new Dictionary<string, object>
            {
                { "model", cfg.VisionModel },
                { "temperature", 0.3 },
                { "max_tokens", cfg.MaxTokens },
                { "messages", messages }
            };
            string body = new JavaScriptSerializer().Serialize(req);

            using (var client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(cfg.TimeoutSeconds);
                var httpReq = new HttpRequestMessage(HttpMethod.Post, cfg.VisionBaseUrl.TrimEnd('/') + "/chat/completions");
                httpReq.Headers.Add("Authorization", "Bearer " + cfg.VisionApiKey);
                httpReq.Content = new StringContent(body, Encoding.UTF8, "application/json");

                HttpResponseMessage resp = await client.SendAsync(httpReq).ConfigureAwait(false);
                string respBody = await resp.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (!resp.IsSuccessStatusCode)
                {
                    return new AIReviewResult { Error = "视觉模型 API 返回 " + (int)resp.StatusCode + "：" + Truncate(respBody, 300) };
                }

                string content = ExtractContent(respBody);
                if (content == null)
                {
                    return new AIReviewResult { Error = "视觉模型 API 返回结构无法解析：" + Truncate(respBody, 300) };
                }
                return new AIReviewResult { Report = content };
            }
        }
        catch (Exception ex)
        {
            return new AIReviewResult { Error = "调用视觉模型 API 失败：" + ex.Message };
        }
    }

        private static string ExtractContent(string respBody)
        {
            try
            {
                var parsed = new JavaScriptSerializer().Deserialize<Dictionary<string, object>>(respBody);
                if (parsed == null || !parsed.ContainsKey("choices")) return null;
                object choicesObj;
                if (!parsed.TryGetValue("choices", out choicesObj)) return null;
                // .NET 4.5 的 JavaScriptSerializer 把 JSON 数组反序列化为 ArrayList（不是 object[]），
                // 这里统一按 IList 取第一个元素，避免“返回结构无法解析”。
                var list = choicesObj as System.Collections.IList;
                if (list == null || list.Count == 0) return null;

                var first = list[0] as Dictionary<string, object>;
                if (first == null || !first.ContainsKey("message")) return null;
                var msg = first["message"] as Dictionary<string, object>;
                if (msg == null || !msg.ContainsKey("content")) return null;
                object contentObj = msg["content"];
                return contentObj == null ? null : Convert.ToString(contentObj);
            }
            catch
            {
                return null;
            }
        }

        private static string Truncate(string s, int max)
        {
            if (string.IsNullOrEmpty(s)) return "(空)";
            s = s.Replace("\r", " ").Replace("\n", " ");
            return s.Length > max ? s.Substring(0, max) + "…" : s;
        }
    }
}
