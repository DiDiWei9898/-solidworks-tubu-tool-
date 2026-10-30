namespace 涂布二次开发工具.Modules
{
    partial class CalcControl
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
            this.cardCalcList = new 涂布二次开发工具.UI.CardPanel();
            this.lstCalcList = new System.Windows.Forms.ListBox();
            this.cardCalcInput = new 涂布二次开发工具.UI.CardPanel();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lblParam2 = new System.Windows.Forms.Label();
            this.txtParam2 = new System.Windows.Forms.TextBox();
            this.lblParam1 = new System.Windows.Forms.Label();
            this.txtParam1 = new System.Windows.Forms.TextBox();
            this.cardCalcList.SuspendLayout();
            this.cardCalcInput.SuspendLayout();
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
            this.lblTitle.Text = "工程计算";
            // 
            // cardCalcList
            // 
            this.cardCalcList.BorderColor = System.Drawing.Color.LightGray;
            this.cardCalcList.CardTitle = "计算工具";
            this.cardCalcList.Controls.Add(this.lstCalcList);
            this.cardCalcList.Location = new System.Drawing.Point(15, 50);
            this.cardCalcList.Name = "cardCalcList";
            this.cardCalcList.Size = new System.Drawing.Size(250, 380);
            this.cardCalcList.TabIndex = 1;
            this.cardCalcList.TitleColor = System.Drawing.Color.FromArgb(156, 39, 176);
            // 
            // lstCalcList
            // 
            this.lstCalcList.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.lstCalcList.FormattingEnabled = true;
            this.lstCalcList.ItemHeight = 21;
            this.lstCalcList.Items.AddRange(new object[] {
            "涂布间隙计算",
            "涂布流量计算",
            "压力分布计算",
            "辊面线速度",
            "涂布厚度换算",
            "干燥风量计算"});
            this.lstCalcList.Location = new System.Drawing.Point(15, 50);
            this.lstCalcList.Name = "lstCalcList";
            this.lstCalcList.Size = new System.Drawing.Size(220, 308);
            this.lstCalcList.TabIndex = 0;
            // 
            // cardCalcInput
            // 
            this.cardCalcInput.BorderColor = System.Drawing.Color.LightGray;
            this.cardCalcInput.CardTitle = "参数输入与结果";
            this.cardCalcInput.Controls.Add(this.lblResult);
            this.cardCalcInput.Controls.Add(this.btnCalculate);
            this.cardCalcInput.Controls.Add(this.txtParam2);
            this.cardCalcInput.Controls.Add(this.lblParam2);
            this.cardCalcInput.Controls.Add(this.txtParam1);
            this.cardCalcInput.Controls.Add(this.lblParam1);
            this.cardCalcInput.Location = new System.Drawing.Point(285, 50);
            this.cardCalcInput.Name = "cardCalcInput";
            this.cardCalcInput.Size = new System.Drawing.Size(475, 380);
            this.cardCalcInput.TabIndex = 2;
            this.cardCalcInput.TitleColor = System.Drawing.Color.FromArgb(156, 39, 176);
            // 
            // lblResult
            // 
            this.lblResult.BackColor = System.Drawing.Color.FromArgb(248, 240, 252);
            this.lblResult.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.lblResult.ForeColor = System.Drawing.Color.FromArgb(156, 39, 176);
            this.lblResult.Location = new System.Drawing.Point(15, 180);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(445, 60);
            this.lblResult.TabIndex = 5;
            this.lblResult.Text = "计算结果将显示在这里";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCalculate
            // 
            this.btnCalculate.BackColor = System.Drawing.Color.FromArgb(156, 39, 176);
            this.btnCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalculate.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.btnCalculate.ForeColor = System.Drawing.Color.White;
            this.btnCalculate.Location = new System.Drawing.Point(15, 280);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(150, 40);
            this.btnCalculate.TabIndex = 4;
            this.btnCalculate.Text = "计算";
            this.btnCalculate.UseVisualStyleBackColor = false;
            // 
            // lblParam2
            // 
            this.lblParam2.AutoSize = true;
            this.lblParam2.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.lblParam2.Location = new System.Drawing.Point(15, 110);
            this.lblParam2.Name = "lblParam2";
            this.lblParam2.Size = new System.Drawing.Size(80, 17);
            this.lblParam2.TabIndex = 2;
            this.lblParam2.Text = "参数二：";
            // 
            // txtParam2
            // 
            this.txtParam2.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.txtParam2.Location = new System.Drawing.Point(100, 107);
            this.txtParam2.Name = "txtParam2";
            this.txtParam2.Size = new System.Drawing.Size(150, 23);
            this.txtParam2.TabIndex = 3;
            // 
            // lblParam1
            // 
            this.lblParam1.AutoSize = true;
            this.lblParam1.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.lblParam1.Location = new System.Drawing.Point(15, 65);
            this.lblParam1.Name = "lblParam1";
            this.lblParam1.Size = new System.Drawing.Size(80, 17);
            this.lblParam1.TabIndex = 0;
            this.lblParam1.Text = "参数一：";
            // 
            // txtParam1
            // 
            this.txtParam1.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.txtParam1.Location = new System.Drawing.Point(100, 62);
            this.txtParam1.Name = "txtParam1";
            this.txtParam1.Size = new System.Drawing.Size(150, 23);
            this.txtParam1.TabIndex = 1;
            // 
            // CalcControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.Controls.Add(this.cardCalcInput);
            this.Controls.Add(this.cardCalcList);
            this.Controls.Add(this.lblTitle);
            this.Name = "CalcControl";
            this.Size = new System.Drawing.Size(860, 560);
            this.cardCalcList.ResumeLayout(false);
            this.cardCalcInput.ResumeLayout(false);
            this.cardCalcInput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private 涂布二次开发工具.UI.CardPanel cardCalcList;
        private System.Windows.Forms.ListBox lstCalcList;
        private 涂布二次开发工具.UI.CardPanel cardCalcInput;
        private System.Windows.Forms.Label lblParam1;
        private System.Windows.Forms.TextBox txtParam1;
        private System.Windows.Forms.Label lblParam2;
        private System.Windows.Forms.TextBox txtParam2;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label lblResult;
    }
}
