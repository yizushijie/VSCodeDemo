using RichTextBoxPlusLib;
using System;
using System.Drawing;
using System.IO.Ports;
using System.Management;
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
		private string parity = "NONE";

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
			return 1;
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
			return 1;
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
                if (msg != null)
                {
                    msg.Clear();
                    RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "请插入设备!\r\n", Color.Black, false);
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
			return 1;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="portIndex"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int OpenDevice(string portName, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		///
		/// </summary>
		/// <returns></returns>
		public override int CloseDevice()
		{
			return 1;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="portIndex"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int CloseDevice(int portIndex, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="portIndex"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int CloseDevice(string portName, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 检测设备
		/// </summary>
		/// <returns></returns>
		public override bool IsAttached()
		{
			return false;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="portIndex"></param>
		/// <returns></returns>
		public override bool IsAttached(int portIndex)
		{
			return false;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="portIndex"></param>
		/// <returns></returns>
		public override bool IsAttached(string portName)
		{
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
				this.m_COMMPortErrMsg = "设备插入！\r\n";
                this.AddDevice(cbb, msg);
				if (msg != null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.m_COMMPortErrMsg, Color.Black, false);
				}
			}
			else if (e.NewEvent.ClassPath.ClassName == "__InstanceDeletionEvent")
			{
				this.m_COMMPortErrMsg = "设备拔出！\r\n";
                this.RemoveDevice(cbb, msg);
                if (msg != null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.m_COMMPortErrMsg, Color.Red, false);
				}
			}
		}

		#endregion 事件定义
	}
}