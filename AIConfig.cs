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
    /// </summary>
    public class AIConfig
    {
        public string BaseUrl = "https://api.deepseek.com";
        public string ApiKey = "";
        public string Model = "deepseek-chat";
        public int TimeoutSeconds = 120;
        public int MaxTokens = 4000;

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
            }
            catch { }
            return cfg;
        }

        /// <summary>配置文件是否已填写 API Key。</summary>
        public bool HasKey { get { return !string.IsNullOrWhiteSpace(ApiKey); } }

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
                + "  \"MaxTokens\": 4000\n"
                + "}";
        }
    }
}
