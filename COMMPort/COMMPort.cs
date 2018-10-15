using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace COMMPortLib
{
	/// <summary>
	/// CRC检验方式
	/// </summary>
	public enum USE_CRC : byte
	{
		CRC_NONE = 0,           //---无校验方式
		CRC_CHECKSUM = 1,           //---检验和
		CRC_CRC8 = 2,           //---CRC8校验
		CRC_CRC16 = 3,          //---CRC16校验
		CRC_CRC32 = 4,          //---CRC32校验
	};

	/// <summary>
	/// 
	/// </summary>
	public enum USE_STATE : byte
	{
		IDLE = 0,                       //---空闲状态
		BUSY = 1,                       //---忙状态
		ERROR = 2,                      //---错误状态
	};

	/// <summary>
	/// 
	/// </summary>
	public class COMMDevice
	{

		#region 变量定义

		/// <summary>
		/// 设备名称集合
		/// </summary>
		public List<string> deviceNames = null;

		/// <summary>
		/// 当前使用设备的名称
		/// </summary>
		public string deviceUsedName = null;

		/// <summary>
		/// 当前使用设备的序号
		/// </summary>
		public int deviceUsedIndex = -1;

		/// <summary>
		/// 当前设备状态，打开----true；关闭---false；
		/// </summary>
		public bool deviceIsOpen = false;

		#endregion

		#region 构造函数

		/// <summary>
		/// 
		/// </summary>
		public COMMDevice()
		{
			this.Init();
		}

		#endregion

		#region 函数定义

		/// <summary>
		/// 
		/// </summary>
		public void Init()
		{
			this.deviceNames = null;
			this.deviceUsedName = null;
			this.deviceUsedIndex = -1;
			this.deviceIsOpen = false;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="names"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public int Init(string[] names,string name=null)
		{
			//---判断当前设备是否存在通信设备
			if ((names == null) || (names.Length == 0))
			{
				this.Init();
				return 1;
			}
			//---获取端口的序号
			int[] namesIndex = new int[names.Length];
			int index = 0;
			int errDeviceNameCount = 0;
			string str = "";
			//---遍历端口信息
			for (index = 0; index < names.Length; index++)
			{
				//---判断端口名称是否合法
				if (names[index].StartsWith("COM") || names[index].StartsWith("com"))
				{
					//---去除字符串中非数字字符
					str = Regex.Replace(names[index], @"[^\d]*", "");
					//---将字符串转换成数字
					namesIndex[index - errDeviceNameCount] = (int.Parse(str));
				}
				else
				{
					errDeviceNameCount++;
				}
			}
			//---重置缓存区的大小
			Array.Resize<int>(ref namesIndex, (index - errDeviceNameCount));
			//---数组从小到大排序
			int[] temp = namesIndex.OrderBy(x => x).ToArray();
			//---数据合法
			if ((temp == null) || (temp.Length == 0))
			{
				return 2;
			}
			//---存储端口信息
			if (this.deviceNames==null)
			{
				this.deviceNames = new List<string>();
			}
			//---更新端口信息
			for (index = 0; index < temp.Length; index++)
			{
				str = "COM" + Convert.ToString(temp[index]);
				if ((name!=null)&&(name!=string.Empty)&&(name!=""))
				{
					if (name==str)
					{
						this.deviceUsedName = name;
						this.deviceUsedIndex = index;
					}
				}
				this.deviceNames.Add(str);
			}
			return 0;
		}

		#endregion
	}

	/// <summary>
	/// 通信端口
	/// </summary>
	public partial class COMMPort 
	{

		#region 变量定义
		/// <summary>
		/// 设备名称
		/// </summary>
		private string commPortName = null;

		/// <summary>
		/// 设备索引号
		/// </summary>
		private int commPortIndex = 0;

        /// <summary>
        /// 设备的端口信息
        /// </summary>
        private COMMDevice commDevices = new COMMDevice();

		/// <summary>
		/// 工作状态，0---空闲；1---忙；2---错误
		/// </summary>
		private bool commPortSTATE = false;

		/// <summary>
		/// 当前端口发送数据缓存区的大小
		/// </summary>
		private int commPortWriteBufferSize = 64;

		/// <summary>
		/// 发送数据使用的CRC校验方式
		/// </summary>
		private byte commPortWriteCRC = 0;//(byte)USE_CRC.CRC_CRC8;//0;

		/// <summary>
		/// 当前端口接收数据缓存区的大小
		/// </summary>
		private int commPortReadBufferSize = 64;

		/// <summary>
		/// 读取数据使用的CRC校验方式
		/// </summary>
		private byte commPortReadCRC = 0;//(byte)USE_CRC.CRC_CRC8;//0;

		/// <summary>
		/// 耗时时间
		/// </summary>
		private TimeSpan usedTime=TimeSpan.MinValue;

		/// <summary>
		/// 错误信息
		/// </summary>
		private string commPortErrMsg = string.Empty;

		/// <summary>
		/// 使用的窗体
		/// </summary>
		private Form usedForm = null;

		/// <summary>
		/// 接收报头
		/// </summary>
		private byte commPortReadID = 0x5A;

		/// <summary>
		/// 发送数据报头
		/// </summary>
		private byte commPortWriteID = 0x55;

		/// <summary>
		/// 是否使能多设备通信，一个串口带多个设备，使能---true，不使能---false
		/// </summary>
		private bool isEnableMultiDevice = false;

		#endregion

		#region 属性定义
		/// <summary>
		/// 设备名称
		/// </summary>
		public virtual string m_COMMPortName
		{
			get
			{
				return this.commPortName;
			}
			set
			{
				this.commPortName = value;
			}
		}

		/// <summary>
		/// 设备索引号
		/// </summary>
		public virtual int m_COMMPortIndex
		{
			get
			{
				return this.commPortIndex;
			}
			set
			{
				this.commPortIndex = value;
			}
		}

        /// <summary>
        /// 
        /// </summary>
        public virtual COMMDevice m_COMMDevices
        {
            get
            {
                return this.commDevices;
            }
        }

		/// <summary>
		/// 工作状态，0---空闲；1---忙；2---错误
		/// </summary>
		public virtual bool m_COMMPortSTATE
		{
			get
			{
				return this.commPortSTATE;
			}
			set
			{
				this.commPortSTATE = value;
			}
		}

		/// <summary>
		/// 当前端口发送数据缓存区的大小
		/// </summary>
		public virtual int m_COMMPortWriteBufferSize
		{
			get
			{
				return this.commPortWriteBufferSize;
			}
			set
			{
				this.commPortWriteBufferSize = value;
			}
		}

		/// <summary>
		/// 发送数据使用的CRC校验方式
		/// </summary>
		public virtual byte m_COMMPortWriteCRC
		{
			get
			{
				return this.commPortWriteCRC;
			}
			set
			{
				this.commPortWriteCRC = value;
			}
		}

		/// <summary>
		/// 当前端口接收数据缓存区的大小
		/// </summary>
		public virtual int m_COMMPortReadBufferSize
		{
			get
			{
				return this.commPortReadBufferSize;
			}
			set
			{
				this.commPortReadBufferSize=value;
			}
		}

		/// <summary>
		/// 读取数据使用的CRC校验方式
		/// </summary>
		public virtual byte m_COMMPortReadCRC
		{
			get
			{
				return this.commPortReadCRC;
			}
			set
			{
				this.commPortReadCRC = value;
			}
		}

		/// <summary>
		/// 耗时时间
		/// </summary>
		public virtual TimeSpan m_UsedTime
		{
			get
			{
				return this.usedTime;
			}
		}

		/// <summary>
		/// 错误信息
		/// </summary>
		public virtual string m_COMMPortErrMsg
		{
			get
			{
				return this.commPortErrMsg;
			}
			set
			{
				this.commPortErrMsg = value;
			}
		}

		/// <summary>
		/// 使用的窗体
		/// </summary>
		public virtual Form m_UsedForm
		{
			get
			{
				return this.usedForm;
			}
			set
			{
				this.usedForm = value;
			}
		}

		/// <summary>
		/// 接收报头
		/// </summary>
		public virtual byte m_COMMPortReadID
		{
			get
			{
				return this.commPortReadID;
			}
			set
			{
				this.commPortReadID = value;
			}
		}

		/// <summary>
		/// 发送数据报头
		/// </summary>
		public virtual byte m_COMMPortWriteID
		{
			get
			{
				return this.commPortWriteID;
			}
			set
			{
				this.commPortWriteID = value;
			}
		}

		/// <summary>
		/// 多设备通信过程中设备的ID信息
		/// </summary>
		public virtual bool m_IsEnableMultiDevice
		{
			get
			{
				return this.isEnableMultiDevice;
			}
			set
			{
				this.isEnableMultiDevice = value;
			}
		}

		/// <summary>
		/// 获取多设备在通信时，读取数据的起始位置
		/// </summary>
		public virtual int m_COMMPortDataReadIndex
		{
			get
			{
				int _return = 0;
				if (this.isEnableMultiDevice==true)
				{
					if (this.commPortReadBufferSize>0xFF)
					{
						_return = 4; 
					}
					else
					{
						_return = 3;
					}
				}
				else
				{
					if (this.commPortReadBufferSize > 0xFF)
					{
						_return = 3;
					}
					else
					{
						_return = 2;
					}
				}
				return _return;
			}
		}

		#endregion

		#region 构造函数

		/// <summary>
		/// 
		/// </summary>
		public COMMPort()
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="isEnMultiDevice"></param>
		/// <param name="msg"></param>
		public COMMPort(Form useForm=null,bool isEnMultiDevice = false, RichTextBox msg = null)
		{
			
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="useForm"></param>
		/// <param name="bandRate"></param>
		/// <param name="msg"></param>
		public COMMPort(Form useForm, int bandRate, RichTextBox msg = null)
		{
			
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="useForm"></param>
		/// <param name="bandRate"></param>
		/// <param name="isEnMultiDevice"></param>
		/// <param name="msg"></param>
		public COMMPort(Form useForm, int bandRate, bool isEnMultiDevice = false, RichTextBox msg = null)
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="useForm"></param>
		/// <param name="portIndex"></param>
		/// <param name="bandRate"></param>
		/// <param name="msg"></param>
		public COMMPort(Form useForm,int portIndex, int bandRate, RichTextBox msg = null)
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="useForm"></param>
		/// <param name="portIndex"></param>
		/// <param name="bandRate"></param>
		/// <param name="isEnMultiDevice"></param>
		/// <param name="msg"></param>
		public COMMPort(Form useForm, int portIndex, int bandRate, bool isEnMultiDevice = false, RichTextBox msg = null)
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="useForm"></param>
		/// <param name="portName"></param>
		/// <param name="bandRate"></param>
		/// <param name="msg"></param>
		public COMMPort(Form useForm, string portName, int bandRate, RichTextBox msg = null)
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="useForm"></param>
		/// <param name="portName"></param>
		/// <param name="bandRate"></param>
		/// <param name="isEnMultiDevice"></param>
		/// <param name="msg"></param>
		public COMMPort(Form useForm, string portName, int bandRate, bool isEnMultiDevice = false, RichTextBox msg = null)
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="useForm"></param>
		/// <param name="writeSize"></param>
		/// <param name="writeCRC"></param>
		/// <param name="writeID"></param>
		/// <param name="msg"></param>
		public COMMPort(Form useForm, int writeSize, byte writeCRC, byte writeID,RichTextBox msg = null)
		{

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
		public COMMPort(Form useForm, int writeSize, byte writeCRC, byte writeID, bool isEnMultiDevice = false, RichTextBox msg = null)
		{

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
		public COMMPort(Form useForm,int writeSize,byte writeCRC,byte writeID,int readSize,byte readCRC,byte readID,int bandRate, RichTextBox msg = null)
		{

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
		public COMMPort(Form useForm, int writeSize, byte writeCRC, byte writeID, int readSize, byte readCRC, byte readID, int bandRate, bool isEnMultiDevice = false, RichTextBox msg = null)
		{

		}

		#endregion

		#region 函数定义

		/// <summary>
		/// 初始化
		/// </summary>
		/// <returns></returns>
		public virtual int Init()
		{
			return 1;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public virtual int Init(int portIndex, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int Init(string portName, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="index"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int Init(ComboBox cbb, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 刷新设备
		/// </summary>
		/// <returns></returns>
		public virtual int AddDevice()
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cbb"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int AddDevice(ComboBox cbb, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public virtual int RemoveDevice()
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cbb"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int RemoveDevice(ComboBox cbb, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cbb"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int RefreshDevice(ComboBox cbb, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public virtual int WriteToDevice(byte cmd, RichTextBox msg = null)
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
		public virtual int WriteToDevice(int portIndex,byte cmd, RichTextBox msg = null)
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
		public virtual int WriteToDevice(string portName, byte cmd, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cmd"></param>
		/// <returns></returns>
		public virtual int WriteToDevice(byte[] cmd, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int WriteToDevice(int portIndex, byte[] cmd, RichTextBox msg = null)
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
		public virtual int WriteToDevice(string portName, byte[] cmd, RichTextBox msg = null)
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
		public virtual int WriteToDevice(ref byte[] cmd, RichTextBox msg = null)
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
		public virtual int WriteToDevice(int portIndex, ref byte[] cmd, RichTextBox msg = null)
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
		public virtual int WriteToDevice(string portName, ref byte[] cmd, RichTextBox msg = null)
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
		public virtual int ReadFromDevice(ref byte[] cmd,int timeout=200, RichTextBox msg = null)
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
		public virtual int ReadFromDevice(int portIndex,ref byte[] cmd, int timeout = 200, RichTextBox msg = null)
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
		public virtual int ReadFromDevice(string portName, ref byte[] cmd, int timeout = 200, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 打开设备
		/// </summary>
		/// <returns></returns>
		public virtual int OpenDevice()
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="portIndex"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int OpenDevice(int portIndex, RichTextBox msg = null)
		{
			return 1;
		}
	
		/// <summary>
		/// 
		/// </summary>
		/// <param name="portIndex"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int OpenDevice(string portName, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public virtual int CloseDevice()
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="portIndex"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int CloseDevice(int portIndex, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="portIndex"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int CloseDevice(string portName, RichTextBox msg = null)
		{
			return 1;
		}

		/// <summary>
		/// 检测设备
		/// </summary>
		/// <returns></returns>
		public virtual bool IsAttached()
		{
			return false;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="portIndex"></param>
		/// <returns></returns>
		public virtual bool IsAttached(int portIndex)
		{
			return false;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="portIndex"></param>
		/// <returns></returns>
		public virtual bool IsAttached(string portName)
		{
			return false;
		}

		#endregion

		#region 事件定义

		/// <summary>
		/// 数据接收事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public virtual void DataReceivedHandler(object sender, EventArgs e)
		{

		}
		#endregion
	}
}
