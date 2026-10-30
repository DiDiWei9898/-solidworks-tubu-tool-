using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;

namespace WindowsFormsApplication5
{
    /// <summary>
    /// AI 审核配置。从 exe 同目录的 ai_config.json 读取；缺省按 DeepSeek（OpenAI 兼容接口）配置，
    /// 可改 BaseUrl / Model 切换到通义、智谱、火山方舟等任意 OpenAI 兼容端点。
    /// 视觉通道（可选）：配置 VisionBaseUrl / VisionApiKey / VisionModel 后，审核时会把图纸图片
    /// 连同结构化数据一起发送，实现「看图 + 数据」联合审核。缺省指向通义千问 VL（OpenAI 兼容模式）。
    /// </summary>
    public class AIConfig
    {
        public string BaseUrl = "https://api.deepseek.com";
        public string ApiKey = "";
        public string Model = "deepseek-chat";
        public int TimeoutSeconds = 120;
        public int MaxTokens = 4000;

        // ===== 视觉通道（可选）=====
        public string VisionBaseUrl = "https://dashscope.aliyuncs.com/compatible-mode/v1";
        public string VisionApiKey = "";
        public string VisionModel = "qwen-vl-plus";

        public static AIConfig Load()
        {
            var cfg = new AIConfig();
            try
            {
                string dir = AppDomain.CurrentDomain.BaseDirectory;
                string path = Path.Combine(dir, "ai_config.json");
                if (!File.Exists(path)) return cfg;

                string json = File.ReadAllText(path, Encoding.UTF8);
                var dict = new JavaScriptSerializer().Deserialize<Dictionary<string, object>>(json);
                if (dict == null) return cfg;

                cfg.BaseUrl = GetStr(dict, "BaseUrl", cfg.BaseUrl);
                cfg.ApiKey = GetStr(dict, "ApiKey", cfg.ApiKey);
                cfg.Model = GetStr(dict, "Model", cfg.Model);
                cfg.TimeoutSeconds = GetInt(dict, "TimeoutSeconds", cfg.TimeoutSeconds);
                cfg.MaxTokens = GetInt(dict, "MaxTokens", cfg.MaxTokens);
                cfg.VisionBaseUrl = GetStr(dict, "VisionBaseUrl", cfg.VisionBaseUrl);
                cfg.VisionApiKey = GetStr(dict, "VisionApiKey", cfg.VisionApiKey);
                cfg.VisionModel = GetStr(dict, "VisionModel", cfg.VisionModel);
            }
            catch { }
            return cfg;
        }

        /// <summary>配置文件是否已填写 API Key。</summary>
        public bool HasKey { get { return !string.IsNullOrWhiteSpace(ApiKey); } }

        /// <summary>视觉通道是否已配置（填写了视觉 API Key）。</summary>
        public bool HasVisionKey { get { return !string.IsNullOrWhiteSpace(VisionApiKey); } }

        private static string GetStr(Dictionary<string, object> dict, string key, string def)
        {
            object v;
            if (dict.TryGetValue(key, out v) && v != null)
            {
                string s = Convert.ToString(v);
                if (!string.IsNullOrWhiteSpace(s)) return s.Trim();
            }
            return def;
        }

        private static int GetInt(Dictionary<string, object> dict, string key, int def)
        {
            object v;
            if (dict.TryGetValue(key, out v) && v != null)
            {
                try { return Convert.ToInt32(v); } catch { }
            }
            return def;
        }

        /// <summary>生成一份默认配置文件的样例文本（纯 JSON，可直接保存为 ai_config.json 后填写 ApiKey）。</summary>
        public static string SampleConfigText()
        {
            return "{\n"
                + "  \"BaseUrl\": \"https://api.deepseek.com\",\n"
                + "  \"ApiKey\": \"\",\n"
                + "  \"Model\": \"deepseek-chat\",\n"
                + "  \"TimeoutSeconds\": 120,\n"
                + "  \"MaxTokens\": 4000,\n"
                + "  \"VisionBaseUrl\": \"https://dashscope.aliyuncs.com/compatible-mode/v1\",\n"
                + "  \"VisionApiKey\": \"\",\n"
                + "  \"VisionModel\": \"qwen-vl-plus\"\n"
                + "}";
        }
    }
}
