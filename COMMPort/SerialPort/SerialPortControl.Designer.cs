namespace COMMPortLib
{
	partial class SerialPortControl
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
            this.components = new System.ComponentModel.Container();
            this.groupBox_portName = new System.Windows.Forms.GroupBox();
            this.panel_PortName = new System.Windows.Forms.Panel();
            this.label_portParityBits = new System.Windows.Forms.Label();
            this.comboBox_portParityBits = new System.Windows.Forms.ComboBox();
            this.label_portStopBits = new System.Windows.Forms.Label();
            this.comboBox_portStopBits = new System.Windows.Forms.ComboBox();
            this.label_portDataBits = new System.Windows.Forms.Label();
            this.comboBox_portDataBits = new System.Windows.Forms.ComboBox();
            this.label_portBaudRate = new System.Windows.Forms.Label();
            this.comboBox_portBaudRate = new System.Windows.Forms.ComboBox();
            this.pictureBox_portState = new System.Windows.Forms.PictureBox();
            this.button_initDevice = new System.Windows.Forms.Button();
            this.label_portName = new System.Windows.Forms.Label();
            this.comboBox_portName = new System.Windows.Forms.ComboBox();
            this.toolTip_msg = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox_portName.SuspendLayout();
            this.panel_PortName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_portState)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_portName
            // 
            this.groupBox_portName.Controls.Add(this.panel_PortName);
            this.groupBox_portName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_portName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox_portName.Location = new System.Drawing.Point(0, 2);
            this.groupBox_portName.Name = "groupBox_portName";
            this.groupBox_portName.Size = new System.Drawing.Size(157, 189);
            this.groupBox_portName.TabIndex = 6;
            this.groupBox_portName.TabStop = false;
            this.groupBox_portName.Text = "通信端口";
            // 
            // panel_PortName
            // 
            this.panel_PortName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_PortName.Controls.Add(this.label_portParityBits);
            this.panel_PortName.Controls.Add(this.comboBox_portParityBits);
            this.panel_PortName.Controls.Add(this.label_portStopBits);
            this.panel_PortName.Controls.Add(this.comboBox_portStopBits);
            this.panel_PortName.Controls.Add(this.label_portDataBits);
            this.panel_PortName.Controls.Add(this.comboBox_portDataBits);
            this.panel_PortName.Controls.Add(this.label_portBaudRate);
            this.panel_PortName.Controls.Add(this.comboBox_portBaudRate);
            this.panel_PortName.Controls.Add(this.pictureBox_portState);
            this.panel_PortName.Controls.Add(this.button_initDevice);
            this.panel_PortName.Controls.Add(this.label_portName);
            this.panel_PortName.Controls.Add(this.comboBox_portName);
            this.panel_PortName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_PortName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel_PortName.Location = new System.Drawing.Point(3, 17);
            this.panel_PortName.Name = "panel_PortName";
            this.panel_PortName.Size = new System.Drawing.Size(151, 169);
            this.panel_PortName.TabIndex = 1;
            // 
            // label_portParityBits
            // 
            this.label_portParityBits.AutoSize = true;
            this.label_portParityBits.Location = new System.Drawing.Point(3, 116);
            this.label_portParityBits.Name = "label_portParityBits";
            this.label_portParityBits.Size = new System.Drawing.Size(47, 12);
            this.label_portParityBits.TabIndex = 11;
            this.label_portParityBits.Text = "校验位:";
            // 
            // comboBox_portParityBits
            // 
            this.comboBox_portParityBits.FormattingEnabled = true;
            this.comboBox_portParityBits.Items.AddRange(new object[] {
            "无",
            "奇校验",
            "偶校验"});
            this.comboBox_portParityBits.Location = new System.Drawing.Point(56, 113);
            this.comboBox_portParityBits.Name = "comboBox_portParityBits";
            this.comboBox_portParityBits.Size = new System.Drawing.Size(83, 20);
            this.comboBox_portParityBits.TabIndex = 10;
            this.comboBox_portParityBits.Text = "无";
            // 
            // label_portStopBits
            // 
            this.label_portStopBits.AutoSize = true;
            this.label_portStopBits.Location = new System.Drawing.Point(3, 90);
            this.label_portStopBits.Name = "label_portStopBits";
            this.label_portStopBits.Size = new System.Drawing.Size(47, 12);
            this.label_portStopBits.TabIndex = 9;
            this.label_portStopBits.Text = "停止位:";
            // 
            // comboBox_portStopBits
            // 
            this.comboBox_portStopBits.FormattingEnabled = true;
            this.comboBox_portStopBits.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.comboBox_portStopBits.Location = new System.Drawing.Point(56, 87);
            this.comboBox_portStopBits.Name = "comboBox_portStopBits";
            this.comboBox_portStopBits.Size = new System.Drawing.Size(83, 20);
            this.comboBox_portStopBits.TabIndex = 8;
            this.comboBox_portStopBits.Text = "1";
            // 
            // label_portDataBits
            // 
            this.label_portDataBits.AutoSize = true;
            this.label_portDataBits.Location = new System.Drawing.Point(3, 64);
            this.label_portDataBits.Name = "label_portDataBits";
            this.label_portDataBits.Size = new System.Drawing.Size(47, 12);
            this.label_portDataBits.TabIndex = 7;
            this.label_portDataBits.Text = "数据位:";
            // 
            // comboBox_portDataBits
            // 
            this.comboBox_portDataBits.FormattingEnabled = true;
            this.comboBox_portDataBits.Items.AddRange(new object[] {
            "9",
            "8",
            "7",
            "6",
            "5"});
            this.comboBox_portDataBits.Location = new System.Drawing.Point(56, 61);
            this.comboBox_portDataBits.Name = "comboBox_portDataBits";
            this.comboBox_portDataBits.Size = new System.Drawing.Size(83, 20);
            this.comboBox_portDataBits.TabIndex = 6;
            this.comboBox_portDataBits.Text = "8";
            // 
            // label_portBaudRate
            // 
            this.label_portBaudRate.AutoSize = true;
            this.label_portBaudRate.Location = new System.Drawing.Point(3, 38);
            this.label_portBaudRate.Name = "label_portBaudRate";
            this.label_portBaudRate.Size = new System.Drawing.Size(47, 12);
            this.label_portBaudRate.TabIndex = 5;
            this.label_portBaudRate.Text = "波特率:";
            // 
            // comboBox_portBaudRate
            // 
            this.comboBox_portBaudRate.FormattingEnabled = true;
            this.comboBox_portBaudRate.Items.AddRange(new object[] {
            "自定义",
            "115200",
            "76800",
            "57600",
            "38400",
            "19200",
            "14400",
            "9600",
            "4800",
            "2400",
            "1200"});
            this.comboBox_portBaudRate.Location = new System.Drawing.Point(56, 35);
            this.comboBox_portBaudRate.Name = "comboBox_portBaudRate";
            this.comboBox_portBaudRate.Size = new System.Drawing.Size(83, 20);
            this.comboBox_portBaudRate.TabIndex = 4;
            this.comboBox_portBaudRate.Text = "115200";
            // 
            // pictureBox_portState
            // 
            this.pictureBox_portState.Image = global::COMMPortLib.Properties.Resources.lost;
            this.pictureBox_portState.Location = new System.Drawing.Point(25, 139);
            this.pictureBox_portState.Name = "pictureBox_portState";
            this.pictureBox_portState.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_portState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_portState.TabIndex = 3;
            this.pictureBox_portState.TabStop = false;
            this.pictureBox_portState.Tag = "1";
            // 
            // button_initDevice
            // 
            this.button_initDevice.Location = new System.Drawing.Point(56, 139);
            this.button_initDevice.Name = "button_initDevice";
            this.button_initDevice.Size = new System.Drawing.Size(83, 25);
            this.button_initDevice.TabIndex = 2;
            this.button_initDevice.Text = "打开端口";
            this.button_initDevice.UseVisualStyleBackColor = true;
            // 
            // label_portName
            // 
            this.label_portName.AutoSize = true;
            this.label_portName.Location = new System.Drawing.Point(3, 13);
            this.label_portName.Name = "label_portName";
            this.label_portName.Size = new System.Drawing.Size(47, 12);
            this.label_portName.TabIndex = 1;
            this.label_portName.Text = "端口号:";
            // 
            // comboBox_portName
            // 
            this.comboBox_portName.FormattingEnabled = true;
            this.comboBox_portName.Location = new System.Drawing.Point(56, 10);
            this.comboBox_portName.Name = "comboBox_portName";
            this.comboBox_portName.Size = new System.Drawing.Size(83, 20);
            this.comboBox_portName.TabIndex = 0;
            // 
            // SerialPortControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox_portName);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SerialPortControl";
            this.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.Size = new System.Drawing.Size(157, 191);
            this.groupBox_portName.ResumeLayout(false);
            this.panel_PortName.ResumeLayout(false);
            this.panel_PortName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_portState)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox_portName;
		private System.Windows.Forms.Panel panel_PortName;
		private System.Windows.Forms.PictureBox pictureBox_portState;
		private System.Windows.Forms.Button button_initDevice;
		private System.Windows.Forms.Label label_portName;
		private System.Windows.Forms.ComboBox comboBox_portName;
		private System.Windows.Forms.Label label_portParityBits;
		private System.Windows.Forms.ComboBox comboBox_portParityBits;
		private System.Windows.Forms.Label label_portStopBits;
		private System.Windows.Forms.ComboBox comboBox_portStopBits;
		private System.Windows.Forms.Label label_portDataBits;
		private System.Windows.Forms.ComboBox comboBox_portDataBits;
		private System.Windows.Forms.Label label_portBaudRate;
		private System.Windows.Forms.ComboBox comboBox_portBaudRate;
        private System.Windows.Forms.ToolTip toolTip_msg;
    }
}
