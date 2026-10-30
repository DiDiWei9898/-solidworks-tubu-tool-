namespace WindowsFormsApplication5
{
    partial class Form1
    {
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label 版本;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox7;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelSubTitle;
        private System.Windows.Forms.GroupBox gbConnect;
        private System.Windows.Forms.GroupBox gbProps;
        private System.Windows.Forms.GroupBox gbReplace;
        private System.Windows.Forms.GroupBox gbClean;
        private System.Windows.Forms.GroupBox gbDwg;
        private System.Windows.Forms.GroupBox gbPack;
        private System.Windows.Forms.GroupBox gbOther;
        private System.Windows.Forms.GroupBox gbCheck;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.Button buttonAICheck;
        private System.Windows.Forms.Label lblHintCheck;
        private System.Windows.Forms.GroupBox gbAIConfig;
        private System.Windows.Forms.TextBox txtApiKey;
        private System.Windows.Forms.TextBox txtBaseUrl;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtVisionApiKey;
        private System.Windows.Forms.TextBox txtVisionBaseUrl;
        private System.Windows.Forms.TextBox txtVisionModel;
        private System.Windows.Forms.Button btnSaveAIConfig;
        private System.Windows.Forms.Label lblAIConfigStatus;
        private System.Windows.Forms.Label lblApiKeyField;
        private System.Windows.Forms.Label lblBaseUrlField;
        private System.Windows.Forms.Label lblModelField;
        private System.Windows.Forms.Label lblVisionApiKeyField;
        private System.Windows.Forms.Label lblVisionBaseUrlField;
        private System.Windows.Forms.Label lblVisionModelField;
        private System.Windows.Forms.ToolTip toolTipAI;
        private System.Windows.Forms.Label lblAIHelp1;
        private System.Windows.Forms.Label lblAIHelp2;
        private System.Windows.Forms.Label lblDir1;
        private System.Windows.Forms.Label lblDir2;
        private System.Windows.Forms.Label lblPartName;
        private System.Windows.Forms.Label lblDwg;
        private System.Windows.Forms.Label lblSave;
        private System.Windows.Forms.Label lblRename;
        private System.Windows.Forms.Label lblPath6;
        private System.Windows.Forms.Label lblHintConnect;
        private System.Windows.Forms.Label lblHintClean;
        private System.Windows.Forms.Label lblHintDwg;
        private System.Windows.Forms.Label lblHintOther;

        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button10 = new System.Windows.Forms.Button();
            this.版本 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button12 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button16 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelSubTitle = new System.Windows.Forms.Label();
            this.gbConnect = new System.Windows.Forms.GroupBox();
            this.gbProps = new System.Windows.Forms.GroupBox();
            this.gbReplace = new System.Windows.Forms.GroupBox();
            this.gbClean = new System.Windows.Forms.GroupBox();
            this.gbDwg = new System.Windows.Forms.GroupBox();
            this.gbPack = new System.Windows.Forms.GroupBox();
            this.gbOther = new System.Windows.Forms.GroupBox();
            this.gbCheck = new System.Windows.Forms.GroupBox();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.buttonAICheck = new System.Windows.Forms.Button();
            this.lblHintCheck = new System.Windows.Forms.Label();
            this.gbAIConfig = new System.Windows.Forms.GroupBox();
            this.txtApiKey = new System.Windows.Forms.TextBox();
            this.txtBaseUrl = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtVisionApiKey = new System.Windows.Forms.TextBox();
            this.txtVisionBaseUrl = new System.Windows.Forms.TextBox();
            this.txtVisionModel = new System.Windows.Forms.TextBox();
            this.btnSaveAIConfig = new System.Windows.Forms.Button();
            this.lblAIConfigStatus = new System.Windows.Forms.Label();
            this.lblApiKeyField = new System.Windows.Forms.Label();
            this.lblBaseUrlField = new System.Windows.Forms.Label();
            this.lblModelField = new System.Windows.Forms.Label();
            this.lblVisionApiKeyField = new System.Windows.Forms.Label();
            this.lblVisionBaseUrlField = new System.Windows.Forms.Label();
            this.lblVisionModelField = new System.Windows.Forms.Label();
            this.toolTipAI = new System.Windows.Forms.ToolTip();
            this.lblAIHelp1 = new System.Windows.Forms.Label();
            this.lblAIHelp2 = new System.Windows.Forms.Label();
            this.lblDir1 = new System.Windows.Forms.Label();
            this.lblDir2 = new System.Windows.Forms.Label();
            this.lblPartName = new System.Windows.Forms.Label();
            this.lblDwg = new System.Windows.Forms.Label();
            this.lblSave = new System.Windows.Forms.Label();
            this.lblRename = new System.Windows.Forms.Label();
            this.lblPath6 = new System.Windows.Forms.Label();
            this.lblHintConnect = new System.Windows.Forms.Label();
            this.lblHintClean = new System.Windows.Forms.Label();
            this.lblHintDwg = new System.Windows.Forms.Label();
            this.lblHintOther = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.gbConnect.SuspendLayout();
            this.gbProps.SuspendLayout();
            this.gbReplace.SuspendLayout();
            this.gbClean.SuspendLayout();
            this.gbDwg.SuspendLayout();
            this.gbPack.SuspendLayout();
            this.gbOther.SuspendLayout();
            this.gbCheck.SuspendLayout();
            this.gbAIConfig.SuspendLayout();
            base.SuspendLayout();

            // ============ 顶部标题栏 ============
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(27, 42, 74);
            this.panelHeader.Controls.Add(this.labelTitle);
            this.panelHeader.Controls.Add(this.labelSubTitle);
            this.panelHeader.Controls.Add(this.版本);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(960, 64);
            this.panelHeader.TabIndex = 0;

            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("微软雅黑", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(24, 12);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(180, 30);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "涂布一组工具";

            this.labelSubTitle.AutoSize = true;
            this.labelSubTitle.Font = new System.Drawing.Font("微软雅黑", 8.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            this.labelSubTitle.ForeColor = System.Drawing.Color.FromArgb(159, 176, 204);
            this.labelSubTitle.Location = new System.Drawing.Point(26, 42);
            this.labelSubTitle.Name = "labelSubTitle";
            this.labelSubTitle.Size = new System.Drawing.Size(300, 18);
            this.labelSubTitle.TabIndex = 1;
            this.labelSubTitle.Text = "SolidWorks 涂布工程二次开发工具";

            this.版本.AutoSize = false;
            this.版本.Cursor = System.Windows.Forms.Cursors.Hand;
            this.版本.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            this.版本.ForeColor = System.Drawing.Color.FromArgb(143, 176, 255);
            this.版本.Location = new System.Drawing.Point(856, 20);
            this.版本.Name = "版本";
            this.版本.Size = new System.Drawing.Size(88, 26);
            this.版本.TabIndex = 2;
            this.版本.Text = "版本";
            this.版本.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.版本.Click += new System.EventHandler(label1_Click);

            // ============ 分组 1：SolidWorks 连接 ============
            this.gbConnect.BackColor = System.Drawing.Color.White;
            this.gbConnect.Controls.Add(this.button3);
            this.gbConnect.Controls.Add(this.button1);
            this.gbConnect.Controls.Add(this.lblHintConnect);
            this.gbConnect.Font = new System.Drawing.Font("微软雅黑", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            this.gbConnect.ForeColor = System.Drawing.Color.FromArgb(43, 58, 85);
            this.gbConnect.Location = new System.Drawing.Point(16, 80);
            this.gbConnect.Name = "gbConnect";
            this.gbConnect.Size = new System.Drawing.Size(430, 96);
            this.gbConnect.TabIndex = 1;
            this.gbConnect.TabStop = false;
            this.gbConnect.Text = "SolidWorks 连接";

            this.StyleButton(this.button3, "打开SW");
            this.button3.Location = new System.Drawing.Point(18, 26);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(190, 34);
            this.button3.TabIndex = 0;
            this.button3.Click += new System.EventHandler(button3_Click);

            this.StyleButton(this.button1, "获取solidwork");
            this.button1.Location = new System.Drawing.Point(222, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 34);
            this.button1.TabIndex = 1;
            this.button1.Click += new System.EventHandler(button1_Click);

            this.StyleHint(this.lblHintConnect, "未启动时用「打开SW」新建实例；已运行时用「获取solidwork」连接。");
            this.lblHintConnect.Location = new System.Drawing.Point(18, 68);
            this.lblHintConnect.Name = "lblHintConnect";
            this.lblHintConnect.Size = new System.Drawing.Size(394, 20);
            this.lblHintConnect.TabIndex = 2;

            // ============ 分组 2：文档属性与工程图模板 ============
            this.gbProps.BackColor = System.Drawing.Color.White;
            this.gbProps.Controls.Add(this.button5);
            this.gbProps.Controls.Add(this.button7);
            this.gbProps.Controls.Add(this.button8);
            this.gbProps.Controls.Add(this.button6);
            this.gbProps.Font = new System.Drawing.Font("微软雅黑", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            this.gbProps.ForeColor = System.Drawing.Color.FromArgb(43, 58, 85);
            this.gbProps.Location = new System.Drawing.Point(462, 80);
            this.gbProps.Name = "gbProps";
            this.gbProps.Size = new System.Drawing.Size(482, 96);
            this.gbProps.TabIndex = 2;
            this.gbProps.TabStop = false;
            this.gbProps.Text = "文档属性与工程图模板";

            this.StyleButton(this.button5, "同名图号和物料编码");
            this.button5.Location = new System.Drawing.Point(18, 24);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(200, 34);
            this.button5.TabIndex = 0;
            this.button5.Click += new System.EventHandler(button5_Click);

            this.StyleButton(this.button7, "机加模板改成赢合");
            this.button7.Location = new System.Drawing.Point(232, 24);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(200, 34);
            this.button7.TabIndex = 1;
            this.button7.Click += new System.EventHandler(button7_Click);

            this.StyleButton(this.button8, "A4装配模板改赢合");
            this.button8.Location = new System.Drawing.Point(18, 58);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(200, 34);
            this.button8.TabIndex = 2;
            this.button8.Click += new System.EventHandler(button8_Click);

            this.StyleButton(this.button6, "质量单位修改为KG");
            this.button6.Location = new System.Drawing.Point(232, 58);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(200, 34);
            this.button6.TabIndex = 3;
            this.button6.Click += new System.EventHandler(button6_Click);

            // ============ 分组 3：一键替换 ============
            this.gbReplace.BackColor = System.Drawing.Color.White;
            this.gbReplace.Controls.Add(this.button10);
            this.gbReplace.Controls.Add(this.button11);
            this.gbReplace.Controls.Add(this.button12);
            this.gbReplace.Controls.Add(this.textBox1);
            this.gbReplace.Controls.Add(this.textBox2);
            this.gbReplace.Controls.Add(this.textBox3);
            this.gbReplace.Controls.Add(this.lblDir1);
            this.gbReplace.Controls.Add(this.lblDir2);
            this.gbReplace.Controls.Add(this.lblPartName);
            this.gbReplace.Font = new System.Drawing.Font("微软雅黑", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            this.gbReplace.ForeColor = System.Drawing.Color.FromArgb(43, 58, 85);
            this.gbReplace.Location = new System.Drawing.Point(16, 192);
            this.gbReplace.Name = "gbReplace";
            this.gbReplace.Size = new System.Drawing.Size(928, 150);
            this.gbReplace.TabIndex = 3;
            this.gbReplace.TabStop = false;
            this.gbReplace.Text = "一键替换";

            this.StyleButton(this.button10, "一键替换打包到目标文件夹的最新零件");
            this.button10.Location = new System.Drawing.Point(18, 26);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(290, 34);
            this.button10.TabIndex = 0;
            this.button10.Click += new System.EventHandler(button10_Click);

            this.StyleFieldLabel(this.lblDir1, "目标文件夹");
            this.lblDir1.Location = new System.Drawing.Point(322, 32);
            this.lblDir1.Name = "lblDir1";
            this.lblDir1.Size = new System.Drawing.Size(62, 22);
            this.lblDir1.TabIndex = 1;

            this.StyleTextBox(this.textBox1);
            this.textBox1.Location = new System.Drawing.Point(390, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(484, 26);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(textBox1_TextChanged);

            this.StyleButton(this.button11, "一键替换打包到目标文件夹的最新组件");
            this.button11.Location = new System.Drawing.Point(18, 64);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(290, 34);
            this.button11.TabIndex = 3;
            this.button11.Click += new System.EventHandler(button11_Click_1);

            this.StyleFieldLabel(this.lblDir2, "目标文件夹");
            this.lblDir2.Location = new System.Drawing.Point(322, 70);
            this.lblDir2.Name = "lblDir2";
            this.lblDir2.Size = new System.Drawing.Size(62, 22);
            this.lblDir2.TabIndex = 4;

            this.StyleTextBox(this.textBox2);
            this.textBox2.Location = new System.Drawing.Point(390, 64);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(484, 26);
            this.textBox2.TabIndex = 5;
            this.textBox2.TextChanged += new System.EventHandler(textBox2_TextChanged);

            this.StyleButton(this.button12, "一键替换指定零件");
            this.button12.Location = new System.Drawing.Point(18, 102);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(290, 34);
            this.button12.TabIndex = 6;
            this.button12.Click += new System.EventHandler(button12_Click);

            this.StyleFieldLabel(this.lblPartName, "指定零件名");
            this.lblPartName.Location = new System.Drawing.Point(322, 108);
            this.lblPartName.Name = "lblPartName";
            this.lblPartName.Size = new System.Drawing.Size(62, 22);
            this.lblPartName.TabIndex = 7;

            this.StyleTextBox(this.textBox3);
            this.textBox3.Location = new System.Drawing.Point(390, 102);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(484, 26);
            this.textBox3.TabIndex = 8;
            this.textBox3.TextChanged += new System.EventHandler(textBox3_TextChanged);

            // ============ 分组 4：装配体清理 ============
            this.gbClean.BackColor = System.Drawing.Color.White;
            this.gbClean.Controls.Add(this.button9);
            this.gbClean.Controls.Add(this.lblHintClean);
            this.gbClean.Font = new System.Drawing.Font("微软雅黑", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            this.gbClean.ForeColor = System.Drawing.Color.FromArgb(43, 58, 85);
            this.gbClean.Location = new System.Drawing.Point(16, 358);
            this.gbClean.Name = "gbClean";
            this.gbClean.Size = new System.Drawing.Size(456, 130);
            this.gbClean.TabIndex = 4;
            this.gbClean.TabStop = false;
            this.gbClean.Text = "装配体清理";

            this.StyleButton(this.button9, "一键删除传动");
            this.button9.Location = new System.Drawing.Point(18, 28);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(260, 36);
            this.button9.TabIndex = 0;
            this.button9.Click += new System.EventHandler(button9_Click);

            this.StyleHint(this.lblHintClean, "按命名规则批量删除装配体中的传动部件（平键、轴承、风批、旋转接头、密封胶条等）。请先打开目标装配体；执行后不可撤销，建议先另存副本。");
            this.lblHintClean.Location = new System.Drawing.Point(18, 72);
            this.lblHintClean.Name = "lblHintClean";
            this.lblHintClean.Size = new System.Drawing.Size(420, 50);
            this.lblHintClean.TabIndex = 1;

            // ============ 分组 5：工程图 ============
            this.gbDwg.BackColor = System.Drawing.Color.White;
            this.gbDwg.Controls.Add(this.button2);
            this.gbDwg.Controls.Add(this.textBox7);
            this.gbDwg.Controls.Add(this.lblDwg);
            this.gbDwg.Controls.Add(this.lblHintDwg);
            this.gbDwg.Font = new System.Drawing.Font("微软雅黑", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            this.gbDwg.ForeColor = System.Drawing.Color.FromArgb(43, 58, 85);
            this.gbDwg.Location = new System.Drawing.Point(488, 358);
            this.gbDwg.Name = "gbDwg";
            this.gbDwg.Size = new System.Drawing.Size(456, 130);
            this.gbDwg.TabIndex = 5;
            this.gbDwg.TabStop = false;
            this.gbDwg.Text = "工程图";

            this.StyleButton(this.button2, "创建三视图");
            this.button2.Location = new System.Drawing.Point(18, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 36);
            this.button2.TabIndex = 0;
            this.button2.Click += new System.EventHandler(button2_Click_1);

            this.StyleFieldLabel(this.lblDwg, "图纸路径");
            this.lblDwg.Location = new System.Drawing.Point(158, 36);
            this.lblDwg.Name = "lblDwg";
            this.lblDwg.Size = new System.Drawing.Size(60, 22);
            this.lblDwg.TabIndex = 1;

            this.StyleTextBox(this.textBox7);
            this.textBox7.Location = new System.Drawing.Point(224, 28);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(196, 26);
            this.textBox7.TabIndex = 2;
            this.textBox7.TextChanged += new System.EventHandler(textBox7_TextChanged);

            this.StyleHint(this.lblHintDwg, "新建第三视角工程图并导出 PDF。当前导出路径固定为 D:\\test\\foodprocessor.pdf。");
            this.lblHintDwg.Location = new System.Drawing.Point(18, 72);
            this.lblHintDwg.Name = "lblHintDwg";
            this.lblHintDwg.Size = new System.Drawing.Size(420, 50);
            this.lblHintDwg.TabIndex = 3;

            // ============ 分组 6：打包（Pack and Go） ============
            this.gbPack.BackColor = System.Drawing.Color.White;
            this.gbPack.Controls.Add(this.button16);
            this.gbPack.Controls.Add(this.textBox4);
            this.gbPack.Controls.Add(this.textBox5);
            this.gbPack.Controls.Add(this.lblSave);
            this.gbPack.Controls.Add(this.lblRename);
            this.gbPack.Font = new System.Drawing.Font("微软雅黑", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            this.gbPack.ForeColor = System.Drawing.Color.FromArgb(43, 58, 85);
            this.gbPack.Location = new System.Drawing.Point(16, 504);
            this.gbPack.Name = "gbPack";
            this.gbPack.Size = new System.Drawing.Size(928, 78);
            this.gbPack.TabIndex = 6;
            this.gbPack.TabStop = false;
            this.gbPack.Text = "打包（Pack and Go）";

            this.StyleButton(this.button16, "打包位置");
            this.button16.Location = new System.Drawing.Point(18, 26);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(130, 34);
            this.button16.TabIndex = 0;
            this.button16.Click += new System.EventHandler(button16_Click);

            this.StyleFieldLabel(this.lblSave, "保存位置");
            this.lblSave.Location = new System.Drawing.Point(158, 32);
            this.lblSave.Name = "lblSave";
            this.lblSave.Size = new System.Drawing.Size(60, 22);
            this.lblSave.TabIndex = 1;

            this.StyleTextBox(this.textBox4);
            this.textBox4.Location = new System.Drawing.Point(224, 26);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(452, 26);
            this.textBox4.TabIndex = 2;
            this.textBox4.TextChanged += new System.EventHandler(textBox4_TextChanged);

            this.StyleFieldLabel(this.lblRename, "替换名称");
            this.lblRename.Location = new System.Drawing.Point(692, 32);
            this.lblRename.Name = "lblRename";
            this.lblRename.Size = new System.Drawing.Size(60, 22);
            this.lblRename.TabIndex = 3;

            this.StyleTextBox(this.textBox5);
            this.textBox5.Location = new System.Drawing.Point(758, 26);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(134, 26);
            this.textBox5.TabIndex = 4;
            this.textBox5.TextChanged += new System.EventHandler(textBox5_TextChanged);

            // ============ 分组 7：其他（预留） ============
            this.gbOther.BackColor = System.Drawing.Color.White;
            this.gbOther.Controls.Add(this.button4);
            this.gbOther.Controls.Add(this.textBox6);
            this.gbOther.Controls.Add(this.lblPath6);
            this.gbOther.Controls.Add(this.lblHintOther);
            this.gbOther.Font = new System.Drawing.Font("微软雅黑", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            this.gbOther.ForeColor = System.Drawing.Color.FromArgb(43, 58, 85);
            this.gbOther.Location = new System.Drawing.Point(16, 598);
            this.gbOther.Name = "gbOther";
            this.gbOther.Size = new System.Drawing.Size(928, 92);
            this.gbOther.TabIndex = 7;
            this.gbOther.TabStop = false;
            this.gbOther.Text = "其他";

            this.StyleButton(this.button4, "执行");
            this.button4.Location = new System.Drawing.Point(18, 26);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(130, 34);
            this.button4.TabIndex = 0;
            this.button4.Click += new System.EventHandler(button4_Click_1);

            this.StyleFieldLabel(this.lblPath6, "路径");
            this.lblPath6.Location = new System.Drawing.Point(158, 32);
            this.lblPath6.Name = "lblPath6";
            this.lblPath6.Size = new System.Drawing.Size(60, 22);
            this.lblPath6.TabIndex = 1;

            this.StyleTextBox(this.textBox6);
            this.textBox6.Location = new System.Drawing.Point(224, 26);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(680, 26);
            this.textBox6.TabIndex = 2;
            this.textBox6.TextChanged += new System.EventHandler(textBox6_TextChanged);

            this.StyleHint(this.lblHintOther, "该按钮暂无绑定功能（预留），可在 Form1.cs 的 button4_Click_1 中自行完善。");
            this.lblHintOther.Location = new System.Drawing.Point(18, 66);
            this.lblHintOther.Name = "lblHintOther";
            this.lblHintOther.Size = new System.Drawing.Size(892, 20);
            this.lblHintOther.TabIndex = 3;

            // ============ 分组 9：AI 审核配置（界面填写，无需再改 ai_config.json） ============
            this.gbAIConfig.BackColor = System.Drawing.Color.White;
            this.gbAIConfig.Controls.Add(this.txtApiKey);
            this.gbAIConfig.Controls.Add(this.txtBaseUrl);
            this.gbAIConfig.Controls.Add(this.txtModel);
            this.gbAIConfig.Controls.Add(this.txtVisionApiKey);
            this.gbAIConfig.Controls.Add(this.txtVisionBaseUrl);
            this.gbAIConfig.Controls.Add(this.txtVisionModel);
            this.gbAIConfig.Controls.Add(this.btnSaveAIConfig);
            this.gbAIConfig.Controls.Add(this.lblAIConfigStatus);
            this.gbAIConfig.Controls.Add(this.lblAIHelp1);
            this.gbAIConfig.Controls.Add(this.lblAIHelp2);
            this.gbAIConfig.Font = new System.Drawing.Font("微软雅黑", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            this.gbAIConfig.ForeColor = System.Drawing.Color.FromArgb(43, 58, 85);
            this.gbAIConfig.Location = new System.Drawing.Point(16, 706);
            this.gbAIConfig.Name = "gbAIConfig";
            this.gbAIConfig.Size = new System.Drawing.Size(928, 162);
            this.gbAIConfig.TabIndex = 9;
            this.gbAIConfig.TabStop = false;
            this.gbAIConfig.Text = "AI 审核配置（直接在界面填写，保存后无需再改 ai_config.json）";

            this.StyleFieldLabel(this.lblApiKeyField, "ApiKey");
            this.lblApiKeyField.Location = new System.Drawing.Point(18, 26);
            this.lblApiKeyField.Name = "lblApiKeyField";
            this.lblApiKeyField.Size = new System.Drawing.Size(55, 22);
            this.lblApiKeyField.TabIndex = 0;

            this.StyleTextBox(this.txtApiKey);
            this.txtApiKey.Location = new System.Drawing.Point(80, 22);
            this.txtApiKey.Name = "txtApiKey";
            this.txtApiKey.Size = new System.Drawing.Size(200, 26);
            this.txtApiKey.TabIndex = 1;
            this.toolTipAI.SetToolTip(this.txtApiKey, "文本通道密钥（必填）。DeepSeek 在 platform.deepseek.com 获取；也支持通义/智谱/火山方舟等 OpenAI 兼容密钥。");

            this.StyleFieldLabel(this.lblBaseUrlField, "BaseUrl");
            this.lblBaseUrlField.Location = new System.Drawing.Point(290, 26);
            this.lblBaseUrlField.Name = "lblBaseUrlField";
            this.lblBaseUrlField.Size = new System.Drawing.Size(60, 22);
            this.lblBaseUrlField.TabIndex = 2;

            this.StyleTextBox(this.txtBaseUrl);
            this.txtBaseUrl.Location = new System.Drawing.Point(356, 22);
            this.txtBaseUrl.Name = "txtBaseUrl";
            this.txtBaseUrl.Size = new System.Drawing.Size(270, 26);
            this.txtBaseUrl.TabIndex = 3;
            this.toolTipAI.SetToolTip(this.txtBaseUrl, "接口地址，结尾不要斜杠。默认 https://api.deepseek.com；换通义填 https://dashscope.aliyuncs.com/compatible-mode/v1");

            this.StyleFieldLabel(this.lblModelField, "Model");
            this.lblModelField.Location = new System.Drawing.Point(640, 26);
            this.lblModelField.Name = "lblModelField";
            this.lblModelField.Size = new System.Drawing.Size(45, 22);
            this.lblModelField.TabIndex = 4;

            this.StyleTextBox(this.txtModel);
            this.txtModel.Location = new System.Drawing.Point(692, 22);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(218, 26);
            this.txtModel.TabIndex = 5;
            this.toolTipAI.SetToolTip(this.txtModel, "模型名。默认 deepseek-chat；通义用 qwen-plus；智谱用 glm-4-plus");

            this.StyleHint(this.lblAIHelp1, "文本通道：ApiKey=大模型密钥（必填）；BaseUrl=接口地址（结尾不带 /）；Model=模型名，如 deepseek-chat / qwen-plus / glm-4-plus");
            this.lblAIHelp1.Location = new System.Drawing.Point(18, 52);
            this.lblAIHelp1.Name = "lblAIHelp1";
            this.lblAIHelp1.Size = new System.Drawing.Size(892, 18);
            this.lblAIHelp1.TabIndex = 14;

            this.StyleFieldLabel(this.lblVisionApiKeyField, "视觉Key");
            this.lblVisionApiKeyField.Location = new System.Drawing.Point(18, 74);
            this.lblVisionApiKeyField.Name = "lblVisionApiKeyField";
            this.lblVisionApiKeyField.Size = new System.Drawing.Size(55, 22);
            this.lblVisionApiKeyField.TabIndex = 6;

            this.StyleTextBox(this.txtVisionApiKey);
            this.txtVisionApiKey.Location = new System.Drawing.Point(80, 70);
            this.txtVisionApiKey.Name = "txtVisionApiKey";
            this.txtVisionApiKey.Size = new System.Drawing.Size(200, 26);
            this.txtVisionApiKey.TabIndex = 7;
            this.toolTipAI.SetToolTip(this.txtVisionApiKey, "视觉通道密钥（选填，填了才启用「看图+数据」联合审核）。阿里云百炼 bailian.console.aliyun.com 获取。");

            this.StyleFieldLabel(this.lblVisionBaseUrlField, "视觉地址");
            this.lblVisionBaseUrlField.Location = new System.Drawing.Point(290, 74);
            this.lblVisionBaseUrlField.Name = "lblVisionBaseUrlField";
            this.lblVisionBaseUrlField.Size = new System.Drawing.Size(75, 22);
            this.lblVisionBaseUrlField.TabIndex = 8;

            this.StyleTextBox(this.txtVisionBaseUrl);
            this.txtVisionBaseUrl.Location = new System.Drawing.Point(372, 70);
            this.txtVisionBaseUrl.Name = "txtVisionBaseUrl";
            this.txtVisionBaseUrl.Size = new System.Drawing.Size(270, 26);
            this.txtVisionBaseUrl.TabIndex = 9;
            this.toolTipAI.SetToolTip(this.txtVisionBaseUrl, "视觉接口地址，默认 https://dashscope.aliyuncs.com/compatible-mode/v1（通义千问 VL），一般不用改。");

            this.StyleFieldLabel(this.lblVisionModelField, "视觉模型");
            this.lblVisionModelField.Location = new System.Drawing.Point(652, 74);
            this.lblVisionModelField.Name = "lblVisionModelField";
            this.lblVisionModelField.Size = new System.Drawing.Size(55, 22);
            this.lblVisionModelField.TabIndex = 10;

            this.StyleTextBox(this.txtVisionModel);
            this.txtVisionModel.Location = new System.Drawing.Point(714, 70);
            this.txtVisionModel.Name = "txtVisionModel";
            this.txtVisionModel.Size = new System.Drawing.Size(196, 26);
            this.txtVisionModel.TabIndex = 11;
            this.toolTipAI.SetToolTip(this.txtVisionModel, "视觉模型名，默认 qwen-vl-plus；可按效果换 qwen-vl-max / qwen2.5-vl-72b-instruct");

            this.StyleHint(this.lblAIHelp2, "视觉通道（选填）：视觉Key=火山方舟/百炼密钥，填写后启用「看图+数据」联合审核；若文本通道用的就是方舟/百炼地址，视觉Key可留空，会自动复用文本Key（一个Key两用）");
            this.lblAIHelp2.Location = new System.Drawing.Point(18, 100);
            this.lblAIHelp2.Name = "lblAIHelp2";
            this.lblAIHelp2.Size = new System.Drawing.Size(892, 18);
            this.lblAIHelp2.TabIndex = 15;

            this.StyleButton(this.btnSaveAIConfig, "保存 AI 配置");
            this.btnSaveAIConfig.Location = new System.Drawing.Point(18, 126);
            this.btnSaveAIConfig.Name = "btnSaveAIConfig";
            this.btnSaveAIConfig.Size = new System.Drawing.Size(150, 28);
            this.btnSaveAIConfig.TabIndex = 12;
            this.btnSaveAIConfig.Click += new System.EventHandler(btnSaveAIConfig_Click);

            this.StyleHint(this.lblAIConfigStatus, "打开程序时自动加载 ai_config.json；填写后点「保存 AI 配置」即可生效。");
            this.lblAIConfigStatus.Location = new System.Drawing.Point(180, 132);
            this.lblAIConfigStatus.Name = "lblAIConfigStatus";
            this.lblAIConfigStatus.Size = new System.Drawing.Size(730, 20);
            this.lblAIConfigStatus.TabIndex = 13;

            // ============ 分组 8：图纸检查 ============
            this.gbCheck.BackColor = System.Drawing.Color.White;
            this.gbCheck.Controls.Add(this.buttonAICheck);
            this.gbCheck.Controls.Add(this.buttonCheck);
            this.gbCheck.Controls.Add(this.lblHintCheck);
            this.gbCheck.Font = new System.Drawing.Font("微软雅黑", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            this.gbCheck.ForeColor = System.Drawing.Color.FromArgb(43, 58, 85);
            this.gbCheck.Location = new System.Drawing.Point(16, 880);
            this.gbCheck.Name = "gbCheck";
            this.gbCheck.Size = new System.Drawing.Size(928, 92);
            this.gbCheck.TabIndex = 8;
            this.gbCheck.TabStop = false;
            this.gbCheck.Text = "图纸检查";

            this.StyleButton(this.buttonCheck, "检查当前工程图");
            this.buttonCheck.Location = new System.Drawing.Point(18, 26);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(200, 36);
            this.buttonCheck.TabIndex = 0;
            this.buttonCheck.Click += new System.EventHandler(buttonCheck_Click);

            this.StyleButton(this.buttonAICheck, "AI 智能审核");
            this.buttonAICheck.Location = new System.Drawing.Point(230, 26);
            this.buttonAICheck.Name = "buttonAICheck";
            this.buttonAICheck.Size = new System.Drawing.Size(200, 36);
            this.buttonAICheck.TabIndex = 1;
            this.buttonAICheck.Click += new System.EventHandler(buttonAICheck_Click);

            this.StyleHint(this.lblHintCheck, "规则检查：标注/格式/标题栏（按赢合模板）问题，只读不修改图纸；AI 智能审核：把图纸结构化信息发给大模型 API 全面审核，可在上方「AI 审核配置」栏填写 ApiKey 后使用。");
            this.lblHintCheck.Location = new System.Drawing.Point(18, 68);
            this.lblHintCheck.Name = "lblHintCheck";
            this.lblHintCheck.Size = new System.Drawing.Size(892, 20);
            this.lblHintCheck.TabIndex = 2;

            // ============ 窗体 ============
            base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(239, 242, 247);
            base.ClientSize = new System.Drawing.Size(960, 992);
            base.Controls.Add(this.gbCheck);
            base.Controls.Add(this.gbAIConfig);
            base.Controls.Add(this.gbOther);
            base.Controls.Add(this.gbPack);
            base.Controls.Add(this.gbDwg);
            base.Controls.Add(this.gbClean);
            base.Controls.Add(this.gbReplace);
            base.Controls.Add(this.gbProps);
            base.Controls.Add(this.gbConnect);
            base.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("等线", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.Name = "Form1";
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "涂布一组工具";
            base.Load += new System.EventHandler(Form1_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.gbConnect.ResumeLayout(false);
            this.gbProps.ResumeLayout(false);
            this.gbReplace.ResumeLayout(false);
            this.gbClean.ResumeLayout(false);
            this.gbDwg.ResumeLayout(false);
            this.gbPack.ResumeLayout(false);
            this.gbOther.ResumeLayout(false);
            this.gbCheck.ResumeLayout(false);
            this.gbAIConfig.ResumeLayout(false);
            this.gbAIConfig.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        // ============ 样式辅助方法 ============
        private void StyleButton(System.Windows.Forms.Button btn, string text)
        {
            btn.Text = text;
            btn.BackColor = System.Drawing.Color.White;
            btn.ForeColor = System.Drawing.Color.FromArgb(36, 50, 74);
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(193, 205, 224);
            btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(234, 241, 254);
            btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(216, 229, 251);
            btn.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.UseVisualStyleBackColor = false;
        }

        private void StyleTextBox(System.Windows.Forms.TextBox tb)
        {
            tb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tb.BackColor = System.Drawing.Color.White;
            tb.Font = new System.Drawing.Font("等线", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
        }

        private void StyleFieldLabel(System.Windows.Forms.Label lbl, string text)
        {
            lbl.Text = text;
            lbl.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            lbl.ForeColor = System.Drawing.Color.FromArgb(90, 107, 135);
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        }

        private void StyleHint(System.Windows.Forms.Label lbl, string text)
        {
            lbl.Text = text;
            lbl.Font = new System.Drawing.Font("微软雅黑", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            lbl.ForeColor = System.Drawing.Color.FromArgb(138, 151, 173);
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        }
    }
}
