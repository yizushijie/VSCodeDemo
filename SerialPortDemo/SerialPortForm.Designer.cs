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
            this.serialPortControl1 = new COMMPortLib.SerialPortControl();
            this.tabControl_FuncMenu.SuspendLayout();
            this.tabPage_SerialPort.SuspendLayout();
            this.panel_serialPort.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_FuncMenu
            // 
            this.tabControl_FuncMenu.Controls.Add(this.tabPage_SerialPort);
            this.tabControl_FuncMenu.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabControl_FuncMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_FuncMenu.Location = new System.Drawing.Point(0, 0);
            this.tabControl_FuncMenu.Name = "tabControl_FuncMenu";
            this.tabControl_FuncMenu.Padding = new System.Drawing.Point(6, 8);
            this.tabControl_FuncMenu.SelectedIndex = 0;
            this.tabControl_FuncMenu.Size = new System.Drawing.Size(802, 499);
            this.tabControl_FuncMenu.TabIndex = 0;
            // 
            // tabPage_SerialPort
            // 
            this.tabPage_SerialPort.Controls.Add(this.panel_serialPort);
            this.tabPage_SerialPort.Location = new System.Drawing.Point(4, 32);
            this.tabPage_SerialPort.Margin = new System.Windows.Forms.Padding(1);
            this.tabPage_SerialPort.Name = "tabPage_SerialPort";
            this.tabPage_SerialPort.Size = new System.Drawing.Size(794, 463);
            this.tabPage_SerialPort.TabIndex = 0;
            this.tabPage_SerialPort.Text = "串口调试助手";
            this.tabPage_SerialPort.UseVisualStyleBackColor = true;
            // 
            // panel_serialPort
            // 
            this.panel_serialPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_serialPort.Controls.Add(this.serialPortControl1);
            this.panel_serialPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_serialPort.Location = new System.Drawing.Point(0, 0);
            this.panel_serialPort.Margin = new System.Windows.Forms.Padding(2);
            this.panel_serialPort.Name = "panel_serialPort";
            this.panel_serialPort.Size = new System.Drawing.Size(794, 463);
            this.panel_serialPort.TabIndex = 0;
            // 
            // serialPortControl1
            // 
            this.serialPortControl1.Location = new System.Drawing.Point(2, 2);
            this.serialPortControl1.Margin = new System.Windows.Forms.Padding(2);
            this.serialPortControl1.Name = "serialPortControl1";
            this.serialPortControl1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.serialPortControl1.Size = new System.Drawing.Size(157, 191);
            this.serialPortControl1.TabIndex = 0;
            // 
            // SerialPortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 499);
            this.Controls.Add(this.tabControl_FuncMenu);
            this.Name = "SerialPortForm";
            this.Text = "调试助手";
            this.tabControl_FuncMenu.ResumeLayout(false);
            this.tabPage_SerialPort.ResumeLayout(false);
            this.panel_serialPort.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_FuncMenu;
        private System.Windows.Forms.TabPage tabPage_SerialPort;
        private System.Windows.Forms.Panel panel_serialPort;
        private COMMPortLib.SerialPortControl serialPortControl1;
    }
}

