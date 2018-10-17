namespace COMMPortForm
{
	partial class COMMPort
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
			this.panel_PortName = new System.Windows.Forms.Panel();
			this.comboBox_portName = new System.Windows.Forms.ComboBox();
			this.label_portName = new System.Windows.Forms.Label();
			this.button_openDevice = new System.Windows.Forms.Button();
			this.pictureBox_portState = new System.Windows.Forms.PictureBox();
			this.groupBox_portName = new System.Windows.Forms.GroupBox();
			this.panel_PortName.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_portState)).BeginInit();
			this.groupBox_portName.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel_PortName
			// 
			this.panel_PortName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel_PortName.Controls.Add(this.pictureBox_portState);
			this.panel_PortName.Controls.Add(this.button_openDevice);
			this.panel_PortName.Controls.Add(this.label_portName);
			this.panel_PortName.Controls.Add(this.comboBox_portName);
			this.panel_PortName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_PortName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.panel_PortName.Location = new System.Drawing.Point(3, 17);
			this.panel_PortName.Name = "panel_PortName";
			this.panel_PortName.Size = new System.Drawing.Size(284, 46);
			this.panel_PortName.TabIndex = 1;
			// 
			// comboBox_portName
			// 
			this.comboBox_portName.FormattingEnabled = true;
			this.comboBox_portName.Location = new System.Drawing.Point(65, 11);
			this.comboBox_portName.Name = "comboBox_portName";
			this.comboBox_portName.Size = new System.Drawing.Size(98, 20);
			this.comboBox_portName.TabIndex = 0;
			// 
			// label_portName
			// 
			this.label_portName.AutoSize = true;
			this.label_portName.Location = new System.Drawing.Point(3, 14);
			this.label_portName.Name = "label_portName";
			this.label_portName.Size = new System.Drawing.Size(47, 12);
			this.label_portName.TabIndex = 1;
			this.label_portName.Text = "端口号:";
			// 
			// button_openDevice
			// 
			this.button_openDevice.Location = new System.Drawing.Point(200, 8);
			this.button_openDevice.Name = "button_openDevice";
			this.button_openDevice.Size = new System.Drawing.Size(74, 25);
			this.button_openDevice.TabIndex = 2;
			this.button_openDevice.Text = "打开端口";
			this.button_openDevice.UseVisualStyleBackColor = true;
			// 
			// pictureBox_portState
			// 
			this.pictureBox_portState.Image = global::COMMPortForm.Properties.Resources.lost;
			this.pictureBox_portState.Location = new System.Drawing.Point(169, 8);
			this.pictureBox_portState.Name = "pictureBox_portState";
			this.pictureBox_portState.Size = new System.Drawing.Size(25, 25);
			this.pictureBox_portState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox_portState.TabIndex = 3;
			this.pictureBox_portState.TabStop = false;
			this.pictureBox_portState.Tag = "1";
			// 
			// groupBox_portName
			// 
			this.groupBox_portName.Controls.Add(this.panel_PortName);
			this.groupBox_portName.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox_portName.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox_portName.Location = new System.Drawing.Point(0, 10);
			this.groupBox_portName.Name = "groupBox_portName";
			this.groupBox_portName.Size = new System.Drawing.Size(290, 66);
			this.groupBox_portName.TabIndex = 5;
			this.groupBox_portName.TabStop = false;
			this.groupBox_portName.Text = "通信端口";
			// 
			// COMMPort
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox_portName);
			this.Name = "COMMPort";
			this.Size = new System.Drawing.Size(290, 76);
			this.panel_PortName.ResumeLayout(false);
			this.panel_PortName.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_portState)).EndInit();
			this.groupBox_portName.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel_PortName;
		private System.Windows.Forms.PictureBox pictureBox_portState;
		private System.Windows.Forms.Button button_openDevice;
		private System.Windows.Forms.Label label_portName;
		private System.Windows.Forms.ComboBox comboBox_portName;
		private System.Windows.Forms.GroupBox groupBox_portName;
	}
}

