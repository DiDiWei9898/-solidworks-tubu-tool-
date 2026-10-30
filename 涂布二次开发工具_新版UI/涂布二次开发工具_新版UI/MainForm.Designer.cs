namespace 涂布二次开发工具
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSwStatus = new System.Windows.Forms.Label();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelNav = new System.Windows.Forms.Panel();
            this.lblNavTitle = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(33, 37, 43);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Controls.Add(this.lblSwStatus);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1100, 50);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(180, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "涂布二次开发工具";
            // 
            // lblSwStatus
            // 
            this.lblSwStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSwStatus.AutoSize = true;
            this.lblSwStatus.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblSwStatus.ForeColor = System.Drawing.Color.FromArgb(120, 200, 120);
            this.lblSwStatus.Location = new System.Drawing.Point(900, 18);
            this.lblSwStatus.Name = "lblSwStatus";
            this.lblSwStatus.Size = new System.Drawing.Size(160, 17);
            this.lblSwStatus.TabIndex = 1;
            this.lblSwStatus.Text = "● SolidWorks 已连接";
            this.lblSwStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(45, 55, 72);
            this.panelLeft.Controls.Add(this.panelNav);
            this.panelLeft.Controls.Add(this.lblNavTitle);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 50);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(200, 650);
            this.panelLeft.TabIndex = 1;
            // 
            // panelNav
            // 
            this.panelNav.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNav.Location = new System.Drawing.Point(0, 50);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(200, 600);
            this.panelNav.TabIndex = 1;
            // 
            // lblNavTitle
            // 
            this.lblNavTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNavTitle.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblNavTitle.ForeColor = System.Drawing.Color.FromArgb(150, 160, 175);
            this.lblNavTitle.Location = new System.Drawing.Point(0, 0);
            this.lblNavTitle.Name = "lblNavTitle";
            this.lblNavTitle.Size = new System.Drawing.Size(200, 50);
            this.lblNavTitle.TabIndex = 0;
            this.lblNavTitle.Text = "  功能菜单";
            this.lblNavTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(200, 50);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(20);
            this.panelContent.Size = new System.Drawing.Size(900, 600);
            this.panelContent.TabIndex = 2;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.panelBottom.Controls.Add(this.lblStatus);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(200, 650);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(900, 30);
            this.panelBottom.TabIndex = 3;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("微软雅黑", 8.5F);
            this.lblStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblStatus.Location = new System.Drawing.Point(15, 7);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(120, 17);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "就绪 | 版本 2.0.0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "涂布二次开发工具";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSwStatus;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label lblNavTitle;
        private System.Windows.Forms.Panel panelNav;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label lblStatus;
    }
}
