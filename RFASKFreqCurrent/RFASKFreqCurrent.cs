using COMMPortLib;
using RichTextBoxPlusLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UserControlPlusLib;

namespace RFASKFreqCurrentLib
{
    /// <summary>
    /// 命令枚举
    /// </summary>
    public enum RFASKFreqCurrentPointCMD : byte
    {
		CMD_RFASK_CMD1_FREQ_CURRENT_POINT_FREQ_GET		=0x01,
		CMD_RFASK_CMD1_FREQ_CURRENT_POINT_FREQ_SET		=0x02,
		CMD_RFASK_CMD1_FREQ_CURRENT_POINT_CURRENT_GET	=0x03,
		CMD_RFASK_CMD1_FREQ_CURRENT_POINT_CURRENT_SET	=0x04,
		CMD_RFASK_CMD1_FREQ_CURRENT_POINT_DO			=0x05
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

        #endregion

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
         

        #endregion

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
            if (usedPort == null)
            {
                this.usedPort = new COMMPort();
            }
            this.usedPort = usePort;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="useForm"></param>
        /// <param name="usePort"></param>
        public RFASKFreqCurrent(Form useForm,COMMPort usePort)
        {
            if (usedPort==null)
            {
                this.usedPort = new COMMPort();
            }
            this.usedPort = usePort;
        }



        #endregion

        #region 析构函数

        /// <summary>
        /// 析构函数
        /// </summary>
        ~RFASKFreqCurrent()
        {
            GC.SuppressFinalize(this);
        }

		#endregion

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
		public virtual int FreqCurrentSet(int index,int freqPointIndex , FreqCurrentControl deviceFreqCurrent, COMMPort usedPort, RichTextBox msg = null)
		{
			int _return = 0;
			int cmd = 0;
			//---第几个扫描任务的解析
			switch (freqPointIndex)
			{
				case 1:
					cmd = CMD_RFASK_CMD1_FREQ_CURRENT_POINT_ONE;
					break;
				case 2:
					cmd = CMD_RFASK_CMD1_FREQ_CURRENT_POINT_TWO;
					break;
				default:
					if (msg != null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "频率电流扫描任务命令不合法!\r\n", Color.Red, false);
					}
					return 1;
			}
			//---频率电流扫描执行的操作
			switch (index)
			{
				case 1:
					_return = this.FreqCurrentGetFreqParm(cmd, deviceFreqCurrent, usedPort, msg);
					break;
				case 2:
					_return = this.FreqCurrentSetFreqParm(cmd, deviceFreqCurrent, usedPort, msg);
					break;
				case 3:
					_return = this.FreqCurrentGetCurrentParm(cmd, deviceFreqCurrent, usedPort, msg);
					break;
				case 4:
					_return = this.FreqCurrentSetCurrentParm(cmd, deviceFreqCurrent, usedPort, msg);
					break;
				case 5:
					_return = this.FreqCurrentDo(cmd, deviceFreqCurrent, usedPort, msg);
					break;
				default:
					if (msg != null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "频率电流扫描操作不合法!\r\n", Color.Red, false);
					}
					_return = 1;
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
		protected virtual int FreqCurrentGetFreqParm(int freqPointIndexCMD,FreqCurrentControl deviceFreq, COMMPort usedPort, RichTextBox msg = null)
		{
			if (usedPort == null)
			{
				if (msg != null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "通信端口初始化失败!\r\n", Color.Red, false);
				}
				return 1;
			}
			if (deviceFreq == null)
			{
				if (msg != null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "频率电流控件传递错误!\r\n", Color.Red, false);
				}
				return 2;
			}
			int _return = 0;
			byte[] cmd = new byte[] { (byte)freqPointIndexCMD, (byte)RFASKFreqCurrentPointCMD.CMD_RFASK_CMD1_FREQ_CURRENT_POINT_FREQ_GET };
			byte[] res = null;
			//---将命令写入设备并读取返回的值
			_return = usedPort.SendCmdAndReadResponse(cmd, ref res, 300);
			//---通信验证
			if ((_return == 0) && (usedPort.m_COMMBytesPassed == true) && (res[usedPort.m_COMMPortDataReadIndex + 1] == 0) && (res[usedPort.m_COMMPortDataReadIndex + 2] == cmd[1]))
			{
				if (msg != null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "频率电流的频率参数获取成功!\r\n", Color.Black, false);
				}
				//---获取起始频率
				_return = res[usedPort.m_COMMPortDataReadIndex + 3];
				_return=(_return<<8)+ res[usedPort.m_COMMPortDataReadIndex + 4];
				_return = (_return << 8) + res[usedPort.m_COMMPortDataReadIndex + 5];
				_return = (_return << 8) + res[usedPort.m_COMMPortDataReadIndex + 6];
				//---刷新起始频率
				deviceFreq.m_StartFreq=(float)(_return*1.0/100);
				//---获取步进频率
				_return = res[usedPort.m_COMMPortDataReadIndex + 7];
				_return = (_return << 8) + res[usedPort.m_COMMPortDataReadIndex + 8];
				//---刷新步进频率
				deviceFreq.m_StepFreq = (float)(_return * 1.0 / 100);
				//---获取频率采集点的个数
				_return = res[usedPort.m_COMMPortDataReadIndex + 9];
				_return = (_return << 8) + res[usedPort.m_COMMPortDataReadIndex + 10];
				//---刷新频率采集点
				deviceFreq.m_StepPointNum = _return;
				//---恢复返回值
				_return = 0;
			}
			else
			{
				if (_return != 0)
				{
					if (msg != null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "通信发生错误!\r\n", Color.Red, false);
					}
				}
				else if (usedPort.m_COMMBytesPassed == false)
				{
					if (msg != null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "读取的数据格式不合法!\r\n", Color.Red, false);
					}
				}
				else if (res[usedPort.m_COMMPortDataReadIndex + 1] != 0)
				{
					if (msg != null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "数据返回的结果错误!\r\n", Color.Red, false);
					}
				}
				else
				{
					if (msg != null)
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
			int _return = 0;
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
			int _return = 0;
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
			int _return = 0;
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
			int _return = 0;
			return _return;
		}

		#endregion

		#region 事件定义

		#endregion

	}
}
