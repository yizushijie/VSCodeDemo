namespace RFASKFreqCurrentForm
{
    partial class RFASKFreqCurrentForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.toolStrip_BottomMenu = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel_SysTickName = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator_SysTickName = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel_SysTick = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator_SysTick = new System.Windows.Forms.ToolStripSeparator();
			this.timer_SysTick = new System.Windows.Forms.Timer(this.components);
			this.tabControl_FuncMenu = new System.Windows.Forms.TabControl();
			this.tabPage_Func = new System.Windows.Forms.TabPage();
			this.richTextBoxEx_msg = new RichTextBoxPlusLib.RichTextBoxEx();
			this.preFreqControl_preFreq = new UserControlPlusLib.PreFreqControl();
			this.deviceTypeControl_deviceType = new UserControlPlusLib.DeviceTypeControl();
			this.freqCurrentControl_freqCurrentPointTwo = new UserControlPlusLib.FreqCurrentControl();
			this.freqCurrentControl_freqCurrentPointOne = new UserControlPlusLib.FreqCurrentControl();
			this.clockRateControl_clockRate = new UserControlPlusLib.ClockRateControl();
			this.commPortControl_commPort = new COMMPortLib.COMMPortControl();
			this.tabPage_Chart = new System.Windows.Forms.TabPage();
			this.myChart_freqCurrent = new UserControlPlusLib.MyChart.MyChart();
			this.button_startMonitorData = new System.Windows.Forms.Button();
			this.button_stopMonitorData = new System.Windows.Forms.Button();
			this.toolStrip_BottomMenu.SuspendLayout();
			this.tabControl_FuncMenu.SuspendLayout();
			this.tabPage_Func.SuspendLayout();
			this.tabPage_Chart.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip_BottomMenu
			// 
			this.toolStrip_BottomMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.toolStrip_BottomMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_SysTickName,
            this.toolStripSeparator_SysTickName,
            this.toolStripLabel_SysTick,
            this.toolStripSeparator_SysTick});
			this.toolStrip_BottomMenu.Location = new System.Drawing.Point(0, 636);
			this.toolStrip_BottomMenu.Name = "toolStrip_BottomMenu";
			this.toolStrip_BottomMenu.Size = new System.Drawing.Size(813, 25);
			this.toolStrip_BottomMenu.TabIndex = 3;
			this.toolStrip_BottomMenu.Text = "底部状态栏";
			// 
			// toolStripLabel_SysTickName
			// 
			this.toolStripLabel_SysTickName.Name = "toolStripLabel_SysTickName";
			this.toolStripLabel_SysTickName.Size = new System.Drawing.Size(56, 22);
			this.toolStripLabel_SysTickName.Text = "当前时间";
			// 
			// toolStripSeparator_SysTickName
			// 
			this.toolStripSeparator_SysTickName.Name = "toolStripSeparator_SysTickName";
			this.toolStripSeparator_SysTickName.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripLabel_SysTick
			// 
			this.toolStripLabel_SysTick.Name = "toolStripLabel_SysTick";
			this.toolStripLabel_SysTick.Size = new System.Drawing.Size(119, 22);
			this.toolStripLabel_SysTick.Text = "2018/8/30 00:00:00";
			// 
			// toolStripSeparator_SysTick
			// 
			this.toolStripSeparator_SysTick.Name = "toolStripSeparator_SysTick";
			this.toolStripSeparator_SysTick.Size = new System.Drawing.Size(6, 25);
			// 
			// timer_SysTick
			// 
			this.timer_SysTick.Enabled = true;
			this.timer_SysTick.Interval = 1000;
			// 
			// tabControl_FuncMenu
			// 
			this.tabControl_FuncMenu.Controls.Add(this.tabPage_Func);
			this.tabControl_FuncMenu.Controls.Add(this.tabPage_Chart);
			this.tabControl_FuncMenu.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl_FuncMenu.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.tabControl_FuncMenu.ItemSize = new System.Drawing.Size(80, 20);
			this.tabControl_FuncMenu.Location = new System.Drawing.Point(0, 1);
			this.tabControl_FuncMenu.Name = "tabControl_FuncMenu";
			this.tabControl_FuncMenu.Padding = new System.Drawing.Point(82, 2);
			this.tabControl_FuncMenu.SelectedIndex = 0;
			this.tabControl_FuncMenu.Size = new System.Drawing.Size(813, 635);
			this.tabControl_FuncMenu.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.tabControl_FuncMenu.TabIndex = 4;
			// 
			// tabPage_Func
			// 
			this.tabPage_Func.BackColor = System.Drawing.Color.Transparent;
			this.tabPage_Func.Controls.Add(this.richTextBoxEx_msg);
			this.tabPage_Func.Controls.Add(this.preFreqControl_preFreq);
			this.tabPage_Func.Controls.Add(this.deviceTypeControl_deviceType);
			this.tabPage_Func.Controls.Add(this.freqCurrentControl_freqCurrentPointTwo);
			this.tabPage_Func.Controls.Add(this.freqCurrentControl_freqCurrentPointOne);
			this.tabPage_Func.Controls.Add(this.clockRateControl_clockRate);
			this.tabPage_Func.Controls.Add(this.commPortControl_commPort);
			this.tabPage_Func.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.tabPage_Func.Location = new System.Drawing.Point(4, 24);
			this.tabPage_Func.Name = "tabPage_Func";
			this.tabPage_Func.Size = new System.Drawing.Size(805, 607);
			this.tabPage_Func.TabIndex = 0;
			this.tabPage_Func.Text = "功能参数";
			// 
			// richTextBoxEx_msg
			// 
			this.richTextBoxEx_msg.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.richTextBoxEx_msg.Location = new System.Drawing.Point(0, 408);
			this.richTextBoxEx_msg.Name = "richTextBoxEx_msg";
			this.richTextBoxEx_msg.Size = new System.Drawing.Size(805, 199);
			this.richTextBoxEx_msg.TabIndex = 9;
			this.richTextBoxEx_msg.Text = "";
			// 
			// preFreqControl_preFreq
			// 
			this.preFreqControl_preFreq.Location = new System.Drawing.Point(4, 276);
			this.preFreqControl_preFreq.m_Enabled = true;
			this.preFreqControl_preFreq.m_FuncName = "预设频率";
			this.preFreqControl_preFreq.m_PreFreqFour = 205F;
			this.preFreqControl_preFreq.m_PreFreqIndex = 5;
			this.preFreqControl_preFreq.m_PreFreqOne = 512F;
			this.preFreqControl_preFreq.m_PreFreqThree = 315F;
			this.preFreqControl_preFreq.m_PreFreqTwo = 433.92F;
			this.preFreqControl_preFreq.MaximumSize = new System.Drawing.Size(258, 129);
			this.preFreqControl_preFreq.MinimumSize = new System.Drawing.Size(258, 129);
			this.preFreqControl_preFreq.Name = "preFreqControl_preFreq";
			this.preFreqControl_preFreq.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.preFreqControl_preFreq.Size = new System.Drawing.Size(258, 129);
			this.preFreqControl_preFreq.TabIndex = 8;
			// 
			// deviceTypeControl_deviceType
			// 
			this.deviceTypeControl_deviceType.Location = new System.Drawing.Point(3, 167);
			this.deviceTypeControl_deviceType.m_AmpTimes = 100F;
			this.deviceTypeControl_deviceType.m_DeviceType = "SYN4XXR";
			this.deviceTypeControl_deviceType.m_Enabled = true;
			this.deviceTypeControl_deviceType.m_FuncName = "器件参数";
			this.deviceTypeControl_deviceType.m_SampleRes = 0F;
			this.deviceTypeControl_deviceType.MaximumSize = new System.Drawing.Size(258, 103);
			this.deviceTypeControl_deviceType.MinimumSize = new System.Drawing.Size(258, 103);
			this.deviceTypeControl_deviceType.Name = "deviceTypeControl_deviceType";
			this.deviceTypeControl_deviceType.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.deviceTypeControl_deviceType.Size = new System.Drawing.Size(258, 103);
			this.deviceTypeControl_deviceType.TabIndex = 7;
			// 
			// freqCurrentControl_freqCurrentPointTwo
			// 
			this.freqCurrentControl_freqCurrentPointTwo.Location = new System.Drawing.Point(538, 3);
			this.freqCurrentControl_freqCurrentPointTwo.m_Enabled = true;
			this.freqCurrentControl_freqCurrentPointTwo.m_FreqCurrentPointMaxNum = 200;
			this.freqCurrentControl_freqCurrentPointTwo.m_FuncName = "高压低频参数配置";
			this.freqCurrentControl_freqCurrentPointTwo.m_PassSpacePointMax = 1;
			this.freqCurrentControl_freqCurrentPointTwo.m_PassSpacePointMin = 1;
			this.freqCurrentControl_freqCurrentPointTwo.m_PassSpacePointNum = 1;
			this.freqCurrentControl_freqCurrentPointTwo.m_StartFreq = 400F;
			this.freqCurrentControl_freqCurrentPointTwo.m_StartPassMax = 1F;
			this.freqCurrentControl_freqCurrentPointTwo.m_StartPassMin = 1F;
			this.freqCurrentControl_freqCurrentPointTwo.m_StepFreq = 2F;
			this.freqCurrentControl_freqCurrentPointTwo.m_StepPointNum = 100;
			this.freqCurrentControl_freqCurrentPointTwo.m_StopPassMax = 1F;
			this.freqCurrentControl_freqCurrentPointTwo.m_StopPassMin = 1F;
			this.freqCurrentControl_freqCurrentPointTwo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.freqCurrentControl_freqCurrentPointTwo.MaximumSize = new System.Drawing.Size(264, 402);
			this.freqCurrentControl_freqCurrentPointTwo.MinimumSize = new System.Drawing.Size(264, 402);
			this.freqCurrentControl_freqCurrentPointTwo.Name = "freqCurrentControl_freqCurrentPointTwo";
			this.freqCurrentControl_freqCurrentPointTwo.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.freqCurrentControl_freqCurrentPointTwo.Size = new System.Drawing.Size(264, 402);
			this.freqCurrentControl_freqCurrentPointTwo.TabIndex = 6;
			// 
			// freqCurrentControl_freqCurrentPointOne
			// 
			this.freqCurrentControl_freqCurrentPointOne.Location = new System.Drawing.Point(268, 3);
			this.freqCurrentControl_freqCurrentPointOne.m_Enabled = true;
			this.freqCurrentControl_freqCurrentPointOne.m_FreqCurrentPointMaxNum = 200;
			this.freqCurrentControl_freqCurrentPointOne.m_FuncName = "低压高频参数配置";
			this.freqCurrentControl_freqCurrentPointOne.m_PassSpacePointMax = 1;
			this.freqCurrentControl_freqCurrentPointOne.m_PassSpacePointMin = 1;
			this.freqCurrentControl_freqCurrentPointOne.m_PassSpacePointNum = 1;
			this.freqCurrentControl_freqCurrentPointOne.m_StartFreq = 200F;
			this.freqCurrentControl_freqCurrentPointOne.m_StartPassMax = 1F;
			this.freqCurrentControl_freqCurrentPointOne.m_StartPassMin = 1F;
			this.freqCurrentControl_freqCurrentPointOne.m_StepFreq = 2F;
			this.freqCurrentControl_freqCurrentPointOne.m_StepPointNum = 100;
			this.freqCurrentControl_freqCurrentPointOne.m_StopPassMax = 1F;
			this.freqCurrentControl_freqCurrentPointOne.m_StopPassMin = 1F;
			this.freqCurrentControl_freqCurrentPointOne.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.freqCurrentControl_freqCurrentPointOne.MaximumSize = new System.Drawing.Size(264, 402);
			this.freqCurrentControl_freqCurrentPointOne.MinimumSize = new System.Drawing.Size(264, 402);
			this.freqCurrentControl_freqCurrentPointOne.Name = "freqCurrentControl_freqCurrentPointOne";
			this.freqCurrentControl_freqCurrentPointOne.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.freqCurrentControl_freqCurrentPointOne.Size = new System.Drawing.Size(264, 402);
			this.freqCurrentControl_freqCurrentPointOne.TabIndex = 5;
			// 
			// clockRateControl_clockRate
			// 
			this.clockRateControl_clockRate.Location = new System.Drawing.Point(4, 61);
			this.clockRateControl_clockRate.m_ClockRate = 20000;
			this.clockRateControl_clockRate.m_ClockRateMin = 20000;
			this.clockRateControl_clockRate.m_Enabled = true;
			this.clockRateControl_clockRate.m_FuncName = "时钟WM8510";
			this.clockRateControl_clockRate.Name = "clockRateControl_clockRate";
			this.clockRateControl_clockRate.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.clockRateControl_clockRate.Size = new System.Drawing.Size(258, 86);
			this.clockRateControl_clockRate.TabIndex = 4;
			// 
			// commPortControl_commPort
			// 
			this.commPortControl_commPort.Location = new System.Drawing.Point(2, 2);
			this.commPortControl_commPort.Margin = new System.Windows.Forms.Padding(2);
			this.commPortControl_commPort.Name = "commPortControl_commPort";
			this.commPortControl_commPort.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.commPortControl_commPort.Size = new System.Drawing.Size(260, 54);
			this.commPortControl_commPort.TabIndex = 0;
			// 
			// tabPage_Chart
			// 
			this.tabPage_Chart.BackColor = System.Drawing.Color.Transparent;
			this.tabPage_Chart.Controls.Add(this.button_stopMonitorData);
			this.tabPage_Chart.Controls.Add(this.button_startMonitorData);
			this.tabPage_Chart.Controls.Add(this.myChart_freqCurrent);
			this.tabPage_Chart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.tabPage_Chart.ForeColor = System.Drawing.Color.LightGray;
			this.tabPage_Chart.Location = new System.Drawing.Point(4, 24);
			this.tabPage_Chart.Name = "tabPage_Chart";
			this.tabPage_Chart.Size = new System.Drawing.Size(805, 607);
			this.tabPage_Chart.TabIndex = 1;
			this.tabPage_Chart.Text = "波形曲线";
			// 
			// myChart_freqCurrent
			// 
			this.myChart_freqCurrent.Dock = System.Windows.Forms.DockStyle.Left;
			this.myChart_freqCurrent.Location = new System.Drawing.Point(0, 0);
			this.myChart_freqCurrent.m_Title = "测试数据";
			this.myChart_freqCurrent.m_XAxisTitle = "频率MHz";
			this.myChart_freqCurrent.m_YAxisTitle = "电流uA";
			this.myChart_freqCurrent.Name = "myChart_freqCurrent";
			this.myChart_freqCurrent.Size = new System.Drawing.Size(721, 607);
			this.myChart_freqCurrent.TabIndex = 0;
			// 
			// button_startMonitorData
			// 
			this.button_startMonitorData.ForeColor = System.Drawing.Color.Black;
			this.button_startMonitorData.Location = new System.Drawing.Point(727, 16);
			this.button_startMonitorData.Name = "button_startMonitorData";
			this.button_startMonitorData.Size = new System.Drawing.Size(75, 26);
			this.button_startMonitorData.TabIndex = 1;
			this.button_startMonitorData.Text = "开始监控";
			this.button_startMonitorData.UseVisualStyleBackColor = true;
			// 
			// button_stopMonitorData
			// 
			this.button_stopMonitorData.ForeColor = System.Drawing.Color.Black;
			this.button_stopMonitorData.Location = new System.Drawing.Point(727, 48);
			this.button_stopMonitorData.Name = "button_stopMonitorData";
			this.button_stopMonitorData.Size = new System.Drawing.Size(75, 26);
			this.button_stopMonitorData.TabIndex = 2;
			this.button_stopMonitorData.Text = "停止监控";
			this.button_stopMonitorData.UseVisualStyleBackColor = true;
			// 
			// RFASKFreqCurrentForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(813, 661);
			this.Controls.Add(this.tabControl_FuncMenu);
			this.Controls.Add(this.toolStrip_BottomMenu);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Name = "RFASKFreqCurrentForm";
			this.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ASK频率电流扫描";
			this.toolStrip_BottomMenu.ResumeLayout(false);
			this.toolStrip_BottomMenu.PerformLayout();
			this.tabControl_FuncMenu.ResumeLayout(false);
			this.tabPage_Func.ResumeLayout(false);
			this.tabPage_Chart.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip_BottomMenu;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_SysTickName;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator_SysTickName;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_SysTick;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator_SysTick;
        private System.Windows.Forms.Timer timer_SysTick;
        private System.Windows.Forms.TabControl tabControl_FuncMenu;
        private System.Windows.Forms.TabPage tabPage_Func;
        private System.Windows.Forms.TabPage tabPage_Chart;
        private COMMPortLib.COMMPortControl commPortControl_commPort;
        private UserControlPlusLib.FreqCurrentControl freqCurrentControl_freqCurrentPointTwo;
        private UserControlPlusLib.FreqCurrentControl freqCurrentControl_freqCurrentPointOne;
        private UserControlPlusLib.ClockRateControl clockRateControl_clockRate;
        private UserControlPlusLib.DeviceTypeControl deviceTypeControl_deviceType;
        private UserControlPlusLib.PreFreqControl preFreqControl_preFreq;
        private RichTextBoxPlusLib.RichTextBoxEx richTextBoxEx_msg;
		private UserControlPlusLib.MyChart.MyChart myChart_freqCurrent;
		private System.Windows.Forms.Button button_stopMonitorData;
		private System.Windows.Forms.Button button_startMonitorData;
	}
}

