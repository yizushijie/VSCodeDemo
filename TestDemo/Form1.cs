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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void Form1_Load(object sender, EventArgs e)
		{
			this.usedPort = new SerialCOMMPort(this);
			this.commPortControl1.Init(this,this.usedPort, this.richTextBoxControl1);


            // this.ledControl1.AddClickEvent = new EventHandler(buttonCheckControl_Click);

            this.ledControl1.UserClick += new EventHandler (delegate { this.buttonCheckControl_Click(); } );
            //this.button1.Click += new EventHandler(this.button_Click);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			btn.Enabled = false;
			switch (btn.Text)
			{
				case "写入":
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(this.richTextBoxControl1, "433M小信号源初始功率，读取成功!\r\n", Color.Black, false);
					break;

				default:
					break;
			}
			btn.Enabled = true;
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCheckControl_Click()
        {

            if (this.ledControl1.Checked)
            {
                this.richTextBoxControl1.Text += "LED打开。\r\n";
            }
        }
    }
}