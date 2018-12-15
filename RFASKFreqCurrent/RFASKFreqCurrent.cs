using COMMPortLib;
using RichTextBoxPlusLib;
using System;
using System.Drawing;
using System.Windows.Forms;
using UserControlPlusLib;

namespace RFASKFreqCurrentLib
{
	/// <summary>
	/// 命令枚举
	/// </summary>
	public enum RFASKFreqCurrentPointCMD : byte
	{
		CMD_RFASK_CMD1_FREQ_CURRENT_POINT_FREQ_GET = 0x01,
		CMD_RFASK_CMD1_FREQ_CURRENT_POINT_FREQ_SET = 0x02,
		CMD_RFASK_CMD1_FREQ_CURRENT_POINT_CURRENT_GET = 0x03,
		CMD_RFASK_CMD1_FREQ_CURRENT_POINT_CURRENT_SET = 0x04,
		CMD_RFASK_CMD1_FREQ_CURRENT_POINT_DO = 0x05
	}

	public partial class RFASKFreqCurrent
	{
		#region 变量定义

		/// <summary>
		/// 使用的串口
		/// </summary>
		private COMMPort usedPort = null;

		/// <summary>
		/// 第一电压电流点的配置
		/// </summary>
		private const byte CMD_RFASK_CMD1_FREQ_CURRENT_POINT_ONE = 0x04;

		/// <summary>
		/// 第二电压电流点的配置
		/// </summary
		private const byte CMD_RFASK_CMD1_FREQ_CURRENT_POINT_TWO = 0x05;

		#endregion 变量定义

		#region 属性定义

		/// <summary>
		///
		/// </summary>
		public virtual COMMPort m_UsedPort
		{
			get
			{
				return this.usedPort;
			}
		}

		#endregion 属性定义

		#region 构造函数

		/// <summary>
		///
		/// </summary>
		public RFASKFreqCurrent()
		{
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="usePort"></param>
		public RFASKFreqCurrent(COMMPort usePort)
		{
			if (usedPort==null)
			{
				this.usedPort=new COMMPort();
			}
			this.usedPort=usePort;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="useForm"></param>
		/// <param name="usePort"></param>
		public RFASKFreqCurrent(Form useForm, COMMPort usePort)
		{
			if (usedPort==null)
			{
				this.usedPort=new COMMPort();
			}
			this.usedPort=usePort;
		}

		#endregion 构造函数

		#region 析构函数

		/// <summary>
		/// 析构函数
		/// </summary>
		~RFASKFreqCurrent()
		{
			GC.SuppressFinalize(this);
		}

		#endregion 析构函数

		#region 函数定义

		/// <summary>
		///
		/// </summary>
		/// <param name="index"></param>
		/// <param name="freqPointIndex"></param>
		/// <param name="deviceFreqCurrent"></param>
		/// <param name="usedPort"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int FreqCurrentSet(int index, int freqPointIndex, FreqCurrentControl deviceFreqCurrent, COMMPort usedPort, RichTextBox msg = null)
		{
			int _return = 0;
			int cmd = 0;

			//---第几个扫描任务的解析
			switch (freqPointIndex)
			{
				case 1:
					cmd=CMD_RFASK_CMD1_FREQ_CURRENT_POINT_ONE;
					break;

				case 2:
					cmd=CMD_RFASK_CMD1_FREQ_CURRENT_POINT_TWO;
					break;

				default:
					if (msg!=null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "频率电流扫描任务命令不合法!\r\n", Color.Red, false);
					}
					return 1;
			}

			//---频率电流扫描执行的操作
			switch (index)
			{
				case 1:

					//---获取频率参数
					_return=this.FreqCurrentGetFreqParm(cmd, deviceFreqCurrent, usedPort, msg);
					break;

				case 2:

					//---配置频率参数
					_return=this.FreqCurrentSetFreqParm(cmd, deviceFreqCurrent, usedPort, msg);
					break;

				case 3:

					//---获取电流参数
					_return=this.FreqCurrentGetCurrentParm(cmd, deviceFreqCurrent, usedPort, msg);
					break;

				case 4:

					//---设置电流参数
					_return=this.FreqCurrentSetCurrentParm(cmd, deviceFreqCurrent, usedPort, msg);
					break;

				case 5:

					//---执行频率电流扫描
					_return=this.FreqCurrentDo(cmd, deviceFreqCurrent, usedPort, msg);
					break;

				default:
					if (msg!=null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "频率电流扫描操作不合法!\r\n", Color.Red, false);
					}
					_return=1;
					break;
			}
			return _return;
		}

		/// <summary>
		/// 读取设备的频率配置参数
		/// </summary>
		/// <param name="freqPointIndex"></param>
		/// <param name="deviceFreq"></param>
		/// <param name="usedPort"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		protected virtual int FreqCurrentGetFreqParm(int freqPointIndexCMD, FreqCurrentControl deviceFreq, COMMPort usedPort, RichTextBox msg = null)
		{
			if (usedPort==null)
			{
				if (msg!=null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "通信端口初始化失败!\r\n", Color.Red, false);
				}
				return 1;
			}
			if (deviceFreq==null)
			{
				if (msg!=null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "频率电流控件传递错误!\r\n", Color.Red, false);
				}
				return 2;
			}
			int _return = 0;
			byte[] cmd = new byte[] { (byte)freqPointIndexCMD, (byte)RFASKFreqCurrentPointCMD.CMD_RFASK_CMD1_FREQ_CURRENT_POINT_FREQ_GET };
			byte[] res = null;

			//---将命令写入设备并读取返回的值
			_return=usedPort.SendCmdAndReadResponse(cmd, ref res, 300);

			//---通信验证
			if ((_return==0)&&(usedPort.m_COMMBytesPassed==true)&&(res[usedPort.m_COMMPortDataReadIndex+1]==0)&&(res[usedPort.m_COMMPortDataReadIndex+2]==cmd[1]))
			{
				if (msg!=null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "频率电流的第"+(freqPointIndexCMD-3).ToString()+"个点的频率参数获取成功!\r\n", Color.Black, false);
				}

				//---获取起始频率
				_return=res[usedPort.m_COMMPortDataReadIndex+3];
				_return=(_return<<8)+res[usedPort.m_COMMPortDataReadIndex+4];
				_return=(_return<<8)+res[usedPort.m_COMMPortDataReadIndex+5];
				_return=(_return<<8)+res[usedPort.m_COMMPortDataReadIndex+6];

				//---刷新起始频率
				deviceFreq.m_StartFreq=(float)(_return*1.0/100);

				//---获取步进频率
				_return=res[usedPort.m_COMMPortDataReadIndex+7];
				_return=(_return<<8)+res[usedPort.m_COMMPortDataReadIndex+8];

				//---刷新步进频率
				deviceFreq.m_StepFreq=(float)(_return*1.0/100);

				//---获取频率采集点的个数
				_return=res[usedPort.m_COMMPortDataReadIndex+9];
				_return=(_return<<8)+res[usedPort.m_COMMPortDataReadIndex+10];

				//---刷新频率采集点
				deviceFreq.m_StepPointNum=_return;

				//---恢复返回值
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
		/// 设置设备的频率配置参数
		/// </summary>
		/// <param name="freqPointIndex"></param>
		/// <param name="deviceFreq"></param>
		/// <param name="usedPort"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		protected virtual int FreqCurrentSetFreqParm(int freqPointIndexCMD, FreqCurrentControl deviceFreq, COMMPort usedPort, RichTextBox msg = null)
		{
			if (usedPort==null)
			{
				if (msg!=null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "通信端口初始化失败!\r\n", Color.Red, false);
				}
				return 1;
			}
			if (deviceFreq==null)
			{
				if (msg!=null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "频率电流控件传递错误!\r\n", Color.Red, false);
				}
				return 2;
			}
			int _return = 0;
			byte[] cmd = new byte[] {
										(byte)freqPointIndexCMD, (byte)RFASKFreqCurrentPointCMD.CMD_RFASK_CMD1_FREQ_CURRENT_POINT_FREQ_SET,
										0x00,0x00,0x00,0x00,
										0x00,0x00,
										0x00,0x00
									 };

			//---数据填充，起始射频频率
			_return=(int)(deviceFreq.m_StartFreq*100);
			cmd[2]=(byte)(_return>>24);
			cmd[3]=(byte)(_return>>16);
			cmd[4]=(byte)(_return>>8);
			cmd[5]=(byte)(_return);

			//---数据填充，步进射频频率
			_return=(int)(deviceFreq.m_StepFreq*100);
			cmd[6]=(byte)(_return>>8);
			cmd[7]=(byte)(_return);

			//---数据填充，步进射频频率
			_return=(int)(deviceFreq.m_StepPointNum);
			cmd[8]=(byte)(_return>>8);
			cmd[9]=(byte)(_return);

			//---回传的命令
			byte[] res = null;

			//---将命令写入设备并读取返回的值
			_return=usedPort.SendCmdAndReadResponse(cmd, ref res, 300);

			//---通信验证
			if ((_return==0)&&(usedPort.m_COMMBytesPassed==true)&&(res[usedPort.m_COMMPortDataReadIndex+1]==0)&&(res[usedPort.m_COMMPortDataReadIndex+2]==cmd[1]))
			{
				if (msg!=null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "频率电流的第"+(freqPointIndexCMD-3).ToString()+"个点的频率参数设置成功!\r\n", Color.Black, false);
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

		/// <summary>
		/// 获取设备的电流配置参数
		/// </summary>
		/// <param name="freqPointIndex"></param>
		/// <param name="deviceCurrent"></param>
		/// <param name="usedPort"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		protected virtual int FreqCurrentGetCurrentParm(int freqPointIndexCMD, FreqCurrentControl deviceCurrent, COMMPort usedPort, RichTextBox msg = null)
		{
			if (usedPort==null)
			{
				if (msg!=null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "通信端口初始化失败!\r\n", Color.Red, false);
				}
				return 1;
			}
			if (deviceCurrent==null)
			{
				if (msg!=null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "频率电流控件传递错误!\r\n", Color.Red, false);
				}
				return 2;
			}
			int _return = 0;
			byte[] cmd = new byte[] { (byte)freqPointIndexCMD, (byte)RFASKFreqCurrentPointCMD.CMD_RFASK_CMD1_FREQ_CURRENT_POINT_CURRENT_GET };
			byte[] res = null;

			//---将命令写入设备并读取返回的值
			_return=usedPort.SendCmdAndReadResponse(cmd, ref res, 300);

			//---通信验证
			if ((_return==0)&&(usedPort.m_COMMBytesPassed==true)&&(res[usedPort.m_COMMPortDataReadIndex+1]==0)&&(res[usedPort.m_COMMPortDataReadIndex+2]==cmd[1]))
			{
				if (msg!=null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "频率电流的第"+(freqPointIndexCMD-3).ToString()+"个点的电流参数获取成功!\r\n", Color.Black, false);
				}

				//---获取起始最大电流
				_return=res[usedPort.m_COMMPortDataReadIndex+3];
				_return=(_return<<8)+res[usedPort.m_COMMPortDataReadIndex+4];

				//---刷新起始最大电流
				deviceCurrent.m_StartPassMax=(float)(_return*1.0/100);

				//---获取起始最小电流
				_return=res[usedPort.m_COMMPortDataReadIndex+5];
				_return=(_return<<8)+res[usedPort.m_COMMPortDataReadIndex+6];

				//---刷新起始最小电流
				deviceCurrent.m_StartPassMin=(float)(_return*1.0/100);

				//---ADC间隔点数
				_return=res[usedPort.m_COMMPortDataReadIndex+7];
				_return=(_return<<8)+res[usedPort.m_COMMPortDataReadIndex+8];

				//---刷新ADC间隔点数
				deviceCurrent.m_PassSpacePointNum=_return;

				//---ADC合格的最大值
				_return=res[usedPort.m_COMMPortDataReadIndex+9];
				_return=(_return<<8)+res[usedPort.m_COMMPortDataReadIndex+10];

				//---刷新ADC合格的最大值
				deviceCurrent.m_PassSpacePointMax=_return;

				//---ADC合格的最小值
				_return=res[usedPort.m_COMMPortDataReadIndex+11];
				_return=(_return<<8)+res[usedPort.m_COMMPortDataReadIndex+12];

				//---刷新ADC合格的最小值
				deviceCurrent.m_PassSpacePointMin=_return;

				//---获取截止最大电流
				_return=res[usedPort.m_COMMPortDataReadIndex+13];
				_return=(_return<<8)+res[usedPort.m_COMMPortDataReadIndex+14];

				//---刷新截止最大电流
				deviceCurrent.m_StopPassMax=(float)(_return*1.0/100);

				//---获取截止最小电流
				_return=res[usedPort.m_COMMPortDataReadIndex+15];
				_return=(_return<<8)+res[usedPort.m_COMMPortDataReadIndex+16];

				//---刷新截止最小电流
				deviceCurrent.m_StopPassMin=(float)(_return*1.0/100);

				//---恢复返回值
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
		/// 设置设备的电流配置参数
		/// </summary>
		/// <param name="freqPointIndex"></param>
		/// <param name="deviceCurrent"></param>
		/// <param name="usedPort"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		protected virtual int FreqCurrentSetCurrentParm(int freqPointIndexCMD, FreqCurrentControl deviceCurrent, COMMPort usedPort, RichTextBox msg = null)
		{
			if (usedPort==null)
			{
				if (msg!=null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "通信端口初始化失败!\r\n", Color.Red, false);
				}
				return 1;
			}
			if (deviceCurrent==null)
			{
				if (msg!=null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "频率电流控件传递错误!\r\n", Color.Red, false);
				}
				return 2;
			}
			int _return = 0;
			byte[] cmd = new byte[] {
										(byte)freqPointIndexCMD, (byte)RFASKFreqCurrentPointCMD.CMD_RFASK_CMD1_FREQ_CURRENT_POINT_CURRENT_SET,
										0x00,0x00,
										0x00,0x00,
										0x00,0x00,
										0x00,0x00,
										0x00,0x00,
										0x00,0x00,
										0x00,0x00
									};

			//---参数设置---起始频率点的电流最大值
			_return=(int)(deviceCurrent.m_StartPassMax*100);
			cmd[2]=(byte)(_return>>8);
			cmd[3]=(byte)(_return);

			//---参数设置---起始频率点的电流最小值
			_return=(int)(deviceCurrent.m_StartPassMin*100);
			cmd[4]=(byte)(_return>>8);
			cmd[5]=(byte)(_return);

			//---参数设置---ADC采样结果比对的点的间隔数
			_return=(int)(deviceCurrent.m_PassSpacePointNum);
			cmd[6]=(byte)(_return>>8);
			cmd[7]=(byte)(_return);

			//---参数设置---ADC采样结果差值的最大值
			_return=(int)(deviceCurrent.m_PassSpacePointMax);
			cmd[8]=(byte)(_return>>8);
			cmd[9]=(byte)(_return);

			//---参数设置---ADC采样结果差值的最小值
			_return=(int)(deviceCurrent.m_PassSpacePointMin);
			cmd[10]=(byte)(_return>>8);
			cmd[11]=(byte)(_return);

			//---参数设置---终止频率点的电流最大值
			_return=(int)(deviceCurrent.m_StopPassMax*100);
			cmd[12]=(byte)(_return>>8);
			cmd[13]=(byte)(_return);

			//---参数设置---终止频率点的电流最小值
			_return=(int)(deviceCurrent.m_StopPassMin*100);
			cmd[14]=(byte)(_return>>8);
			cmd[15]=(byte)(_return);

			//---返回的结果
			byte[] res = null;

			//---将命令写入设备并读取返回的值
			_return=usedPort.SendCmdAndReadResponse(cmd, ref res, 300);

			//---通信验证
			if ((_return==0)&&(usedPort.m_COMMBytesPassed==true)&&(res[usedPort.m_COMMPortDataReadIndex+1]==0)&&(res[usedPort.m_COMMPortDataReadIndex+2]==cmd[1]))
			{
				if (msg!=null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "频率电流的第"+(freqPointIndexCMD-3).ToString()+"个点的电流参数设置成功!\r\n", Color.Black, false);
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

		/// <summary>
		/// 执行频率电流扫描任务
		/// </summary>
		/// <param name="freqPointIndex"></param>
		/// <param name="deviceCurrent"></param>
		/// <param name="usedPort"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		protected virtual int FreqCurrentDo(int freqPointIndexCMD, FreqCurrentControl deviceCurrent, COMMPort usedPort, RichTextBox msg = null)
		{
			if (usedPort==null)
			{
				if (msg!=null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "通信端口初始化失败!\r\n", Color.Red, false);
				}
				return 1;
			}
			if (deviceCurrent==null)
			{
				if (msg!=null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "频率电流控件传递错误!\r\n", Color.Red, false);
				}
				return 2;
			}
			int _return = 0;
			byte[] cmd = new byte[] { (byte)freqPointIndexCMD, (byte)RFASKFreqCurrentPointCMD.CMD_RFASK_CMD1_FREQ_CURRENT_POINT_DO };
			byte[] res = null;

			//---将命令写入设备并读取返回的值
			_return=usedPort.SendCmdAndReadResponse(cmd, ref res, 1000);

			//---通信验证
			if ((_return==0)&&(usedPort.m_COMMBytesPassed==true)&&(res[usedPort.m_COMMPortDataReadIndex+1]==0)&&(res[usedPort.m_COMMPortDataReadIndex+2]==cmd[1]))
			{
				if (msg!=null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "频率电流的第"+(freqPointIndexCMD-3).ToString()+"个点的频率电流扫描!\r\n", Color.Black, false);

					//---进行一次频率电流扫描消耗的时间
					RichTextBoxPlus.AppendTextInfoWithDateTime(msg, "消耗的时间:"+((int)usedPort.m_UsedTime.Milliseconds).ToString("D")+"ms\r\n", Color.Black, false);
				}
				this.usedSiteCurrent=new RFASKSiteCurrent();
				byte[] siteCurrent = new byte[res.Length-usedPort.m_COMMPortDataReadIndex-4];
				Array.Copy(res, (usedPort.m_COMMPortDataReadIndex+4), siteCurrent, 0, siteCurrent.Length);

				//---获取各个site的电流
				this.usedSiteCurrent.Init(res[usedPort.m_COMMPortDataReadIndex+3], siteCurrent);

				//---打印Log数据
				this.usedSiteCurrent.PrintfLog(msg);
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