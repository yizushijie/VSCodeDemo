using COMMPortLib;
using MessageBoxPlusLib;
using RichTextBoxPlusLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RFASKFreqCurrentScanLib
{

	public enum CMD_RFASK_CLK : byte
	{
		CMD_RFASK_FREQ				=0x01,			//---设置命令的主命令
		CMD_RFASK_SUB_SET_WM8510	=0x01,			//---设置WM8510的输出
		CMD_RFASK_SUB_GET_WM8510	=0x02,			//---读取WM8510的输出
		CMD_RFASK_SUB_RESET_WM8510	=0x03,			//---复位WM8510设备
		CMD_RFASK_SUB_SET_CLK_CHANNEL		=0x04,			//---使能输出的通道
	}

	public partial class RFASKFreqCurrentScan
    {
        #region 变量定义
        /// <summary>
		/// 使用的通信端口
		/// </summary>
		private COMMPort usedPort = null;

        /// <summary>
        /// 使用的窗体
        /// </summary>
        private Form usedForm = null;

        #endregion

        #region 属性定义

        /// <summary>
        /// 属性只读
        /// </summary>
        public COMMPort m_COMMPort
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
        public RFASKFreqCurrentScan()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="useForm"></param>
        /// <param name="usePort"></param>
        /// <param name="cbb"></param>
        /// <param name="msg"></param>
        public RFASKFreqCurrentScan(Form useForm, COMMPort usePort=null, ComboBox cbb = null, RichTextBox msg = null)
        {
            if (this.usedForm==null)
            {
                this.usedForm = new Form();
            }
            this.usedForm = useForm;

            if (usePort!=null)
            {
                if (this.usedPort==null)
                {
                    this.usedPort = new COMMPort();
                }
                this.usedPort = usePort;
            }
        }

        #endregion

        #region 析构函数

        /// <summary>
        /// 
        /// </summary>
        ~RFASKFreqCurrentScan()
        {
            
        }

		#endregion

		#region 函数定义

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int OpenDevice(string name, RichTextBox msg = null)
		{
			if (this.usedPort != null)
			{
				return this.usedPort.OpenDevice(name, msg);
			}
			else
			{
				if (this.usedForm != null)
				{
					MessageBoxPlus.Show(this.usedForm, "通信端口初始化失败!\r\n", "错误提示");
				}
				else
				{
					MessageBox.Show("通信端口初始化失败!\r\n", "错误提示");
				}
			}
			return 1;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="name"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int CloseDevice(string name, RichTextBox msg = null)
		{
			if (this.usedPort != null)
			{
				return this.usedPort.CloseDevice(name, msg);
			}
			else
			{
				if (this.usedForm != null)
				{
					MessageBoxPlus.Show(this.usedForm, "通信端口初始化失败!\r\n", "错误提示");
				}
				else
				{
					MessageBox.Show("通信端口初始化失败!\r\n", "错误提示");
				}
			}
			return 1;
		}

		/// <summary>
		/// 设备频率的频率输出
		/// </summary>
		/// <param name="name"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int WriteFreqHzToDevice(NumericUpDown nd, RichTextBox msg = null)
		{
			int _return = 0;
			if ((this.usedPort!=null)&&(this.usedPort.IsAttached()==true))
			{
				UInt32 freqVal = Convert.ToUInt32(nd.Value);
				byte[] cmd = new byte[] { 0x55, 0x06, (byte)CMD_RFASK_CLK.CMD_RFASK_FREQ, (byte)CMD_RFASK_CLK.CMD_RFASK_SUB_SET_WM8510, 0x00, 0x00, 0x00, 0x00 };
				cmd[4] = (byte)(freqVal >> 24);
				cmd[5] = (byte)(freqVal >> 16);
				cmd[6] = (byte)(freqVal >> 8);
				cmd[7] = (byte)(freqVal);
				byte[] res = null;
				_return = this.usedPort.SendCmdAndReadResponse(cmd, ref res, 300);
				if ((this.usedPort.IsReadValidData(_return)) &&(res!=null)&&(res[0]==this.usedPort.m_COMMPortReceID)&&(res[2 + this.usedPort.m_DeviceIDIndex]== (byte)CMD_RFASK_CLK.CMD_RFASK_FREQ)&&(res[3 + this.usedPort.m_DeviceIDIndex] == (byte)CMD_RFASK_CLK.CMD_RFASK_SUB_SET_WM8510)&&(res[4 + this.usedPort.m_DeviceIDIndex]==0))
				{
					if (msg!=null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "时钟频率设置成功!\r\n", Color.Black, false);
					}
				}
				else
				{
					if (msg != null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "时钟频率设置失败!\t"+this.usedPort.m_COMMPortErrMsg, Color.Red, false);
					}
				}
			}
			else
			{
				if (this.usedForm != null)
				{
					MessageBoxPlus.Show(this.usedForm, "通信端口初始化失败!\r\n", "错误提示");
				}
				else
				{
					MessageBox.Show("通信端口初始化失败!\r\n", "错误提示");
				}
			}
			return _return;
		}

		/// <summary>
		/// 读取设备的输出频率
		/// </summary>
		/// <param name="nd"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int ReadFreqHzFromDevice(NumericUpDown nd, RichTextBox msg = null)
		{
			int _return = 0;
			if ((this.usedPort != null) && (this.usedPort.IsAttached() == true))
			{
				UInt32 writeFreqVal = Convert.ToUInt32(nd.Value);
				byte[] cmd = new byte[] { (byte)CMD_RFASK_CLK.CMD_RFASK_FREQ, (byte)CMD_RFASK_CLK.CMD_RFASK_SUB_GET_WM8510};
				byte[] res = null;
				_return = this.usedPort.SendCmdAndReadResponse(cmd, ref res,true, 300);
				if ((this.usedPort.IsReadValidData(_return)) && (res != null) && (res[0] == this.usedPort.m_COMMPortReceID) && (res[2 + this.usedPort.m_COMMReceCMDIndex] == (byte)CMD_RFASK_CLK.CMD_RFASK_FREQ) && (res[3 + this.usedPort.m_COMMReceCMDIndex] == (byte)CMD_RFASK_CLK.CMD_RFASK_SUB_GET_WM8510) && (res[4 + this.usedPort.m_COMMReceCMDIndex] == 0))
				{
					if (msg != null)
					{
						string str = null;
						UInt32 readFreqVal = res[5 + this.usedPort.m_COMMReceCMDIndex];
						readFreqVal=(readFreqVal<<8)+ res[6 + this.usedPort.m_COMMReceCMDIndex];
						readFreqVal = (readFreqVal << 8) + res[7 + this.usedPort.m_COMMReceCMDIndex];
						readFreqVal = (readFreqVal << 8) + res[8 + this.usedPort.m_COMMReceCMDIndex];
						if (readFreqVal>writeFreqVal)
						{
							if ((readFreqVal-writeFreqVal)>100000)
							{
								RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "时钟频率校验错误!\t"+readFreqVal.ToString() + "\t检验精度+/-10KHz" + "\r\n", Color.Red, false);
							}
							else
							{
								str = "校验之后的频率是：" + readFreqVal.ToString() + "Hz\t";
								RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "时钟频率校验成功!\t" + str + "检验精度+/-10KHz" + "\r\n", Color.Black, false);
							}
						}
						else
						{
							if ((writeFreqVal - readFreqVal) > 100000)
							{
								RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "时钟频率校验错误!\t" + readFreqVal.ToString()+ "\t验精度+/-10KHz" + "\r\n", Color.Red, false);
							}
							else
							{
								str = "校验之后的频率是：" + readFreqVal.ToString() + "Hz\t";
								RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "时钟频率校验成功!\t" + str + "检验精度+/-10KHz"+"\r\n", Color.Black, false);
							}
						}
					}
				}
				else
				{
					if (msg != null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "时钟频率设置失败!\t" + this.usedPort.m_COMMPortErrMsg, Color.Red, false);
					}
				}
			}
			else
			{
				if (this.usedForm != null)
				{
					MessageBoxPlus.Show(this.usedForm, "通信端口初始化失败!\r\n", "错误提示");
				}
				else
				{
					MessageBox.Show("通信端口初始化失败!\r\n", "错误提示");
				}
			}
			return _return;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int ResetFreqHzToDevice(NumericUpDown nd,RichTextBox msg = null)
		{
			int _return = 0;
			if ((this.usedPort != null) && (this.usedPort.IsAttached() == true))
			{
				byte[] cmd = new byte[] { (byte)CMD_RFASK_CLK.CMD_RFASK_FREQ, (byte)CMD_RFASK_CLK.CMD_RFASK_SUB_RESET_WM8510 };
				byte[] res = null;
				_return = this.usedPort.SendCmdAndReadResponse(cmd, ref res, true, 300);
				if ((this.usedPort.IsReadValidData(_return)) && (res != null) && (res[0] == this.usedPort.m_COMMPortReceID) && (res[2 + this.usedPort.m_COMMReceCMDIndex] == (byte)CMD_RFASK_CLK.CMD_RFASK_FREQ) && (res[3 + this.usedPort.m_COMMReceCMDIndex] == (byte)CMD_RFASK_CLK.CMD_RFASK_SUB_RESET_WM8510) && (res[4 + this.usedPort.m_COMMReceCMDIndex] == 0))
				{
					if (msg != null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "时钟设备复位成功!\r\n", Color.Black, false);
					}
					nd.Value = nd.Minimum;
				}
				else
				{
					if (msg != null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "时钟设备复位失败!\t" + this.usedPort.m_COMMPortErrMsg, Color.Red, false);
					}
				}
			}
			else
			{
				if (this.usedForm != null)
				{
					MessageBoxPlus.Show(this.usedForm, "通信端口初始化失败!\r\n", "错误提示");
				}
				else
				{
					MessageBox.Show("通信端口初始化失败!\r\n", "错误提示");
				}
			}
			return _return;
		}

		#endregion

		#region 事件定义
		/// <summary>
		/// 
		/// </summary>
		/// <param name="m"></param>
		/// <param name="cbb"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int DevicesChangedEvent(ref Message m, ComboBox cbb = null, RichTextBox msg = null)
        {
            if (this.usedPort != null)
            {
                return this.usedPort.DevicesChangedEvent(ref m, cbb, msg);
            }
            return 0;
        }
        #endregion

    }
}
