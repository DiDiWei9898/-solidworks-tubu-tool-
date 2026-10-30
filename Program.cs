using System;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            // .NET 4.5 默认走旧版 TLS，火山方舟/DeepSeek 等 HTTPS 接口要求 TLS1.2+，
            // 不设置会报“发送请求时出错/连接被重置”，这里在进程启动时统一启用 TLS1.2。
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
