namespace SerialPortDemo
{
    partial class SerialPortForm
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
			this.tabControl_FuncMenu = new System.Windows.Forms.TabControl();
			this.tabPage_SerialPort = new System.Windows.Forms.TabPage();
			this.panel_serialPort = new System.Windows.Forms.Panel();
			this.tabControl_FuncSendMemu = new System.Windows.Forms.TabControl();
			this.tabPage_sendData = new System.Windows.Forms.TabPage();
			this.panel_tx = new System.Windows.Forms.Panel();
			this.groupBox_rx = new System.Windows.Forms.GroupBox();
			this.serialPortControl = new COMMPortLib.SerialPortControl();
			this.toolStrip_BottomMenu = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel_SysTickName = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator_SysTickName = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel_SysTick = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator_SysTick = new System.Windows.Forms.ToolStripSeparator();
			this.tabControl_FuncMenu.SuspendLayout();
			this.tabPage_SerialPort.SuspendLayout();
			this.panel_serialPort.SuspendLayout();
			this.tabControl_FuncSendMemu.SuspendLayout();
			this.tabPage_sendData.SuspendLayout();
			this.toolStrip_BottomMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl_FuncMenu
			// 
			this.tabControl_FuncMenu.Controls.Add(this.tabPage_SerialPort);
			this.tabControl_FuncMenu.Cursor = System.Windows.Forms.Cursors.Default;
			this.tabControl_FuncMenu.Dock = System.Windows.Forms.DockStyle.Top;
			this.tabControl_FuncMenu.Location = new System.Drawing.Point(0, 0);
			this.tabControl_FuncMenu.Name = "tabControl_FuncMenu";
			this.tabControl_FuncMenu.Padding = new System.Drawing.Point(4, 4);
			this.tabControl_FuncMenu.SelectedIndex = 0;
			this.tabControl_FuncMenu.Size = new System.Drawing.Size(729, 504);
			this.tabControl_FuncMenu.TabIndex = 0;
			// 
			// tabPage_SerialPort
			// 
			this.tabPage_SerialPort.Controls.Add(this.panel_serialPort);
			this.tabPage_SerialPort.Location = new System.Drawing.Point(4, 24);
			this.tabPage_SerialPort.Margin = new System.Windows.Forms.Padding(1);
			this.tabPage_SerialPort.Name = "tabPage_SerialPort";
			this.tabPage_SerialPort.Size = new System.Drawing.Size(721, 476);
			this.tabPage_SerialPort.TabIndex = 0;
			this.tabPage_SerialPort.Text = "串口调试助手";
			this.tabPage_SerialPort.UseVisualStyleBackColor = true;
			// 
			// panel_serialPort
			// 
			this.panel_serialPort.Controls.Add(this.tabControl_FuncSendMemu);
			this.panel_serialPort.Controls.Add(this.groupBox_rx);
			this.panel_serialPort.Controls.Add(this.serialPortControl);
			this.panel_serialPort.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_serialPort.Location = new System.Drawing.Point(0, 0);
			this.panel_serialPort.Margin = new System.Windows.Forms.Padding(2);
			this.panel_serialPort.Name = "panel_serialPort";
			this.panel_serialPort.Size = new System.Drawing.Size(721, 476);
			this.panel_serialPort.TabIndex = 0;
			// 
			// tabControl_FuncSendMemu
			// 
			this.tabControl_FuncSendMemu.Controls.Add(this.tabPage_sendData);
			this.tabControl_FuncSendMemu.Cursor = System.Windows.Forms.Cursors.Default;
			this.tabControl_FuncSendMemu.Location = new System.Drawing.Point(3, 298);
			this.tabControl_FuncSendMemu.Name = "tabControl_FuncSendMemu";
			this.tabControl_FuncSendMemu.Padding = new System.Drawing.Point(4, 4);
			this.tabControl_FuncSendMemu.SelectedIndex = 0;
			this.tabControl_FuncSendMemu.Size = new System.Drawing.Size(539, 175);
			this.tabControl_FuncSendMemu.TabIndex = 3;
			// 
			// tabPage_sendData
			// 
			this.tabPage_sendData.Controls.Add(this.panel_tx);
			this.tabPage_sendData.Location = new System.Drawing.Point(4, 24);
			this.tabPage_sendData.Margin = new System.Windows.Forms.Padding(1);
			this.tabPage_sendData.Name = "tabPage_sendData";
			this.tabPage_sendData.Size = new System.Drawing.Size(531, 147);
			this.tabPage_sendData.TabIndex = 0;
			this.tabPage_sendData.Text = "数据发送";
			this.tabPage_sendData.UseVisualStyleBackColor = true;
			// 
			// panel_tx
			// 
			this.panel_tx.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_tx.Location = new System.Drawing.Point(0, 0);
			this.panel_tx.Margin = new System.Windows.Forms.Padding(2);
			this.panel_tx.Name = "panel_tx";
			this.panel_tx.Size = new System.Drawing.Size(531, 147);
			this.panel_tx.TabIndex = 0;
			// 
			// groupBox_rx
			// 
			this.groupBox_rx.Location = new System.Drawing.Point(7, 3);
			this.groupBox_rx.Name = "groupBox_rx";
			this.groupBox_rx.Size = new System.Drawing.Size(535, 289);
			this.groupBox_rx.TabIndex = 1;
			this.groupBox_rx.TabStop = false;
			this.groupBox_rx.Text = "数据接收";
			// 
			// serialPortControl
			// 
			this.serialPortControl.Location = new System.Drawing.Point(547, 1);
			this.serialPortControl.Margin = new System.Windows.Forms.Padding(2);
			this.serialPortControl.Name = "serialPortControl";
			this.serialPortControl.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.serialPortControl.Size = new System.Drawing.Size(157, 191);
			this.serialPortControl.TabIndex = 0;
			// 
			// toolStrip_BottomMenu
			// 
			this.toolStrip_BottomMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.toolStrip_BottomMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_SysTickName,
            this.toolStripSeparator_SysTickName,
            this.toolStripLabel_SysTick,
            this.toolStripSeparator_SysTick});
			this.toolStrip_BottomMenu.Location = new System.Drawing.Point(0, 473);
			this.toolStrip_BottomMenu.Name = "toolStrip_BottomMenu";
			this.toolStrip_BottomMenu.Size = new System.Drawing.Size(729, 25);
			this.toolStrip_BottomMenu.TabIndex = 4;
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
			// SerialPortForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(729, 498);
			this.Controls.Add(this.toolStrip_BottomMenu);
			this.Controls.Add(this.tabControl_FuncMenu);
			this.DoubleBuffered = true;
			this.Name = "SerialPortForm";
			this.Text = "调试助手";
			this.Load += new System.EventHandler(this.SerialPortForm_Load);
			this.tabControl_FuncMenu.ResumeLayout(false);
			this.tabPage_SerialPort.ResumeLayout(false);
			this.panel_serialPort.ResumeLayout(false);
			this.tabControl_FuncSendMemu.ResumeLayout(false);
			this.tabPage_sendData.ResumeLayout(false);
			this.toolStrip_BottomMenu.ResumeLayout(false);
			this.toolStrip_BottomMenu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_FuncMenu;
        private System.Windows.Forms.TabPage tabPage_SerialPort;
        private System.Windows.Forms.Panel panel_serialPort;
        private COMMPortLib.SerialPortControl serialPortControl;
        private System.Windows.Forms.GroupBox groupBox_rx;
        private RichTextBoxPlusLib.RichTextBoxEx richTextBoxEx_rx;
        private System.Windows.Forms.ToolStrip toolStrip_BottomMenu;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_SysTickName;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator_SysTickName;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_SysTick;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator_SysTick;
        private System.Windows.Forms.TabControl tabControl_FuncSendMemu;
        private System.Windows.Forms.TabPage tabPage_sendData;
        private System.Windows.Forms.Panel panel_tx;
        private RichTextBoxPlusLib.RichTextBoxEx richTextBoxEx_tx;
    }
}

