namespace UserControlPlusLib
{
    partial class DeviceTypeControl
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
            this.groupBox_deviceType = new System.Windows.Forms.GroupBox();
            this.panel_deviceType = new System.Windows.Forms.Panel();
            this.label_sampleResUnite = new System.Windows.Forms.Label();
            this.numericUpDown_ampTimes = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_sampleRes = new System.Windows.Forms.NumericUpDown();
            this.label_ampTimes = new System.Windows.Forms.Label();
            this.label_sampleRes = new System.Windows.Forms.Label();
            this.button_writeDeviceConfig = new System.Windows.Forms.Button();
            this.button_readDeviceConfig = new System.Windows.Forms.Button();
            this.label_deviceType = new System.Windows.Forms.Label();
            this.comboBox_deviceType = new System.Windows.Forms.ComboBox();
            this.groupBox_deviceType.SuspendLayout();
            this.panel_deviceType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ampTimes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_sampleRes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_deviceType
            // 
            this.groupBox_deviceType.Controls.Add(this.panel_deviceType);
            this.groupBox_deviceType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_deviceType.Location = new System.Drawing.Point(0, 3);
            this.groupBox_deviceType.Name = "groupBox_deviceType";
            this.groupBox_deviceType.Size = new System.Drawing.Size(258, 100);
            this.groupBox_deviceType.TabIndex = 7;
            this.groupBox_deviceType.TabStop = false;
            this.groupBox_deviceType.Text = "器件参数";
            // 
            // panel_deviceType
            // 
            this.panel_deviceType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_deviceType.Controls.Add(this.label_sampleResUnite);
            this.panel_deviceType.Controls.Add(this.numericUpDown_ampTimes);
            this.panel_deviceType.Controls.Add(this.numericUpDown_sampleRes);
            this.panel_deviceType.Controls.Add(this.label_ampTimes);
            this.panel_deviceType.Controls.Add(this.label_sampleRes);
            this.panel_deviceType.Controls.Add(this.button_writeDeviceConfig);
            this.panel_deviceType.Controls.Add(this.button_readDeviceConfig);
            this.panel_deviceType.Controls.Add(this.label_deviceType);
            this.panel_deviceType.Controls.Add(this.comboBox_deviceType);
            this.panel_deviceType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_deviceType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel_deviceType.Location = new System.Drawing.Point(3, 17);
            this.panel_deviceType.Name = "panel_deviceType";
            this.panel_deviceType.Size = new System.Drawing.Size(252, 80);
            this.panel_deviceType.TabIndex = 2;
            // 
            // label_sampleResUnite
            // 
            this.label_sampleResUnite.AutoSize = true;
            this.label_sampleResUnite.Location = new System.Drawing.Point(156, 31);
            this.label_sampleResUnite.Name = "label_sampleResUnite";
            this.label_sampleResUnite.Size = new System.Drawing.Size(17, 12);
            this.label_sampleResUnite.TabIndex = 8;
            this.label_sampleResUnite.Text = "Ω";
            // 
            // numericUpDown_ampTimes
            // 
            this.numericUpDown_ampTimes.DecimalPlaces = 2;
            this.numericUpDown_ampTimes.Location = new System.Drawing.Point(68, 55);
            this.numericUpDown_ampTimes.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDown_ampTimes.Name = "numericUpDown_ampTimes";
            this.numericUpDown_ampTimes.Size = new System.Drawing.Size(85, 21);
            this.numericUpDown_ampTimes.TabIndex = 7;
            this.numericUpDown_ampTimes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_ampTimes.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericUpDown_sampleRes
            // 
            this.numericUpDown_sampleRes.DecimalPlaces = 2;
            this.numericUpDown_sampleRes.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_sampleRes.Location = new System.Drawing.Point(68, 28);
            this.numericUpDown_sampleRes.Name = "numericUpDown_sampleRes";
            this.numericUpDown_sampleRes.Size = new System.Drawing.Size(85, 21);
            this.numericUpDown_sampleRes.TabIndex = 6;
            this.numericUpDown_sampleRes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_ampTimes
            // 
            this.label_ampTimes.AutoSize = true;
            this.label_ampTimes.Location = new System.Drawing.Point(3, 57);
            this.label_ampTimes.Name = "label_ampTimes";
            this.label_ampTimes.Size = new System.Drawing.Size(59, 12);
            this.label_ampTimes.TabIndex = 5;
            this.label_ampTimes.Text = "放大倍数:";
            // 
            // label_sampleRes
            // 
            this.label_sampleRes.AutoSize = true;
            this.label_sampleRes.Location = new System.Drawing.Point(3, 31);
            this.label_sampleRes.Name = "label_sampleRes";
            this.label_sampleRes.Size = new System.Drawing.Size(59, 12);
            this.label_sampleRes.TabIndex = 4;
            this.label_sampleRes.Text = "采样电阻:";
            // 
            // button_writeDeviceConfig
            // 
            this.button_writeDeviceConfig.Location = new System.Drawing.Point(186, 46);
            this.button_writeDeviceConfig.Name = "button_writeDeviceConfig";
            this.button_writeDeviceConfig.Size = new System.Drawing.Size(61, 25);
            this.button_writeDeviceConfig.TabIndex = 3;
            this.button_writeDeviceConfig.Text = "写入参数";
            this.button_writeDeviceConfig.UseVisualStyleBackColor = true;
            // 
            // button_readDeviceConfig
            // 
            this.button_readDeviceConfig.Location = new System.Drawing.Point(186, 15);
            this.button_readDeviceConfig.Name = "button_readDeviceConfig";
            this.button_readDeviceConfig.Size = new System.Drawing.Size(61, 25);
            this.button_readDeviceConfig.TabIndex = 2;
            this.button_readDeviceConfig.Text = "读取参数";
            this.button_readDeviceConfig.UseVisualStyleBackColor = true;
            // 
            // label_deviceType
            // 
            this.label_deviceType.AutoSize = true;
            this.label_deviceType.Location = new System.Drawing.Point(3, 6);
            this.label_deviceType.Name = "label_deviceType";
            this.label_deviceType.Size = new System.Drawing.Size(59, 12);
            this.label_deviceType.TabIndex = 1;
            this.label_deviceType.Text = "器件类型:";
            // 
            // comboBox_deviceType
            // 
            this.comboBox_deviceType.FormattingEnabled = true;
            this.comboBox_deviceType.Items.AddRange(new object[] {
            "SYN4XXR",
            "SYN5XXR",
            "CRUX",
            "F11xT",
            "CRATER",
            "ARA"});
            this.comboBox_deviceType.Location = new System.Drawing.Point(68, 3);
            this.comboBox_deviceType.Name = "comboBox_deviceType";
            this.comboBox_deviceType.Size = new System.Drawing.Size(85, 20);
            this.comboBox_deviceType.TabIndex = 0;
            this.comboBox_deviceType.Text = "SYN4XXR";
            // 
            // DeviceTypeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox_deviceType);
            this.Name = "DeviceTypeControl";
            this.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.Size = new System.Drawing.Size(258, 103);
            this.groupBox_deviceType.ResumeLayout(false);
            this.panel_deviceType.ResumeLayout(false);
            this.panel_deviceType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ampTimes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_sampleRes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_deviceType;
        private System.Windows.Forms.Panel panel_deviceType;
        private System.Windows.Forms.Label label_sampleResUnite;
        private System.Windows.Forms.NumericUpDown numericUpDown_ampTimes;
        private System.Windows.Forms.NumericUpDown numericUpDown_sampleRes;
        private System.Windows.Forms.Label label_ampTimes;
        private System.Windows.Forms.Label label_sampleRes;
        private System.Windows.Forms.Button button_writeDeviceConfig;
        private System.Windows.Forms.Button button_readDeviceConfig;
        private System.Windows.Forms.Label label_deviceType;
        private System.Windows.Forms.ComboBox comboBox_deviceType;
    }
}
