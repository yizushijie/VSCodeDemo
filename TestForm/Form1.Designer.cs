namespace TestForm
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.myChart1 = new UserControlPlusLib.MyChart.MyChart();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// myChart1
			// 
			this.myChart1.Location = new System.Drawing.Point(12, 12);
			this.myChart1.Name = "myChart1";
			this.myChart1.Size = new System.Drawing.Size(604, 554);
			this.myChart1.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(671, 163);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(62, 24);
			this.button1.TabIndex = 1;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 578);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.myChart1);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private UserControlPlusLib.MyChart.MyChart myChart1;
		private System.Windows.Forms.Button button1;
	}
}