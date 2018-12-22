using COMMPortLib;
using RichTextBoxPlusLib;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClockWM8510Lib
{
	public enum CLOCKWM8510CMD : byte
	{
		CMD_RFASK_CMD2_SET_WM8510 = 0x01,
		CMD_RFASK_CMD2_GET_WM8510 = 0x02,
		CMD_RFASK_CMD2_RESET_WM8510 = 0x03,
		CMD_RFASK_CMD2_CHANNELA_WM8510 = 0x04,
		CMD_RFASK_CMD2_CHANNELB_WM8510 = 0x05,
		CMD_RFASK_CMD2_CHANNELC_WM8510 = 0x06,
		CMD_RFASK_CMD2_CHANNELD_WM8510 = 0x07,
		CMD_RFASK_CMD2_CHANNELS_WM8510 = 0x08
	}

	public partial class ClockWM8510
	{
		#region 变量定义

		/// <summary>
		/// 设置最小输出频率，20KHz
		/// </summary>
		private int minFreq = 21000;

		/// <summary>
		/// 最大输出频率，38MHz
		/// </summary>
		private int maxFreq = 38000000;

		/// <summary>
		/// 设置命令的主命令
		/// </summary>
		private const byte CMD_RFASK_CMD1_FREQ_WM8510 = 0x01;

		#endregion 变量定义

		#region 属性定义

		/// <summary>
		///
		/// </summary>
		public virtual int m_MinFreq
		{
			get
			{
				return this.minFreq;
			}

			set
			{
				this.minFreq=value;
			}
		}

		/// <summary>
		///
		/// </summary>
		public virtual int m_MaxFreq
		{
			get
			{
				return this.maxFreq;
			}

			set
			{
				this.maxFreq=value;
			}
		}

		#endregion 属性定义

		#region 构造函数

		/// <summary>
		///
		/// </summary>
		public ClockWM8510()
		{
		}

		#endregion 构造函数

		#region 析构函数

		/// <summary>
		///
		/// </summary>
		~ClockWM8510()
		{
			GC.SuppressFinalize(this);
		}

		#endregion 析构函数

		#region 函数定义

		/// <summary>
		/// 获取有关时钟芯片WM8510的设置
		/// </summary>
		/// <param name="freq"></param>
		/// <param name="index"></param>
		/// <param name="usedPort"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int ClockWM8510Set(int freq, int index, COMMPort usedPort, RichTextBox msg = null)
		{
			int _return = 0;
			switch (index)
			{
				case 1:
					_return=this.ClockWM8510SetFreq(freq, usedPort, msg);
					break;

				case 2:
					_return=this.ClockWM8510GetFreq(freq, usedPort, msg);
					break;

				case 3:
					_return=this.ClockWM8510Reset(usedPort, msg);
					break;

				default:
					if (msg!=null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "WM8510的设置操作不合法!\r\n", Color.Red, false);
					}
					_return=1;
					break;
			}
			return _return;
		}

		/// <summary>
		/// 设置WM8510输出频率
		/// </summary>
		/// <param name="freq"></param>
		/// <param name="usedPort"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		protected virtual int ClockWM8510SetFreq(int freq, COMMPort usedPort, RichTextBox msg = null)
		{
			if (usedPort==null)
			{
				if (msg!=null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "通信端口初始化失败!\r\n", Color.Red, false);
				}
				return 1;
			}

			//---判断频率的最小值
			if (freq<this.m_MinFreq)
			{
				freq=this.m_MinFreq;
			}
			int _return = 0;
			byte[] cmd = new byte[] { CMD_RFASK_CMD1_FREQ_WM8510, (byte)CLOCKWM8510CMD.CMD_RFASK_CMD2_SET_WM8510, (byte)(freq>>24), (byte)(freq>>16), (byte)(freq>>8), (byte)freq };
			byte[] res = null;

			//---将命令写入设备
			_return=usedPort.SendCmdAndReadResponse(cmd, ref res, 200);

			//---通信验证
			if ((_return==0)&&(usedPort.m_COMMPortDataFormatPassed==true)&&(res[usedPort.m_COMMPortDataReadIndex+1]==0)&&(res[usedPort.m_COMMPortDataReadIndex+2]==cmd[1]))
			{
				if (msg!=null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "时钟频率设置成功!\r\n", Color.Black, false);
				}
			}
			else
			{
				if (_return!=0)
				{
					if (msg!=null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "通信发生错误!\r\n", Color.Red, false);
					}
				}
				else if (usedPort.m_COMMPortDataFormatPassed==false)
				{
					if (msg!=null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "读取的数据格式不合法!\r\n", Color.Red, false);
					}
				}
				else if (res[usedPort.m_COMMPortDataReadIndex+1]!=0)
				{
					if (msg!=null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "数据返回的结果错误!\r\n", Color.Red, false);
					}
				}
				else
				{
					if (msg!=null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "通信命令验证错误!\r\n", Color.Red, false);
					}
				}
			}
			return _return;
		}

		/// <summary>
		/// 读取WM8510输出频率
		/// </summary>
		/// <param name="freq"></param>
		/// <param name="usedPort"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		protected virtual int ClockWM8510GetFreq(float freq, COMMPort usedPort, RichTextBox msg = null)
		{
			if (usedPort==null)
			{
				if (msg!=null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "通信端口初始化失败!\r\n", Color.Red, false);
				}
				return 1;
			}
			int _return = 0;
			int getFreq = 0;
			byte[] cmd = new byte[] { CMD_RFASK_CMD1_FREQ_WM8510, (byte)CLOCKWM8510CMD.CMD_RFASK_CMD2_GET_WM8510 };
			byte[] res = null;

			//---将命令写入设备
			_return=usedPort.SendCmdAndReadResponse(cmd, ref res, 200);

			//---通信验证
			if ((_return==0)&&(usedPort.m_COMMPortDataFormatPassed==true)&&(res[usedPort.m_COMMPortDataReadIndex+1]==0)&&(res[usedPort.m_COMMPortDataReadIndex+2]==cmd[1]))
			{
				if (msg!=null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "时钟频率读取成功!\r\n", Color.Black, false);
				}
				getFreq=res[usedPort.m_COMMPortDataReadIndex+3];
				getFreq=(getFreq<<8)+res[usedPort.m_COMMPortDataReadIndex+4];
				getFreq=(getFreq<<8)+res[usedPort.m_COMMPortDataReadIndex+5];
				getFreq=(getFreq<<8)+res[usedPort.m_COMMPortDataReadIndex+6];

				//---时钟频率的校验
				if (getFreq<freq)
				{
					if ((freq-getFreq)<5000)
					{
						if (msg!=null)
						{
							RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "时钟频率验证成功!\r\n", Color.Black, false);
						}
					}
					else
					{
						if (msg!=null)
						{
							RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "时钟频率验证失败!\t读取频率是："+getFreq.ToString()+"Hz\r\n", Color.Red, false);
						}
					}
				}
				else
				{
					if ((getFreq-freq)<5000)
					{
						if (msg!=null)
						{
							RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "时钟频率验证成功!\r\n", Color.Black, false);
						}
					}
					else
					{
						if (msg!=null)
						{
							RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "时钟频率验证失败!\t读取频率是："+getFreq.ToString()+"Hz\r\n", Color.Red, false);
						}
					}
				}
			}
			else
			{
				if (_return!=0)
				{
					if (msg!=null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "通信发生错误!\r\n", Color.Red, false);
					}
				}
				else if (usedPort.m_COMMPortDataFormatPassed==false)
				{
					if (msg!=null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "读取的数据格式不合法!\r\n", Color.Red, false);
					}
				}
				else if (res[usedPort.m_COMMPortDataReadIndex+1]!=0)
				{
					if (msg!=null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "数据返回的结果错误!\r\n", Color.Red, false);
					}
				}
				else
				{
					if (msg!=null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "通信命令验证错误!\r\n", Color.Red, false);
					}
				}
			}
			return _return;
		}

		/// <summary>
		/// 复位WM8510
		/// </summary>
		/// <param name="usedPort"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		protected virtual int ClockWM8510Reset(COMMPort usedPort, RichTextBox msg = null)
		{
			if (usedPort==null)
			{
				if (msg!=null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "通信端口初始化失败!\r\n", Color.Red, false);
				}
				return 1;
			}
			int _return = 0;
			byte[] cmd = new byte[] { CMD_RFASK_CMD1_FREQ_WM8510, (byte)CLOCKWM8510CMD.CMD_RFASK_CMD2_RESET_WM8510 };
			byte[] res = null;

			//---将命令写入设备
			_return=usedPort.SendCmdAndReadResponse(cmd, ref res, 200);

			//---通信验证
			if ((_return==0)&&(usedPort.m_COMMPortDataFormatPassed==true)&&(res[usedPort.m_COMMPortDataReadIndex+1]==0)&&(res[usedPort.m_COMMPortDataReadIndex+2]==cmd[1]))
			{
				if (msg!=null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "时钟设备复位成功!\r\n", Color.Black, false);
				}
			}
			else
			{
				if (_return!=0)
				{
					if (msg!=null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "通信发生错误!\r\n", Color.Red, false);
					}
				}
				else if (usedPort.m_COMMPortDataFormatPassed==false)
				{
					if (msg!=null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "读取的数据格式不合法!\r\n", Color.Red, false);
					}
				}
				else if (res[usedPort.m_COMMPortDataReadIndex+1]!=0)
				{
					if (msg!=null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "数据返回的结果错误!\r\n", Color.Red, false);
					}
				}
				else
				{
					if (msg!=null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "通信命令验证错误!\r\n", Color.Red, false);
					}
				}
			}
			return _return;
		}

		/// <summary>
		/// 时钟输出通道
		/// </summary>
		/// <param name="channel"></param>
		/// <param name="isOpen"></param>
		/// <param name="usedPort"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int ClockWM8510SetChannel(int channel, bool isOpen, COMMPort usedPort, RichTextBox msg = null)
		{
			if (usedPort==null)
			{
				if (msg!=null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "通信端口初始化失败!\r\n", Color.Red, false);
				}
				return 1;
			}
			int _return = 0;
			string str = null;
			byte[] cmd = new byte[] { CMD_RFASK_CMD1_FREQ_WM8510, 0x00, 0x00 };
			switch (channel)
			{
				case 1:
					cmd[1]=(byte)CLOCKWM8510CMD.CMD_RFASK_CMD2_CHANNELA_WM8510;
					str="时钟频率A通道输出";
					break;

				case 2:
					cmd[1]=(byte)CLOCKWM8510CMD.CMD_RFASK_CMD2_CHANNELB_WM8510;
					str="时钟频率B通道输出";
					break;

				case 3:
					cmd[1]=(byte)CLOCKWM8510CMD.CMD_RFASK_CMD2_CHANNELC_WM8510;
					str="时钟频率C通道输出";
					break;

				case 4:
					cmd[1]=(byte)CLOCKWM8510CMD.CMD_RFASK_CMD2_CHANNELD_WM8510;
					str="时钟频率D通道输出";
					break;

				case 5:
					cmd[1]=(byte)CLOCKWM8510CMD.CMD_RFASK_CMD2_CHANNELS_WM8510;
					str="时钟频率全通道输出";
					break;

				default:
					return 2;
			}
			if (isOpen==true)
			{
				cmd[2]=0x01;
			}
			byte[] res = null;

			//---将命令写入设备
			_return=usedPort.SendCmdAndReadResponse(cmd, ref res, 200);

			//---通信验证
			if ((_return==0)&&(usedPort.m_COMMPortDataFormatPassed==true)&&(res[usedPort.m_COMMPortDataReadIndex+1]==0)&&(res[usedPort.m_COMMPortDataReadIndex+2]==cmd[1]))
			{
				if (isOpen==true)
				{
					str+="打开!\r\n";
				}
				else
				{
					str+="关闭!\r\n";
				}
				if (msg!=null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, str, Color.Black, false);
				}
			}
			else
			{
				if (_return!=0)
				{
					if (msg!=null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "通信发生错误!\r\n", Color.Red, false);
					}
				}
				else if (usedPort.m_COMMPortDataFormatPassed==false)
				{
					if (msg!=null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "读取的数据格式不合法!\r\n", Color.Red, false);
					}
				}
				else if (res[usedPort.m_COMMPortDataReadIndex+1]!=0)
				{
					if (msg!=null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "数据返回的结果错误!\r\n", Color.Red, false);
					}
				}
				else
				{
					if (msg!=null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "通信命令验证错误!\r\n", Color.Red, false);
					}
				}
			}
			return _return;
		}

		#endregion 函数定义
	}
}