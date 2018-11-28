using RichTextBoxPlusLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

		#endregion

		#region 构造函数

		/// <summary>
		/// 无参数的构造函数
		/// </summary>
		public RFASKSiteCurrent()
		{
			if (this.siteACurrentX100mA==null)
			{
				this.siteACurrentX100mA = new List<int>();
			}
			if (this.siteBCurrentX100mA == null)
			{
				this.siteBCurrentX100mA = new List<int>();
			}
			if (this.siteCCurrentX100mA == null)
			{
				this.siteCCurrentX100mA = new List<int>();
			}
			if (this.siteDCurrentX100mA == null)
			{
				this.siteDCurrentX100mA = new List<int>();
			}
		}

		#endregion

		#region 函数定义

		public void Init(byte fs,byte[] cmd)
		{
			this.GetStartFreqAndSiteNum(fs);
			this.GetSiteCurrent(cmd);
		}

		/// <summary>
		/// 获取起始频率和site数
		/// </summary>
		/// <param name="cmd">The command.</param>
		public void GetStartFreqAndSiteNum(byte cmd)
		{
			int _return = cmd;
			//---计算SITE数
			this.siteNum = (_return & 0x07);
			//---近视计算起始射频频率MHz
			_return &= 0xF8;
			_return >>= 3;
			_return *= 20;
			this.startFreqMHz = _return;
		}


		/// <summary>
		/// 解析site的电流
		/// </summary>
		/// <param name="cmd">The command.</param>
		public void GetSiteCurrent(byte[]cmd)
		{
			int siteCurrentNum = cmd.Length - 8;
			siteCurrentNum /= 8;
			int i = 0;
			int siteCurrent = 0;
			for ( i = 0; i < siteCurrentNum; i++)
			{
				siteCurrent = cmd[i * 8];
				siteCurrent=(siteCurrent<<8)+cmd[i * 8+1];
				this.siteACurrentX100mA.Add(siteCurrent);

				siteCurrent = cmd[i * 8+2];
				siteCurrent = (siteCurrent << 8) + cmd[i * 8 + 3];
				this.siteBCurrentX100mA.Add(siteCurrent);

				siteCurrent = cmd[i * 8+4];
				siteCurrent = (siteCurrent << 8) + cmd[i * 8 + 5];
				this.siteCCurrentX100mA.Add(siteCurrent);

				siteCurrent = cmd[i * 8 + 6];
				siteCurrent = (siteCurrent << 8) + cmd[i * 8 + 7];
				this.siteDCurrentX100mA.Add(siteCurrent);
			}
			siteCurrent = cmd[i * 8];
			siteCurrent = (siteCurrent << 8) + cmd[i * 8 + 1];
			this.siteAErrorPointIndex = siteCurrent;

			siteCurrent = cmd[i * 8 + 2];
			siteCurrent = (siteCurrent << 8) + cmd[i * 8 + 3];
			this.siteBErrorPointIndex = siteCurrent;

			siteCurrent = cmd[i * 8 + 4];
			siteCurrent = (siteCurrent << 8) + cmd[i * 8 + 5];
			this.siteCErrorPointIndex = siteCurrent;

			siteCurrent = cmd[i * 8 + 6];
			siteCurrent = (siteCurrent << 8) + cmd[i * 8 + 7];
			this.siteDErrorPointIndex = siteCurrent;
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
			if( (this.siteACurrentX100mA.Count==0)||(this.siteBCurrentX100mA.Count==0)||(this.siteCCurrentX100mA.Count==0)||(this.siteDCurrentX100mA.Count==0))
			{
				return;
			}
			string str = "粗略起始频率:" + this.startFreqMHz.ToString("D")+"MHz" + ";有效的SITE数:" + this.siteNum.ToString("D") + "\r\n";
			if (msg != null)
			{
				RichTextBoxPlus.AppendTextInfoWithDateTime(msg,str, Color.Black, false);
			}
			int i = 0;
			//---起始频率
			int freqMHz = 0;
			for (i = 0;  i< this.siteACurrentX100mA.Count; i++)
			{
				if (i==0)
				{
					freqMHz = this.startFreqMHz;
				}
				else
				{
					freqMHz += this.stepFreqMHz;
				}
				str = freqMHz.ToString("D")+";"+this.siteACurrentX100mA[i].ToString("D") + ";" + this.siteBCurrentX100mA[i].ToString("D") + ";" + this.siteCCurrentX100mA[i].ToString("D") + ";" + this.siteDCurrentX100mA[i].ToString("D") + "\r\n";
				if (msg != null)
				{
					RichTextBoxPlus.AppendTextInfoWithoutDateTime(msg, str, Color.Black, false);
				}
			}
		}

		#endregion

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

		#endregion

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

		#endregion

	}
}
