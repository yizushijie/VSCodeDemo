using COMMPortLib;
using RichTextBoxPlusLib;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace TestDemo
{
	public partial class Form1 : Form
	{
		private COMMPort usedPort = new COMMPort();

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.usedPort = new SerialCOMMPort();
			this.commPortForm1.Init(this,this.usedPort, this.richTextBox1);

			//this.button1.Click += new EventHandler(this.button_Click);
		}

		private void button_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			btn.Enabled = false;
			switch (btn.Text)
			{
				case "写入":
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(this.richTextBox1, "433M小信号源初始功率，读取成功!\r\n", Color.Black, false);
					break;

				default:
					break;
			}
			btn.Enabled = true;
		}
	}
}