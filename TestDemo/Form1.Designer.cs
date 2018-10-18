namespace TestDemo
{
	partial class Form1
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
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.clockRateControl1 = new ControlPlusLib.ClockRate.ClockRateControl();
			this.commPortControl1 = new COMMPortLib.COMMPortControl();
			this.buttonCheckControl1 = new ControlPlusLib.ButtonCheckControl();
			this.SuspendLayout();
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(0, 228);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(441, 159);
			this.richTextBox1.TabIndex = 1;
			this.richTextBox1.Text = "";
			// 
			// clockRateControl1
			// 
			this.clockRateControl1.Location = new System.Drawing.Point(0, 70);
			this.clockRateControl1.Name = "clockRateControl1";
			this.clockRateControl1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.clockRateControl1.Size = new System.Drawing.Size(215, 90);
			this.clockRateControl1.TabIndex = 3;
			// 
			// commPortControl1
			// 
			this.commPortControl1.Location = new System.Drawing.Point(0, 11);
			this.commPortControl1.Margin = new System.Windows.Forms.Padding(2);
			this.commPortControl1.Name = "commPortControl1";
			this.commPortControl1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.commPortControl1.Size = new System.Drawing.Size(260, 54);
			this.commPortControl1.TabIndex = 4;
			// 
			// buttonCheckControl1
			// 
			this.buttonCheckControl1.BackColor = System.Drawing.Color.Transparent;
			this.buttonCheckControl1.Checked = false;
			this.buttonCheckControl1.CheckStylePlus = ControlPlusLib.CheckStyle.style1;
			this.buttonCheckControl1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonCheckControl1.Location = new System.Drawing.Point(426, 119);
			this.buttonCheckControl1.Margin = new System.Windows.Forms.Padding(2);
			this.buttonCheckControl1.Name = "buttonCheckControl1";
			this.buttonCheckControl1.Size = new System.Drawing.Size(87, 27);
			this.buttonCheckControl1.TabIndex = 5;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.buttonCheckControl1);
			this.Controls.Add(this.commPortControl1);
			this.Controls.Add(this.clockRateControl1);
			this.Controls.Add(this.richTextBox1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}

		#endregion
        private System.Windows.Forms.RichTextBox richTextBox1;
		private ControlPlusLib.ClockRate.ClockRateControl clockRateControl1;
		private COMMPortLib.COMMPortControl commPortControl1;
		private ControlPlusLib.ButtonCheckControl buttonCheckControl1;
	}
}

