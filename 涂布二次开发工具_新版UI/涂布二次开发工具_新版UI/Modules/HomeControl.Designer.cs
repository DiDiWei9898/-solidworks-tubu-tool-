namespace 涂布二次开发工具.Modules
{
    partial class HomeControl
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.cardParamModel = new 涂布二次开发工具.UI.CardPanel();
            this.btnParamModel = new System.Windows.Forms.Button();
            this.lblParamModelDesc = new System.Windows.Forms.Label();
            this.cardDrawing = new 涂布二次开发工具.UI.CardPanel();
            this.btnDrawing = new System.Windows.Forms.Button();
            this.lblDrawingDesc = new System.Windows.Forms.Label();
            this.cardBom = new 涂布二次开发工具.UI.CardPanel();
            this.btnBom = new System.Windows.Forms.Button();
            this.lblBomDesc = new System.Windows.Forms.Label();
            this.cardCalc = new 涂布二次开发工具.UI.CardPanel();
            this.btnCalc = new System.Windows.Forms.Button();
            this.lblCalcDesc = new System.Windows.Forms.Label();
            this.cardParamModel.SuspendLayout();
            this.cardDrawing.SuspendLayout();
            this.cardBom.SuspendLayout();
            this.cardCalc.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(50, 60, 80);
            this.lblWelcome.Location = new System.Drawing.Point(10, 10);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(180, 29);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "欢迎使用涂布工具";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.lblDesc.ForeColor = System.Drawing.Color.Gray;
            this.lblDesc.Location = new System.Drawing.Point(12, 45);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(380, 17);
            this.lblDesc.TabIndex = 1;
            this.lblDesc.Text = "SolidWorks 涂布工程二次开发平台 · 提升设计效率";
            // 
            // cardParamModel
            // 
            this.cardParamModel.BorderColor = System.Drawing.Color.LightGray;
            this.cardParamModel.CardTitle = "参数化建模";
            this.cardParamModel.Controls.Add(this.btnParamModel);
            this.cardParamModel.Controls.Add(this.lblParamModelDesc);
            this.cardParamModel.Location = new System.Drawing.Point(15, 80);
            this.cardParamModel.Name = "cardParamModel";
            this.cardParamModel.Size = new System.Drawing.Size(210, 150);
            this.cardParamModel.TabIndex = 2;
            this.cardParamModel.TitleColor = System.Drawing.Color.FromArgb(30, 136, 229);
            // 
            // btnParamModel
            // 
            this.btnParamModel.BackColor = System.Drawing.Color.FromArgb(30, 136, 229);
            this.btnParamModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParamModel.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnParamModel.ForeColor = System.Drawing.Color.White;
            this.btnParamModel.Location = new System.Drawing.Point(15, 105);
            this.btnParamModel.Name = "btnParamModel";
            this.btnParamModel.Size = new System.Drawing.Size(120, 30);
            this.btnParamModel.TabIndex = 1;
            this.btnParamModel.Text = "开始建模 →";
            this.btnParamModel.UseVisualStyleBackColor = false;
            // 
            // lblParamModelDesc
            // 
            this.lblParamModelDesc.Font = new System.Drawing.Font("微软雅黑", 8.5F);
            this.lblParamModelDesc.ForeColor = System.Drawing.Color.Gray;
            this.lblParamModelDesc.Location = new System.Drawing.Point(15, 50);
            this.lblParamModelDesc.Name = "lblParamModelDesc";
            this.lblParamModelDesc.Size = new System.Drawing.Size(180, 50);
            this.lblParamModelDesc.TabIndex = 0;
            this.lblParamModelDesc.Text = "输入尺寸参数，自动生成涂布头、模头等零件3D模型";
            // 
            // cardDrawing
            // 
            this.cardDrawing.BorderColor = System.Drawing.Color.LightGray;
            this.cardDrawing.CardTitle = "工程图工具";
            this.cardDrawing.Controls.Add(this.btnDrawing);
            this.cardDrawing.Controls.Add(this.lblDrawingDesc);
            this.cardDrawing.Location = new System.Drawing.Point(240, 80);
            this.cardDrawing.Name = "cardDrawing";
            this.cardDrawing.Size = new System.Drawing.Size(210, 150);
            this.cardDrawing.TabIndex = 3;
            this.cardDrawing.TitleColor = System.Drawing.Color.FromArgb(76, 175, 80);
            // 
            // btnDrawing
            // 
            this.btnDrawing.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnDrawing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrawing.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnDrawing.ForeColor = System.Drawing.Color.White;
            this.btnDrawing.Location = new System.Drawing.Point(15, 105);
            this.btnDrawing.Name = "btnDrawing";
            this.btnDrawing.Size = new System.Drawing.Size(120, 30);
            this.btnDrawing.TabIndex = 1;
            this.btnDrawing.Text = "批量出图 →";
            this.btnDrawing.UseVisualStyleBackColor = false;
            // 
            // lblDrawingDesc
            // 
            this.lblDrawingDesc.Font = new System.Drawing.Font("微软雅黑", 8.5F);
            this.lblDrawingDesc.ForeColor = System.Drawing.Color.Gray;
            this.lblDrawingDesc.Location = new System.Drawing.Point(15, 50);
            this.lblDrawingDesc.Name = "lblDrawingDesc";
            this.lblDrawingDesc.Size = new System.Drawing.Size(180, 50);
            this.lblDrawingDesc.TabIndex = 0;
            this.lblDrawingDesc.Text = "自动生成工程图、标注尺寸、批量导出PDF格式";
            // 
            // cardBom
            // 
            this.cardBom.BorderColor = System.Drawing.Color.LightGray;
            this.cardBom.CardTitle = "BOM 工具";
            this.cardBom.Controls.Add(this.btnBom);
            this.cardBom.Controls.Add(this.lblBomDesc);
            this.cardBom.Location = new System.Drawing.Point(15, 245);
            this.cardBom.Name = "cardBom";
            this.cardBom.Size = new System.Drawing.Size(210, 150);
            this.cardBom.TabIndex = 4;
            this.cardBom.TitleColor = System.Drawing.Color.FromArgb(255, 152, 0);
            // 
            // btnBom
            // 
            this.btnBom.BackColor = System.Drawing.Color.FromArgb(255, 152, 0);
            this.btnBom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBom.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnBom.ForeColor = System.Drawing.Color.White;
            this.btnBom.Location = new System.Drawing.Point(15, 105);
            this.btnBom.Name = "btnBom";
            this.btnBom.Size = new System.Drawing.Size(120, 30);
            this.btnBom.TabIndex = 1;
            this.btnBom.Text = "生成BOM →";
            this.btnBom.UseVisualStyleBackColor = false;
            // 
            // lblBomDesc
            // 
            this.lblBomDesc.Font = new System.Drawing.Font("微软雅黑", 8.5F);
            this.lblBomDesc.ForeColor = System.Drawing.Color.Gray;
            this.lblBomDesc.Location = new System.Drawing.Point(15, 50);
            this.lblBomDesc.Name = "lblBomDesc";
            this.lblBomDesc.Size = new System.Drawing.Size(180, 50);
            this.lblBomDesc.TabIndex = 0;
            this.lblBomDesc.Text = "自动提取装配体物料清单，分类整理并导出Excel";
            // 
            // cardCalc
            // 
            this.cardCalc.BorderColor = System.Drawing.Color.LightGray;
            this.cardCalc.CardTitle = "工程计算";
            this.cardCalc.Controls.Add(this.btnCalc);
            this.cardCalc.Controls.Add(this.lblCalcDesc);
            this.cardCalc.Location = new System.Drawing.Point(240, 245);
            this.cardCalc.Name = "cardCalc";
            this.cardCalc.Size = new System.Drawing.Size(210, 150);
            this.cardCalc.TabIndex = 5;
            this.cardCalc.TitleColor = System.Drawing.Color.FromArgb(156, 39, 176);
            // 
            // btnCalc
            // 
            this.btnCalc.BackColor = System.Drawing.Color.FromArgb(156, 39, 176);
            this.btnCalc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalc.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnCalc.ForeColor = System.Drawing.Color.White;
            this.btnCalc.Location = new System.Drawing.Point(15, 105);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(120, 30);
            this.btnCalc.TabIndex = 1;
            this.btnCalc.Text = "开始计算 →";
            this.btnCalc.UseVisualStyleBackColor = false;
            // 
            // lblCalcDesc
            // 
            this.lblCalcDesc.Font = new System.Drawing.Font("微软雅黑", 8.5F);
            this.lblCalcDesc.ForeColor = System.Drawing.Color.Gray;
            this.lblCalcDesc.Location = new System.Drawing.Point(15, 50);
            this.lblCalcDesc.Name = "lblCalcDesc";
            this.lblCalcDesc.Size = new System.Drawing.Size(180, 50);
            this.lblCalcDesc.TabIndex = 0;
            this.lblCalcDesc.Text = "涂布间隙、压力分布、流量等常用工程计算公式";
            // 
            // HomeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.Controls.Add(this.cardCalc);
            this.Controls.Add(this.cardBom);
            this.Controls.Add(this.cardDrawing);
            this.Controls.Add(this.cardParamModel);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.lblWelcome);
            this.Name = "HomeControl";
            this.Size = new System.Drawing.Size(860, 560);
            this.cardParamModel.ResumeLayout(false);
            this.cardDrawing.ResumeLayout(false);
            this.cardBom.ResumeLayout(false);
            this.cardCalc.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblDesc;
        private 涂布二次开发工具.UI.CardPanel cardParamModel;
        private System.Windows.Forms.Button btnParamModel;
        private System.Windows.Forms.Label lblParamModelDesc;
        private 涂布二次开发工具.UI.CardPanel cardDrawing;
        private System.Windows.Forms.Button btnDrawing;
        private System.Windows.Forms.Label lblDrawingDesc;
        private 涂布二次开发工具.UI.CardPanel cardBom;
        private System.Windows.Forms.Button btnBom;
        private System.Windows.Forms.Label lblBomDesc;
        private 涂布二次开发工具.UI.CardPanel cardCalc;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.Label lblCalcDesc;
    }
}
