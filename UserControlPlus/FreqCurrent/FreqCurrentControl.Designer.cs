namespace UserControlPlusLib
{
    partial class FreqCurrentControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
			this.groupBox_funcName = new System.Windows.Forms.GroupBox();
			this.groupBox_passConfig = new System.Windows.Forms.GroupBox();
			this.button_startDo = new System.Windows.Forms.Button();
			this.groupBox_stopPassConfig = new System.Windows.Forms.GroupBox();
			this.panel_stopPass = new System.Windows.Forms.Panel();
			this.label_stopPassMaxUnite = new System.Windows.Forms.Label();
			this.numericUpDown_stopPassMax = new System.Windows.Forms.NumericUpDown();
			this.label_stopPassMax = new System.Windows.Forms.Label();
			this.label_stopPassMinUnite = new System.Windows.Forms.Label();
			this.numericUpDown_stopPassMin = new System.Windows.Forms.NumericUpDown();
			this.label_stopPassMin = new System.Windows.Forms.Label();
			this.groupBox_passSpaceConfig = new System.Windows.Forms.GroupBox();
			this.panel_passSpace = new System.Windows.Forms.Panel();
			this.label_passSpacePointMaxADCUnite = new System.Windows.Forms.Label();
			this.numericUpDown_passSpacePointMax = new System.Windows.Forms.NumericUpDown();
			this.label_passSpacePointMinADC = new System.Windows.Forms.Label();
			this.label_passSpacePointMinADCUnite = new System.Windows.Forms.Label();
			this.numericUpDown_passSpacePointNum = new System.Windows.Forms.NumericUpDown();
			this.label_passSpacePointNum = new System.Windows.Forms.Label();
			this.numericUpDown_passSpacePointMin = new System.Windows.Forms.NumericUpDown();
			this.label_passSpacePointMaxADC = new System.Windows.Forms.Label();
			this.button_writePassConfig = new System.Windows.Forms.Button();
			this.groupBox_startPassConfig = new System.Windows.Forms.GroupBox();
			this.panel_startPass = new System.Windows.Forms.Panel();
			this.label_startPassMaxUnite = new System.Windows.Forms.Label();
			this.numericUpDown_startPassMax = new System.Windows.Forms.NumericUpDown();
			this.label_startPassMax = new System.Windows.Forms.Label();
			this.label_startPassMinUnite = new System.Windows.Forms.Label();
			this.numericUpDown_startPassMin = new System.Windows.Forms.NumericUpDown();
			this.label_startPassMin = new System.Windows.Forms.Label();
			this.button_readPassConfig = new System.Windows.Forms.Button();
			this.groupBox_freqConfig = new System.Windows.Forms.GroupBox();
			this.panel_freqConfig = new System.Windows.Forms.Panel();
			this.numericUpDown_stepPointNum = new System.Windows.Forms.NumericUpDown();
			this.label_stepPointNum = new System.Windows.Forms.Label();
			this.label_stepFreqUnite = new System.Windows.Forms.Label();
			this.button_writeFreqConfig = new System.Windows.Forms.Button();
			this.numericUpDown_stepFreq = new System.Windows.Forms.NumericUpDown();
			this.label_stepFreq = new System.Windows.Forms.Label();
			this.label_startFreqUnite = new System.Windows.Forms.Label();
			this.button_readFreqConfig = new System.Windows.Forms.Button();
			this.numericUpDown_startFreq = new System.Windows.Forms.NumericUpDown();
			this.label_startFreq = new System.Windows.Forms.Label();
			this.groupBox_funcName.SuspendLayout();
			this.groupBox_passConfig.SuspendLayout();
			this.groupBox_stopPassConfig.SuspendLayout();
			this.panel_stopPass.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_stopPassMax)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_stopPassMin)).BeginInit();
			this.groupBox_passSpaceConfig.SuspendLayout();
			this.panel_passSpace.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_passSpacePointMax)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_passSpacePointNum)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_passSpacePointMin)).BeginInit();
			this.groupBox_startPassConfig.SuspendLayout();
			this.panel_startPass.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_startPassMax)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_startPassMin)).BeginInit();
			this.groupBox_freqConfig.SuspendLayout();
			this.panel_freqConfig.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_stepPointNum)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_stepFreq)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_startFreq)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox_funcName
			// 
			this.groupBox_funcName.Controls.Add(this.groupBox_passConfig);
			this.groupBox_funcName.Controls.Add(this.groupBox_freqConfig);
			this.groupBox_funcName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox_funcName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.groupBox_funcName.Location = new System.Drawing.Point(0, 3);
			this.groupBox_funcName.Margin = new System.Windows.Forms.Padding(6);
			this.groupBox_funcName.Name = "groupBox_funcName";
			this.groupBox_funcName.Padding = new System.Windows.Forms.Padding(6, 6, 6, 0);
			this.groupBox_funcName.Size = new System.Drawing.Size(264, 399);
			this.groupBox_funcName.TabIndex = 0;
			this.groupBox_funcName.TabStop = false;
			this.groupBox_funcName.Text = "电压频率参数";
			// 
			// groupBox_passConfig
			// 
			this.groupBox_passConfig.Controls.Add(this.button_startDo);
			this.groupBox_passConfig.Controls.Add(this.groupBox_stopPassConfig);
			this.groupBox_passConfig.Controls.Add(this.groupBox_passSpaceConfig);
			this.groupBox_passConfig.Controls.Add(this.button_writePassConfig);
			this.groupBox_passConfig.Controls.Add(this.groupBox_startPassConfig);
			this.groupBox_passConfig.Controls.Add(this.button_readPassConfig);
			this.groupBox_passConfig.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox_passConfig.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.groupBox_passConfig.Location = new System.Drawing.Point(6, 123);
			this.groupBox_passConfig.Name = "groupBox_passConfig";
			this.groupBox_passConfig.Size = new System.Drawing.Size(252, 276);
			this.groupBox_passConfig.TabIndex = 11;
			this.groupBox_passConfig.TabStop = false;
			this.groupBox_passConfig.Text = "合格条件参数";
			// 
			// button_startDo
			// 
			this.button_startDo.Location = new System.Drawing.Point(175, 247);
			this.button_startDo.Name = "button_startDo";
			this.button_startDo.Size = new System.Drawing.Size(71, 25);
			this.button_startDo.TabIndex = 15;
			this.button_startDo.Text = "开始测试";
			this.button_startDo.UseVisualStyleBackColor = true;
			// 
			// groupBox_stopPassConfig
			// 
			this.groupBox_stopPassConfig.Controls.Add(this.panel_stopPass);
			this.groupBox_stopPassConfig.Location = new System.Drawing.Point(0, 201);
			this.groupBox_stopPassConfig.Name = "groupBox_stopPassConfig";
			this.groupBox_stopPassConfig.Size = new System.Drawing.Size(172, 74);
			this.groupBox_stopPassConfig.TabIndex = 11;
			this.groupBox_stopPassConfig.TabStop = false;
			this.groupBox_stopPassConfig.Text = "终止点电流合格条件";
			// 
			// panel_stopPass
			// 
			this.panel_stopPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel_stopPass.Controls.Add(this.label_stopPassMaxUnite);
			this.panel_stopPass.Controls.Add(this.numericUpDown_stopPassMax);
			this.panel_stopPass.Controls.Add(this.label_stopPassMax);
			this.panel_stopPass.Controls.Add(this.label_stopPassMinUnite);
			this.panel_stopPass.Controls.Add(this.numericUpDown_stopPassMin);
			this.panel_stopPass.Controls.Add(this.label_stopPassMin);
			this.panel_stopPass.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_stopPass.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.panel_stopPass.Location = new System.Drawing.Point(3, 17);
			this.panel_stopPass.Name = "panel_stopPass";
			this.panel_stopPass.Size = new System.Drawing.Size(166, 54);
			this.panel_stopPass.TabIndex = 3;
			// 
			// label_stopPassMaxUnite
			// 
			this.label_stopPassMaxUnite.AutoSize = true;
			this.label_stopPassMaxUnite.Location = new System.Drawing.Point(141, 31);
			this.label_stopPassMaxUnite.Name = "label_stopPassMaxUnite";
			this.label_stopPassMaxUnite.Size = new System.Drawing.Size(17, 12);
			this.label_stopPassMaxUnite.TabIndex = 11;
			this.label_stopPassMaxUnite.Text = "mA";
			// 
			// numericUpDown_stopPassMax
			// 
			this.numericUpDown_stopPassMax.DecimalPlaces = 2;
			this.numericUpDown_stopPassMax.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.numericUpDown_stopPassMax.Location = new System.Drawing.Point(60, 29);
			this.numericUpDown_stopPassMax.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDown_stopPassMax.Name = "numericUpDown_stopPassMax";
			this.numericUpDown_stopPassMax.Size = new System.Drawing.Size(75, 21);
			this.numericUpDown_stopPassMax.TabIndex = 10;
			this.numericUpDown_stopPassMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDown_stopPassMax.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
			// 
			// label_stopPassMax
			// 
			this.label_stopPassMax.AutoSize = true;
			this.label_stopPassMax.Location = new System.Drawing.Point(3, 31);
			this.label_stopPassMax.Name = "label_stopPassMax";
			this.label_stopPassMax.Size = new System.Drawing.Size(59, 12);
			this.label_stopPassMax.TabIndex = 9;
			this.label_stopPassMax.Text = "合格上限:";
			// 
			// label_stopPassMinUnite
			// 
			this.label_stopPassMinUnite.AutoSize = true;
			this.label_stopPassMinUnite.Location = new System.Drawing.Point(141, 4);
			this.label_stopPassMinUnite.Name = "label_stopPassMinUnite";
			this.label_stopPassMinUnite.Size = new System.Drawing.Size(17, 12);
			this.label_stopPassMinUnite.TabIndex = 8;
			this.label_stopPassMinUnite.Text = "mA";
			// 
			// numericUpDown_stopPassMin
			// 
			this.numericUpDown_stopPassMin.DecimalPlaces = 2;
			this.numericUpDown_stopPassMin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.numericUpDown_stopPassMin.Location = new System.Drawing.Point(60, 2);
			this.numericUpDown_stopPassMin.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDown_stopPassMin.Name = "numericUpDown_stopPassMin";
			this.numericUpDown_stopPassMin.Size = new System.Drawing.Size(75, 21);
			this.numericUpDown_stopPassMin.TabIndex = 6;
			this.numericUpDown_stopPassMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDown_stopPassMin.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
			// 
			// label_stopPassMin
			// 
			this.label_stopPassMin.AutoSize = true;
			this.label_stopPassMin.Location = new System.Drawing.Point(3, 5);
			this.label_stopPassMin.Name = "label_stopPassMin";
			this.label_stopPassMin.Size = new System.Drawing.Size(59, 12);
			this.label_stopPassMin.TabIndex = 4;
			this.label_stopPassMin.Text = "合格下限:";
			// 
			// groupBox_passSpaceConfig
			// 
			this.groupBox_passSpaceConfig.Controls.Add(this.panel_passSpace);
			this.groupBox_passSpaceConfig.Location = new System.Drawing.Point(0, 97);
			this.groupBox_passSpaceConfig.Name = "groupBox_passSpaceConfig";
			this.groupBox_passSpaceConfig.Size = new System.Drawing.Size(172, 101);
			this.groupBox_passSpaceConfig.TabIndex = 9;
			this.groupBox_passSpaceConfig.TabStop = false;
			this.groupBox_passSpaceConfig.Text = "电流差值合格条件";
			// 
			// panel_passSpace
			// 
			this.panel_passSpace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel_passSpace.Controls.Add(this.label_passSpacePointMaxADCUnite);
			this.panel_passSpace.Controls.Add(this.numericUpDown_passSpacePointMax);
			this.panel_passSpace.Controls.Add(this.label_passSpacePointMinADC);
			this.panel_passSpace.Controls.Add(this.label_passSpacePointMinADCUnite);
			this.panel_passSpace.Controls.Add(this.numericUpDown_passSpacePointNum);
			this.panel_passSpace.Controls.Add(this.label_passSpacePointNum);
			this.panel_passSpace.Controls.Add(this.numericUpDown_passSpacePointMin);
			this.panel_passSpace.Controls.Add(this.label_passSpacePointMaxADC);
			this.panel_passSpace.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_passSpace.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.panel_passSpace.Location = new System.Drawing.Point(3, 17);
			this.panel_passSpace.Name = "panel_passSpace";
			this.panel_passSpace.Size = new System.Drawing.Size(166, 81);
			this.panel_passSpace.TabIndex = 3;
			// 
			// label_passSpacePointMaxADCUnite
			// 
			this.label_passSpacePointMaxADCUnite.AutoSize = true;
			this.label_passSpacePointMaxADCUnite.Location = new System.Drawing.Point(141, 31);
			this.label_passSpacePointMaxADCUnite.Name = "label_passSpacePointMaxADCUnite";
			this.label_passSpacePointMaxADCUnite.Size = new System.Drawing.Size(23, 12);
			this.label_passSpacePointMaxADCUnite.TabIndex = 14;
			this.label_passSpacePointMaxADCUnite.Text = "ADC";
			// 
			// numericUpDown_passSpacePointMax
			// 
			this.numericUpDown_passSpacePointMax.Location = new System.Drawing.Point(60, 29);
			this.numericUpDown_passSpacePointMax.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDown_passSpacePointMax.Name = "numericUpDown_passSpacePointMax";
			this.numericUpDown_passSpacePointMax.Size = new System.Drawing.Size(75, 21);
			this.numericUpDown_passSpacePointMax.TabIndex = 13;
			this.numericUpDown_passSpacePointMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDown_passSpacePointMax.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
			// 
			// label_passSpacePointMinADC
			// 
			this.label_passSpacePointMinADC.AutoSize = true;
			this.label_passSpacePointMinADC.Location = new System.Drawing.Point(3, 31);
			this.label_passSpacePointMinADC.Name = "label_passSpacePointMinADC";
			this.label_passSpacePointMinADC.Size = new System.Drawing.Size(59, 12);
			this.label_passSpacePointMinADC.TabIndex = 12;
			this.label_passSpacePointMinADC.Text = "合格下限:";
			// 
			// label_passSpacePointMinADCUnite
			// 
			this.label_passSpacePointMinADCUnite.AutoSize = true;
			this.label_passSpacePointMinADCUnite.Location = new System.Drawing.Point(141, 58);
			this.label_passSpacePointMinADCUnite.Name = "label_passSpacePointMinADCUnite";
			this.label_passSpacePointMinADCUnite.Size = new System.Drawing.Size(23, 12);
			this.label_passSpacePointMinADCUnite.TabIndex = 11;
			this.label_passSpacePointMinADCUnite.Text = "ADC";
			// 
			// numericUpDown_passSpacePointNum
			// 
			this.numericUpDown_passSpacePointNum.Location = new System.Drawing.Point(60, 2);
			this.numericUpDown_passSpacePointNum.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDown_passSpacePointNum.Name = "numericUpDown_passSpacePointNum";
			this.numericUpDown_passSpacePointNum.Size = new System.Drawing.Size(75, 21);
			this.numericUpDown_passSpacePointNum.TabIndex = 6;
			this.numericUpDown_passSpacePointNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDown_passSpacePointNum.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
			// 
			// label_passSpacePointNum
			// 
			this.label_passSpacePointNum.AutoSize = true;
			this.label_passSpacePointNum.Location = new System.Drawing.Point(3, 5);
			this.label_passSpacePointNum.Name = "label_passSpacePointNum";
			this.label_passSpacePointNum.Size = new System.Drawing.Size(59, 12);
			this.label_passSpacePointNum.TabIndex = 4;
			this.label_passSpacePointNum.Text = "间隔点数:";
			// 
			// numericUpDown_passSpacePointMin
			// 
			this.numericUpDown_passSpacePointMin.Location = new System.Drawing.Point(60, 56);
			this.numericUpDown_passSpacePointMin.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDown_passSpacePointMin.Name = "numericUpDown_passSpacePointMin";
			this.numericUpDown_passSpacePointMin.Size = new System.Drawing.Size(75, 21);
			this.numericUpDown_passSpacePointMin.TabIndex = 10;
			this.numericUpDown_passSpacePointMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDown_passSpacePointMin.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
			// 
			// label_passSpacePointMaxADC
			// 
			this.label_passSpacePointMaxADC.AutoSize = true;
			this.label_passSpacePointMaxADC.Location = new System.Drawing.Point(3, 58);
			this.label_passSpacePointMaxADC.Name = "label_passSpacePointMaxADC";
			this.label_passSpacePointMaxADC.Size = new System.Drawing.Size(59, 12);
			this.label_passSpacePointMaxADC.TabIndex = 9;
			this.label_passSpacePointMaxADC.Text = "合格上限:";
			// 
			// button_writePassConfig
			// 
			this.button_writePassConfig.Location = new System.Drawing.Point(175, 217);
			this.button_writePassConfig.Name = "button_writePassConfig";
			this.button_writePassConfig.Size = new System.Drawing.Size(71, 25);
			this.button_writePassConfig.TabIndex = 13;
			this.button_writePassConfig.Text = "写入参数";
			this.button_writePassConfig.UseVisualStyleBackColor = true;
			// 
			// groupBox_startPassConfig
			// 
			this.groupBox_startPassConfig.Controls.Add(this.panel_startPass);
			this.groupBox_startPassConfig.Location = new System.Drawing.Point(0, 20);
			this.groupBox_startPassConfig.Name = "groupBox_startPassConfig";
			this.groupBox_startPassConfig.Size = new System.Drawing.Size(172, 74);
			this.groupBox_startPassConfig.TabIndex = 8;
			this.groupBox_startPassConfig.TabStop = false;
			this.groupBox_startPassConfig.Text = "起始点电流合格条件";
			// 
			// panel_startPass
			// 
			this.panel_startPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel_startPass.Controls.Add(this.label_startPassMaxUnite);
			this.panel_startPass.Controls.Add(this.numericUpDown_startPassMax);
			this.panel_startPass.Controls.Add(this.label_startPassMax);
			this.panel_startPass.Controls.Add(this.label_startPassMinUnite);
			this.panel_startPass.Controls.Add(this.numericUpDown_startPassMin);
			this.panel_startPass.Controls.Add(this.label_startPassMin);
			this.panel_startPass.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_startPass.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.panel_startPass.Location = new System.Drawing.Point(3, 17);
			this.panel_startPass.Name = "panel_startPass";
			this.panel_startPass.Size = new System.Drawing.Size(166, 54);
			this.panel_startPass.TabIndex = 3;
			// 
			// label_startPassMaxUnite
			// 
			this.label_startPassMaxUnite.AutoSize = true;
			this.label_startPassMaxUnite.Location = new System.Drawing.Point(141, 31);
			this.label_startPassMaxUnite.Name = "label_startPassMaxUnite";
			this.label_startPassMaxUnite.Size = new System.Drawing.Size(17, 12);
			this.label_startPassMaxUnite.TabIndex = 11;
			this.label_startPassMaxUnite.Text = "mA";
			// 
			// numericUpDown_startPassMax
			// 
			this.numericUpDown_startPassMax.DecimalPlaces = 2;
			this.numericUpDown_startPassMax.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.numericUpDown_startPassMax.Location = new System.Drawing.Point(60, 29);
			this.numericUpDown_startPassMax.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDown_startPassMax.Name = "numericUpDown_startPassMax";
			this.numericUpDown_startPassMax.Size = new System.Drawing.Size(75, 21);
			this.numericUpDown_startPassMax.TabIndex = 10;
			this.numericUpDown_startPassMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDown_startPassMax.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
			// 
			// label_startPassMax
			// 
			this.label_startPassMax.AutoSize = true;
			this.label_startPassMax.Location = new System.Drawing.Point(3, 31);
			this.label_startPassMax.Name = "label_startPassMax";
			this.label_startPassMax.Size = new System.Drawing.Size(59, 12);
			this.label_startPassMax.TabIndex = 9;
			this.label_startPassMax.Text = "合格上限:";
			// 
			// label_startPassMinUnite
			// 
			this.label_startPassMinUnite.AutoSize = true;
			this.label_startPassMinUnite.Location = new System.Drawing.Point(141, 5);
			this.label_startPassMinUnite.Name = "label_startPassMinUnite";
			this.label_startPassMinUnite.Size = new System.Drawing.Size(17, 12);
			this.label_startPassMinUnite.TabIndex = 8;
			this.label_startPassMinUnite.Text = "mA";
			// 
			// numericUpDown_startPassMin
			// 
			this.numericUpDown_startPassMin.DecimalPlaces = 2;
			this.numericUpDown_startPassMin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.numericUpDown_startPassMin.Location = new System.Drawing.Point(60, 2);
			this.numericUpDown_startPassMin.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDown_startPassMin.Name = "numericUpDown_startPassMin";
			this.numericUpDown_startPassMin.Size = new System.Drawing.Size(75, 21);
			this.numericUpDown_startPassMin.TabIndex = 6;
			this.numericUpDown_startPassMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDown_startPassMin.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
			// 
			// label_startPassMin
			// 
			this.label_startPassMin.AutoSize = true;
			this.label_startPassMin.Location = new System.Drawing.Point(3, 5);
			this.label_startPassMin.Name = "label_startPassMin";
			this.label_startPassMin.Size = new System.Drawing.Size(59, 12);
			this.label_startPassMin.TabIndex = 4;
			this.label_startPassMin.Text = "合格下限:";
			// 
			// button_readPassConfig
			// 
			this.button_readPassConfig.Location = new System.Drawing.Point(175, 186);
			this.button_readPassConfig.Name = "button_readPassConfig";
			this.button_readPassConfig.Size = new System.Drawing.Size(71, 25);
			this.button_readPassConfig.TabIndex = 12;
			this.button_readPassConfig.Text = "读取参数";
			this.button_readPassConfig.UseVisualStyleBackColor = true;
			// 
			// groupBox_freqConfig
			// 
			this.groupBox_freqConfig.Controls.Add(this.panel_freqConfig);
			this.groupBox_freqConfig.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox_freqConfig.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.groupBox_freqConfig.Location = new System.Drawing.Point(6, 20);
			this.groupBox_freqConfig.Name = "groupBox_freqConfig";
			this.groupBox_freqConfig.Size = new System.Drawing.Size(252, 100);
			this.groupBox_freqConfig.TabIndex = 9;
			this.groupBox_freqConfig.TabStop = false;
			this.groupBox_freqConfig.Text = "频率参数";
			// 
			// panel_freqConfig
			// 
			this.panel_freqConfig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel_freqConfig.Controls.Add(this.numericUpDown_stepPointNum);
			this.panel_freqConfig.Controls.Add(this.label_stepPointNum);
			this.panel_freqConfig.Controls.Add(this.label_stepFreqUnite);
			this.panel_freqConfig.Controls.Add(this.button_writeFreqConfig);
			this.panel_freqConfig.Controls.Add(this.numericUpDown_stepFreq);
			this.panel_freqConfig.Controls.Add(this.label_stepFreq);
			this.panel_freqConfig.Controls.Add(this.label_startFreqUnite);
			this.panel_freqConfig.Controls.Add(this.button_readFreqConfig);
			this.panel_freqConfig.Controls.Add(this.numericUpDown_startFreq);
			this.panel_freqConfig.Controls.Add(this.label_startFreq);
			this.panel_freqConfig.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_freqConfig.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.panel_freqConfig.Location = new System.Drawing.Point(3, 17);
			this.panel_freqConfig.Name = "panel_freqConfig";
			this.panel_freqConfig.Size = new System.Drawing.Size(246, 80);
			this.panel_freqConfig.TabIndex = 3;
			// 
			// numericUpDown_stepPointNum
			// 
			this.numericUpDown_stepPointNum.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
			this.numericUpDown_stepPointNum.Location = new System.Drawing.Point(60, 56);
			this.numericUpDown_stepPointNum.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.numericUpDown_stepPointNum.Name = "numericUpDown_stepPointNum";
			this.numericUpDown_stepPointNum.Size = new System.Drawing.Size(75, 21);
			this.numericUpDown_stepPointNum.TabIndex = 13;
			this.numericUpDown_stepPointNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDown_stepPointNum.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
			// 
			// label_stepPointNum
			// 
			this.label_stepPointNum.AutoSize = true;
			this.label_stepPointNum.Location = new System.Drawing.Point(3, 58);
			this.label_stepPointNum.Name = "label_stepPointNum";
			this.label_stepPointNum.Size = new System.Drawing.Size(59, 12);
			this.label_stepPointNum.TabIndex = 12;
			this.label_stepPointNum.Text = "扫描点数:";
			// 
			// label_stepFreqUnite
			// 
			this.label_stepFreqUnite.AutoSize = true;
			this.label_stepFreqUnite.Location = new System.Drawing.Point(141, 31);
			this.label_stepFreqUnite.Name = "label_stepFreqUnite";
			this.label_stepFreqUnite.Size = new System.Drawing.Size(23, 12);
			this.label_stepFreqUnite.TabIndex = 11;
			this.label_stepFreqUnite.Text = "MHz";
			// 
			// button_writeFreqConfig
			// 
			this.button_writeFreqConfig.Location = new System.Drawing.Point(170, 50);
			this.button_writeFreqConfig.Name = "button_writeFreqConfig";
			this.button_writeFreqConfig.Size = new System.Drawing.Size(71, 25);
			this.button_writeFreqConfig.TabIndex = 3;
			this.button_writeFreqConfig.Text = "写入参数";
			this.button_writeFreqConfig.UseVisualStyleBackColor = true;
			// 
			// numericUpDown_stepFreq
			// 
			this.numericUpDown_stepFreq.DecimalPlaces = 2;
			this.numericUpDown_stepFreq.Location = new System.Drawing.Point(60, 29);
			this.numericUpDown_stepFreq.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDown_stepFreq.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
			this.numericUpDown_stepFreq.Name = "numericUpDown_stepFreq";
			this.numericUpDown_stepFreq.Size = new System.Drawing.Size(75, 21);
			this.numericUpDown_stepFreq.TabIndex = 10;
			this.numericUpDown_stepFreq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDown_stepFreq.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
			// 
			// label_stepFreq
			// 
			this.label_stepFreq.AutoSize = true;
			this.label_stepFreq.Location = new System.Drawing.Point(3, 31);
			this.label_stepFreq.Name = "label_stepFreq";
			this.label_stepFreq.Size = new System.Drawing.Size(59, 12);
			this.label_stepFreq.TabIndex = 9;
			this.label_stepFreq.Text = "步进频率:";
			// 
			// label_startFreqUnite
			// 
			this.label_startFreqUnite.AutoSize = true;
			this.label_startFreqUnite.Location = new System.Drawing.Point(141, 5);
			this.label_startFreqUnite.Name = "label_startFreqUnite";
			this.label_startFreqUnite.Size = new System.Drawing.Size(23, 12);
			this.label_startFreqUnite.TabIndex = 8;
			this.label_startFreqUnite.Text = "MHz";
			// 
			// button_readFreqConfig
			// 
			this.button_readFreqConfig.Location = new System.Drawing.Point(170, 18);
			this.button_readFreqConfig.Name = "button_readFreqConfig";
			this.button_readFreqConfig.Size = new System.Drawing.Size(71, 25);
			this.button_readFreqConfig.TabIndex = 2;
			this.button_readFreqConfig.Text = "读取参数";
			this.button_readFreqConfig.UseVisualStyleBackColor = true;
			// 
			// numericUpDown_startFreq
			// 
			this.numericUpDown_startFreq.DecimalPlaces = 2;
			this.numericUpDown_startFreq.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.numericUpDown_startFreq.Location = new System.Drawing.Point(60, 2);
			this.numericUpDown_startFreq.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDown_startFreq.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.numericUpDown_startFreq.Name = "numericUpDown_startFreq";
			this.numericUpDown_startFreq.Size = new System.Drawing.Size(75, 21);
			this.numericUpDown_startFreq.TabIndex = 6;
			this.numericUpDown_startFreq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDown_startFreq.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			// 
			// label_startFreq
			// 
			this.label_startFreq.AutoSize = true;
			this.label_startFreq.Location = new System.Drawing.Point(3, 5);
			this.label_startFreq.Name = "label_startFreq";
			this.label_startFreq.Size = new System.Drawing.Size(59, 12);
			this.label_startFreq.TabIndex = 4;
			this.label_startFreq.Text = "起始频率:";
			// 
			// FreqCurrentControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox_funcName);
			this.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.Name = "FreqCurrentControl";
			this.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.Size = new System.Drawing.Size(264, 402);
			this.groupBox_funcName.ResumeLayout(false);
			this.groupBox_passConfig.ResumeLayout(false);
			this.groupBox_stopPassConfig.ResumeLayout(false);
			this.panel_stopPass.ResumeLayout(false);
			this.panel_stopPass.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_stopPassMax)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_stopPassMin)).EndInit();
			this.groupBox_passSpaceConfig.ResumeLayout(false);
			this.panel_passSpace.ResumeLayout(false);
			this.panel_passSpace.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_passSpacePointMax)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_passSpacePointNum)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_passSpacePointMin)).EndInit();
			this.groupBox_startPassConfig.ResumeLayout(false);
			this.panel_startPass.ResumeLayout(false);
			this.panel_startPass.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_startPassMax)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_startPassMin)).EndInit();
			this.groupBox_freqConfig.ResumeLayout(false);
			this.panel_freqConfig.ResumeLayout(false);
			this.panel_freqConfig.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_stepPointNum)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_stepFreq)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_startFreq)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_funcName;
        private System.Windows.Forms.GroupBox groupBox_freqConfig;
        private System.Windows.Forms.Panel panel_freqConfig;
        private System.Windows.Forms.NumericUpDown numericUpDown_stepPointNum;
        private System.Windows.Forms.Label label_stepPointNum;
        private System.Windows.Forms.Label label_stepFreqUnite;
        private System.Windows.Forms.NumericUpDown numericUpDown_stepFreq;
        private System.Windows.Forms.Label label_stepFreq;
        private System.Windows.Forms.Label label_startFreqUnite;
        private System.Windows.Forms.NumericUpDown numericUpDown_startFreq;
        private System.Windows.Forms.Label label_startFreq;
        private System.Windows.Forms.GroupBox groupBox_passConfig;
        private System.Windows.Forms.GroupBox groupBox_stopPassConfig;
        private System.Windows.Forms.Panel panel_stopPass;
        private System.Windows.Forms.Label label_stopPassMaxUnite;
        private System.Windows.Forms.NumericUpDown numericUpDown_stopPassMax;
        private System.Windows.Forms.Label label_stopPassMax;
        private System.Windows.Forms.Label label_stopPassMinUnite;
        private System.Windows.Forms.NumericUpDown numericUpDown_stopPassMin;
        private System.Windows.Forms.Label label_stopPassMin;
        private System.Windows.Forms.GroupBox groupBox_passSpaceConfig;
        private System.Windows.Forms.Panel panel_passSpace;
        private System.Windows.Forms.Label label_passSpacePointMaxADCUnite;
        private System.Windows.Forms.NumericUpDown numericUpDown_passSpacePointMax;
        private System.Windows.Forms.Label label_passSpacePointMinADC;
        private System.Windows.Forms.Label label_passSpacePointMinADCUnite;
        private System.Windows.Forms.NumericUpDown numericUpDown_passSpacePointMin;
        private System.Windows.Forms.Label label_passSpacePointMaxADC;
        private System.Windows.Forms.NumericUpDown numericUpDown_passSpacePointNum;
        private System.Windows.Forms.Label label_passSpacePointNum;
        private System.Windows.Forms.Button button_writePassConfig;
        private System.Windows.Forms.GroupBox groupBox_startPassConfig;
        private System.Windows.Forms.Panel panel_startPass;
        private System.Windows.Forms.Label label_startPassMaxUnite;
        private System.Windows.Forms.NumericUpDown numericUpDown_startPassMax;
        private System.Windows.Forms.Label label_startPassMax;
        private System.Windows.Forms.Label label_startPassMinUnite;
        private System.Windows.Forms.NumericUpDown numericUpDown_startPassMin;
        private System.Windows.Forms.Label label_startPassMin;
        private System.Windows.Forms.Button button_readPassConfig;
        private System.Windows.Forms.Button button_startDo;
		private System.Windows.Forms.Button button_writeFreqConfig;
		private System.Windows.Forms.Button button_readFreqConfig;
	}
}
