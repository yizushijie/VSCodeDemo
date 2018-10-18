namespace ControlPlusLib.ClockRate
{
	partial class ClockRateControl
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
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.button_setClockRate = new System.Windows.Forms.Button();
			this.label_Channel1 = new System.Windows.Forms.Label();
			this.label_Channel3 = new System.Windows.Forms.Label();
			this.label_Channel4 = new System.Windows.Forms.Label();
			this.label_Channel2 = new System.Windows.Forms.Label();
			this.label_clockRateUnite = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox_portName = new System.Windows.Forms.GroupBox();
			this.panel_PortName = new System.Windows.Forms.Panel();
			this.buttonCheckControl_Channel4 = new ControlPlusLib.ButtonCheckControl();
			this.buttonCheckControl_Channel3 = new ControlPlusLib.ButtonCheckControl();
			this.buttonCheckControl_Channel2 = new ControlPlusLib.ButtonCheckControl();
			this.buttonCheckControl_Channel1 = new ControlPlusLib.ButtonCheckControl();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.groupBox_portName.SuspendLayout();
			this.panel_PortName.SuspendLayout();
			this.SuspendLayout();
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(36, 5);
			this.numericUpDown1.Maximum = new decimal(new int[] {
            40000000,
            0,
            0,
            0});
			this.numericUpDown1.Minimum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(92, 21);
			this.numericUpDown1.TabIndex = 1;
			this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDown1.ThousandsSeparator = true;
			this.numericUpDown1.Value = new decimal(new int[] {
            20000,
            0,
            0,
            0});
			// 
			// button_setClockRate
			// 
			this.button_setClockRate.Location = new System.Drawing.Point(155, 3);
			this.button_setClockRate.Name = "button_setClockRate";
			this.button_setClockRate.Size = new System.Drawing.Size(44, 23);
			this.button_setClockRate.TabIndex = 2;
			this.button_setClockRate.Text = "设置";
			this.button_setClockRate.UseVisualStyleBackColor = true;
			// 
			// label_Channel1
			// 
			this.label_Channel1.AutoSize = true;
			this.label_Channel1.Location = new System.Drawing.Point(5, 33);
			this.label_Channel1.Name = "label_Channel1";
			this.label_Channel1.Size = new System.Drawing.Size(35, 12);
			this.label_Channel1.TabIndex = 4;
			this.label_Channel1.Text = "通道1";
			// 
			// label_Channel3
			// 
			this.label_Channel3.AutoSize = true;
			this.label_Channel3.Location = new System.Drawing.Point(105, 33);
			this.label_Channel3.Name = "label_Channel3";
			this.label_Channel3.Size = new System.Drawing.Size(35, 12);
			this.label_Channel3.TabIndex = 6;
			this.label_Channel3.Text = "通道3";
			// 
			// label_Channel4
			// 
			this.label_Channel4.AutoSize = true;
			this.label_Channel4.Location = new System.Drawing.Point(155, 33);
			this.label_Channel4.Name = "label_Channel4";
			this.label_Channel4.Size = new System.Drawing.Size(35, 12);
			this.label_Channel4.TabIndex = 8;
			this.label_Channel4.Text = "通道4";
			// 
			// label_Channel2
			// 
			this.label_Channel2.AutoSize = true;
			this.label_Channel2.Location = new System.Drawing.Point(55, 33);
			this.label_Channel2.Name = "label_Channel2";
			this.label_Channel2.Size = new System.Drawing.Size(35, 12);
			this.label_Channel2.TabIndex = 10;
			this.label_Channel2.Text = "通道2";
			// 
			// label_clockRateUnite
			// 
			this.label_clockRateUnite.AutoSize = true;
			this.label_clockRateUnite.Location = new System.Drawing.Point(134, 10);
			this.label_clockRateUnite.Name = "label_clockRateUnite";
			this.label_clockRateUnite.Size = new System.Drawing.Size(17, 12);
			this.label_clockRateUnite.TabIndex = 3;
			this.label_clockRateUnite.Text = "Hz";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 10);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(29, 12);
			this.label4.TabIndex = 15;
			this.label4.Text = "频率";
			// 
			// groupBox_portName
			// 
			this.groupBox_portName.Controls.Add(this.panel_PortName);
			this.groupBox_portName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox_portName.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox_portName.Location = new System.Drawing.Point(0, 2);
			this.groupBox_portName.Name = "groupBox_portName";
			this.groupBox_portName.Size = new System.Drawing.Size(215, 88);
			this.groupBox_portName.TabIndex = 16;
			this.groupBox_portName.TabStop = false;
			this.groupBox_portName.Text = "时钟设置";
			// 
			// panel_PortName
			// 
			this.panel_PortName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel_PortName.Controls.Add(this.button_setClockRate);
			this.panel_PortName.Controls.Add(this.label4);
			this.panel_PortName.Controls.Add(this.numericUpDown1);
			this.panel_PortName.Controls.Add(this.buttonCheckControl_Channel4);
			this.panel_PortName.Controls.Add(this.label_clockRateUnite);
			this.panel_PortName.Controls.Add(this.buttonCheckControl_Channel3);
			this.panel_PortName.Controls.Add(this.label_Channel1);
			this.panel_PortName.Controls.Add(this.buttonCheckControl_Channel2);
			this.panel_PortName.Controls.Add(this.label_Channel3);
			this.panel_PortName.Controls.Add(this.buttonCheckControl_Channel1);
			this.panel_PortName.Controls.Add(this.label_Channel4);
			this.panel_PortName.Controls.Add(this.label_Channel2);
			this.panel_PortName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_PortName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.panel_PortName.Location = new System.Drawing.Point(3, 17);
			this.panel_PortName.Name = "panel_PortName";
			this.panel_PortName.Size = new System.Drawing.Size(209, 68);
			this.panel_PortName.TabIndex = 1;
			// 
			// buttonCheckControl_Channel4
			// 
			this.buttonCheckControl_Channel4.BackColor = System.Drawing.Color.Transparent;
			this.buttonCheckControl_Channel4.Checked = false;
			this.buttonCheckControl_Channel4.CheckStylePlus = ControlPlusLib.CheckStyle.style1;
			this.buttonCheckControl_Channel4.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonCheckControl_Channel4.Location = new System.Drawing.Point(155, 48);
			this.buttonCheckControl_Channel4.Margin = new System.Windows.Forms.Padding(2);
			this.buttonCheckControl_Channel4.Name = "buttonCheckControl_Channel4";
			this.buttonCheckControl_Channel4.Size = new System.Drawing.Size(44, 14);
			this.buttonCheckControl_Channel4.TabIndex = 14;
			// 
			// buttonCheckControl_Channel3
			// 
			this.buttonCheckControl_Channel3.BackColor = System.Drawing.Color.Transparent;
			this.buttonCheckControl_Channel3.Checked = false;
			this.buttonCheckControl_Channel3.CheckStylePlus = ControlPlusLib.CheckStyle.style1;
			this.buttonCheckControl_Channel3.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonCheckControl_Channel3.Location = new System.Drawing.Point(105, 48);
			this.buttonCheckControl_Channel3.Margin = new System.Windows.Forms.Padding(2);
			this.buttonCheckControl_Channel3.Name = "buttonCheckControl_Channel3";
			this.buttonCheckControl_Channel3.Size = new System.Drawing.Size(44, 14);
			this.buttonCheckControl_Channel3.TabIndex = 13;
			// 
			// buttonCheckControl_Channel2
			// 
			this.buttonCheckControl_Channel2.BackColor = System.Drawing.Color.Transparent;
			this.buttonCheckControl_Channel2.Checked = false;
			this.buttonCheckControl_Channel2.CheckStylePlus = ControlPlusLib.CheckStyle.style1;
			this.buttonCheckControl_Channel2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonCheckControl_Channel2.Location = new System.Drawing.Point(55, 48);
			this.buttonCheckControl_Channel2.Margin = new System.Windows.Forms.Padding(2);
			this.buttonCheckControl_Channel2.Name = "buttonCheckControl_Channel2";
			this.buttonCheckControl_Channel2.Size = new System.Drawing.Size(44, 14);
			this.buttonCheckControl_Channel2.TabIndex = 12;
			// 
			// buttonCheckControl_Channel1
			// 
			this.buttonCheckControl_Channel1.BackColor = System.Drawing.Color.Transparent;
			this.buttonCheckControl_Channel1.Checked = false;
			this.buttonCheckControl_Channel1.CheckStylePlus = ControlPlusLib.CheckStyle.style1;
			this.buttonCheckControl_Channel1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonCheckControl_Channel1.Location = new System.Drawing.Point(5, 48);
			this.buttonCheckControl_Channel1.Margin = new System.Windows.Forms.Padding(2);
			this.buttonCheckControl_Channel1.Name = "buttonCheckControl_Channel1";
			this.buttonCheckControl_Channel1.Size = new System.Drawing.Size(44, 14);
			this.buttonCheckControl_Channel1.TabIndex = 11;
			// 
			// ClockRateControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox_portName);
			this.Name = "ClockRateControl";
			this.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.Size = new System.Drawing.Size(215, 90);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.groupBox_portName.ResumeLayout(false);
			this.panel_PortName.ResumeLayout(false);
			this.panel_PortName.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Button button_setClockRate;
		private System.Windows.Forms.Label label_Channel1;
		private System.Windows.Forms.Label label_Channel3;
		private System.Windows.Forms.Label label_Channel4;
		private System.Windows.Forms.Label label_Channel2;
		private System.Windows.Forms.Label label_clockRateUnite;
		private ButtonCheckControl buttonCheckControl_Channel1;
		private ButtonCheckControl buttonCheckControl_Channel2;
		private ButtonCheckControl buttonCheckControl_Channel3;
		private ButtonCheckControl buttonCheckControl_Channel4;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox_portName;
		private System.Windows.Forms.Panel panel_PortName;
	}
}
