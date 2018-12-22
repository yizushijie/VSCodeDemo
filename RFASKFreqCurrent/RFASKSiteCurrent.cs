using FileFuncLib;
using RichTextBoxPlusLib;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using UserControlPlusLib.MyChart;
using ZedGraph;

namespace RFASKFreqCurrentLib
{
	public class RFASKSiteCurrent
	{
		#region 变量定义

		/// <summary>
		/// 起始频率
		/// </summary>
		public int startFreqMHz = 200;

		/// <summary>
		/// 测试site的个数
		/// </summary>
		public int siteNum = 4;

		/// <summary>
		/// 默认步进频率是2MHz
		/// </summary>
		public int stepFreqMHz = 2;

		/// <summary>
		/// siteA失效点的序号
		/// </summary>
		public int siteAErrorPointIndex = 0;

		/// <summary>
		/// siteA失效点的序号
		/// </summary>
		public int siteBErrorPointIndex = 0;

		/// <summary>
		/// siteA失效点的序号
		/// </summary>
		public int siteCErrorPointIndex = 0;

		/// <summary>
		/// siteA失效点的序号
		/// </summary>
		public int siteDErrorPointIndex = 0;

		/// <summary>
		/// siteA的电流
		/// </summary>
		public List<int> siteACurrentX100mA = null;

		/// <summary>
		/// siteC的电流
		/// </summary>
		public List<int> siteBCurrentX100mA = null;

		/// <summary>
		/// siteC的电流
		/// </summary>
		public List<int> siteCCurrentX100mA = null;

		/// <summary>
		/// siteD的电流
		/// </summary>
		public List<int> siteDCurrentX100mA = null;

		#endregion 变量定义

		#region 构造函数

		/// <summary>
		/// 无参数的构造函数
		/// </summary>
		public RFASKSiteCurrent()
		{
			if (this.siteACurrentX100mA==null)
			{
				this.siteACurrentX100mA=new List<int>();
			}
			if (this.siteBCurrentX100mA==null)
			{
				this.siteBCurrentX100mA=new List<int>();
			}
			if (this.siteCCurrentX100mA==null)
			{
				this.siteCCurrentX100mA=new List<int>();
			}
			if (this.siteDCurrentX100mA==null)
			{
				this.siteDCurrentX100mA=new List<int>();
			}
		}

		#endregion 构造函数

		#region 函数定义

		public void Init(byte fs, byte[] cmd)
		{
			this.GetStartFreqAndSiteNum(fs);
			this.GetSiteCurrent(cmd);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="fs"></param>
		/// <param name="cmd"></param>
		public void Init(byte fs,int freqSpan, MyChart usedChart)
		{
			int i = 0;
			int freqMHz = this.startFreqMHz;
			int _return = 0;
			usedChart.ClearChart();
			if (this.siteACurrentX100mA[0]>100)
			{
				usedChart.AddShowCurve("SITEA", Color.Blue);
				_return |= 0x01;
			}
			if (this.siteBCurrentX100mA[0] > 100)
			{
				usedChart.AddShowCurve("SITEB", Color.Yellow);
				_return |= 0x02;
			}
			if (this.siteCCurrentX100mA[0] > 100)
			{
				usedChart.AddShowCurve("SITEC", Color.Green);
				_return |= 0x04;
			}
			if (this.siteDCurrentX100mA[0] > 100)
			{
				usedChart.AddShowCurve("SITED", Color.GreenYellow);
				_return |= 0x08;
			}
			usedChart.SetXAxisScaleMin(freqMHz-freqSpan*10);
			usedChart.SetXAxisScaleMajorStep(freqSpan*5);
			//usedChart.SetYAxisScaleMajorStep(freqSpan);
			for (i = 0; i < this.siteACurrentX100mA.Count; i++)
			{
				if (i!=0)
				{
					freqMHz += freqSpan;
				}
				if ((_return&0x01)!=0)
				{
					usedChart.AddXYPoint("SITEA", freqMHz, this.siteACurrentX100mA[i]);
				}
				if ((_return & 0x02) != 0)
				{
					usedChart.AddXYPoint("SITEB", freqMHz, this.siteBCurrentX100mA[i]);
				}
				if ((_return & 0x04) != 0)
				{
					usedChart.AddXYPoint("SITEC", freqMHz, this.siteCCurrentX100mA[i]);
				}
				if ((_return & 0x08) != 0)
				{
					usedChart.AddXYPoint("SITED", freqMHz, this.siteDCurrentX100mA[i]);
				}								
			}
			//usedChart.AddShowCurve("SITEA", listA, Color.Blue);
			//usedChart.AddShowCurve("SITEB", listB, Color.Yellow);
			//usedChart.AddShowCurve("SITEC", listC, Color.Green);
			//usedChart.AddShowCurve("SITED", listD, Color.GreenYellow);
		}

		/// <summary>
		/// 获取起始频率和site数
		/// </summary>
		/// <param name="cmd">The command.</param>
		public void GetStartFreqAndSiteNum(byte cmd)
		{
			int _return = cmd;

			//---计算SITE数
			this.siteNum=(_return&0x07);

			//---近视计算起始射频频率MHz
			_return&=0xF8;
			_return>>=3;
			_return*=20;
			this.startFreqMHz=_return;
		}

		/// <summary>
		/// 解析site的电流
		/// </summary>
		/// <param name="cmd">The command.</param>
		public void GetSiteCurrent(byte[] cmd)
		{
			int siteCurrentNum = cmd.Length-8;
			siteCurrentNum/=8;
			int i = 0;
			int siteCurrent = 0;
			for (i=0 ; i<siteCurrentNum ; i++)
			{
				siteCurrent=cmd[i*8];
				siteCurrent=(siteCurrent<<8)+cmd[i*8+1];
				this.siteACurrentX100mA.Add(siteCurrent);

				siteCurrent=cmd[i*8+2];
				siteCurrent=(siteCurrent<<8)+cmd[i*8+3];
				this.siteBCurrentX100mA.Add(siteCurrent);

				siteCurrent=cmd[i*8+4];
				siteCurrent=(siteCurrent<<8)+cmd[i*8+5];
				this.siteCCurrentX100mA.Add(siteCurrent);

				siteCurrent=cmd[i*8+6];
				siteCurrent=(siteCurrent<<8)+cmd[i*8+7];
				this.siteDCurrentX100mA.Add(siteCurrent);
			}
			siteCurrent=cmd[i*8];
			siteCurrent=(siteCurrent<<8)+cmd[i*8+1];
			this.siteAErrorPointIndex=siteCurrent;

			siteCurrent=cmd[i*8+2];
			siteCurrent=(siteCurrent<<8)+cmd[i*8+3];
			this.siteBErrorPointIndex=siteCurrent;

			siteCurrent=cmd[i*8+4];
			siteCurrent=(siteCurrent<<8)+cmd[i*8+5];
			this.siteCErrorPointIndex=siteCurrent;

			siteCurrent=cmd[i*8+6];
			siteCurrent=(siteCurrent<<8)+cmd[i*8+7];
			this.siteDErrorPointIndex=siteCurrent;
		}

		/// <summary>
		/// 打印Log数据
		/// </summary>
		public void PrintfLog(RichTextBox msg = null)
		{
			if (msg==null)
			{
				return;
			}
			if ((this.siteACurrentX100mA.Count==0)||(this.siteBCurrentX100mA.Count==0)||(this.siteCCurrentX100mA.Count==0)||(this.siteDCurrentX100mA.Count==0))
			{
				return;
			}
			string str = "粗略起始频率:"+this.startFreqMHz.ToString("D")+"MHz"+";有效的SITE数:"+this.siteNum.ToString("D")+"\r\n";
			if (msg!=null)
			{
				RichTextBoxPlus.AppendTextInfoWithDateTime(msg, str, Color.Black, false);
			}
			int i = 0;

			//---起始频率
			int freqMHz = 0;
			string fileLog = "";
			for (i=0 ; i<this.siteACurrentX100mA.Count ; i++)
			{
				if (i==0)
				{
					freqMHz=this.startFreqMHz;
				}
				else
				{
					freqMHz+=this.stepFreqMHz;
				}
				str=freqMHz.ToString("D")+";"+this.siteACurrentX100mA[i].ToString("D")+";"+this.siteBCurrentX100mA[i].ToString("D")+";"+this.siteCCurrentX100mA[i].ToString("D")+";"+this.siteDCurrentX100mA[i].ToString("D")+"\r\n";
				if (msg!=null)
				{
					RichTextBoxPlus.AppendTextInfoWithoutDateTime(msg, str, Color.Black, false);
				}
				fileLog+=str;
			}
			FileFuncTXT txtFile = new FileFuncTXT();
			txtFile.WriteToTxtFile("sitemA.txt", fileLog);
		}

		#endregion 函数定义
	}

	/// <summary>
	/// SITE电流的处理函数
	/// </summary>
	public partial class RFASKFreqCurrent
	{
		#region 变量定义

		/// <summary>
		/// 各个SITE的电流
		/// </summary>
		private RFASKSiteCurrent usedSiteCurrent = null;

		#endregion 变量定义

		#region 属性定义

		/// <summary>
		/// 属性只读
		/// </summary>
		/// <value>
		/// The m used site current.
		/// </value>
		public virtual RFASKSiteCurrent m_UsedSiteCurrent
		{
			get
			{
				return this.usedSiteCurrent;
			}
		}

		#endregion 属性定义
	}
}