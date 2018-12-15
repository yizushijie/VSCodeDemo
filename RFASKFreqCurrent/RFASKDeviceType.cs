using COMMPortLib;
using RichTextBoxPlusLib;
using System.Drawing;
using System.Windows.Forms;
using UserControlPlusLib;

namespace RFASKFreqCurrentLib
{
	/// <summary>
	/// 命令枚举
	/// </summary>
	public enum RFASKFreqCurrentCMD : byte
	{
		CMD_RFASK_CMD1_FREQ_CURRENT_DEVICE_TYPE_GET = 0x01,            //===设备类型
		CMD_RFASK_CMD1_FREQ_CURRENT_SAMPLE_RES_GET = 0x02,            //===采样电阻
		CMD_RFASK_CMD1_FREQ_CURRENT_AMP_TIMES_GET = 0x03,            //===放大倍数
		CMD_RFASK_CMD1_FREQ_CURRENT_DEVICE_TYPE_SET = 0x04,            //===设备类型
		CMD_RFASK_CMD1_FREQ_CURRENT_SAMPLE_RES_SET = 0x05,            //===采样电阻
		CMD_RFASK_CMD1_FREQ_CURRENT_AMP_TIMES_SET = 0x06,            //===放大倍数
		CMD_RFASK_CMD1_FREQ_CURRENT_DEVICE_GET = 0x07,            //===设备的基本参数获取
		CMD_RFASK_CMD1_FREQ_CURRENT_DEVICE_SET = 0x08,            //===设备的基本参数设置
	}

	public partial class RFASKFreqCurrent
	{
		#region 变量定义

		/// <summary>
		/// 采样电阻的大小
		/// </summary>
		private float usedSampleRes = 0.5F;

		/// <summary>
		/// 放大倍数
		/// </summary>
		private float usedAmpTimes = 100.00F;

		/// <summary>
		/// 频率电流扫描的基本参数配置
		/// </summary>
		private const byte CMD_RFASK_CMD1_FREQ_CURRENT = 0x03;

		#endregion 变量定义

		#region 属性定义

		/// <summary>
		/// 采样电阻属性为读写
		/// </summary>
		public virtual float m_UsedSampleRes
		{
			get
			{
				return this.usedSampleRes;
			}

			set
			{
				this.usedSampleRes=value;
			}
		}

		/// <summary>
		/// 放大倍数属性为读写
		/// </summary>
		public virtual float m_UsedAmpTimes
		{
			get
			{
				return this.usedAmpTimes;
			}

			set
			{
				this.usedAmpTimes=value;
			}
		}

		#endregion 属性定义



		#region 函数定义

		/// <summary>
		/// 设备类型的设置和获取
		/// </summary>
		/// <param name="index"></param>
		/// <param name="deviceType"></param>
		/// <param name="usedPort"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int DeviceTypeSet(int index, DeviceTypeControl deviceType, COMMPort usedPort, RichTextBox msg = null)
		{
			int _return = 0;
			switch (index)
			{
				case 1:
					_return=this.DeviceTypeGetDevice(deviceType, usedPort, msg);
					break;

				case 2:
					_return=this.DeviceTypeSetDevice(deviceType, usedPort, msg);
					break;

				default:
					if (msg!=null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "预设频率点操作不合法!\r\n", Color.Red, false);
					}
					_return=1;
					break;
			}
			return _return;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="deviceType"></param>
		/// <returns></returns>
		protected virtual int DeviceTypeGetDevice(DeviceTypeControl deviceType, COMMPort usedPort, RichTextBox msg = null)
		{
			if (usedPort==null)
			{
				if (msg!=null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "通信端口初始化失败!\r\n", Color.Red, false);
				}
				return 1;
			}
			if (deviceType==null)
			{
				if (msg!=null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "设备类型控件传递错误!\r\n", Color.Red, false);
				}
				return 2;
			}
			int _return = 0;
			byte[] cmd = new byte[] { CMD_RFASK_CMD1_FREQ_CURRENT, (byte)RFASKFreqCurrentCMD.CMD_RFASK_CMD1_FREQ_CURRENT_DEVICE_GET };
			byte[] res = null;

			//---将命令写入设备
			_return=usedPort.SendCmdAndReadResponse(cmd, ref res, 300);

			//---通信验证
			if ((_return==0)&&(usedPort.m_COMMBytesPassed==true)&&(res[usedPort.m_COMMPortDataReadIndex+1]==0)&&(res[usedPort.m_COMMPortDataReadIndex+2]==cmd[1]))
			{
				if (msg!=null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "设备类型参数获取成功!\r\n", Color.Black, false);
				}

				//---设置设备的类型
				if (deviceType.SetDeviceType(res[usedPort.m_COMMPortDataReadIndex+3])==false)
				{
					if (msg!=null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "设备类型不能识别!\r\n", Color.Black, false);
					}
					return 3;
				}
				_return=res[usedPort.m_COMMPortDataReadIndex+4];
				_return=(_return<<8)+res[usedPort.m_COMMPortDataReadIndex+5];

				//---设置采样电阻的大小
				deviceType.m_SampleRes=(float)(_return*1.0/100);
				_return=res[usedPort.m_COMMPortDataReadIndex+6];
				_return=(_return<<8)+res[usedPort.m_COMMPortDataReadIndex+7];

				//---获取放大倍数
				deviceType.m_AmpTimes=(float)(_return*1.0);
				_return=0;
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
				else if (usedPort.m_COMMBytesPassed==false)
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
		///
		/// </summary>
		/// <param name="deviceType"></param>
		/// <returns></returns>
		protected virtual int DeviceTypeSetDevice(DeviceTypeControl deviceType, COMMPort usedPort, RichTextBox msg = null)
		{
			if (usedPort==null)
			{
				if (msg!=null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "通信端口初始化失败!\r\n", Color.Red, false);
				}
				return 1;
			}
			if (deviceType==null)
			{
				if (msg!=null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "设备类型控件传递错误!\r\n", Color.Red, false);
				}
				return 2;
			}
			int _return = 0;
			byte[] cmd = new byte[] { CMD_RFASK_CMD1_FREQ_CURRENT, (byte)RFASKFreqCurrentCMD.CMD_RFASK_CMD1_FREQ_CURRENT_DEVICE_SET, 0x00, 0x00, 0x00, 0x00, 0x00 };
			cmd[2]=(byte)deviceType.GetDeviceType(deviceType.m_DeviceType);
			if (cmd[2]==0)
			{
				if (msg!=null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "设备类型无法识别!\r\n", Color.Red, false);
				}
				return 2;
			}
			float temp = deviceType.m_SampleRes;
			_return=(int)(temp*100);
			cmd[3]=(byte)(_return>>8);
			cmd[4]=(byte)(_return);
			temp=deviceType.m_AmpTimes;
			_return=(int)(temp*1);
			cmd[5]=(byte)(_return>>8);
			cmd[6]=(byte)(_return);
			byte[] res = null;

			//---将命令写入设备
			_return=usedPort.SendCmdAndReadResponse(cmd, ref res, 300);

			//---通信验证
			if ((_return==0)&&(usedPort.m_COMMBytesPassed==true)&&(res[usedPort.m_COMMPortDataReadIndex+1]==0)&&(res[usedPort.m_COMMPortDataReadIndex+2]==cmd[1]))
			{
				if (msg!=null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "设备类型参数设置成功!\r\n", Color.Black, false);
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
				else if (usedPort.m_COMMBytesPassed==false)
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