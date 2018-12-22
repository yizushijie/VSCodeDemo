using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace TestForm
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		int sitaA = 1;
		private void Form1_Load(object sender, EventArgs e)
		{

			this.myChart1.SetTitle("数据测试");
			PointPairList list = new PointPairList();
			for (int i = 0; i < 25; i++)
			{
				double x = (double)i * 0.4;
				list.Add(x, x);
			}
			this.myChart1.AddShowCurve("折线图", list, Color.Red,SymbolType.Circle);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Color temp = this.myChart1.GetCurveColor("折线图");
			if (temp==Color.Red)
			{
				this.myChart1.SetCurveColor("折线图",Color.Blue);
			}
			else
			{
				this.myChart1.SetCurveColor("折线图", Color.Red);
			}
			PointPairList list = new PointPairList();
			for (int i = 0; i < 125; i++)
			{
				double x = (double)i * 1;
				list.Add(x, x);
			}
			this.myChart1.AddShowCurve(sitaA.ToString(), list, Color.Red, SymbolType.Circle);
			sitaA++;
			if (sitaA>4)
			{
				sitaA = 1;
			}
		}
	}
}