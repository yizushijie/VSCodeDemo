using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyPort
{
	public partial class MyPort : UserControl
	{
		private ComboBox comboBox1;

		private void InitializeComponent()
		{
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(40, 39);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 20);
			this.comboBox1.TabIndex = 0;
			// 
			// MyPort
			// 
			this.Controls.Add(this.comboBox1);
			this.Name = "MyPort";
			this.Size = new System.Drawing.Size(324, 160);
			this.ResumeLayout(false);

		}

	}
}
