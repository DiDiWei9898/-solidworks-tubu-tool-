namespace 涂布二次开发工具.Modules
{
    partial class BomControl
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
            this.cardSettings = new 涂布二次开发工具.UI.CardPanel();
            this.chkGroupByMaterial = new System.Windows.Forms.CheckBox();
            this.chkHideStandard = new System.Windows.Forms.CheckBox();
            this.chkIncludeQty = new System.Windows.Forms.CheckBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.cardPreview = new 涂布二次开发工具.UI.CardPanel();
            this.dgvPreview = new System.Windows.Forms.DataGridView();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPartName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cardSettings.SuspendLayout();
            this.cardPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(50, 60, 80);
            this.lblTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(100, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "BOM 工具";
            // 
            // cardSettings
            // 
            this.cardSettings.BorderColor = System.Drawing.Color.LightGray;
            this.cardSettings.CardTitle = "BOM 设置";
            this.cardSettings.Controls.Add(this.btnExport);
            this.cardSettings.Controls.Add(this.btnGenerate);
            this.cardSettings.Controls.Add(this.chkIncludeQty);
            this.cardSettings.Controls.Add(this.chkHideStandard);
            this.cardSettings.Controls.Add(this.chkGroupByMaterial);
            this.cardSettings.Location = new System.Drawing.Point(15, 50);
            this.cardSettings.Name = "cardSettings";
            this.cardSettings.Size = new System.Drawing.Size(280, 380);
            this.cardSettings.TabIndex = 1;
            this.cardSettings.TitleColor = System.Drawing.Color.FromArgb(255, 152, 0);
            // 
            // chkGroupByMaterial
            // 
            this.chkGroupByMaterial.AutoSize = true;
            this.chkGroupByMaterial.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.chkGroupByMaterial.Location = new System.Drawing.Point(15, 55);
            this.chkGroupByMaterial.Name = "chkGroupByMaterial";
            this.chkGroupByMaterial.Size = new System.Drawing.Size(130, 21);
            this.chkGroupByMaterial.TabIndex = 0;
            this.chkGroupByMaterial.Text = "按材料分组";
            this.chkGroupByMaterial.UseVisualStyleBackColor = true;
            // 
            // chkHideStandard
            // 
            this.chkHideStandard.AutoSize = true;
            this.chkHideStandard.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.chkHideStandard.Location = new System.Drawing.Point(15, 90);
            this.chkHideStandard.Name = "chkHideStandard";
            this.chkHideStandard.Size = new System.Drawing.Size(150, 21);
            this.chkHideStandard.TabIndex = 1;
            this.chkHideStandard.Text = "隐藏标准件";
            this.chkHideStandard.UseVisualStyleBackColor = true;
            // 
            // chkIncludeQty
            // 
            this.chkIncludeQty.AutoSize = true;
            this.chkIncludeQty.Checked = true;
            this.chkIncludeQty.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeQty.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.chkIncludeQty.Location = new System.Drawing.Point(15, 125);
            this.chkIncludeQty.Name = "chkIncludeQty";
            this.chkIncludeQty.Size = new System.Drawing.Size(150, 21);
            this.chkIncludeQty.TabIndex = 2;
            this.chkIncludeQty.Text = "包含数量列";
            this.chkIncludeQty.UseVisualStyleBackColor = true;
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(255, 152, 0);
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(15, 280);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(240, 40);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "生成 BOM 表";
            this.btnGenerate.UseVisualStyleBackColor = false;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.White;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnExport.ForeColor = System.Drawing.Color.FromArgb(255, 152, 0);
            this.btnExport.Location = new System.Drawing.Point(15, 330);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(240, 35);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "导出 Excel";
            this.btnExport.UseVisualStyleBackColor = false;
            // 
            // cardPreview
            // 
            this.cardPreview.BorderColor = System.Drawing.Color.LightGray;
            this.cardPreview.CardTitle = "BOM 预览";
            this.cardPreview.Controls.Add(this.dgvPreview);
            this.cardPreview.Location = new System.Drawing.Point(310, 50);
            this.cardPreview.Name = "cardPreview";
            this.cardPreview.Size = new System.Drawing.Size(450, 380);
            this.cardPreview.TabIndex = 2;
            this.cardPreview.TitleColor = System.Drawing.Color.FromArgb(100, 116, 139);
            // 
            // dgvPreview
            // 
            this.dgvPreview.AllowUserToAddRows = false;
            this.dgvPreview.AllowUserToDeleteRows = false;
            this.dgvPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNo,
            this.colPartName,
            this.colMaterial,
            this.colQty,
            this.colNote});
            this.dgvPreview.Location = new System.Drawing.Point(15, 50);
            this.dgvPreview.Name = "dgvPreview";
            this.dgvPreview.ReadOnly = true;
            this.dgvPreview.RowTemplate.Height = 25;
            this.dgvPreview.Size = new System.Drawing.Size(420, 300);
            this.dgvPreview.TabIndex = 0;
            // 
            // colNo
            // 
            this.colNo.HeaderText = "序号";
            this.colNo.Name = "colNo";
            this.colNo.Width = 50;
            // 
            // colPartName
            // 
            this.colPartName.HeaderText = "零件名称";
            this.colPartName.Name = "colPartName";
            this.colPartName.Width = 120;
            // 
            // colMaterial
            // 
            this.colMaterial.HeaderText = "材料";
            this.colMaterial.Name = "colMaterial";
            this.colMaterial.Width = 80;
            // 
            // colQty
            // 
            this.colQty.HeaderText = "数量";
            this.colQty.Name = "colQty";
            this.colQty.Width = 50;
            // 
            // colNote
            // 
            this.colNote.HeaderText = "备注";
            this.colNote.Name = "colNote";
            this.colNote.Width = 80;
            // 
            // BomControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.Controls.Add(this.cardPreview);
            this.Controls.Add(this.cardSettings);
            this.Controls.Add(this.lblTitle);
            this.Name = "BomControl";
            this.Size = new System.Drawing.Size(860, 560);
            this.cardSettings.ResumeLayout(false);
            this.cardSettings.PerformLayout();
            this.cardPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private 涂布二次开发工具.UI.CardPanel cardSettings;
        private System.Windows.Forms.CheckBox chkGroupByMaterial;
        private System.Windows.Forms.CheckBox chkHideStandard;
        private System.Windows.Forms.CheckBox chkIncludeQty;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnExport;
        private 涂布二次开发工具.UI.CardPanel cardPreview;
        private System.Windows.Forms.DataGridView dgvPreview;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPartName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNote;
    }
}
