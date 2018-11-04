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
            this.components = new System.ComponentModel.Container();
            this.clockRateControl1 = new UserControlPlusLib.ClockRateControl();
            this.ledControl1 = new UserControlPlusLib.LedControl();
            this.commPortControl1 = new COMMPortLib.COMMPortControl();
            this.richTextBoxControl1 = new RichTextBoxPlusLib.RichTextBoxEx();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clockRateControl1
            // 
            this.clockRateControl1.Location = new System.Drawing.Point(0, 70);
            this.clockRateControl1.Name = "clockRateControl1";
            this.clockRateControl1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.clockRateControl1.Size = new System.Drawing.Size(260, 90);
            this.clockRateControl1.TabIndex = 3;
            // 
            // ledControl1
            // 
            this.ledControl1.LedChecked = false;
            this.ledControl1.CheckStylePlus = UserControlPlusLib.CheckStyle.style1;
            this.ledControl1.LedColor = System.Drawing.Color.Black;
            this.ledControl1.Location = new System.Drawing.Point(460, 102);
            this.ledControl1.MaximumSize = new System.Drawing.Size(46, 49);
            this.ledControl1.MinimumSize = new System.Drawing.Size(46, 49);
            this.ledControl1.Name = "ledControl1";
            this.ledControl1.Size = new System.Drawing.Size(46, 49);
            this.ledControl1.TabIndex = 5;
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
            // richTextBoxControl1
            // 
            this.richTextBoxControl1.Location = new System.Drawing.Point(12, 231);
            this.richTextBoxControl1.Name = "richTextBoxControl1";
            this.richTextBoxControl1.Size = new System.Drawing.Size(353, 141);
            this.richTextBoxControl1.TabIndex = 6;
            this.richTextBoxControl1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(550, 228);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBoxControl1);
            this.Controls.Add(this.ledControl1);
            this.Controls.Add(this.commPortControl1);
            this.Controls.Add(this.clockRateControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

		}

		#endregion
		private UserControlPlusLib.ClockRateControl clockRateControl1;
		private COMMPortLib.COMMPortControl commPortControl1;
        private UserControlPlusLib.LedControl ledControl1;
        private RichTextBoxPlusLib.RichTextBoxEx richTextBoxControl1;
        private System.Windows.Forms.Button button1;
    }
}

