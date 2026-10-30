namespace 涂布二次开发工具.Modules
{
    partial class DrawingControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.cardOptions = new 涂布二次开发工具.UI.CardPanel();
            this.chkAutoDim = new System.Windows.Forms.CheckBox();
            this.chkAutoTitle = new System.Windows.Forms.CheckBox();
            this.chkExportPdf = new System.Windows.Forms.CheckBox();
            this.lblSheetSize = new System.Windows.Forms.Label();
            this.cmbSheetSize = new System.Windows.Forms.ComboBox();
            this.btnBatchDraw = new System.Windows.Forms.Button();
            this.btnExportAll = new System.Windows.Forms.Button();
            this.cardQueue = new 涂布二次开发工具.UI.CardPanel();
            this.lstQueue = new System.Windows.Forms.ListBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.cardOptions.SuspendLayout();
            this.cardQueue.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(50, 60, 80);
            this.lblTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(130, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "工程图工具";
            // 
            // cardOptions
            // 
            this.cardOptions.BorderColor = System.Drawing.Color.LightGray;
            this.cardOptions.CardTitle = "出图选项";
            this.cardOptions.Controls.Add(this.lblProgress);
            this.cardOptions.Controls.Add(this.progressBar);
            this.cardOptions.Controls.Add(this.btnExportAll);
            this.cardOptions.Controls.Add(this.btnBatchDraw);
            this.cardOptions.Controls.Add(this.cmbSheetSize);
            this.cardOptions.Controls.Add(this.lblSheetSize);
            this.cardOptions.Controls.Add(this.chkExportPdf);
            this.cardOptions.Controls.Add(this.chkAutoTitle);
            this.cardOptions.Controls.Add(this.chkAutoDim);
            this.cardOptions.Location = new System.Drawing.Point(15, 50);
            this.cardOptions.Name = "cardOptions";
            this.cardOptions.Size = new System.Drawing.Size(350, 380);
            this.cardOptions.TabIndex = 1;
            this.cardOptions.TitleColor = System.Drawing.Color.FromArgb(76, 175, 80);
            // 
            // chkAutoDim
            // 
            this.chkAutoDim.AutoSize = true;
            this.chkAutoDim.Checked = true;
            this.chkAutoDim.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoDim.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.chkAutoDim.Location = new System.Drawing.Point(15, 55);
            this.chkAutoDim.Name = "chkAutoDim";
            this.chkAutoDim.Size = new System.Drawing.Size(130, 21);
            this.chkAutoDim.TabIndex = 0;
            this.chkAutoDim.Text = "自动标注尺寸";
            this.chkAutoDim.UseVisualStyleBackColor = true;
            // 
            // chkAutoTitle
            // 
            this.chkAutoTitle.AutoSize = true;
            this.chkAutoTitle.Checked = true;
            this.chkAutoTitle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoTitle.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.chkAutoTitle.Location = new System.Drawing.Point(15, 90);
            this.chkAutoTitle.Name = "chkAutoTitle";
            this.chkAutoTitle.Size = new System.Drawing.Size(130, 21);
            this.chkAutoTitle.TabIndex = 1;
            this.chkAutoTitle.Text = "自动填写标题栏";
            this.chkAutoTitle.UseVisualStyleBackColor = true;
            // 
            // chkExportPdf
            // 
            this.chkExportPdf.AutoSize = true;
            this.chkExportPdf.Checked = true;
            this.chkExportPdf.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExportPdf.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.chkExportPdf.Location = new System.Drawing.Point(15, 125);
            this.chkExportPdf.Name = "chkExportPdf";
            this.chkExportPdf.Size = new System.Drawing.Size(130, 21);
            this.chkExportPdf.TabIndex = 2;
            this.chkExportPdf.Text = "导出 PDF 格式";
            this.chkExportPdf.UseVisualStyleBackColor = true;
            // 
            // lblSheetSize
            // 
            this.lblSheetSize.AutoSize = true;
            this.lblSheetSize.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.lblSheetSize.Location = new System.Drawing.Point(15, 170);
            this.lblSheetSize.Name = "lblSheetSize";
            this.lblSheetSize.Size = new System.Drawing.Size(70, 17);
            this.lblSheetSize.TabIndex = 3;
            this.lblSheetSize.Text = "图纸幅面：";
            // 
            // cmbSheetSize
            // 
            this.cmbSheetSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSheetSize.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.cmbSheetSize.FormattingEnabled = true;
            this.cmbSheetSize.Items.AddRange(new object[] {
            "A4",
            "A3",
            "A2",
            "A1",
            "自定义"});
            this.cmbSheetSize.Location = new System.Drawing.Point(90, 167);
            this.cmbSheetSize.Name = "cmbSheetSize";
            this.cmbSheetSize.Size = new System.Drawing.Size(120, 25);
            this.cmbSheetSize.TabIndex = 4;
            // 
            // btnBatchDraw
            // 
            this.btnBatchDraw.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnBatchDraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatchDraw.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.btnBatchDraw.ForeColor = System.Drawing.Color.White;
            this.btnBatchDraw.Location = new System.Drawing.Point(15, 280);
            this.btnBatchDraw.Name = "btnBatchDraw";
            this.btnBatchDraw.Size = new System.Drawing.Size(150, 40);
            this.btnBatchDraw.TabIndex = 5;
            this.btnBatchDraw.Text = "批量生成工程图";
            this.btnBatchDraw.UseVisualStyleBackColor = false;
            // 
            // btnExportAll
            // 
            this.btnExportAll.BackColor = System.Drawing.Color.White;
            this.btnExportAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportAll.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnExportAll.ForeColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnExportAll.Location = new System.Drawing.Point(180, 280);
            this.btnExportAll.Name = "btnExportAll";
            this.btnExportAll.Size = new System.Drawing.Size(150, 40);
            this.btnExportAll.TabIndex = 6;
            this.btnExportAll.Text = "全部导出";
            this.btnExportAll.UseVisualStyleBackColor = false;
            // 
            // cardQueue
            // 
            this.cardQueue.BorderColor = System.Drawing.Color.LightGray;
            this.cardQueue.CardTitle = "待出图零件";
            this.cardQueue.Controls.Add(this.lstQueue);
            this.cardQueue.Location = new System.Drawing.Point(385, 50);
            this.cardQueue.Name = "cardQueue";
            this.cardQueue.Size = new System.Drawing.Size(375, 380);
            this.cardQueue.TabIndex = 2;
            this.cardQueue.TitleColor = System.Drawing.Color.FromArgb(100, 116, 139);
            // 
            // lstQueue
            // 
            this.lstQueue.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lstQueue.FormattingEnabled = true;
            this.lstQueue.ItemHeight = 17;
            this.lstQueue.Items.AddRange(new object[] {
            "☐ 涂布头模头.SLDPRT",
            "☐ 涂布辊.SLDPRT",
            "☐ 背辊.SLDPRT",
            "☐ 垫片-0.15mm.SLDPRT",
            "☐ 模体组件.SLDPRT",
            "☐ 调节螺杆.SLDPRT",
            "☐ 安装底板.SLDPRT"});
            this.lstQueue.Location = new System.Drawing.Point(15, 50);
            this.lstQueue.Name = "lstQueue";
            this.lstQueue.Size = new System.Drawing.Size(345, 293);
            this.lstQueue.TabIndex = 0;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(15, 335);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(250, 15);
            this.progressBar.TabIndex = 7;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("微软雅黑", 8.5F);
            this.lblProgress.ForeColor = System.Drawing.Color.Gray;
            this.lblProgress.Location = new System.Drawing.Point(270, 335);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(50, 15);
            this.lblProgress.TabIndex = 8;
            this.lblProgress.Text = "0 / 0";
            // 
            // DrawingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.Controls.Add(this.cardQueue);
            this.Controls.Add(this.cardOptions);
            this.Controls.Add(this.lblTitle);
            this.Name = "DrawingControl";
            this.Size = new System.Drawing.Size(860, 560);
            this.cardOptions.ResumeLayout(false);
            this.cardOptions.PerformLayout();
            this.cardQueue.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private 涂布二次开发工具.UI.CardPanel cardOptions;
        private System.Windows.Forms.CheckBox chkAutoDim;
        private System.Windows.Forms.CheckBox chkAutoTitle;
        private System.Windows.Forms.CheckBox chkExportPdf;
        private System.Windows.Forms.Label lblSheetSize;
        private System.Windows.Forms.ComboBox cmbSheetSize;
        private System.Windows.Forms.Button btnBatchDraw;
        private System.Windows.Forms.Button btnExportAll;
        private 涂布二次开发工具.UI.CardPanel cardQueue;
        private System.Windows.Forms.ListBox lstQueue;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblProgress;
    }
}
