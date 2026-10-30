using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SolidWorks.Interop.sldworks;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        public class FileTimeInfo
        {
            public string FileName;

            public DateTime FileCreateTime;
        }

        private class FileUtils
        {
            public static FileTimeInfo GetLatestFileTimeInfo(string dir, string ext)
            {
                List<FileTimeInfo> list = new List<FileTimeInfo>();
                DirectoryInfo directoryInfo = new DirectoryInfo(dir);
                FileInfo[] files = directoryInfo.GetFiles();
                foreach (FileInfo fileInfo in files)
                {
                    if (fileInfo.Extension.ToUpper() == ext.ToUpper())
                    {
                        list.Add(new FileTimeInfo
                        {
                            FileName = fileInfo.FullName,
                            FileCreateTime = fileInfo.CreationTime
                        });
                    }
                }
                IOrderedEnumerable<FileTimeInfo> source = list.OrderBy((FileTimeInfo x) => x.FileCreateTime);
                return source.LastOrDefault();
            }
        }

        private SldWorks swApp = null;

        private ModelDoc2 ModleDoc = null;

        private ModelDoc2 DrawModleDoc = null;

        private ModelDoc2 swAssemModleDoc = null;

        private Sheet swSheet;

        private IContainer components = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            open_swfile("", getProcesson("SLDWORKS"), "SldWorks.Application");
        }

        public int getProcesson(string processName)
        {
            int result = 0;
            try
            {
                Process[] processesByName = Process.GetProcessesByName(processName);
                int num = 0;
                if (num < processesByName.Length)
                {
                    Process process2 = processesByName[num];
                    result = 1;
                    return result;
                }
            }
            catch
            {
            }
            return result;
        }

        public void open_swfile(string filepath, int x, string pgid)
        {
            switch (x)
            {
                case 0:
                    MessageBox.Show("当前solidwoks无启动");
                    break;
                case 1:
                    {
                        Type typeFromProgID = Type.GetTypeFromProgID(pgid);
                        swApp = (SldWorks)Marshal.GetActiveObject("SldWorks.Application");
                        ModleDoc = (ModelDoc2)(dynamic)swApp.ActiveDoc;
                        break;
                    }
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            open_swfile("", getProcesson("SLDWORKS"), "SldWork.Application");
            int Errors = -1;
            int Warnings = -1;
            string text = "C:\\Users\\Administrator\\Desktop\\参数化骨架\\231XXG11301A.SLDPRT";
            swApp.OpenDoc6(text, 1, 16, "", ref Errors, ref Warnings);
            object[] array = (dynamic)swApp.GetDocuments();
            int num = 1;
            object[] array2 = array;
            foreach (object obj in array2)
            {
                ModelDoc2 modelDoc = (ModelDoc2)obj;
                MessageBox.Show("SW进程打开的所有文档-" + num + ":" + modelDoc.GetTitle());
                num++;
            }
            MessageBox.Show("当前激活的文档为：被激活后");
            SldWorks sldWorks = swApp;
            int Errors2 = Errors;
            sldWorks.ActivateDoc3(text, UseUserPreferences: true, 2, ref Errors2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            swApp = (SldWorks)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("B2F1524F-6CFE-4386-B472-AB1148DEA4F1")));
            swApp.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            open_swfile("", getProcesson("SLDWORKS"), "SldWork.Application");
            int Errors = -1;
            int Warnings = -1;
            string fileName = "C:\\Users\\Administrator\\Desktop\\参数化骨架\\231XXG11301A.SLDPRT";
            ModelDoc2 modelDoc = swApp.OpenDoc6(fileName, 1, 16, "", ref Errors, ref Warnings);
            modelDoc.AddConfiguration3("文档添加配置示例", "", "", 128);
            ConfigurationManager configurationManager = modelDoc.ConfigurationManager;
            configurationManager.AddConfiguration("配置管理器添加配置示例", "", "", 128, "默认", "");
            Configuration activeConfiguration = configurationManager.ActiveConfiguration;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            open_swfile("", getProcesson("SLDWORKS"), "SldWork.Application");
            ModelDocExtension extension = ModleDoc.Extension;
            string[] array = (dynamic)ModleDoc.GetConfigurationNames();
            bool WasResolved = false;
            CustomPropertyManager customPropertyManager = ((IModelDocExtension)extension).get_CustomPropertyManager("");
            string ValOut = "";
            string ResolvedValOut = "";
            customPropertyManager.Get5("图号", UseCached: true, out ValOut, out ResolvedValOut, out WasResolved);
            string ValOut2 = "";
            string ResolvedValOut2 = "";
            customPropertyManager.Get5("物料编码", UseCached: true, out ValOut2, out ResolvedValOut2, out WasResolved);
            string pathName = ModleDoc.GetPathName();
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(pathName);
            customPropertyManager.Add3("图号", 30, fileNameWithoutExtension, 2);
            customPropertyManager.Add3("物料编码", 30, fileNameWithoutExtension, 2);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            open_swfile("", getProcesson("SLDWORKS"), "SldWork.Application");
            ModelDocExtension extension = ModleDoc.Extension;
            extension.SetUserPreferenceInteger(259, 0, 3);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string templateName = "Z:\\附件\\赢合自定义属性\\机加A4惠州赢合新.slddrt";
            open_swfile("", getProcesson("SLDWORKS"), "SldWork.Application");
            DrawingDoc drawingDoc = (DrawingDoc)ModleDoc;
            string[] array = (dynamic)drawingDoc.GetSheetNames();
            drawingDoc.SetupSheet5(array[0], 12, 12, 0.0, 0.0, FirstAngle: true, templateName, 0.0, 0.0, "默认", RemoveModifiedNotes: true);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string templateName = "Z:\\附件\\赢合自定义属性\\装配体YH-A4新.drwdot";
            open_swfile("", getProcesson("SLDWORKS"), "SldWork.Application");
            DrawingDoc drawingDoc = (DrawingDoc)ModleDoc;
            string[] array = (dynamic)drawingDoc.GetSheetNames();
            drawingDoc.SetupSheet5(array[0], 12, 12, 0.0, 0.0, FirstAngle: true, templateName, 0.0, 0.0, "默认", RemoveModifiedNotes: true);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button10_Click(object sender, EventArgs e)
        {
            open_swfile("", getProcesson("SLDWORKS"), "SldWork.Application");
            string text = textBox1.Text.ToString();
            string dir = text + "\\";
            FileTimeInfo latestFileTimeInfo = FileUtils.GetLatestFileTimeInfo(dir, ".SLDPRT");
            MessageBox.Show(latestFileTimeInfo.FileName);
            SelectionMgr selectionMgr = (dynamic)ModleDoc.SelectionManager;
            Component2 component = (dynamic)selectionMgr.GetSelectedObjectsComponent4(1, 0);
            string name = component.Name2;
            string fileName = latestFileTimeInfo.FileName;
            // 去掉临时文件占位符（~）后替换；原代码用两个正则实现，改为字符串替换，行为一致、开销更小
            string fileName2 = fileName.Replace("~", string.Empty);
            AssemblyDoc assemblyDoc = null;
            swAssemModleDoc = ModleDoc;
            assemblyDoc = (AssemblyDoc)swAssemModleDoc;
            SelectData data = ((SelectionMgr)(dynamic)swAssemModleDoc.SelectionManager).CreateSelectData();
            component.Select4(Append: false, data, ShowPopup: false);
            assemblyDoc.ReplaceComponents(fileName2, "默认", ReplaceAllInstance: true, ReAttachMates: true);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("软件版本2023.6.06  江铭制作");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            open_swfile("", getProcesson("SLDWORKS"), "SldWork.Application");
            SelectionMgr selectionMgr = (dynamic)ModleDoc.SelectionManager;
            AssemblyDoc assemblyDoc = null;
            swAssemModleDoc = ModleDoc;
            assemblyDoc = (AssemblyDoc)swAssemModleDoc;
            string title = swAssemModleDoc.GetTitle();
            string text = title.Substring(0, 4);
            SelectData data = ((SelectionMgr)(dynamic)swAssemModleDoc.SelectionManager).CreateSelectData();
            Component2 component = null;

            // ===== 与图号前缀字母无关的传动件删除，只执行一次（原代码嵌套在字母循环中重复执行了 25 次）=====
            for (int k = 0; k < 10; k++)
            {
                component = assemblyDoc.GetComponentByName("LBE-CM500pa-4(乐波尔)-" + k.ToString().Trim());
                if (component != null)
                {
                    component.Select4(Append: false, data, ShowPopup: false);
                    ModleDoc.EditDelete();
                }
            }
            for (int l = 0; l < 10; l++)
            {
                component = assemblyDoc.GetComponentByName("LBE-CM-60paX-4(乐波尔)-" + l.ToString().Trim());
                if (component != null)
                {
                    component.Select4(Append: false, data, ShowPopup: false);
                    ModleDoc.EditDelete();
                }
            }
            for (int m = 0; m < 10; m++)
            {
                component = assemblyDoc.GetComponentByName("LBE-CM250PaX4(乐波尔)-" + m.ToString().Trim());
                if (component != null)
                {
                    component.Select4(Append: false, data, ShowPopup: false);
                    ModleDoc.EditDelete();
                }
            }
            for (int n = 0; n < 10; n++)
            {
                component = assemblyDoc.GetComponentByName("YBE-500PA(北京乐波尔科技)-" + n.ToString().Trim());
                if (component != null)
                {
                    component.Select4(Append: false, data, ShowPopup: false);
                    ModleDoc.EditDelete();
                }
            }
            for (int num = 0; num < 10; num++)
            {
                component = assemblyDoc.GetComponentByName("YBE2300-±60PA(北京乐波尔科技)-" + num.ToString().Trim());
                if (component != null)
                {
                    component.Select4(Append: false, data, ShowPopup: false);
                    ModleDoc.EditDelete();
                }
            }
            for (int num2 = 0; num2 < 30; num2++)
            {
                component = assemblyDoc.GetComponentByName("KQG2L08-02S(L型旋转接头)-" + num2.ToString().Trim());
                if (component != null)
                {
                    component.Select4(Append: false, data, ShowPopup: false);
                    ModleDoc.EditDelete();
                }
            }
            for (int num4 = 391; num4 < 2000; num4 += 100)
            {
                for (int num5 = 0; num5 < 60; num5++)
                {
                    component = assemblyDoc.GetComponentByName(num4.ToString().Trim() + "x174x16-附图(环形硅胶密封胶条)-" + num5.ToString().Trim());
                    if (component != null)
                    {
                        component.Select4(Append: false, data, ShowPopup: false);
                        ModleDoc.EditDelete();
                    }
                }
            }
            for (int num6 = 0; num6 < 20; num6++)
            {
                component = assemblyDoc.GetComponentByName("8x7x36(平键)-1");
                if (component != null)
                {
                    Component2 component2 = component.GetParent();
                    Component2 component3 = null;
                    string text4 = component2.Name2.Substring(0, 13);
                    component3 = assemblyDoc.GetComponentByName(text4 + num6.ToString().Trim());
                    if (component3 != null)
                    {
                        component3.Select4(Append: false, data, ShowPopup: false);
                        ModleDoc.EditDelete();
                    }
                }
            }
            for (int num7 = 0; num7 < 5; num7++)
            {
                component = assemblyDoc.GetComponentByName("VH400-04(SMC)-" + num7.ToString().Trim());
                if (component != null)
                {
                    component.Select4(Append: false, data, ShowPopup: false);
                    ModleDoc.EditDelete();
                }
            }

            // ===== 依赖图号前缀字母的传动件删除（前缀 + A~Y + 编号）=====
            for (char c = 'A'; c < 'Z'; c = (char)(c + 1))
            {
                string text2 = text + c.ToString().Trim();
                for (int i = 0; i < 30; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        component = assemblyDoc.GetComponentByName(text2 + "G9" + j.ToString().Trim() + "000A-" + i.ToString().Trim());
                        if (component != null)
                        {
                            component.Select4(Append: false, data, ShowPopup: false);
                            ModleDoc.EditDelete();
                        }
                    }
                }
            }
            for (char c2 = 'A'; c2 < 'Z'; c2 = (char)(c2 + 1))
            {
                string text3 = text + c2.ToString().Trim();
                for (int num3 = 0; num3 < 10; num3++)
                {
                    component = assemblyDoc.GetComponentByName(text3 + "G16200A-" + num3.ToString().Trim());
                    if (component != null)
                    {
                        component.Select4(Append: false, data, ShowPopup: false);
                        ModleDoc.EditDelete();
                    }
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            open_swfile("", getProcesson("SLDWORKS"), "SldWork.Application");
            SelectionMgr selectionMgr = (dynamic)ModleDoc.SelectionManager;
            AssemblyDoc assemblyDoc = null;
            swAssemModleDoc = ModleDoc;
            assemblyDoc = (AssemblyDoc)swAssemModleDoc;
            string text = swAssemModleDoc.GetTitle().Substring(0, swAssemModleDoc.GetTitle().LastIndexOf("."));
            string text2 = text.Substring(0, 4);
            SelectData data = ((SelectionMgr)(dynamic)swAssemModleDoc.SelectionManager).CreateSelectData();
            Component2 component = null;
            for (int i = 0; i < 20; i++)
            {
                component = assemblyDoc.GetComponentByName("8x7x36(平键)-1");
                Component2 component2 = null;
                Component2 component3 = null;
                component2 = component.GetParent();
                string text3 = component2.Name2.Substring(0, 13);
                component3 = assemblyDoc.GetComponentByName(text3 + i.ToString().Trim());
                if (component3 != null)
                {
                    component3.Select4(Append: false, data, ShowPopup: false);
                    ModleDoc.EditDelete();
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            open_swfile("", getProcesson("SLDWORKS"), "SldWork.Application");
            string text = textBox2.Text.ToString();
            MessageBox.Show(text);
            string dir = text + "\\";
            FileTimeInfo latestFileTimeInfo = FileUtils.GetLatestFileTimeInfo(dir, ".SLDASM");
            SelectionMgr selectionMgr = (dynamic)ModleDoc.SelectionManager;
            Component2 component = (dynamic)selectionMgr.GetSelectedObjectsComponent4(1, 0);
            string name = component.Name2;
            string fileName = latestFileTimeInfo.FileName;
            // 去掉临时文件占位符（~）后替换；原代码用两个正则实现，改为字符串替换，行为一致、开销更小
            string fileName2 = fileName.Replace("~", string.Empty);
            MessageBox.Show(fileName2);
            AssemblyDoc assemblyDoc = null;
            swAssemModleDoc = ModleDoc;
            assemblyDoc = (AssemblyDoc)swAssemModleDoc;
            SelectData data = ((SelectionMgr)(dynamic)swAssemModleDoc.SelectionManager).CreateSelectData();
            component.Select4(Append: false, data, ShowPopup: false);
            assemblyDoc.ReplaceComponents(fileName2, "默认", ReplaceAllInstance: true, ReAttachMates: true);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void button12_Click(object sender, EventArgs e)
        {
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            ModelDoc2 modelDoc = null;
            open_swfile("", getProcesson("SLDWORKS"), "SldWork.Application");
            PackAndGo packAndGo = null;
            EquationMgr equationMgr = null;
            bool flag = true;
            int num = 0;
            string text = null;
            string text2 = null;
            int[] array = null;
            bool flag2 = false;
            int num2 = 0;
            modelDoc = ModleDoc;
            string pathName = modelDoc.GetPathName();
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(pathName);
            string directoryName = Path.GetDirectoryName(pathName);
            ModelDocExtension extension = ModleDoc.Extension;
            packAndGo = extension.GetPackAndGo();
            packAndGo.IncludeDrawings = true;
            packAndGo.IncludeSimulationResults = false;
            packAndGo.IncludeToolboxComponents = true;
            equationMgr = modelDoc.GetEquationMgr();
            num2 = equationMgr.GetCount();
            for (num = 0; num < num2; num++)
            {
                Debug.Print("  Equation #" + num + " = " + ((IEquationMgr)equationMgr).get_Equation(num));
                flag2 = equationMgr.LinkToFile;
                Debug.Print("  Equation linked to file? " + flag2);
                if (flag2)
                {
                    equationMgr.UpdateValuesFromExternalEquationFile();
                    Debug.Print("  Path and filename of linked equation: " + equationMgr.FilePath);
                }
            }
            Debug.Print(" ");
            text2 = textBox5.Text.ToString();
            string key = fileNameWithoutExtension.ToLower();
            dictionary.Add(key, text2);
            string[] array2 = new string[num2];
            flag = packAndGo.GetDocumentNames(out var DocumentNames);
            array2 = (string[])DocumentNames;
            Debug.Print("");
            Debug.Print("  My Pack and Go path and filenames after adding prefix and suffix: ");
            for (num = 0; num < array2.Length; num++)
            {
                Debug.Print("  替换前  My path and filename is: " + array2[num]);
                foreach (KeyValuePair<string, string> item in dictionary)
                {
                    array2[num] = array2[num].Replace(item.Key, item.Value);
                }
                Debug.Print("  替换后  My path and filename is: " + array2[num]);
            }
            packAndGo.SetDocumentSaveToNames(array2);
            text = textBox4.Text.ToString();
            flag = packAndGo.SetSaveToName(Override: true, text);
            packAndGo.FlattenToSingleFolder = true;
            array = (int[])(dynamic)extension.SavePackAndGo(packAndGo);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string text = textBox6.Text.ToString();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            open_swfile("", getProcesson("SLDWORKS"), "SldWork.Application");
            string templateName = "Z:\\附件\\赢合自定义属性\\机加A4惠州赢合新.drwdot";
            string text = "Z:\\附件\\赢合自定义属性\\机加A4惠州赢合新.slddrt";
            string text2 = "Z:\\附件\\赢合自定义属性\\机加A4惠州赢合新.slddrt";
            ModelDoc2 modelDoc = (ModelDoc2)(dynamic)swApp.ActiveDoc;
            string pathName = modelDoc.GetPathName();
            object obj = swApp.NewDocument(templateName, 12, 0.0, 0.0);
            ModelDocExtension modelDocExtension = null;
            ModelDoc2 modelDoc2 = (ModelDoc2)(dynamic)swApp.ActiveDoc;
            modelDocExtension = modelDoc2.Extension;
            DrawingDoc drawingDoc = (DrawingDoc)modelDoc2;
            drawingDoc.Create3rdAngleViews2(pathName);
            bool flag = false;
            Thread.Sleep(2000);
            flag = modelDocExtension.SelectByID2("YH_A4H", "SHEET", 0.0, 0.0, 0.0, Append: false, 0, null, 0);
            modelDoc2.EditSketch();
            modelDoc2.ViewZoomtofit2();
            flag = modelDocExtension.SketchBoxSelect(0.0, 0.0, 0.0, 0.698568, 0.698568, 0.698568);
            modelDoc2.EditDelete();
            Array array = null;
            array = (Array)(dynamic)drawingDoc.InsertModelAnnotations3(0, 23002648, AllViews: false, DuplicateDims: true, HiddenFeatureDims: false, UsePlacementInSketch: true);
            modelDoc2.ClearSelection2(All: true);
            ExportPdfData exportPdfData = null;
            ModelDocExtension modelDocExtension2 = null;
            Thread.Sleep(2000);
            string text3 = null;
            int Errors = 0;
            int Warnings = 0;
            string[] array2 = null;
            text3 = "D:\\test\\foodprocessor.pdf";
            ModelDoc2 modelDoc3 = (ModelDoc2)(dynamic)swApp.ActiveDoc;
            modelDocExtension2 = modelDoc3.Extension;
            exportPdfData = (ExportPdfData)(dynamic)swApp.GetExportFileData(1);
            DrawingDoc drawingDoc2 = (DrawingDoc)modelDoc3;
            array2 = (string[])(dynamic)drawingDoc2.GetSheetNames();
            int num = 0;
            num = array2.Length;
            int num2 = 0;
            object[] array3 = new object[num - 1];
            DispatchWrapper[] array4 = new DispatchWrapper[num - 1];
            for (num2 = 0; num2 < num - 1; num2++)
            {
                flag = drawingDoc2.ActivateSheet(array2[num2]);
                swSheet = (Sheet)(dynamic)drawingDoc2.GetCurrentSheet();
                array3[num2] = swSheet;
                array4[num2] = new DispatchWrapper(array3[num2]);
            }
            flag = exportPdfData.SetSheets(3, array4);
            exportPdfData.ViewPdfAfterSaving = true;
            flag = modelDocExtension2.SaveAs(text3, 0, 1, exportPdfData, ref Errors, ref Warnings);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
        }

        // ==================== 图纸检查 ====================

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            open_swfile("", getProcesson("SLDWORKS"), "SldWorks.Application");
            if (swApp == null)
            {
                MessageBox.Show("未连接 SolidWorks，请先点击「获取solidwork」或「打开SW」。");
                return;
            }
            if (ModleDoc == null)
            {
                MessageBox.Show("当前没有打开的文档，请先在 SolidWorks 中打开需要检查的工程图。");
                return;
            }
            if (ModleDoc.GetType() != 3)
            {
                MessageBox.Show("当前打开的不是工程图（.slddrw）。\n请先打开要检查的 2D 工程图，再点击「检查当前工程图」。");
                return;
            }

            Cursor = Cursors.WaitCursor;
            try
            {
                List<CheckIssue> issues = DrawingChecker.Check(swApp, ModleDoc);
                ShowCheckReport(issues);
            }
            catch (Exception ex)
            {
                MessageBox.Show("检查失败：" + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void ShowCheckReport(List<CheckIssue> issues)
        {
            int err = issues.Count(i => i.Severity == "错误");
            int warn = issues.Count(i => i.Severity == "警告");
            int hint = issues.Count(i => i.Severity == "提示");

            if (issues.Count == 0)
            {
                MessageBox.Show("检查完成：未发现标注或格式错误。", "图纸检查", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var sb = new System.Text.StringBuilder();
            foreach (var group in issues.GroupBy(i => i.Category))
            {
                sb.AppendLine("【" + group.Key + "】");
                foreach (var item in group)
                {
                    sb.AppendLine("  [" + item.Severity + "]" + (string.IsNullOrEmpty(item.Sheet) ? "" : "（" + item.Sheet + "）") + item.Message);
                }
                sb.AppendLine();
            }

            Form resultForm = new Form();
            resultForm.Text = "图纸检查结果";
            resultForm.StartPosition = FormStartPosition.CenterParent;
            resultForm.FormBorderStyle = FormBorderStyle.Sizable;
            resultForm.MinimizeBox = false;
            resultForm.MaximizeBox = false;
            resultForm.ClientSize = new Size(780, 520);
            resultForm.Font = new Font("等线", 9f);

            var summary = new Label();
            summary.Dock = DockStyle.Top;
            summary.Height = 44;
            summary.Padding = new Padding(12, 10, 12, 0);
            summary.Text = "共发现 " + issues.Count + " 个问题：错误 " + err + " 个、警告 " + warn + " 个、提示 " + hint + " 个。"
                         + System.Environment.NewLine + "以下为问题明细（只读检查，未修改图纸）：";
            resultForm.Controls.Add(summary);

            var btnClose = new Button();
            btnClose.Text = "关闭";
            btnClose.Dock = DockStyle.Bottom;
            btnClose.Height = 36;
            btnClose.Click += delegate { resultForm.Close(); };
            resultForm.Controls.Add(btnClose);

            var tb = new TextBox();
            tb.Multiline = true;
            tb.ReadOnly = true;
            tb.ScrollBars = ScrollBars.Both;
            tb.Dock = DockStyle.Fill;
            tb.Font = new Font("等线", 9.5f);
            tb.BackColor = Color.White;
            tb.Text = sb.ToString();
            resultForm.Controls.Add(tb);

            resultForm.ShowDialog(this);
        }

        // ==================== AI 智能审核 ====================

        private async void buttonAICheck_Click(object sender, EventArgs e)
        {
            open_swfile("", getProcesson("SLDWORKS"), "SldWorks.Application");
            if (swApp == null)
            {
                MessageBox.Show("未连接 SolidWorks，请先点击「获取solidwork」或「打开SW」。");
                return;
            }
            if (ModleDoc == null)
            {
                MessageBox.Show("当前没有打开的文档，请先在 SolidWorks 中打开需要审核的工程图。");
                return;
            }
            if (ModleDoc.GetType() != 3)
            {
                MessageBox.Show("当前打开的不是工程图（.slddrw）。\n请先打开要审核的 2D 工程图，再点击「AI 智能审核」。");
                return;
            }

            AIConfig cfg = AIConfig.Load();
            if (!cfg.HasKey)
            {
                MessageBox.Show(
                    "尚未配置大模型 API Key。\n\n请在程序目录（bin\\Debug）下创建 ai_config.json 并填写 ApiKey，例如：\n" + AIConfig.SampleConfigText(),
                    "AI 审核配置", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Cursor = Cursors.WaitCursor;
            string imagePath = null;
            try
            {
                // 1) 提取图纸结构化上下文（含规则检查结果），全部来自 SolidWorks API 只读提取
                string context = DrawingChecker.BuildReviewContextJson(swApp, ModleDoc);

                // 2) 导出当前图纸图片（失败不阻塞审核；供后续 YOLO / 视觉模型与报告展示使用）
                imagePath = TryExportSheetImage();

                // 3) 调用大模型 API 全面审核
                AIReviewResult result = await AIDrawingReviewer.ReviewAsync(cfg, context);
                if (result.Report == null)
                {
                    MessageBox.Show(result.Error ?? "审核失败：未返回报告。", "AI 图纸审核", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ShowAIReviewReport(result.Report, imagePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("AI 审核失败：" + ex.Message, "AI 图纸审核", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        /// <summary>导出当前工程图为 PNG（保存到程序目录 AI_Review 文件夹），供后续 YOLO / 视觉审核使用。</summary>
        private string TryExportSheetImage()
        {
            try
            {
                string dir = Path.Combine(Application.StartupPath, "AI_Review");
                Directory.CreateDirectory(dir);
                string baseName = "drawing";
                try { baseName = Path.GetFileNameWithoutExtension(ModleDoc.GetTitle()) ?? "drawing"; } catch { }
                string png = Path.Combine(dir, baseName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png");

                // 工程图的图形区 = 活动视图窗口；用 PrintWindow 渲染捕获（无视遮挡），失败退回屏幕捕获
                object viewObj = ModleDoc.ActiveView;
                if (viewObj == null) return null;
                IntPtr hwnd = new IntPtr(((IModelView)viewObj).GetViewHWnd());
                if (hwnd == IntPtr.Zero) return null;

                using (Bitmap bmp = NativeImageCapture.CaptureWindow(hwnd))
                {
                    if (bmp == null) return null;
                    bmp.Save(png, ImageFormat.Png);
                }
                return File.Exists(png) ? png : null;
            }
            catch { return null; }
        }

        private void ShowAIReviewReport(string report, string imagePath)
        {
            Form resultForm = new Form();
            resultForm.Text = "AI 图纸审核报告";
            resultForm.StartPosition = FormStartPosition.CenterParent;
            resultForm.FormBorderStyle = FormBorderStyle.Sizable;
            resultForm.MinimizeBox = false;
            resultForm.MaximizeBox = false;
            resultForm.ClientSize = new Size(860, 640);
            resultForm.Font = new Font("等线", 9f);

            var summary = new Label();
            summary.Dock = DockStyle.Top;
            summary.Height = 30;
            summary.Padding = new Padding(12, 8, 12, 0);
            summary.Text = "以下为 AI 依据图纸结构化数据生成的审核意见（仅供参考，最终以人工复核为准）。"
                         + (string.IsNullOrEmpty(imagePath) ? "" : System.Environment.NewLine + "已导出图纸图片：" + imagePath);
            resultForm.Controls.Add(summary);

            var btnClose = new Button();
            btnClose.Text = "关闭";
            btnClose.Dock = DockStyle.Bottom;
            btnClose.Height = 36;
            btnClose.Click += delegate { resultForm.Close(); };
            resultForm.Controls.Add(btnClose);

            var tb = new TextBox();
            tb.Multiline = true;
            tb.ReadOnly = true;
            tb.ScrollBars = ScrollBars.Both;
            tb.Dock = DockStyle.Fill;
            tb.Font = new Font("等线", 9.5f);
            tb.BackColor = Color.White;
            tb.Text = report;
            resultForm.Controls.Add(tb);

            resultForm.ShowDialog(this);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    /// <summary>
    /// 窗口图像捕获：用 PrintWindow 渲染捕获（无视遮挡），失败时退回屏幕拷贝；
    /// 用于把 SolidWorks 工程图图形区导出为 PNG，供 AI 视觉 / YOLO 审核使用。
    /// </summary>
    internal static class NativeImageCapture
    {
        [DllImport("user32.dll")]
        private static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);
        [DllImport("user32.dll")]
        private static extern bool ClientToScreen(IntPtr hWnd, ref POINT lpPoint);
        [DllImport("user32.dll")]
        private static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, uint nFlags);

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT { public int L, T, R, B; }
        [StructLayout(LayoutKind.Sequential)]
        private struct POINT { public int X, Y; }

        /// <summary>捕获指定窗口客户区图像；失败或内容为空时返回 null。</summary>
        public static Bitmap CaptureWindow(IntPtr hwnd)
        {
            try
            {
                RECT rc;
                if (!GetClientRect(hwnd, out rc)) return null;
                int w = rc.R - rc.L, h = rc.B - rc.T;
                if (w <= 0 || h <= 0) return null;

                Bitmap bmp = new Bitmap(w, h);
                bool ok = false;
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    IntPtr hdc = g.GetHdc();
                    try { ok = PrintWindow(hwnd, hdc, 2); }
                    finally { g.ReleaseHdc(hdc); }

                    if (!ok)
                    {
                        POINT pt = new POINT { X = 0, Y = 0 };
                        if (ClientToScreen(hwnd, ref pt))
                            g.CopyFromScreen(pt.X, pt.Y, 0, 0, new Size(w, h));
                    }
                }

                // 内容自检：全黑/全透明视为捕获失败
                int samples = 0, nonBlack = 0;
                for (int y = 0; y < h; y += 60)
                {
                    for (int x = 0; x < w; x += 60)
                    {
                        Color c = bmp.GetPixel(x, y);
                        samples++;
                        if (c.R > 24 || c.G > 24 || c.B > 24) nonBlack++;
                    }
                }
                if (samples == 0 || nonBlack * 10 < samples)
                {
                    bmp.Dispose();
                    return null;
                }
                return bmp;
            }
            catch { return null; }
        }
    }
}
