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
            this.tabPage_Chart = new System.Windows.Forms.TabPage();
            this.commPortControl1 = new COMMPortLib.COMMPortControl();
            this.preFreqControl1 = new UserControlPlusLib.FreqCurrent.PreFreqControl();
            this.deviceTypeControl1 = new UserControlPlusLib.DeviceType.DeviceTypeControl();
            this.freqCurrentControl2 = new UserControlPlusLib.FreqCurrent.FreqCurrentControl();
            this.freqCurrentControl1 = new UserControlPlusLib.FreqCurrent.FreqCurrentControl();
            this.clockRateControl1 = new UserControlPlusLib.ClockRate.ClockRateControl();
            this.richTextBoxEx1 = new RichTextBoxPlusLib.RichTextBoxEx();
            this.toolStrip_BottomMenu.SuspendLayout();
            this.tabControl_FuncMenu.SuspendLayout();
            this.tabPage_Func.SuspendLayout();
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
            this.tabPage_Func.Controls.Add(this.richTextBoxEx1);
            this.tabPage_Func.Controls.Add(this.preFreqControl1);
            this.tabPage_Func.Controls.Add(this.deviceTypeControl1);
            this.tabPage_Func.Controls.Add(this.freqCurrentControl2);
            this.tabPage_Func.Controls.Add(this.freqCurrentControl1);
            this.tabPage_Func.Controls.Add(this.clockRateControl1);
            this.tabPage_Func.Controls.Add(this.commPortControl1);
            this.tabPage_Func.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage_Func.Location = new System.Drawing.Point(4, 24);
            this.tabPage_Func.Name = "tabPage_Func";
            this.tabPage_Func.Size = new System.Drawing.Size(805, 607);
            this.tabPage_Func.TabIndex = 0;
            this.tabPage_Func.Text = "功能参数";
            // 
            // tabPage_Chart
            // 
            this.tabPage_Chart.BackColor = System.Drawing.Color.Transparent;
            this.tabPage_Chart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage_Chart.ForeColor = System.Drawing.Color.LightGray;
            this.tabPage_Chart.Location = new System.Drawing.Point(4, 24);
            this.tabPage_Chart.Name = "tabPage_Chart";
            this.tabPage_Chart.Size = new System.Drawing.Size(805, 607);
            this.tabPage_Chart.TabIndex = 1;
            this.tabPage_Chart.Text = "波形曲线";
            // 
            // commPortControl1
            // 
            this.commPortControl1.Location = new System.Drawing.Point(2, 2);
            this.commPortControl1.Margin = new System.Windows.Forms.Padding(2);
            this.commPortControl1.Name = "commPortControl1";
            this.commPortControl1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.commPortControl1.Size = new System.Drawing.Size(260, 54);
            this.commPortControl1.TabIndex = 0;
            // 
            // preFreqControl1
            // 
            this.preFreqControl1.Location = new System.Drawing.Point(4, 276);
            this.preFreqControl1.MaximumSize = new System.Drawing.Size(258, 129);
            this.preFreqControl1.MinimumSize = new System.Drawing.Size(258, 129);
            this.preFreqControl1.Name = "preFreqControl1";
            this.preFreqControl1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.preFreqControl1.Size = new System.Drawing.Size(258, 129);
            this.preFreqControl1.TabIndex = 8;
            // 
            // deviceTypeControl1
            // 
            this.deviceTypeControl1.Location = new System.Drawing.Point(3, 167);
            this.deviceTypeControl1.m_DeviceType = "SYN4XX";
            this.deviceTypeControl1.MaximumSize = new System.Drawing.Size(258, 103);
            this.deviceTypeControl1.MinimumSize = new System.Drawing.Size(258, 103);
            this.deviceTypeControl1.Name = "deviceTypeControl1";
            this.deviceTypeControl1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.deviceTypeControl1.Size = new System.Drawing.Size(258, 103);
            this.deviceTypeControl1.TabIndex = 7;
            // 
            // freqCurrentControl2
            // 
            this.freqCurrentControl2.Location = new System.Drawing.Point(538, 3);
            this.freqCurrentControl2.m_FuncName = "电压频率参数";
            this.freqCurrentControl2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.freqCurrentControl2.MaximumSize = new System.Drawing.Size(264, 402);
            this.freqCurrentControl2.MinimumSize = new System.Drawing.Size(264, 402);
            this.freqCurrentControl2.Name = "freqCurrentControl2";
            this.freqCurrentControl2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.freqCurrentControl2.Size = new System.Drawing.Size(264, 402);
            this.freqCurrentControl2.TabIndex = 6;
            // 
            // freqCurrentControl1
            // 
            this.freqCurrentControl1.Location = new System.Drawing.Point(268, 3);
            this.freqCurrentControl1.m_FuncName = "电压频率参数";
            this.freqCurrentControl1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.freqCurrentControl1.MaximumSize = new System.Drawing.Size(264, 402);
            this.freqCurrentControl1.MinimumSize = new System.Drawing.Size(264, 402);
            this.freqCurrentControl1.Name = "freqCurrentControl1";
            this.freqCurrentControl1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.freqCurrentControl1.Size = new System.Drawing.Size(264, 402);
            this.freqCurrentControl1.TabIndex = 5;
            // 
            // clockRateControl1
            // 
            this.clockRateControl1.Location = new System.Drawing.Point(4, 61);
            this.clockRateControl1.Name = "clockRateControl1";
            this.clockRateControl1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.clockRateControl1.Size = new System.Drawing.Size(258, 86);
            this.clockRateControl1.TabIndex = 4;
            // 
            // richTextBoxEx1
            // 
            this.richTextBoxEx1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richTextBoxEx1.Location = new System.Drawing.Point(0, 408);
            this.richTextBoxEx1.Name = "richTextBoxEx1";
            this.richTextBoxEx1.Size = new System.Drawing.Size(805, 199);
            this.richTextBoxEx1.TabIndex = 9;
            this.richTextBoxEx1.Text = "";
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
        private COMMPortLib.COMMPortControl commPortControl1;
        private UserControlPlusLib.FreqCurrent.FreqCurrentControl freqCurrentControl2;
        private UserControlPlusLib.FreqCurrent.FreqCurrentControl freqCurrentControl1;
        private UserControlPlusLib.ClockRate.ClockRateControl clockRateControl1;
        private UserControlPlusLib.DeviceType.DeviceTypeControl deviceTypeControl1;
        private UserControlPlusLib.FreqCurrent.PreFreqControl preFreqControl1;
        private RichTextBoxPlusLib.RichTextBoxEx richTextBoxEx1;
    }
}

