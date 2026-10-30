namespace 涂布二次开发工具.Modules
{
    partial class ParamModelControl
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
            this.cardParams = new 涂布二次开发工具.UI.CardPanel();
            this.lblModelType = new System.Windows.Forms.Label();
            this.cmbModelType = new System.Windows.Forms.ComboBox();
            this.lblWidth = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.lblWidthUnit = new System.Windows.Forms.Label();
            this.lblGap = new System.Windows.Forms.Label();
            this.txtGap = new System.Windows.Forms.TextBox();
            this.lblGapUnit = new System.Windows.Forms.Label();
            this.lblLength = new System.Windows.Forms.Label();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.lblLengthUnit = new System.Windows.Forms.Label();
            this.lblThickness = new System.Windows.Forms.Label();
            this.txtThickness = new System.Windows.Forms.TextBox();
            this.lblThicknessUnit = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.cardHistory = new 涂布二次开发工具.UI.CardPanel();
            this.lstHistory = new System.Windows.Forms.ListBox();
            this.cardParams.SuspendLayout();
            this.cardHistory.SuspendLayout();
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
            this.lblTitle.Text = "参数化建模";
            // 
            // cardParams
            // 
            this.cardParams.BorderColor = System.Drawing.Color.LightGray;
            this.cardParams.CardTitle = "参数输入";
            this.cardParams.Controls.Add(this.btnPreview);
            this.cardParams.Controls.Add(this.btnGenerate);
            this.cardParams.Controls.Add(this.lblThicknessUnit);
            this.cardParams.Controls.Add(this.txtThickness);
            this.cardParams.Controls.Add(this.lblThickness);
            this.cardParams.Controls.Add(this.lblLengthUnit);
            this.cardParams.Controls.Add(this.txtLength);
            this.cardParams.Controls.Add(this.lblLength);
            this.cardParams.Controls.Add(this.lblGapUnit);
            this.cardParams.Controls.Add(this.txtGap);
            this.cardParams.Controls.Add(this.lblGap);
            this.cardParams.Controls.Add(this.lblWidthUnit);
            this.cardParams.Controls.Add(this.txtWidth);
            this.cardParams.Controls.Add(this.lblWidth);
            this.cardParams.Controls.Add(this.cmbModelType);
            this.cardParams.Controls.Add(this.lblModelType);
            this.cardParams.Location = new System.Drawing.Point(15, 50);
            this.cardParams.Name = "cardParams";
            this.cardParams.Size = new System.Drawing.Size(380, 380);
            this.cardParams.TabIndex = 1;
            this.cardParams.TitleColor = System.Drawing.Color.FromArgb(30, 136, 229);
            // 
            // lblModelType
            // 
            this.lblModelType.AutoSize = true;
            this.lblModelType.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.lblModelType.Location = new System.Drawing.Point(15, 55);
            this.lblModelType.Name = "lblModelType";
            this.lblModelType.Size = new System.Drawing.Size(70, 17);
            this.lblModelType.TabIndex = 0;
            this.lblModelType.Text = "模型类型：";
            // 
            // cmbModelType
            // 
            this.cmbModelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModelType.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.cmbModelType.FormattingEnabled = true;
            this.cmbModelType.Items.AddRange(new object[] {
            "涂布头模头",
            "涂布辊",
            "背辊",
            "模体组件",
            "垫片"});
            this.cmbModelType.Location = new System.Drawing.Point(90, 52);
            this.cmbModelType.Name = "cmbModelType";
            this.cmbModelType.Size = new System.Drawing.Size(180, 25);
            this.cmbModelType.TabIndex = 1;
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.lblWidth.Location = new System.Drawing.Point(15, 100);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(70, 17);
            this.lblWidth.TabIndex = 2;
            this.lblWidth.Text = "涂布宽度：";
            // 
            // txtWidth
            // 
            this.txtWidth.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.txtWidth.Location = new System.Drawing.Point(90, 97);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(120, 23);
            this.txtWidth.TabIndex = 3;
            this.txtWidth.Text = "1300";
            // 
            // lblWidthUnit
            // 
            this.lblWidthUnit.AutoSize = true;
            this.lblWidthUnit.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblWidthUnit.ForeColor = System.Drawing.Color.Gray;
            this.lblWidthUnit.Location = new System.Drawing.Point(215, 100);
            this.lblWidthUnit.Name = "lblWidthUnit";
            this.lblWidthUnit.Size = new System.Drawing.Size(25, 17);
            this.lblWidthUnit.TabIndex = 4;
            this.lblWidthUnit.Text = "mm";
            // 
            // lblGap
            // 
            this.lblGap.AutoSize = true;
            this.lblGap.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.lblGap.Location = new System.Drawing.Point(15, 140);
            this.lblGap.Name = "lblGap";
            this.lblGap.Size = new System.Drawing.Size(70, 17);
            this.lblGap.TabIndex = 5;
            this.lblGap.Text = "间隙大小：";
            // 
            // txtGap
            // 
            this.txtGap.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.txtGap.Location = new System.Drawing.Point(90, 137);
            this.txtGap.Name = "txtGap";
            this.txtGap.Size = new System.Drawing.Size(120, 23);
            this.txtGap.TabIndex = 6;
            this.txtGap.Text = "0.15";
            // 
            // lblGapUnit
            // 
            this.lblGapUnit.AutoSize = true;
            this.lblGapUnit.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblGapUnit.ForeColor = System.Drawing.Color.Gray;
            this.lblGapUnit.Location = new System.Drawing.Point(215, 140);
            this.lblGapUnit.Name = "lblGapUnit";
            this.lblGapUnit.Size = new System.Drawing.Size(25, 17);
            this.lblGapUnit.TabIndex = 7;
            this.lblGapUnit.Text = "mm";
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.lblLength.Location = new System.Drawing.Point(15, 180);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(70, 17);
            this.lblLength.TabIndex = 8;
            this.lblLength.Text = "总长尺寸：";
            // 
            // txtLength
            // 
            this.txtLength.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.txtLength.Location = new System.Drawing.Point(90, 177);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(120, 23);
            this.txtLength.TabIndex = 9;
            this.txtLength.Text = "1500";
            // 
            // lblLengthUnit
            // 
            this.lblLengthUnit.AutoSize = true;
            this.lblLengthUnit.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblLengthUnit.ForeColor = System.Drawing.Color.Gray;
            this.lblLengthUnit.Location = new System.Drawing.Point(215, 180);
            this.lblLengthUnit.Name = "lblLengthUnit";
            this.lblLengthUnit.Size = new System.Drawing.Size(25, 17);
            this.lblLengthUnit.TabIndex = 10;
            this.lblLengthUnit.Text = "mm";
            // 
            // lblThickness
            // 
            this.lblThickness.AutoSize = true;
            this.lblThickness.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.lblThickness.Location = new System.Drawing.Point(15, 220);
            this.lblThickness.Name = "lblThickness";
            this.lblThickness.Size = new System.Drawing.Size(70, 17);
            this.lblThickness.TabIndex = 11;
            this.lblThickness.Text = "厚度规格：";
            // 
            // txtThickness
            // 
            this.txtThickness.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.txtThickness.Location = new System.Drawing.Point(90, 217);
            this.txtThickness.Name = "txtThickness";
            this.txtThickness.Size = new System.Drawing.Size(120, 23);
            this.txtThickness.TabIndex = 12;
            this.txtThickness.Text = "20";
            // 
            // lblThicknessUnit
            // 
            this.lblThicknessUnit.AutoSize = true;
            this.lblThicknessUnit.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblThicknessUnit.ForeColor = System.Drawing.Color.Gray;
            this.lblThicknessUnit.Location = new System.Drawing.Point(215, 220);
            this.lblThicknessUnit.Name = "lblThicknessUnit";
            this.lblThicknessUnit.Size = new System.Drawing.Size(25, 17);
            this.lblThicknessUnit.TabIndex = 13;
            this.lblThicknessUnit.Text = "mm";
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(30, 136, 229);
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(15, 320);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(150, 40);
            this.btnGenerate.TabIndex = 14;
            this.btnGenerate.Text = "生成模型";
            this.btnGenerate.UseVisualStyleBackColor = false;
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.White;
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreview.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnPreview.ForeColor = System.Drawing.Color.FromArgb(30, 136, 229);
            this.btnPreview.Location = new System.Drawing.Point(180, 320);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(150, 40);
            this.btnPreview.TabIndex = 15;
            this.btnPreview.Text = "预览参数";
            this.btnPreview.UseVisualStyleBackColor = false;
            // 
            // cardHistory
            // 
            this.cardHistory.BorderColor = System.Drawing.Color.LightGray;
            this.cardHistory.CardTitle = "最近生成记录";
            this.cardHistory.Controls.Add(this.lstHistory);
            this.cardHistory.Location = new System.Drawing.Point(410, 50);
            this.cardHistory.Name = "cardHistory";
            this.cardHistory.Size = new System.Drawing.Size(350, 380);
            this.cardHistory.TabIndex = 2;
            this.cardHistory.TitleColor = System.Drawing.Color.FromArgb(100, 116, 139);
            // 
            // lstHistory
            // 
            this.lstHistory.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lstHistory.FormattingEnabled = true;
            this.lstHistory.ItemHeight = 17;
            this.lstHistory.Items.AddRange(new object[] {
            "涂布头模头 - 宽度1300mm - 2025/2/20",
            "涂布辊 - 宽度1200mm - 2025/2/18",
            "背辊 - 宽度1300mm - 2025/2/15",
            "垫片组件 - 0.15mm间隙 - 2025/2/10",
            "模体组件 - 标准型 - 2025/2/8"});
            this.lstHistory.Location = new System.Drawing.Point(15, 50);
            this.lstHistory.Name = "lstHistory";
            this.lstHistory.Size = new System.Drawing.Size(320, 293);
            this.lstHistory.TabIndex = 0;
            // 
            // ParamModelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.Controls.Add(this.cardHistory);
            this.Controls.Add(this.cardParams);
            this.Controls.Add(this.lblTitle);
            this.Name = "ParamModelControl";
            this.Size = new System.Drawing.Size(860, 560);
            this.cardParams.ResumeLayout(false);
            this.cardParams.PerformLayout();
            this.cardHistory.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private 涂布二次开发工具.UI.CardPanel cardParams;
        private System.Windows.Forms.Label lblModelType;
        private System.Windows.Forms.ComboBox cmbModelType;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label lblWidthUnit;
        private System.Windows.Forms.Label lblGap;
        private System.Windows.Forms.TextBox txtGap;
        private System.Windows.Forms.Label lblGapUnit;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.Label lblLengthUnit;
        private System.Windows.Forms.Label lblThickness;
        private System.Windows.Forms.TextBox txtThickness;
        private System.Windows.Forms.Label lblThicknessUnit;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnPreview;
        private 涂布二次开发工具.UI.CardPanel cardHistory;
        private System.Windows.Forms.ListBox lstHistory;
    }
}
