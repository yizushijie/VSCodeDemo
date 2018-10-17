using MessageBoxPlusLib;
using RichTextBoxPlusLib;
using System;
using System.Drawing;
using System.IO.Ports;
using System.Management;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace COMMPortLib
{
	public class SerialCOMMPort : COMMPort
	{
		#region 变量定义

		/// <summary>
		/// 通信波特率
		/// </summary>
		private int baudRate = 100000;

		/// <summary>
		/// 数据位
		/// </summary>
		private int dataBits = 8;

		/// <summary>
		/// 奇偶校验
		/// </summary>
		private Parity parityBits = Parity.None;

		/// <summary>
		/// 停止位
		/// </summary>
		private StopBits stopBits = StopBits.One;

		/// <summary>
		/// 使用的串口信息
		/// </summary>
		private SerialPort usedSerialPort = null;

		#endregion 变量定义

		#region 属性定义

		/// <summary>
		/// 设备名称
		/// </summary>
		public override string m_COMMPortName
		{
			get
			{
				return base.m_COMMPortName;
			}
			set
			{
				base.m_COMMPortName = value;
			}
		}

		/// <summary>
		/// 设备索引号
		/// </summary>
		public override int m_COMMPortIndex
		{
			get
			{
				return base.m_COMMPortIndex;
			}
			set
			{
				base.m_COMMPortIndex = value;
			}
		}

		/// <summary>
		///
		/// </summary>
		public override COMMDevice m_COMMDevices
		{
			get
			{
				return base.m_COMMDevices;
			}
		}

		/// <summary>
		/// 工作状态，0---空闲；1---忙；2---错误
		/// </summary>
		public override bool m_COMMPortSTATE
		{
			get
			{
				return base.m_COMMPortSTATE;
			}
			set
			{
				base.m_COMMPortSTATE = value;
			}
		}

		/// <summary>
		/// 当前端口发送数据缓存区的大小
		/// </summary>
		public override int m_COMMPortWriteBufferSize
		{
			get
			{
				return base.m_COMMPortWriteBufferSize;
			}
			set
			{
				base.m_COMMPortWriteBufferSize = value;
			}
		}

		/// <summary>
		/// 发送数据使用的CRC校验方式
		/// </summary>
		public override byte m_COMMPortWriteCRC
		{
			get
			{
				return base.m_COMMPortWriteCRC;
			}
			set
			{
				base.m_COMMPortWriteCRC = value;
			}
		}

		/// <summary>
		/// 当前端口接收数据缓存区的大小
		/// </summary>
		public override int m_COMMPortReadBufferSize
		{
			get
			{
				return base.m_COMMPortReadBufferSize;
			}
			set
			{
				base.m_COMMPortReadBufferSize = value;
			}
		}

		/// <summary>
		/// 读取数据使用的CRC校验方式
		/// </summary>
		public override byte m_COMMPortReadCRC
		{
			get
			{
				return base.m_COMMPortReadCRC;
			}
			set
			{
				base.m_COMMPortReadCRC = value;
			}
		}

		/// <summary>
		/// 耗时时间
		/// </summary>
		public override TimeSpan m_UsedTime
		{
			get
			{
				return base.m_UsedTime;
			}
		}

		/// <summary>
		/// 错误信息
		/// </summary>
		public override string m_COMMPortErrMsg
		{
			get
			{
				return base.m_COMMPortErrMsg;
			}
		}

		/// <summary>
		/// 使用的窗体
		/// </summary>
		public override Form m_UsedForm
		{
			get
			{
				return base.m_UsedForm;
			}
			set
			{
				base.m_UsedForm = value;
			}
		}

		/// <summary>
		/// 接收报头
		/// </summary>
		public override byte m_COMMPortReadID
		{
			get
			{
				return base.m_COMMPortReadID;
			}
			set
			{
				base.m_COMMPortReadID = value;
			}
		}

		/// <summary>
		/// 发送数据报头
		/// </summary>
		public override byte m_COMMPortWriteID
		{
			get
			{
				return base.m_COMMPortWriteID;
			}
			set
			{
				base.m_COMMPortWriteID = value;
			}
		}

		/// <summary>
		/// 多设备通信过程中设备的ID信息
		/// </summary>
		public override bool m_IsEnableMultiDevice
		{
			get
			{
				return base.m_IsEnableMultiDevice;
			}
			set
			{
				base.m_IsEnableMultiDevice = value;
			}
		}

		/// <summary>
		/// 获取多设备在通信时，读取数据的起始位置
		/// </summary>
		public override int m_COMMPortDataReadIndex
		{
			get
			{
				return base.m_COMMPortDataReadIndex;
			}
		}

		#endregion 属性定义

		#region 构造函数

		/// <summary>
		///
		/// </summary>
		public SerialCOMMPort() : base()
		{
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="isEnMultiDevice"></param>
		/// <param name="msg"></param>
		public SerialCOMMPort(Form useForm = null, bool isEnMultiDevice = false, RichTextBox msg = null)
		{
			if (this.m_UsedForm == null)
			{
				this.m_UsedForm = new Form();
			}
			this.m_UsedForm = useForm;
			this.m_IsEnableMultiDevice = isEnMultiDevice;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="useForm"></param>
		/// <param name="bandRate"></param>
		/// <param name="msg"></param>
		public SerialCOMMPort(Form useForm, int useBaudRate, RichTextBox msg = null)
		{
			if (this.m_UsedForm == null)
			{
				this.m_UsedForm = new Form();
			}
			this.m_UsedForm = useForm;

			if (this.baudRate != useBaudRate)
			{
				this.baudRate = useBaudRate;
			}
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="useForm"></param>
		/// <param name="bandRate"></param>
		/// <param name="isEnMultiDevice"></param>
		/// <param name="msg"></param>
		public SerialCOMMPort(Form useForm, int useBaudRate, bool isEnMultiDevice = false, RichTextBox msg = null)
		{
			if (this.m_UsedForm == null)
			{
				this.m_UsedForm = new Form();
			}
			this.m_UsedForm = useForm;

			if (this.baudRate != useBaudRate)
			{
				this.baudRate = useBaudRate;
			}
			this.m_IsEnableMultiDevice = isEnMultiDevice;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="useForm"></param>
		/// <param name="portIndex"></param>
		/// <param name="bandRate"></param>
		/// <param name="msg"></param>
		public SerialCOMMPort(Form useForm, int portIndex, int useBaudRate, RichTextBox msg = null)
		{
			if (this.m_UsedForm == null)
			{
				this.m_UsedForm = new Form();
			}
			this.m_UsedForm = useForm;

			this.m_COMMPortIndex = portIndex;

			if (this.baudRate != useBaudRate)
			{
				this.baudRate = useBaudRate;
			}
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="useForm"></param>
		/// <param name="portIndex"></param>
		/// <param name="bandRate"></param>
		/// <param name="isEnMultiDevice"></param>
		/// <param name="msg"></param>
		public SerialCOMMPort(Form useForm, int portIndex, int useBaudRate, bool isEnMultiDevice = false, RichTextBox msg = null)
		{
			if (this.m_UsedForm == null)
			{
				this.m_UsedForm = new Form();
			}
			this.m_UsedForm = useForm;

			if (this.baudRate != useBaudRate)
			{
				this.baudRate = useBaudRate;
			}

			this.m_IsEnableMultiDevice = isEnMultiDevice;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="useForm"></param>
		/// <param name="portName"></param>
		/// <param name="bandRate"></param>
		/// <param name="msg"></param>
		public SerialCOMMPort(Form useForm, string portName, int useBaudRate, RichTextBox msg = null)
		{
			if (this.m_UsedForm == null)
			{
				this.m_UsedForm = new Form();
			}
			this.m_UsedForm = useForm;

			this.m_COMMPortName = portName;

			if (this.baudRate != useBaudRate)
			{
				this.baudRate = useBaudRate;
			}
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="useForm"></param>
		/// <param name="portName"></param>
		/// <param name="bandRate"></param>
		/// <param name="isEnMultiDevice"></param>
		/// <param name="msg"></param>
		public SerialCOMMPort(Form useForm, string portName, int useBaudRate, bool isEnMultiDevice = false, RichTextBox msg = null)
		{
			if (this.m_UsedForm == null)
			{
				this.m_UsedForm = new Form();
			}
			this.m_UsedForm = useForm;

			this.m_COMMPortName = portName;

			if (this.baudRate != useBaudRate)
			{
				this.baudRate = useBaudRate;
			}

			this.m_IsEnableMultiDevice = isEnMultiDevice;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="useForm"></param>
		/// <param name="writeSize"></param>
		/// <param name="writeCRC"></param>
		/// <param name="writeID"></param>
		/// <param name="msg"></param>
		public SerialCOMMPort(Form useForm, int writeSize, byte writeCRC, byte writeID, RichTextBox msg = null)
		{
			if (this.m_UsedForm == null)
			{
				this.m_UsedForm = new Form();
			}
			this.m_UsedForm = useForm;

			this.m_COMMPortWriteBufferSize = writeSize;
			this.m_COMMPortWriteCRC = writeCRC;
			this.m_COMMPortWriteID = writeID;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="useForm"></param>
		/// <param name="writeSize"></param>
		/// <param name="writeCRC"></param>
		/// <param name="writeID"></param>
		/// <param name="isEnMultiDevice"></param>
		/// <param name="msg"></param>
		public SerialCOMMPort(Form useForm, int writeSize, byte writeCRC, byte writeID, bool isEnMultiDevice = false, RichTextBox msg = null)
		{
			if (this.m_UsedForm == null)
			{
				this.m_UsedForm = new Form();
			}
			this.m_UsedForm = useForm;

			this.m_COMMPortWriteBufferSize = writeSize;
			this.m_COMMPortWriteCRC = writeCRC;
			this.m_COMMPortWriteID = writeID;

			this.m_IsEnableMultiDevice = isEnMultiDevice;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="useForm"></param>
		/// <param name="writeSize"></param>
		/// <param name="writeCRC"></param>
		/// <param name="writeID"></param>
		/// <param name="readSize"></param>
		/// <param name="readCRC"></param>
		/// <param name="readID"></param>
		/// <param name="bandRate"></param>
		/// <param name="msg"></param>
		public SerialCOMMPort(Form useForm, int writeSize, byte writeCRC, byte writeID, int readSize, byte readCRC, byte readID, int useBaudRate, RichTextBox msg = null)
		{
			if (this.m_UsedForm == null)
			{
				this.m_UsedForm = new Form();
			}
			this.m_UsedForm = useForm;

			this.m_COMMPortWriteBufferSize = writeSize;
			this.m_COMMPortWriteCRC = writeCRC;
			this.m_COMMPortWriteID = writeID;

			this.m_COMMPortReadBufferSize = readSize;
			this.m_COMMPortReadCRC = readCRC;
			this.m_COMMPortReadID = readID;

			if (this.baudRate != useBaudRate)
			{
				this.baudRate = useBaudRate;
			}
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="useForm"></param>
		/// <param name="writeSize"></param>
		/// <param name="writeCRC"></param>
		/// <param name="writeID"></param>
		/// <param name="readSize"></param>
		/// <param name="readCRC"></param>
		/// <param name="readID"></param>
		/// <param name="bandRate"></param>
		/// <param name="isEnMultiDevice"></param>
		/// <param name="msg"></param>
		public SerialCOMMPort(Form useForm, int writeSize, byte writeCRC, byte writeID, int readSize, byte readCRC, byte readID, int useBaudRate, bool isEnMultiDevice = false, RichTextBox msg = null)
		{
			if (this.m_UsedForm == null)
			{
				this.m_UsedForm = new Form();
			}
			this.m_UsedForm = useForm;

			this.m_COMMPortWriteBufferSize = writeSize;
			this.m_COMMPortWriteCRC = writeCRC;
			this.m_COMMPortWriteID = writeID;

			this.m_COMMPortReadBufferSize = readSize;
			this.m_COMMPortReadCRC = readCRC;
			this.m_COMMPortReadID = readID;

			if (this.baudRate != useBaudRate)
			{
				this.baudRate = useBaudRate;
			}
			this.m_IsEnableMultiDevice = isEnMultiDevice;
		}

		/// <summary>
		/// 析构函数
		/// </summary>
		~SerialCOMMPort()
		{
			if (this.usedSerialPort != null)
			{
				//---销毁当前对象
				this.usedSerialPort.Dispose();
			}
		}

        #endregion 构造函数

        #region 函数定义


        #endregion

        /// <summary>
		/// 获取校验位信息
		/// </summary>
		/// <param name="parity"></param>
		/// <returns></returns>
		private Parity GetParityBits(string parityBits)
        {
            //---获取校验位
            Parity _return = new Parity();
            //---奇校验
            if (parityBits.StartsWith("奇") || parityBits.StartsWith("Odd") || parityBits.StartsWith("ODD") || parityBits.StartsWith("odd") || parityBits.StartsWith("oDD"))
            {
                _return = Parity.Odd;
            }
            //---偶校验
            else if (parityBits.StartsWith("偶") || parityBits.StartsWith("Even") || parityBits.StartsWith("EVEN") || parityBits.StartsWith("even") || parityBits.StartsWith("eVEN"))
            {
                _return = Parity.Even;
            }
            //---无校验位
            else
            {
                _return = Parity.None;
            }
            return _return;
        }

        /// <summary>
        /// 获取停止位
        /// </summary>
        /// <param name="stopBits"></param>
        /// <returns></returns>
        private StopBits  GetStopBits(string stopBits)
        {
            //---获取校验位
            StopBits _return = new StopBits();
            try
            {
                double stopVal = Math.Truncate(Convert.ToDouble(stopBits));
                int temp = (int)(stopVal * 10);
                //---1位停止位
                if (temp == 10)
                {
                    _return = StopBits.One;
                }
                //---1.5位停止位
                else if (temp == 15)
                {
                    _return = StopBits.OnePointFive;
                }
                //---2位停止位
                else if (temp == 20)
                {
                    _return = StopBits.Two;
                }
                else
                {
                    _return = StopBits.None;
                }
            }
            catch
            {
                _return = StopBits.None;
            }
            return _return;
        }

        #region 重载函数
        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public override int Init()
		{
			return 1;
		}

		/// <summary>
		///
		/// </summary>
		/// <returns></returns>
		public override int Init(int portIndex, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="name"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int Init(string portName, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="index"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int Init(ComboBox cbb, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 刷新设备
		/// </summary>
		/// <returns></returns>
		public override int AddDevice()
		{
            return this.AddDevice(null, null);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="cbb"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int AddDevice(ComboBox cbb, RichTextBox msg = null)
		{
            //---获取记录的设备
            string[] deviceNames = this.m_COMMDevices.deviceNames.ToArray();
            //---刷新当前设备
            string[] tempDeviceNames = SerialPort.GetPortNames();
            //---更新设备记录表
            int _return = this.m_COMMDevices.Init(tempDeviceNames, cbb.Text);
            if ((_return == 0) && (cbb != null))
            {
                cbb.Items.Clear();
                cbb.Items.AddRange(this.m_COMMDevices.deviceNames.ToArray());
                cbb.SelectedIndex = this.m_COMMDevices.deviceUsedIndex;
                if (msg != null)
                {
                    RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "设备添加成功!\r\n", Color.Black, false);
                }
            }
            else
            {
                if (msg != null)
                {
                    RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "设备添加失败!\r\n", Color.Red, false);
                }
            }
            return _return;
		}

		/// <summary>
		///
		/// </summary>
		/// <returns></returns>
		public override int RemoveDevice()
		{
			return this.RemoveDevice(null,null);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="cbb"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int RemoveDevice(ComboBox cbb, RichTextBox msg = null)
		{
            //---获取记录的设备
            string[] deviceNames = this.m_COMMDevices.deviceNames.ToArray();
            //---刷新当前设备
            string[] tempDeviceNames = SerialPort.GetPortNames();
            //---更新设备记录表
            int _return = this.m_COMMDevices.Init(tempDeviceNames, cbb.Text);
            if ((_return == 0) && (cbb != null))
            {
                cbb.Items.Clear();
                cbb.Items.AddRange(this.m_COMMDevices.deviceNames.ToArray());
                cbb.SelectedIndex = this.m_COMMDevices.deviceUsedIndex;
                if (msg != null)
                {
                    RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "设备添加成功!\r\n", Color.Black, false);
                }
            }
            else
            {
                if (msg != null)
                {
                    RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "设备添加失败!\r\n", Color.Red, false);
                }
            }
            return _return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int RefreshDevice()
        {
            return this.RefreshDevice(null,null);
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="cbb"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public override int RefreshDevice(ComboBox cbb, RichTextBox msg = null)
		{
            //---获取当前设备存在的通信端口
            string[] tempDeviceNames= SerialPort.GetPortNames();
            int _return= this.m_COMMDevices.Init(tempDeviceNames,cbb.Text);
            if ((_return==0)&&(cbb!=null))
            {
                cbb.Items.Clear();
                cbb.Items.AddRange(this.m_COMMDevices.deviceNames.ToArray());
                cbb.SelectedIndex = 0;
                if (msg != null)
                {
                    RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "设备刷新成功!\r\n", Color.Black, false);
                }
            }
            else
            {
                if(cbb != null)
                {
                    cbb.Items.Clear();
                    cbb.Text = string.Empty;
                    cbb.SelectedIndex = -1;
                }
                if (this.m_UsedForm!=null)
                {
                    MessageBoxPlus.Show(this.m_UsedForm, "请插入设备!\r\n", "错误提示");
                }
                else
                {
                    if (msg != null)
                    {
                        RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "请插入设备!\r\n", Color.Black, false);
                    }
                    else
                    {
                        MessageBox.Show("请插入设备!\r\n", "错误提示");
                    }
                }
                
            }
            return _return;
        }

		/// <summary>
		///
		/// </summary>
		/// <returns></returns>
		public override int WriteToDevice(byte cmd, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="index"></param>
		/// <param name="cmd"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int WriteToDevice(int portIndex, byte cmd, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="index"></param>
		/// <param name="cmd"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int WriteToDevice(string portName, byte cmd, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="cmd"></param>
		/// <returns></returns>
		public override int WriteToDevice(byte[] cmd, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int WriteToDevice(int portIndex, byte[] cmd, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="portName"></param>
		/// <param name="cmd"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int WriteToDevice(string portName, byte[] cmd, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name=""></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int WriteToDevice(ref byte[] cmd, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="portIndex"></param>
		/// <param name="cmd"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int WriteToDevice(int portIndex, ref byte[] cmd, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="portName"></param>
		/// <param name="cmd"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int WriteToDevice(string portName, ref byte[] cmd, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int ReadFromDevice(ref byte[] cmd, int timeout = 200, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="portIndex"></param>
		/// <param name="cmd"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int ReadFromDevice(int portIndex, ref byte[] cmd, int timeout = 200, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="portName"></param>
		/// <param name="cmd"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int ReadFromDevice(string portName, ref byte[] cmd, int timeout = 200, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 打开设备
		/// </summary>
		/// <returns></returns>
		public override int OpenDevice()
		{
            if (this.usedSerialPort!=null)
            {
                return this.OpenDevice(this.usedSerialPort.PortName,null);
            }
            return 1;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="portIndex"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int OpenDevice(int portIndex, RichTextBox msg = null)
		{
            string str = "COM" + portIndex.ToString();
            return this.OpenDevice(str, msg);
        }

		/// <summary>
		///
		/// </summary>
		/// <param name="portIndex"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int OpenDevice(string portName, RichTextBox msg = null)
		{
            int _return = 1;
            if (((portName != string.Empty) && (portName != null) && (portName != "") && (portName.StartsWith("COM"))))
            {
                this.m_COMMPortErrMsg = string.Empty;
                //---判断串口类是否有效
                if (this.usedSerialPort == null)
                {
                    this.usedSerialPort = new SerialPort();
                }
                //---判断当前端口是否可用
                if (this.usedSerialPort.IsOpen)
                {
                    //---响应窗体事件
                    Application.DoEvents();
                    try
                    {
                        //---关闭端口
                        this.usedSerialPort.Close();
                    }
                    catch
                    {
                        //---端口关闭出现错误
                        this.m_COMMPortErrMsg += "端口：" + this.usedSerialPort.PortName + "被其他应用占用，初始化失败!\r\n";
                        _return = 2;
                        goto GoToExit;
                    }
                }
                //---获取端口名称
                if (this.usedSerialPort.PortName != portName)
                {
                    this.usedSerialPort.PortName = portName;
                    this.m_COMMPortName = portName;
                }
                //---获取端口序号
                this.m_COMMPortIndex = Convert.ToInt16(this.m_COMMPortName.Replace("COM", ""), 10);
                //---设置波特率
                if (this.usedSerialPort.BaudRate != this.baudRate)
                {
                    this.usedSerialPort.BaudRate = this.baudRate;
                }
                //---设置数据位
                if (this.usedSerialPort.DataBits != this.dataBits)
                {
                    this.usedSerialPort.DataBits = this.dataBits;
                }
                //---设置停止位
                if (this.usedSerialPort.StopBits != this.stopBits)
                {
                    this.usedSerialPort.StopBits = this.stopBits;
                }
                //---设置校验位
                if (this.usedSerialPort.Parity != this.parityBits)
                {
                    this.usedSerialPort.Parity = this.parityBits;
                }
                //---打开端口
                try
                {
                    //---打开端口
                    this.usedSerialPort.Open();
                    //---判断端口打开是否成功
                    if (this.usedSerialPort.IsOpen)
                    {
                        this.m_COMMPortErrMsg += "端口：" + this.usedSerialPort.PortName + "打开成功!\r\n";
                        //---清空接收缓存区
                        this.usedSerialPort.DiscardInBuffer();
                        //---清空发送缓存区
                        this.usedSerialPort.DiscardOutBuffer();
                        _return = 0;
                    }
                    else
                    {
                        this.m_COMMPortErrMsg += "端口：" + this.usedSerialPort.PortName + "打开失败!\r\n";
                        _return = 3;
                        goto GoToExit;
                    }
                }
                catch
                {
                    this.m_COMMPortErrMsg += "端口：" + this.usedSerialPort.PortName + "端口被其他应用占用，打开失败!\r\n";
                    _return = 4;
                    goto GoToExit;
                }
                GoToExit:
                if (msg != null)
                {
                    if (_return == 0)
                    {
                        RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.m_COMMPortErrMsg, Color.Black, false);
                    }
                    
                }
                //---消息插件弹出
                if (_return != 0)
                {
                    if (this.m_UsedForm != null)
                    {
                        MessageBoxPlus.Show(this.m_UsedForm, this.m_COMMPortErrMsg, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(this.m_COMMPortErrMsg, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (this.m_UsedForm != null)
                {
                    MessageBoxPlus.Show(this.m_UsedForm, "端口名称不合法!\r\n", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("端口名称不合法!\r\n", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return _return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="portName"></param>
        /// <param name="baudRate"></param>
        /// <param name="dataBits"></param>
        /// <param name="stopBits"></param>
        /// <param name="parityBits"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public override int OpenDevice(string portName, string baudRate, string dataBits, string stopBits, string parityBits, RichTextBox msg = null)
        {
            if (!Regex.IsMatch(baudRate, @"^[+-]?/d*[.]?/d*$")||!Regex.IsMatch(dataBits, @"^[+-]?/d*[.]?/d*$"))
            {
                return 10;
            }
            //---更新波特率
            this.baudRate= Convert.ToInt32(baudRate);
            //---更新数据位
            this.dataBits= Convert.ToInt32(dataBits);
            //---更新停止位
            this.stopBits = this.GetStopBits(stopBits);
            //---更新校验位
            this.parityBits = this.GetParityBits(parityBits);
            //---打开设备
            return this.OpenDevice(portName,msg);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override int CloseDevice()
		{
            int _return = 0;
            if ((this.usedSerialPort!=null)&&this.usedSerialPort.IsOpen)
            {
                try
                {
                    //---响应窗体事件
                    Application.DoEvents();
                    this.usedSerialPort.Close();
                }
                catch
                {
                    _return = 1;
                    this.m_COMMPortErrMsg = "串口关闭发生异常!\r\n";
                }
            }
			return _return;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="portIndex"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int CloseDevice(int portIndex, RichTextBox msg = null)
		{
            string str = "COM" + portIndex.ToString();
            return this.CloseDevice(str,msg);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="portIndex"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int CloseDevice(string portName, RichTextBox msg = null)
		{
            int _return = 2;
            if ((this.usedSerialPort!=null)&&(this.usedSerialPort.PortName==portName))
            {
                _return = this.CloseDevice();
                if (msg != null)
                {
                    if (_return == 0)
                    {
                        RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "端口关闭成功!\r\n", Color.Black, false);
                    }
                    else
                    {
                        RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.m_COMMPortErrMsg, Color.Red, false);
                    }
                }
            }
			return _return;
		}

		/// <summary>
		/// 检测设备
		/// </summary>
		/// <returns></returns>
		public override bool IsAttached()
		{
            if (this.usedSerialPort!=null)
            {
                return this.usedSerialPort.IsOpen;
            }
			return false;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="portIndex"></param>
		/// <returns></returns>
		public override bool IsAttached(int portIndex)
		{
            string str = "COM" + portIndex.ToString();
            return this.IsAttached(str);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="portIndex"></param>
		/// <returns></returns>
		public override bool IsAttached(string portName)
		{
            if (this.usedSerialPort!=null)
            {
                if (this.usedSerialPort.PortName==portName)
                {
                    return this.usedSerialPort.IsOpen;
                }
            }
			return false;
		}

		#endregion 函数定义

		#region 事件定义

		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public override void DataReceivedHandler(object sender, EventArgs e)
		{
			if (e.ToString() == "SerialDataReceivedEventArgs")
			{
			}
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public override void WatcherPortEventHandler(Object sender, EventArrivedEventArgs e, ComboBox cbb=null, RichTextBox msg = null)
		{
			if (e.NewEvent.ClassPath.ClassName == "__InstanceCreationEvent")
			{
                //---设备插入
                this.AddDevice(cbb, msg);
			}
			else if (e.NewEvent.ClassPath.ClassName == "__InstanceDeletionEvent")
			{
                //---设备移除
                this.RemoveDevice(cbb, msg);
			}
		}

		#endregion 事件定义
	}
}