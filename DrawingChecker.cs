using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace WindowsFormsApplication5
{
    /// <summary>一条检查结果。</summary>
    public class CheckIssue
    {
        /// <summary>类别：环境 / 标注 / 格式 / 标题栏 / 视图</summary>
        public string Category;
        /// <summary>严重程度：错误 / 警告 / 提示</summary>
        public string Severity;
        /// <summary>所在图纸（Sheet 名），可能为空</summary>
        public string Sheet;
        /// <summary>问题描述</summary>
        public string Message;
    }

    /// <summary>
    /// 当前激活 SolidWorks 工程图（.slddrw）的只读检查器。
    /// 全部操作均为只读，不会修改图纸内容。
    /// 说明：工程图不支持特征树遍历（FirstFeature 在工程图上会失败），
    /// 本检查器采用“视图驱动”遍历：DrawingDoc.GetFirstView + View.GetFirstAnnotation3 迭代。
    /// 图纸视图（标题栏所在视图，无引用模型）中的注解属于模板内容，不参与检查。
    /// </summary>
    public static class DrawingChecker
    {
        // 标题栏必填 / 建议属性 —— 按赢合科技模板（机加A4 / 装配A4惠州赢合）标题栏实际链接的自定义属性制定。
        // 机加图：材料为必填；装配图：标题栏无材料单元格，不要求材料，按建议项提示。
        // 比例不在此处检查：赢合标题栏的比例单元格链接 SW-图纸比例(Sheet Scale) 内置属性，由“视图比例”检查覆盖。
        private static readonly string[] RequiredPropsPart = { "图号", "名称", "材料", "物料编码", "设计", "设计日期" };
        private static readonly string[] RequiredPropsAssembly = { "图号", "名称", "物料编码", "设计", "设计日期" };
        private static readonly string[] SuggestedPropsPart =
        {
            "审核", "审核日期", "批准", "批准日期", "工艺审核", "工艺审核日期",
            "重量", "机型", "表面处理", "外形尺寸", "热处理", "精密等级", "图纸版本", "变更说明"
        };
        private static readonly string[] SuggestedPropsAssembly =
        {
            "材料", "审核", "审核日期", "批准", "批准日期", "工艺审核", "工艺审核日期",
            "重量", "机型", "表面处理", "精密等级", "图纸版本", "变更说明"
        };

        // 标准图幅（毫米）：A0 ~ A4
        private static readonly int[][] StandardSheetSizes =
        {
            new[] { 841, 1189 }, new[] { 594, 841 }, new[] { 420, 594 },
            new[] { 297, 420 }, new[] { 210, 297 }
        };

        // 允许独立比例、不参与“视图比例一致性”比较的视图类型
        private static readonly int[] ScaleExemptViewTypes =
        {
            (int)swDrawingViewTypes_e.swDrawingSheet,
            (int)swDrawingViewTypes_e.swDrawingDetailView,
            (int)swDrawingViewTypes_e.swDrawingDetachedView,
            (int)swDrawingViewTypes_e.swDrawingAlternatePositionView
        };

        private const double OverlapRatioThreshold = 0.35;   // 文本框相交面积占比超过该值判为重叠
        private const double BorderMargin = 0.008;           // 图框边距（米），越界判定用
        private const double SizeToleranceMm = 3.0;          // 图幅判定的容差（毫米）
        private const double HeightDiffTolerance = 0.0008;   // 尺寸数字高度不一致判定（米）
        private const double DefaultCharHeight = 0.0035;     // 默认字高（米），取不到时兜底

        /// <summary>内部记录：一个需要参与位置/重叠检查的标注项。</summary>
        private class AnnoItem
        {
            public string TypeName;
            public bool IsDimension;
            public string SheetName;
            public double CX, CY;      // 中心（图纸坐标系，米）
            public double HW, HH;      // 半宽 / 半高（米）
            public string Text;
        }

        /// <summary>内部记录：一张图纸。</summary>
        private class SheetInfo
        {
            public string Name;
            public double Width, Height;   // 米
        }

        /// <summary>内部记录：一个视图。</summary>
        private class ViewInfo
        {
            public string Name;
            public int ViewType;
            public double ScaleVal;        // 视图比例值（如 0.5 表示 1:2），取不到为 0
            public string SheetName;
            public string RefModel;        // 引用模型名（含扩展名），图纸视图为空
        }

        /// <summary>内部记录：一次检查的收集快照（规则检查与 AI 审核共用）。</summary>
        private class DrawingSnapshot
        {
            public List<SheetInfo> Sheets;
            public List<AnnoItem> Items;
            public List<ViewInfo> Views;
            public bool HasBalloon;
        }

        /// <summary>对当前工程图执行全部检查，返回问题列表。</summary>
        public static List<CheckIssue> Check(SldWorks swApp, ModelDoc2 model)
        {
            DrawingSnapshot snap;
            return RunChecks(model, out snap);
        }

        /// <summary>检查主体：环境校验 + 收集图纸信息 + 规则检查，同时输出收集快照。</summary>
        private static List<CheckIssue> RunChecks(ModelDoc2 model, out DrawingSnapshot snap)
        {
            var issues = new List<CheckIssue>();
            snap = null;

            // ---------- 环境检查 ----------
            if (model == null)
            {
                issues.Add(new CheckIssue { Category = "环境", Severity = "错误", Message = "SolidWorks 中没有打开的文档。" });
                return issues;
            }
            if (model.GetType() != 3)   // swDocDRAWING = 3
            {
                issues.Add(new CheckIssue { Category = "环境", Severity = "错误", Message = "当前打开的不是工程图（.slddrw）。请先打开需要检查的 2D 工程图。" });
                return issues;
            }

            DrawingDoc draw = null;
            try { draw = (DrawingDoc)model; }
            catch { issues.Add(new CheckIssue { Category = "环境", Severity = "错误", Message = "无法将当前文档转换为工程图对象。" }); return issues; }

            string originalSheet = null;
            try { originalSheet = draw.GetCurrentSheet().GetName(); } catch { }

            try
            {
                // ---------- 收集图纸信息 ----------
                List<SheetInfo> sheets = new List<SheetInfo>();
                try
                {
                    string[] names = draw.GetSheetNames();
                    if (names == null || names.Length == 0)
                    {
                        issues.Add(new CheckIssue { Category = "格式", Severity = "错误", Message = "工程图中没有任何图纸（Sheet）。" });
                    }
                    else
                    {
                        foreach (string name in names)
                        {
                            try
                            {
                                draw.ActivateSheet(name);
                                Sheet sh = draw.GetCurrentSheet();
                                double w = 0, h = 0;
                                if (sh.GetSize(ref w, ref h) != 0 && w > 0 && h > 0)
                                {
                                    sheets.Add(new SheetInfo { Name = name, Width = w, Height = h });
                                }
                                else
                                {
                                    issues.Add(new CheckIssue { Category = "格式", Severity = "警告", Message = "图纸「" + name + "」无法读取图幅尺寸。" });
                                }
                            }
                            catch { issues.Add(new CheckIssue { Category = "格式", Severity = "警告", Message = "图纸「" + name + "」读取失败，已跳过。" }); }
                        }
                    }
                }
                catch { issues.Add(new CheckIssue { Category = "格式", Severity = "错误", Message = "无法读取工程图图纸列表。" }); }

                // ---------- 视图驱动遍历：标注 / 注解 / 视图 ----------
                List<AnnoItem> items = new List<AnnoItem>();
                List<ViewInfo> viewInfos = new List<ViewInfo>();
                bool hasBalloon = false;

                View v = null;
                try { v = (View)draw.GetFirstView(); } catch { }
                while (v != null)
                {
                    try
                    {
                        string vName = string.Empty;
                        try { vName = v.GetName2(); } catch { }
                        int vType = -1;
                        try { vType = v.Type; } catch { }
                        string refModel = string.Empty;
                        try { refModel = v.GetReferencedModelName() ?? string.Empty; } catch { }
                        Sheet vsheet = null;
                        try { vsheet = v.Sheet; } catch { }
                        string vSheetName = (vsheet != null) ? vsheet.GetName() : string.Empty;

                        // 视图比例值
                        double scaleVal = 0;
                        try { scaleVal = v.get_IScaleRatio(); } catch { }
                        if (scaleVal <= 0)
                        {
                            try
                            {
                                double[] ratio = (double[])v.ScaleRatio;
                                if (ratio != null && ratio.Length >= 2 && ratio[1] != 0) scaleVal = ratio[0] / ratio[1];
                            }
                            catch { }
                        }
                        viewInfos.Add(new ViewInfo
                        {
                            Name = vName,
                            ViewType = vType,
                            ScaleVal = scaleVal,
                            SheetName = vSheetName,
                            RefModel = refModel
                        });

                        // 图纸视图（标题栏所在视图，无引用模型）：模板内容不参与检查
                        bool isSheetView = string.IsNullOrEmpty(refModel);
                        if (!isSheetView)
                        {
                            Annotation a = null;
                            try { a = v.GetFirstAnnotation3(); } catch { }
                            while (a != null)
                            {
                                try
                                {
                                    object spec = null;
                                    try { spec = a.GetSpecificAnnotation(); } catch { }

                                    if (spec is DisplayDimension dd)
                                    {
                                        CheckDimensionText(dd, issues, vSheetName);
                                    }
                                    else if (spec is Note note)
                                    {
                                        CheckNoteText(note, issues, vSheetName);
                                        try { if (note.GetBalloonSize() > 0) hasBalloon = true; } catch { }
                                    }

                                    AnnoItem item = BuildAnnoItem(a, spec, vSheetName);
                                    if (item != null) items.Add(item);
                                }
                                catch { }
                                try { a = a.GetNext3(); } catch { break; }
                            }
                        }
                    }
                    catch { }
                    try { v = (View)v.GetNextView(); } catch { break; }
                }

                snap = new DrawingSnapshot { Sheets = sheets, Items = items, Views = viewInfos, HasBalloon = hasBalloon };

                // ---------- 检查 1：重复标注 ----------
                CheckDuplicateDimensions(items, issues);

                // ---------- 检查 2：标注 / 注解相互重叠 ----------
                CheckOverlaps(items, issues);

                // ---------- 检查 3：标注 / 注解越界 ----------
                CheckOutOfBounds(items, sheets, issues);

                // ---------- 检查 4：图幅 / 空白图纸 ----------
                CheckSheets(sheets, viewInfos, issues);

                // ---------- 检查 5：视图比例一致性 ----------
                CheckViewScales(viewInfos, issues);

                // ---------- 检查 6：尺寸数字大小一致性 ----------
                CheckDimensionHeightConsistency(items, issues);

                // ---------- 检查 7：标题栏 ----------
                CheckTitleBlock(model, viewInfos, issues);

                // ---------- 检查 8：球标（装配图提示） ----------
                if (!hasBalloon)
                {
                    issues.Add(new CheckIssue
                    {
                        Category = "标注",
                        Severity = "提示",
                        Message = "工程图中未发现球标（如为装配工程图，请核对是否需要标注球标并链接 BOM）。"
                    });
                }
            }
            catch (Exception ex)
            {
                issues.Add(new CheckIssue { Category = "环境", Severity = "错误", Message = "检查过程发生异常：" + ex.Message });
            }
            finally
            {
                // 恢复原激活图纸，避免影响用户当前操作
                try { if (!string.IsNullOrEmpty(originalSheet)) draw.ActivateSheet(originalSheet); } catch { }
            }
            return issues;
        }

        // ==================== AI 审核上下文 ====================

        /// <summary>
        /// 构建 AI 审核上下文（JSON）：图纸结构化信息 + 规则检查结果。
        /// 全部数据来自 SolidWorks API 只读提取；后续 YOLO 检测结果可追加到同一上下文。
        /// </summary>
        public static string BuildReviewContextJson(SldWorks swApp, ModelDoc2 model)
        {
            DrawingSnapshot snap;
            var issues = RunChecks(model, out snap);

            var sb = new System.Text.StringBuilder();
            sb.Append("{");
            sb.Append("\n  \"docTitle\": ").Append(JsonStr(GetTitleSafe(model))).Append(",");

            string path = string.Empty;
            try { path = model.GetPathName() ?? string.Empty; } catch { }
            if (!string.IsNullOrEmpty(path)) sb.Append("\n  \"docPath\": ").Append(JsonStr(path)).Append(",");

            sb.Append("\n  \"sheets\": [");
            if (snap != null)
            {
                for (int i = 0; i < snap.Sheets.Count; i++)
                {
                    if (i > 0) sb.Append(",");
                    sb.Append("\n    {\"name\": ").Append(JsonStr(snap.Sheets[i].Name))
                      .Append(", \"widthMm\": ").Append((snap.Sheets[i].Width * 1000).ToString("0.#"))
                      .Append(", \"heightMm\": ").Append((snap.Sheets[i].Height * 1000).ToString("0.#")).Append("}");
                }
            }
            sb.Append("\n  ],");

            sb.Append("\n  \"views\": [");
            if (snap != null)
            {
                for (int i = 0; i < snap.Views.Count; i++)
                {
                    if (i > 0) sb.Append(",");
                    sb.Append("\n    {\"name\": ").Append(JsonStr(snap.Views[i].Name))
                      .Append(", \"type\": ").Append(snap.Views[i].ViewType)
                      .Append(", \"scale\": ").Append(JsonStr(RatioText(snap.Views[i].ScaleVal)))
                      .Append(", \"sheet\": ").Append(JsonStr(snap.Views[i].SheetName))
                      .Append(", \"refModel\": ").Append(JsonStr(snap.Views[i].RefModel)).Append("}");
                }
            }
            sb.Append("\n  ],");

            sb.Append("\n  \"annotations\": [");
            if (snap != null)
            {
                var bySheet = snap.Items.GroupBy(i => i.SheetName ?? string.Empty).OrderBy(g => g.Key);
                bool firstGroup = true;
                foreach (var g in bySheet)
                {
                    foreach (AnnoItem item in g)
                    {
                        if (!firstGroup) sb.Append(",");
                        firstGroup = false;
                        sb.Append("\n    {\"sheet\": ").Append(JsonStr(item.SheetName))
                          .Append(", \"type\": ").Append(JsonStr(item.TypeName))
                          .Append(", \"text\": ").Append(JsonStr(Truncate(item.Text, 60)))
                          .Append(", \"centerXmm\": ").Append((item.CX * 1000).ToString("0.#"))
                          .Append(", \"centerYmm\": ").Append((item.CY * 1000).ToString("0.#"))
                          .Append(", \"heightMm\": ").Append((item.HH * 2000).ToString("0.#")).Append("}");
                    }
                }
            }
            sb.Append("\n  ],");

            sb.Append("\n  \"titleBlock\": {");
            var props = GetDrawingProperties(model);
            bool firstProp = true;
            foreach (var kv in props)
            {
                if (!firstProp) sb.Append(",");
                firstProp = false;
                sb.Append("\n    ").Append(JsonStr(kv.Key)).Append(": ").Append(JsonStr(kv.Value));
            }
            sb.Append("\n  },");

            sb.Append("\n  \"ruleIssues\": [");
            for (int i = 0; i < issues.Count; i++)
            {
                if (i > 0) sb.Append(",");
                sb.Append("\n    {\"category\": ").Append(JsonStr(issues[i].Category))
                  .Append(", \"severity\": ").Append(JsonStr(issues[i].Severity))
                  .Append(", \"sheet\": ").Append(JsonStr(issues[i].Sheet))
                  .Append(", \"message\": ").Append(JsonStr(issues[i].Message)).Append("}");
            }
            sb.Append("\n  ]");
            sb.Append("\n}");
            return sb.ToString();
        }

        /// <summary>取标题栏涉及的字段全集（赢合模板：机加 + 装配），用于 AI 上下文中列出属性及当前值。</summary>
        public static string[] GetAllTitleBlockProps()
        {
            var set = new HashSet<string>();
            foreach (string s in RequiredPropsPart) set.Add(s);
            foreach (string s in RequiredPropsAssembly) set.Add(s);
            foreach (string s in SuggestedPropsPart) set.Add(s);
            foreach (string s in SuggestedPropsAssembly) set.Add(s);
            return set.ToArray();
        }

        /// <summary>读取图纸文档自定义属性（含未定义但标题栏引用的字段，值为空），供 AI 上下文使用。</summary>
        private static Dictionary<string, string> GetDrawingProperties(ModelDoc2 model)
        {
            var result = new Dictionary<string, string>();
            foreach (string name in GetAllTitleBlockProps()) result[name] = string.Empty;
            try
            {
                ICustomPropertyManager cpm = model.Extension.get_CustomPropertyManager("");
                if (cpm == null) return result;
                object pn = null, pt = null, pv = null, pr = null;
                try { cpm.GetAll2(ref pn, ref pt, ref pv, ref pr); }
                catch
                {
                    // 兜底：逐个字段读取
                    foreach (string name in result.Keys.ToList())
                        result[name] = GetPropertyValue(cpm, name);
                    return result;
                }
                if (pn != null)
                {
                    object[] arr = pn as object[];
                    object[] vals = pv as object[];
                    object[] resol = pr as object[];
                    if (arr == null) { try { arr = (object[])((Array)pn); } catch { } }
                    if (arr != null)
                    {
                        for (int i = 0; i < arr.Length; i++)
                        {
                            string n = (arr[i] == null) ? string.Empty : arr[i].ToString();
                            if (n.Length == 0) continue;
                            string v = (vals != null && i < vals.Length && vals[i] != null) ? vals[i].ToString() : string.Empty;
                            bool r = (resol != null && i < resol.Length && resol[i] != null) && (bool)resol[i];
                            result[n] = r && v.Length == 0 ? string.Empty : v;
                        }
                    }
                }
            }
            catch { }
            return result;
        }

        private static string GetTitleSafe(ModelDoc2 model)
        {
            try { return model.GetTitle() ?? string.Empty; }
            catch { return string.Empty; }
        }

        /// <summary>JSON 字符串转义。</summary>
        private static string JsonStr(string s)
        {
            if (s == null) return "\"\"";
            var sb = new System.Text.StringBuilder("\"");
            foreach (char c in s)
            {
                switch (c)
                {
                    case '"': sb.Append("\\\""); break;
                    case '\\': sb.Append("\\\\"); break;
                    case '\n': sb.Append("\\n"); break;
                    case '\r': sb.Append("\\r"); break;
                    case '\t': sb.Append("\\t"); break;
                    default:
                        if (c < 0x20) sb.Append("\\u").Append(((int)c).ToString("x4"));
                        else sb.Append(c);
                        break;
                }
            }
            sb.Append("\"");
            return sb.ToString();
        }

        // ==================== 文本类检查 ====================

        private static void CheckDimensionText(DisplayDimension dd, List<CheckIssue> issues, string sheet)
        {
            string t;
            try { t = dd.GetText(0) ?? string.Empty; }
            catch { return; }

            string tt = t.Trim();
            if (tt.Length == 0)
            {
                issues.Add(new CheckIssue { Category = "标注", Severity = "错误", Sheet = sheet, Message = "存在空白尺寸文本（尺寸数字缺失）。" });
                return;
            }
            if (Regex.IsMatch(tt, @"^0([.,]0+)?$"))
                issues.Add(new CheckIssue { Category = "标注", Severity = "警告", Sheet = sheet, Message = "尺寸为 0 或 0.00（零尺寸）：「" + tt + "」。请核实该尺寸是否需要标注。" });
            if (t.IndexOf('?') >= 0 || t.IndexOf('<') >= 0)
                issues.Add(new CheckIssue { Category = "标注", Severity = "错误", Sheet = sheet, Message = "尺寸文本含未解析占位符（? 或 < >）：「" + tt + "」。多为丢失参考或链接错误。" });
            if (Regex.IsMatch(t, @"[\u4e00-\u9fff]"))
                issues.Add(new CheckIssue { Category = "标注", Severity = "警告", Sheet = sheet, Message = "尺寸文本中混入汉字（应使用 φ、M 等符号+数字）：「" + tt + "」。" });
        }

        private static void CheckNoteText(Note note, List<CheckIssue> issues, string sheet)
        {
            string t;
            try { t = note.GetText() ?? string.Empty; }
            catch { return; }

            if (t.Trim().Length == 0)
            {
                issues.Add(new CheckIssue { Category = "标注", Severity = "错误", Sheet = sheet, Message = "存在空白注解文本（无内容的技术要求/注释）。" });
                return;
            }
            if (Regex.IsMatch(t, @"\$PRP|PRPSHEET|PRPMODEL|\?\?|<\?+>"))
                issues.Add(new CheckIssue { Category = "标注", Severity = "错误", Sheet = sheet, Message = "注解中属性链接未解析（内容为空或显示为 ??）：「" + t.Trim() + "」。请检查链接的属性是否已填写。" });
        }

        // ==================== 位置 / 重叠 / 越界 ====================

        private static AnnoItem BuildAnnoItem(Annotation ann, object spec, string sheetName)
        {
            try
            {
                // 中心标记 / 中心线是符号而非文本标注，不参与重叠、越界、字高检查
                if (spec is ICenterMark || spec is ICenterLine) return null;

                double[] pos = (double[])ann.GetPosition();
                if (pos == null || pos.Length < 2) return null;
                if (string.IsNullOrEmpty(sheetName)) return null;   // 图纸视图注解/归属不明：不参与位置类检查

                double h, w;
                bool isDim = false;
                if (spec is DisplayDimension dd)
                {
                    isDim = true;
                    h = GetDimensionCharHeight(dd);
                    w = EstimateTextWidth(GetDimensionTextSafe(dd), h);
                }
                else if (spec is Note note)
                {
                    string txt = GetItemTextSafe(spec);
                    h = GetNoteCharHeight(note);
                    w = EstimateTextWidth(txt, h);
                    int lines = Math.Max(1, CountNewLines(txt) + 1);
                    h = h * lines;
                }
                else
                {
                    // 形位公差、表面粗糙度等其他注解：无文本，按较小框估算
                    h = DefaultCharHeight;
                    w = 0.006;
                }
                if (h <= 0) h = DefaultCharHeight;
                if (w <= 0.004) w = 0.004;

                string typeName = isDim ? "DisplayDimension" : (spec is Note ? "Note" : "Annotation");
                return new AnnoItem
                {
                    TypeName = typeName,
                    IsDimension = isDim,
                    SheetName = sheetName,
                    CX = pos[0], CY = pos[1],
                    HW = w / 2.0, HH = h / 2.0,
                    Text = GetItemTextSafe(spec)
                };
            }
            catch { return null; }
        }

        /// <summary>取尺寸文本的字高（米），取不到时用默认值。</summary>
        private static double GetDimensionCharHeight(DisplayDimension dd)
        {
            try
            {
                object fmtObj = dd.GetTextFormat();
                if (fmtObj != null)
                {
                    TextFormat fmt = fmtObj as TextFormat;
                    if (fmt != null)
                    {
                        double ch = fmt.CharHeight;
                        if (ch > 0) return ch;
                    }
                }
            }
            catch { }
            return DefaultCharHeight;
        }

        private static double GetNoteCharHeight(Note note)
        {
            try
            {
                double h = note.GetHeight();
                if (h > 0) return h;
            }
            catch { }
            return DefaultCharHeight;
        }

        private static string GetDimensionTextSafe(DisplayDimension dd)
        {
            try { return dd.GetText(0) ?? string.Empty; }
            catch { return string.Empty; }
        }

        private static string GetItemTextSafe(object spec)
        {
            try
            {
                if (spec is DisplayDimension dd) return dd.GetText(0) ?? string.Empty;
                if (spec is Note nt) return nt.GetText() ?? string.Empty;
            }
            catch { }
            return string.Empty;
        }

        private static double EstimateTextWidth(string txt, double h)
        {
            if (string.IsNullOrEmpty(txt)) return 0.004;
            int cjk = Regex.Matches(txt, @"[\u4e00-\u9fff]").Count;
            int ascii = txt.Length - cjk - CountNewLines(txt);
            return Math.Max(0.004, cjk * h + ascii * h * 0.55);
        }

        private static int CountNewLines(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            int n = 0;
            for (int i = 0; i < s.Length; i++) if (s[i] == '\n') n++;
            return n;
        }

        private static void CheckDuplicateDimensions(List<AnnoItem> items, List<CheckIssue> issues)
        {
            var groups = items.Where(i => i.IsDimension)
                              .GroupBy(i => new { i.SheetName, T = NormalizeText(i.Text), P = Snap(i.CX) + "_" + Snap(i.CY) });
            foreach (var g in groups)
            {
                if (g.Count() <= 1) continue;
                // 同图、同文本、位置基本重合（<1mm）→ 疑似重复标注
                issues.Add(new CheckIssue
                {
                    Category = "标注",
                    Severity = "警告",
                    Sheet = g.Key.SheetName,
                    Message = "疑似重复标注：「" + (g.Key.T.Length == 0 ? "(空)" : g.Key.T) + "」出现 " + g.Count() + " 次且位置重合。请删除多余尺寸。"
                });
            }
        }

        private static string Snap(double v) { return Math.Round(v, 3).ToString("0.000", System.Globalization.CultureInfo.InvariantCulture); }
        private static string NormalizeText(string s) { return string.IsNullOrEmpty(s) ? string.Empty : s.Trim().Replace(" ", string.Empty); }

        private static void CheckOverlaps(List<AnnoItem> items, List<CheckIssue> issues)
        {
            var bySheet = items.Where(i => !string.IsNullOrEmpty(i.SheetName)).GroupBy(i => i.SheetName);
            foreach (var group in bySheet)
            {
                var arr = group.ToList();
                for (int i = 0; i < arr.Count; i++)
                {
                    for (int j = i + 1; j < arr.Count; j++)
                    {
                        var a = arr[i]; var b = arr[j];
                        double dx = a.CX - b.CX; if (dx < 0) dx = -dx;
                        double dy = a.CY - b.CY; if (dy < 0) dy = -dy;
                        double ox = a.HW + b.HW - dx;
                        double oy = a.HH + b.HH - dy;
                        if (ox <= 1e-9 || oy <= 1e-9) continue;
                        double inter = ox * oy;
                        double areaA = 4 * a.HW * a.HH;
                        double areaB = 4 * b.HW * b.HH;
                        double minArea = Math.Min(areaA, areaB);
                        if (minArea <= 0) continue;
                        if (inter / minArea > OverlapRatioThreshold)
                        {
                            // 完全相同的文本+位置由“重复标注”规则处理，这里避免重复报告
                            if (NormalizeText(a.Text) == NormalizeText(b.Text) &&
                                Math.Abs(a.CX - b.CX) < 0.001 && Math.Abs(a.CY - b.CY) < 0.001)
                                continue;
                            issues.Add(new CheckIssue
                            {
                                Category = "标注",
                                Severity = "警告",
                                Sheet = a.SheetName,
                                Message = "标注/注解文本重叠：「" + Truncate(a.Text) + "」与「" + Truncate(b.Text) + "」。请移动错开。"
                            });
                        }
                    }
                }
            }
        }

        private static string Truncate(string s, int max = 20)
        {
            if (string.IsNullOrEmpty(s)) return "(空)";
            s = s.Replace("\r", " ").Replace("\n", " ");
            return s.Length > max ? s.Substring(0, max) + "…" : s;
        }

        private static void CheckOutOfBounds(List<AnnoItem> items, List<SheetInfo> sheets, List<CheckIssue> issues)
        {
            foreach (var item in items)
            {
                if (string.IsNullOrEmpty(item.SheetName)) continue;
                var sheet = sheets.FirstOrDefault(s => s.Name == item.SheetName);
                if (sheet == null) continue;
                double lo = BorderMargin, hiW = sheet.Width - BorderMargin, hiH = sheet.Height - BorderMargin;
                if (item.CX < lo || item.CX > hiW || item.CY < lo || item.CY > hiH)
                {
                    issues.Add(new CheckIssue
                    {
                        Category = "标注",
                        Severity = "警告",
                        Sheet = item.SheetName,
                        Message = "标注/注解超出图纸图框：「" + Truncate(item.Text) + "」位置 (" +
                                  (item.CX * 1000).ToString("0") + ", " + (item.CY * 1000).ToString("0") + ") mm，超出图框边界。"
                    });
                }
            }
        }

        // ==================== 图纸 / 视图 ====================

        private static void CheckSheets(List<SheetInfo> sheets, List<ViewInfo> viewInfos, List<CheckIssue> issues)
        {
            foreach (var s in sheets)
            {
                double wMm = s.Width * 1000, hMm = s.Height * 1000;
                bool standard = StandardSheetSizes.Any(sz =>
                    (Math.Abs(sz[0] - wMm) < SizeToleranceMm && Math.Abs(sz[1] - hMm) < SizeToleranceMm) ||
                    (Math.Abs(sz[0] - hMm) < SizeToleranceMm && Math.Abs(sz[1] - wMm) < SizeToleranceMm));
                if (!standard)
                    issues.Add(new CheckIssue { Category = "格式", Severity = "提示", Sheet = s.Name, Message = "图幅为非标准尺寸：" + wMm.ToString("0") + "×" + hMm.ToString("0") + " mm（标准为 A0~A4）。" });

                // 空白图纸：该图纸下没有任何模型视图
                if (!viewInfos.Any(v => v.SheetName == s.Name))
                    issues.Add(new CheckIssue { Category = "视图", Severity = "错误", Sheet = s.Name, Message = "图纸「" + s.Name + "」没有任何视图（空白图纸）。" });
            }
        }

        private static void CheckViewScales(List<ViewInfo> viewInfos, List<CheckIssue> issues)
        {
            // 图纸视图、局部放大图、断裂/分离等视图允许独立比例，不参与比较
            var comparable = viewInfos.Where(v => !ScaleExemptViewTypes.Contains(v.ViewType) && v.ScaleVal > 0).ToList();
            if (comparable.Count < 2) return;

            var bySheet = comparable.GroupBy(v => v.SheetName);
            foreach (var group in bySheet)
            {
                var list = group.ToList();
                if (list.Count < 2) continue;
                // 取该图纸下多数视图采用的比例作为基准
                var mode = list.GroupBy(v => Math.Round(v.ScaleVal, 6))
                               .OrderByDescending(g => g.Count())
                               .First();
                double modeVal = mode.Key;
                if (mode.Count() < 2) continue;   // 该图纸只有一个可比视图，无基准

                foreach (var v in list)
                {
                    if (Math.Abs(v.ScaleVal - modeVal) < 1e-9) continue;
                    string vLabel = string.IsNullOrEmpty(v.Name) ? "(未命名视图)" : "视图「" + v.Name + "」";
                    issues.Add(new CheckIssue
                    {
                        Category = "视图",
                        Severity = "警告",
                        Sheet = v.SheetName,
                        Message = vLabel + "比例（" + RatioText(v.ScaleVal) + "）与其他视图不一致（多为 " +
                                  RatioText(modeVal) + "）。请核对是否为误设。"
                    });
                }
            }
        }

        private static string RatioText(double scaleVal)
        {
            if (scaleVal <= 0) return "未知";
            double denom = 1.0 / scaleVal;
            double rounded = Math.Round(denom, 2);
            if (Math.Abs(denom - Math.Round(denom)) < 0.05 && rounded >= 0.05)
                return "1:" + ((int)Math.Round(denom));
            if (Math.Abs(scaleVal - Math.Round(scaleVal)) < 0.05 && scaleVal >= 1)
                return ((int)Math.Round(scaleVal)) + ":1";
            return scaleVal.ToString("0.##");
        }

        // ==================== 尺寸数字大小一致性 ====================

        private static void CheckDimensionHeightConsistency(List<AnnoItem> items, List<CheckIssue> issues)
        {
            var dims = items.Where(i => i.IsDimension && !string.IsNullOrEmpty(i.SheetName)).ToList();
            if (dims.Count < 3) return;

            var bySheet = dims.GroupBy(i => i.SheetName);
            foreach (var group in bySheet)
            {
                var list = group.ToList();
                // 该图纸多数尺寸采用的字高（HH=半高，字高=2*HH）
                double modeH = list.GroupBy(i => Math.Round(2.0 * i.HH * 1000, 1))
                                   .OrderByDescending(g => g.Count())
                                   .First()
                                   .First().HH * 2.0;
                foreach (var item in list)
                {
                    if (Math.Abs(item.HH * 2.0 - modeH) > HeightDiffTolerance)
                        issues.Add(new CheckIssue
                        {
                            Category = "格式",
                            Severity = "提示",
                            Sheet = item.SheetName,
                            Message = "尺寸数字大小不一致：「" + Truncate(item.Text) + "」字高约 " + (item.HH * 2000).ToString("0.0") +
                                      " mm，与其他尺寸（" + (modeH * 1000).ToString("0.0") + " mm）不同。请统一字号。"
                        });
                }
            }
        }

        // ==================== 标题栏 ====================

        private static void CheckTitleBlock(ModelDoc2 model, List<ViewInfo> viewInfos, List<CheckIssue> issues)
        {
            ICustomPropertyManager cpm = null;
            try { cpm = model.Extension.get_CustomPropertyManager(""); } catch { }

            if (cpm == null)
            {
                issues.Add(new CheckIssue { Category = "标题栏", Severity = "警告", Message = "无法读取文档自定义属性，标题栏检查已跳过。" });
                return;
            }

            // 依引用模型类型区分机加图 / 装配图：任一视图引用装配体（.SLDASM）即按装配图标准
            bool isAssembly = viewInfos.Any(v =>
                !string.IsNullOrEmpty(v.RefModel) &&
                v.RefModel.IndexOf("SLDASM", StringComparison.OrdinalIgnoreCase) >= 0);

            string[] required = isAssembly ? RequiredPropsAssembly : RequiredPropsPart;
            string[] suggested = isAssembly ? SuggestedPropsAssembly : SuggestedPropsPart;

            string scope = isAssembly ? "装配图（赢合模板）" : "机加图（赢合模板）";

            foreach (string name in required)
            {
                string val = GetPropertyValue(cpm, name);
                if (string.IsNullOrWhiteSpace(val))
                    issues.Add(new CheckIssue { Category = "标题栏", Severity = "错误", Message = "标题栏必填项缺失：「" + name + "」为空或未填写（按" + scope + "标准）。" });
            }
            foreach (string name in suggested)
            {
                string val = GetPropertyValue(cpm, name);
                if (string.IsNullOrWhiteSpace(val))
                    issues.Add(new CheckIssue { Category = "标题栏", Severity = "提示", Message = "标题栏建议项未填写：「" + name + "」（按" + scope + "标准）。" });
            }

            // 图号与文件名一致性
            try
            {
                string path = model.GetPathName();
                if (!string.IsNullOrEmpty(path))
                {
                    string fileName = Path.GetFileNameWithoutExtension(path);
                    string tuHao = GetPropertyValue(cpm, "图号");
                    if (!string.IsNullOrEmpty(fileName) && !string.IsNullOrEmpty(tuHao) && tuHao.Trim() != fileName.Trim())
                        issues.Add(new CheckIssue { Category = "标题栏", Severity = "提示", Message = "图号「" + tuHao + "」与文件名「" + fileName + "」不一致，请核对。" });
                }
            }
            catch { }
        }

        private static string GetPropertyValue(ICustomPropertyManager cpm, string name)
        {
            try
            {
                string valOut = string.Empty, resolved = string.Empty;
                bool wasResolved = false;
                cpm.Get5(name, true, out valOut, out resolved, out wasResolved);
                return string.IsNullOrEmpty(resolved) ? valOut : resolved;
            }
            catch { return string.Empty; }
        }
    }
}
