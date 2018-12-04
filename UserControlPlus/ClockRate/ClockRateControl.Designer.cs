namespace UserControlPlusLib
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
            this.numericUpDown_clockRate = new System.Windows.Forms.NumericUpDown();
            this.button_writeClockRate = new System.Windows.Forms.Button();
            this.label_Channel1 = new System.Windows.Forms.Label();
            this.label_Channel3 = new System.Windows.Forms.Label();
            this.label_Channel4 = new System.Windows.Forms.Label();
            this.label_Channel2 = new System.Windows.Forms.Label();
            this.label_clockRateUnite = new System.Windows.Forms.Label();
            this.label_clockRateName = new System.Windows.Forms.Label();
            this.groupBox_clockRateName = new System.Windows.Forms.GroupBox();
            this.panel_ClockRate = new System.Windows.Forms.Panel();
            this.button_readClockRate = new System.Windows.Forms.Button();
            this.button_resetClockRate = new System.Windows.Forms.Button();
            this.buttonCheckControl_Channel4 = new UserControlPlusLib.ButtonCheckControl();
            this.buttonCheckControl_Channel3 = new UserControlPlusLib.ButtonCheckControl();
            this.buttonCheckControl_Channel2 = new UserControlPlusLib.ButtonCheckControl();
            this.buttonCheckControl_Channel1 = new UserControlPlusLib.ButtonCheckControl();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_clockRate)).BeginInit();
            this.groupBox_clockRateName.SuspendLayout();
            this.panel_ClockRate.SuspendLayout();
            this.SuspendLayout();
            // 
            // numericUpDown_clockRate
            // 
            this.numericUpDown_clockRate.Location = new System.Drawing.Point(36, 5);
            this.numericUpDown_clockRate.Maximum = new decimal(new int[] {
            40000000,
            0,
            0,
            0});
            this.numericUpDown_clockRate.Minimum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.numericUpDown_clockRate.Name = "numericUpDown_clockRate";
            this.numericUpDown_clockRate.Size = new System.Drawing.Size(92, 21);
            this.numericUpDown_clockRate.TabIndex = 1;
            this.numericUpDown_clockRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_clockRate.ThousandsSeparator = true;
            this.numericUpDown_clockRate.Value = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            // 
            // button_writeClockRate
            // 
            this.button_writeClockRate.Location = new System.Drawing.Point(155, 3);
            this.button_writeClockRate.Name = "button_writeClockRate";
            this.button_writeClockRate.Size = new System.Drawing.Size(44, 23);
            this.button_writeClockRate.TabIndex = 2;
            this.button_writeClockRate.Text = "写入";
            this.button_writeClockRate.UseVisualStyleBackColor = true;
            // 
            // label_Channel1
            // 
            this.label_Channel1.AutoSize = true;
            this.label_Channel1.Location = new System.Drawing.Point(5, 30);
            this.label_Channel1.Name = "label_Channel1";
            this.label_Channel1.Size = new System.Drawing.Size(35, 12);
            this.label_Channel1.TabIndex = 4;
            this.label_Channel1.Text = "通道1";
            // 
            // label_Channel3
            // 
            this.label_Channel3.AutoSize = true;
            this.label_Channel3.Location = new System.Drawing.Point(101, 30);
            this.label_Channel3.Name = "label_Channel3";
            this.label_Channel3.Size = new System.Drawing.Size(35, 12);
            this.label_Channel3.TabIndex = 6;
            this.label_Channel3.Text = "通道3";
            // 
            // label_Channel4
            // 
            this.label_Channel4.AutoSize = true;
            this.label_Channel4.Location = new System.Drawing.Point(149, 30);
            this.label_Channel4.Name = "label_Channel4";
            this.label_Channel4.Size = new System.Drawing.Size(35, 12);
            this.label_Channel4.TabIndex = 8;
            this.label_Channel4.Text = "通道4";
            // 
            // label_Channel2
            // 
            this.label_Channel2.AutoSize = true;
            this.label_Channel2.Location = new System.Drawing.Point(53, 30);
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
            // label_clockRateName
            // 
            this.label_clockRateName.AutoSize = true;
            this.label_clockRateName.Location = new System.Drawing.Point(3, 10);
            this.label_clockRateName.Name = "label_clockRateName";
            this.label_clockRateName.Size = new System.Drawing.Size(29, 12);
            this.label_clockRateName.TabIndex = 15;
            this.label_clockRateName.Text = "频率";
            // 
            // groupBox_clockRateName
            // 
            this.groupBox_clockRateName.Controls.Add(this.panel_ClockRate);
            this.groupBox_clockRateName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_clockRateName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox_clockRateName.Location = new System.Drawing.Point(0, 2);
            this.groupBox_clockRateName.Name = "groupBox_clockRateName";
            this.groupBox_clockRateName.Size = new System.Drawing.Size(258, 84);
            this.groupBox_clockRateName.TabIndex = 16;
            this.groupBox_clockRateName.TabStop = false;
            this.groupBox_clockRateName.Text = "时钟设置";
            // 
            // panel_PortName
            // 
            this.panel_ClockRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_ClockRate.Controls.Add(this.button_readClockRate);
            this.panel_ClockRate.Controls.Add(this.button_resetClockRate);
            this.panel_ClockRate.Controls.Add(this.buttonCheckControl_Channel4);
            this.panel_ClockRate.Controls.Add(this.button_writeClockRate);
            this.panel_ClockRate.Controls.Add(this.label_clockRateName);
            this.panel_ClockRate.Controls.Add(this.numericUpDown_clockRate);
            this.panel_ClockRate.Controls.Add(this.label_clockRateUnite);
            this.panel_ClockRate.Controls.Add(this.buttonCheckControl_Channel3);
            this.panel_ClockRate.Controls.Add(this.label_Channel1);
            this.panel_ClockRate.Controls.Add(this.buttonCheckControl_Channel2);
            this.panel_ClockRate.Controls.Add(this.label_Channel3);
            this.panel_ClockRate.Controls.Add(this.buttonCheckControl_Channel1);
            this.panel_ClockRate.Controls.Add(this.label_Channel4);
            this.panel_ClockRate.Controls.Add(this.label_Channel2);
            this.panel_ClockRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_ClockRate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel_ClockRate.Location = new System.Drawing.Point(3, 17);
            this.panel_ClockRate.Name = "panel_PortName";
            this.panel_ClockRate.Size = new System.Drawing.Size(252, 64);
            this.panel_ClockRate.TabIndex = 1;
            // 
            // button_readClockRate
            // 
            this.button_readClockRate.Location = new System.Drawing.Point(203, 3);
            this.button_readClockRate.Name = "button_readClockRate";
            this.button_readClockRate.Size = new System.Drawing.Size(44, 23);
            this.button_readClockRate.TabIndex = 18;
            this.button_readClockRate.Text = "读取";
            this.button_readClockRate.UseVisualStyleBackColor = true;
            // 
            // button_resetClockRate
            // 
            this.button_resetClockRate.Location = new System.Drawing.Point(203, 36);
            this.button_resetClockRate.Name = "button_resetClockRate";
            this.button_resetClockRate.Size = new System.Drawing.Size(44, 23);
            this.button_resetClockRate.TabIndex = 17;
            this.button_resetClockRate.Text = "复位";
            this.button_resetClockRate.UseVisualStyleBackColor = true;
            // 
            // buttonCheckControl_Channel4
            // 
            this.buttonCheckControl_Channel4.BackColor = System.Drawing.Color.Transparent;
            this.buttonCheckControl_Channel4.Checked = false;
            this.buttonCheckControl_Channel4.CheckStylePlus = UserControlPlusLib.CheckStyle.style1;
            this.buttonCheckControl_Channel4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCheckControl_Channel4.Location = new System.Drawing.Point(149, 45);
            this.buttonCheckControl_Channel4.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCheckControl_Channel4.Name = "buttonCheckControl_Channel4";
            this.buttonCheckControl_Channel4.Size = new System.Drawing.Size(44, 14);
            this.buttonCheckControl_Channel4.TabIndex = 16;
            // 
            // buttonCheckControl_Channel3
            // 
            this.buttonCheckControl_Channel3.BackColor = System.Drawing.Color.Transparent;
            this.buttonCheckControl_Channel3.Checked = false;
            this.buttonCheckControl_Channel3.CheckStylePlus = UserControlPlusLib.CheckStyle.style1;
            this.buttonCheckControl_Channel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCheckControl_Channel3.Location = new System.Drawing.Point(101, 45);
            this.buttonCheckControl_Channel3.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCheckControl_Channel3.Name = "buttonCheckControl_Channel3";
            this.buttonCheckControl_Channel3.Size = new System.Drawing.Size(44, 14);
            this.buttonCheckControl_Channel3.TabIndex = 13;
            // 
            // buttonCheckControl_Channel2
            // 
            this.buttonCheckControl_Channel2.BackColor = System.Drawing.Color.Transparent;
            this.buttonCheckControl_Channel2.Checked = false;
            this.buttonCheckControl_Channel2.CheckStylePlus = UserControlPlusLib.CheckStyle.style1;
            this.buttonCheckControl_Channel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCheckControl_Channel2.Location = new System.Drawing.Point(53, 45);
            this.buttonCheckControl_Channel2.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCheckControl_Channel2.Name = "buttonCheckControl_Channel2";
            this.buttonCheckControl_Channel2.Size = new System.Drawing.Size(44, 14);
            this.buttonCheckControl_Channel2.TabIndex = 12;
            // 
            // buttonCheckControl_Channel1
            // 
            this.buttonCheckControl_Channel1.BackColor = System.Drawing.Color.Transparent;
            this.buttonCheckControl_Channel1.Checked = false;
            this.buttonCheckControl_Channel1.CheckStylePlus = UserControlPlusLib.CheckStyle.style1;
            this.buttonCheckControl_Channel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCheckControl_Channel1.Location = new System.Drawing.Point(5, 45);
            this.buttonCheckControl_Channel1.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCheckControl_Channel1.Name = "buttonCheckControl_Channel1";
            this.buttonCheckControl_Channel1.Size = new System.Drawing.Size(44, 14);
            this.buttonCheckControl_Channel1.TabIndex = 11;
            // 
            // ClockRateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox_clockRateName);
            this.Name = "ClockRateControl";
            this.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.Size = new System.Drawing.Size(258, 86);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_clockRate)).EndInit();
            this.groupBox_clockRateName.ResumeLayout(false);
            this.panel_ClockRate.ResumeLayout(false);
            this.panel_ClockRate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numericUpDown_clockRate;
        private System.Windows.Forms.Button button_writeClockRate;
        private System.Windows.Forms.Label label_Channel1;
        private System.Windows.Forms.Label label_Channel3;
        private System.Windows.Forms.Label label_Channel4;
        private System.Windows.Forms.Label label_Channel2;
        private System.Windows.Forms.Label label_clockRateUnite;
        private ButtonCheckControl buttonCheckControl_Channel1;
        private ButtonCheckControl buttonCheckControl_Channel2;
        private ButtonCheckControl buttonCheckControl_Channel3;
        private System.Windows.Forms.Label label_clockRateName;
        private System.Windows.Forms.GroupBox groupBox_clockRateName;
        private System.Windows.Forms.Panel panel_ClockRate;
        private ButtonCheckControl buttonCheckControl_Channel4;
        private System.Windows.Forms.Button button_resetClockRate;
        private System.Windows.Forms.Button button_readClockRate;
    }
}
