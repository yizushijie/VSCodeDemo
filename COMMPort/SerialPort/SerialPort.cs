using GenFuncLib;
using MessageBoxPlusLib;
using RichTextBoxPlusLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
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

		#region 委托事件

		/// <summary>
		///
		/// </summary>
		public override DataReceivedDelegate m_DataReadEvent
		{
			get
			{
				return base.m_DataReadEvent;
			}

			set
			{
				base.m_DataReadEvent=value;
			}
		}

		#endregion 委托事件

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
				base.m_COMMPortName=value;
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
				base.m_COMMPortIndex=value;
			}
		}

		/// <summary>
		///
		/// </summary>
		public override COMMPortInfo m_COMMPortInfo
		{
			get
			{
				return base.m_COMMPortInfo;
			}

			set
			{
				base.m_COMMPortInfo=value;
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
				base.m_COMMPortSTATE=value;
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
				base.m_COMMPortWriteBufferSize=value;
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
				base.m_COMMPortWriteCRC=value;
			}
		}

		/// <summary>
		///
		/// </summary>
		public override COMMData m_COMMPortWriteData
		{
			get
			{
				return base.m_COMMPortWriteData;
			}

			set
			{
				base.m_COMMPortWriteData=value;
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
				base.m_COMMPortReadBufferSize=value;
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
				base.m_COMMPortReadCRC=value;
			}
		}

		/// <summary>
		///
		/// </summary>
		public override COMMData m_COMMPortReadData
		{
			get
			{
				return base.m_COMMPortReadData;
			}

			set
			{
				base.m_COMMPortReadData=value;
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

			set
			{
				base.m_UsedTime=value;
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
				base.m_UsedForm=value;
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
				base.m_COMMPortReadID=value;
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
				base.m_COMMPortWriteID=value;
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
				base.m_IsEnableMultiDevice=value;
			}
		}

		/// <summary>
		/// 端口是否可用
		/// </summary>
		public override bool m_COMMPortIsOpen
		{
			get
			{
				return base.m_COMMPortIsOpen;
			}
			set
			{
				base.m_COMMPortIsOpen=value;
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

		/// <summary>
		/// 数据格式合法
		/// </summary>
		public override bool m_COMMBytesPassed
		{
			get
			{
				byte wCMD = 0;
				byte rCMD = 0;
				int length = 0;

				//---写入的数据
				if ((this.m_COMMPortWriteData==null)||(this.m_COMMPortWriteData.usedByte==null)||(this.m_COMMPortWriteData.usedByte.Count==0))
				{
					return false;
				}
				if (this.m_COMMPortWriteBufferSize>250)
				{
					wCMD=this.m_COMMPortWriteData.usedByte[3];
				}
				else
				{
					wCMD=this.m_COMMPortWriteData.usedByte[2];
				}

				//---读取的数据
				if ((this.m_COMMPortReadData==null)||(this.m_COMMPortReadData.usedByte==null)||(this.m_COMMPortReadData.usedByte.Count==0))
				{
					return false;
				}
				if (this.m_COMMPortReadBufferSize>250)
				{
					rCMD=this.m_COMMPortReadData.usedByte[3];

					//---数据的有效长度
					length=this.m_COMMPortReadData.usedByte[1];
					length=(length<<8)+this.m_COMMPortReadData.usedByte[2];
					length+=3;
				}
				else
				{
					rCMD=this.m_COMMPortReadData.usedByte[2];

					//---数据的有效长度
					length=this.m_COMMPortReadData.usedByte[1];
					length+=2;
				}

				//---判断数据是否合法
				if ((wCMD==rCMD)&&(length==this.m_COMMPortReadData.usedByte.Count))
				{
					return true;
				}
				else
				{
					return false;
				}
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
			if (this.m_UsedForm==null)
			{
				this.m_UsedForm=new Form();
			}
			this.m_UsedForm=useForm;
			this.m_IsEnableMultiDevice=isEnMultiDevice;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="useForm"></param>
		/// <param name="bandRate"></param>
		/// <param name="msg"></param>
		public SerialCOMMPort(Form useForm, int useBaudRate, RichTextBox msg = null)
		{
			if (this.m_UsedForm==null)
			{
				this.m_UsedForm=new Form();
			}
			this.m_UsedForm=useForm;

			if (this.baudRate!=useBaudRate)
			{
				this.baudRate=useBaudRate;
			}
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="useForm"></param>
		/// <param name="bandRate"></param>
		/// <param name="isEnMultiDevice"></param>
		/// <param name="msg"></param>
		public SerialCOMMPort(Form useForm, int useBaudRate, bool isEnMultiDevice, RichTextBox msg = null)
		{
			if (this.m_UsedForm==null)
			{
				this.m_UsedForm=new Form();
			}
			this.m_UsedForm=useForm;

			if (this.baudRate!=useBaudRate)
			{
				this.baudRate=useBaudRate;
			}
			this.m_IsEnableMultiDevice=isEnMultiDevice;
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
			if (this.m_UsedForm==null)
			{
				this.m_UsedForm=new Form();
			}
			this.m_UsedForm=useForm;

			this.m_COMMPortIndex=portIndex;

			if (this.baudRate!=useBaudRate)
			{
				this.baudRate=useBaudRate;
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
			if (this.m_UsedForm==null)
			{
				this.m_UsedForm=new Form();
			}
			this.m_UsedForm=useForm;

			if (this.baudRate!=useBaudRate)
			{
				this.baudRate=useBaudRate;
			}

			this.m_IsEnableMultiDevice=isEnMultiDevice;
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
			if (this.m_UsedForm==null)
			{
				this.m_UsedForm=new Form();
			}
			this.m_UsedForm=useForm;

			this.m_COMMPortName=portName;

			if (this.baudRate!=useBaudRate)
			{
				this.baudRate=useBaudRate;
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
			if (this.m_UsedForm==null)
			{
				this.m_UsedForm=new Form();
			}
			this.m_UsedForm=useForm;

			this.m_COMMPortName=portName;

			if (this.baudRate!=useBaudRate)
			{
				this.baudRate=useBaudRate;
			}

			this.m_IsEnableMultiDevice=isEnMultiDevice;
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
			if (this.m_UsedForm==null)
			{
				this.m_UsedForm=new Form();
			}
			this.m_UsedForm=useForm;

			this.m_COMMPortWriteBufferSize=writeSize;
			this.m_COMMPortWriteCRC=writeCRC;
			this.m_COMMPortWriteID=writeID;
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
			if (this.m_UsedForm==null)
			{
				this.m_UsedForm=new Form();
			}
			this.m_UsedForm=useForm;

			this.m_COMMPortWriteBufferSize=writeSize;
			this.m_COMMPortWriteCRC=writeCRC;
			this.m_COMMPortWriteID=writeID;

			this.m_IsEnableMultiDevice=isEnMultiDevice;
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
			if (this.m_UsedForm==null)
			{
				this.m_UsedForm=new Form();
			}
			this.m_UsedForm=useForm;

			this.m_COMMPortWriteBufferSize=writeSize;
			this.m_COMMPortWriteCRC=writeCRC;
			this.m_COMMPortWriteID=writeID;

			this.m_COMMPortReadBufferSize=readSize;
			this.m_COMMPortReadCRC=readCRC;
			this.m_COMMPortReadID=readID;

			if (this.baudRate!=useBaudRate)
			{
				this.baudRate=useBaudRate;
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
			if (this.m_UsedForm==null)
			{
				this.m_UsedForm=new Form();
			}
			this.m_UsedForm=useForm;

			this.m_COMMPortWriteBufferSize=writeSize;
			this.m_COMMPortWriteCRC=writeCRC;
			this.m_COMMPortWriteID=writeID;

			this.m_COMMPortReadBufferSize=readSize;
			this.m_COMMPortReadCRC=readCRC;
			this.m_COMMPortReadID=readID;

			if (this.baudRate!=useBaudRate)
			{
				this.baudRate=useBaudRate;
			}
			this.m_IsEnableMultiDevice=isEnMultiDevice;
		}

		#endregion 构造函数

		#region 析构函数

		/// <summary>
		/// 析构函数
		/// </summary>
		~SerialCOMMPort()
		{
			if (this.usedSerialPort!=null)
			{
				//---销毁当前对象
				this.usedSerialPort.Dispose();
			}
			GC.SuppressFinalize(this);
		}

		#endregion 析构函数

		#region 函数定义

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
			if (parityBits.StartsWith("奇")||parityBits.StartsWith("Odd")||parityBits.StartsWith("ODD")||parityBits.StartsWith("odd")||parityBits.StartsWith("oDD"))
			{
				_return=Parity.Odd;
			}

			//---偶校验
			else if (parityBits.StartsWith("偶")||parityBits.StartsWith("Even")||parityBits.StartsWith("EVEN")||parityBits.StartsWith("even")||parityBits.StartsWith("eVEN"))
			{
				_return=Parity.Even;
			}

			//---无校验位
			else
			{
				_return=Parity.None;
			}
			return _return;
		}

		/// <summary>
		/// 获取停止位
		/// </summary>
		/// <param name="stopBits"></param>
		/// <returns></returns>
		private StopBits GetStopBits(string stopBits)
		{
			//---获取校验位
			StopBits _return = new StopBits();
			try
			{
				double stopVal = Math.Truncate(Convert.ToDouble(stopBits));
				int temp = (int)(stopVal*10);

				//---1位停止位
				if (temp==10)
				{
					_return=StopBits.One;
				}

				//---1.5位停止位
				else if (temp==15)
				{
					_return=StopBits.OnePointFive;
				}

				//---2位停止位
				else if (temp==20)
				{
					_return=StopBits.Two;
				}
				else
				{
					_return=StopBits.None;
				}
			}
			catch
			{
				_return=StopBits.None;
			}
			return _return;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="deviceID"></param>
		/// <returns></returns>
		public int ProcessDataToDevice(ref byte[] cmd, int deviceID)
		{
			int _return = 0;
			int length = 0;

			//---处理数据的长度
			if ((this.m_COMMPortWriteBufferSize>250)&&(cmd.Length>2))
			{
				length=cmd[1];
				length=(length<<8)+cmd[2];

				//---为了后面的数据统一
				length+=1;
			}
			else if (cmd.Length>1)
			{
				length=cmd[1];
			}
			else
			{
				//---数据格式不合法
				_return=1;
				return _return;
			}
			byte[] tempCmd = null;

			//---发送的命令报头和长度信息
			if ((cmd[0]!=this.m_COMMPortWriteID)&&(length!=(cmd.Length-2)))
			{
				length=cmd.Length;
				if ((this.m_IsEnableMultiDevice)&&(deviceID!=0))
				{
					length+=1;
					tempCmd=new byte[length];

					//---多设备时，设备ID的地址
					tempCmd[0]=(byte)deviceID;

					//---拷贝数据
					Array.Copy(cmd, 0, tempCmd, 1, cmd.Length);
				}
				else
				{
					tempCmd=new byte[length];

					//---拷贝数据
					Array.Copy(cmd, tempCmd, cmd.Length);
				}

				//---整理之后的数据
				length=tempCmd.Length;
				if (this.m_COMMPortWriteBufferSize>250)
				{
					length+=3;
				}
				else
				{
					length+=2;
				}
				cmd=new byte[length];

				//---拷贝数据
				Array.Copy(tempCmd, 0, cmd, (length-tempCmd.Length), tempCmd.Length);
			}
			else
			{
				if (this.m_COMMPortWriteBufferSize>250)
				{
					length=3;
				}
				else
				{
					length=2;
				}

				//---判断是否需要多设备通信
				if ((this.m_IsEnableMultiDevice)&&(deviceID!=0))
				{
					tempCmd=new byte[cmd.Length-length+1];

					//---多设备时，设备ID的地址
					tempCmd[0]=(byte)deviceID;

					//---拷贝数据
					Array.Copy(cmd, 0, tempCmd, 1, cmd.Length);
				}
				else
				{
					tempCmd=new byte[cmd.Length-length];

					//---拷贝数据
					Array.Copy(cmd, tempCmd, cmd.Length);
				}

				//---整理之后的数据
				cmd=new byte[length+tempCmd.Length];
				Array.Copy(tempCmd, 0, cmd, length, tempCmd.Length);
			}

			//---获取发送数据
			this.m_COMMPortWriteData=new COMMData();

			//---CRC函数的处理
			if (this.m_COMMPortWriteCRC==(byte)USE_CRC.CRC_CHECKSUM)
			{
				//---获取CRC的校验和信息
				byte checkSum = GenFunc.GenFuncCheckSum(cmd, cmd.Length);

				//---重置缓存区的大小
				Array.Resize<byte>(ref cmd, (cmd.Length+1));

				//---自动添加校验和信息
				cmd[cmd.Length-1]=checkSum;

				//---发送数据的信息
				this.m_COMMPortWriteData.usedCRC=(byte)USE_CRC.CRC_CHECKSUM;
				this.m_COMMPortWriteData.usedCRCVal=checkSum;
			}
			else if (this.m_COMMPortWriteCRC==(byte)USE_CRC.CRC_CRC8)
			{
				byte crc8 = GenFunc.GenFuncCRC8Table(cmd, cmd.Length);

				//---重置缓存区的大小
				Array.Resize<byte>(ref cmd, (cmd.Length+1));

				//---自动添加校验和信息
				cmd[cmd.Length-1]=crc8;

				//---发送数据的信息
				this.m_COMMPortWriteData.usedCRC=(byte)USE_CRC.CRC_CRC8;
				this.m_COMMPortWriteData.usedCRCVal=crc8;
			}
			else if (this.m_COMMPortWriteCRC==(byte)USE_CRC.CRC_CRC16)
			{
				int crc16 = GenFunc.GenFuncCRC16Table(cmd, cmd.Length);

				//---重置缓存区的大小
				Array.Resize<byte>(ref cmd, (cmd.Length+2));

				//---自动添加校验和信息
				cmd[cmd.Length-2]=(byte)(crc16>>8);
				cmd[cmd.Length-1]=(byte)(crc16);

				//---发送数据的信息
				this.m_COMMPortWriteData.usedCRC=(byte)USE_CRC.CRC_CRC16;
				this.m_COMMPortWriteData.usedCRCVal=(UInt32)crc16;
			}
			else if (this.m_COMMPortWriteCRC==(byte)USE_CRC.CRC_CRC32)
			{
				UInt32 crc32 = GenFunc.GenFuncCRC32Table(cmd, cmd.Length);

				//---重置缓存区的大小
				Array.Resize<byte>(ref cmd, (cmd.Length+4));

				//---自动添加校验和信息
				cmd[cmd.Length-4]=(byte)(crc32>>24);
				cmd[cmd.Length-3]=(byte)(crc32>>16);
				cmd[cmd.Length-2]=(byte)(crc32>>8);
				cmd[cmd.Length-1]=(byte)(crc32);

				//---发送数据的信息
				this.m_COMMPortWriteData.usedCRC=(byte)USE_CRC.CRC_CRC32;
				this.m_COMMPortWriteData.usedCRCVal=crc32;
			}

			//---重新修正数据长度
			length=cmd.Length;
			cmd[0]=this.m_COMMPortWriteID;
			if (this.m_COMMPortWriteBufferSize>250)
			{
				length-=3;
				cmd[1]=(byte)(length>>8);
				cmd[2]=(byte)length;
			}
			else
			{
				length-=2;
				cmd[1]=(byte)length;
			}
			this.m_COMMPortWriteData.usedByte.AddRange(cmd);
			return _return;
		}

		/// <summary>
		/// 接收数据大小最大为255
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="time"></param>
		/// <returns></returns>
		public int ReadResponse_8BitsTask(ref byte[] cmd, int time = 200)
		{
			int _return = 0;

			//---获取开始时间标签
			DateTime nowTime = DateTime.Now;

			//---接收缓存区
			this.m_COMMPortReadData=new COMMData();

			//---接收数据步序
			byte taskStep = 0;

			//---时间计数器
			DateTime startTime = DateTime.Now;

			//---数据存储的临时变量
			int temp = 0;

			//---清空错误消息
			this.m_COMMPortErrMsg=string.Empty;

			//---工作状态是忙碌
			this.m_COMMPortSTATE=true;

			//---数据的读取---阻塞读取
			while (this.m_COMMPortSTATE)
			{
				try
				{
					switch (taskStep)
					{
						case 0:         //---获取数据报头
							if (this.usedSerialPort.BytesToRead>0)
							{
								temp=this.usedSerialPort.ReadByte();

								//---读取报头
								if ((byte)temp==this.m_COMMPortReadID)
								{
									//---保存数据
									this.m_COMMPortReadData.usedByte.Add((byte)temp);

									//---进入下一任务
									taskStep=1;

									//---重置时间标签
									startTime=DateTime.Now;
								}
							}
							break;

						case 1:         //---获取数据长度
							if (this.usedSerialPort.BytesToRead>0)
							{
								//---读取接收到的数据
								temp=this.usedSerialPort.ReadByte();

								//---数据长度的合法性验证
								if ((temp>0)&&(temp<(this.m_COMMPortReadBufferSize-1)))
								{
									//---数据长度合法，接收数据长度
									this.m_COMMPortReadData.usedByte.Add((byte)temp);

									//---进入下一任务
									taskStep=2;
								}
								else
								{
									//---数据长度不合法，重新接收数据
									this.m_COMMPortReadData.usedByte=new List<byte>();
									taskStep=0;
								}

								//---重置时间标签
								startTime=DateTime.Now;
							}
							break;

						case 2:         //---获取数据
							if (this.usedSerialPort.BytesToRead>0)
							{
								//---读取接收到的数据
								temp=this.usedSerialPort.ReadByte();
								this.m_COMMPortReadData.usedByte.Add((byte)temp);

								//---重置时间标签
								startTime=DateTime.Now;
							}
							break;

						default:
							this.m_COMMPortSTATE=false;
							this.m_COMMPortErrMsg+="接收数据的过程中发生错误!\r\n";
							_return=1;
							break;
					}

					//---计算时间
					TimeSpan endTime = DateTime.Now-startTime;

					//---判断是否发生超时错误
					if (endTime.TotalMilliseconds>time)
					{
						//---退出while循环
						this.m_COMMPortSTATE=false;
						_return=2;
						this.m_COMMPortErrMsg+="数据接收发生超时错误!\r\n";
						break;
					}

					//---判断接收到的数据
					if ((taskStep==2)&&(this.m_COMMPortReadData!=null)&&(this.m_COMMPortReadData.usedByte!=null)&&(this.m_COMMPortReadData.usedByte.Count>2)&&((this.m_COMMPortReadData.usedByte.Count-2)==this.m_COMMPortReadData.usedByte[1]))
					{
						//---退出当前while循环
						this.m_COMMPortSTATE=false;
						_return=0;
						break;
					}
					Application.DoEvents();
				}
				catch (Exception e)   //---读取发生异常状态
				{
					//---退出当前while循环
					this.m_COMMPortSTATE=false;
					this.m_COMMPortErrMsg+=e.ToString();
					if (!this.usedSerialPort.IsOpen)
					{
						this.m_COMMPortErrMsg+="通信端口异常断开\r\n";
					}
					_return=3;
				}
			}

			//---判断接收的数据以及CRC校验
			if ((_return==0)&&(taskStep==2)&&(this.m_COMMPortSTATE==false)&&(this.m_COMMPortReadData.usedByte!=null)&&(this.m_COMMPortReadData.usedByte.Count>2))
			{
				cmd=new byte[this.m_COMMPortReadData.usedByte.Count];
				this.m_COMMPortReadData.usedByte.CopyTo(cmd);

				//---修正数据信息
				if (this.m_COMMPortReadCRC==(byte)USE_CRC.CRC_CHECKSUM)
				{
					//---修正数据的实际长度
					cmd[1]-=1;

					//---计算校验和
					byte checkSum = GenFunc.GenFuncCheckSum(cmd, (cmd.Length-1));

					//---判断校验和信息
					if (checkSum!=cmd[cmd.Length-1])
					{
						this.m_COMMPortErrMsg+="数据校验和发生错误!\r\n";
						_return=4;
					}

					//---接收到的数据
					this.m_COMMPortReadData.usedCRC=(byte)USE_CRC.CRC_CHECKSUM;
					this.m_COMMPortReadData.usedCRCVal=cmd[cmd.Length-1];
				}
				else if (this.m_COMMPortReadCRC==(byte)USE_CRC.CRC_CRC8)
				{
					//---修正数据的实际长度
					cmd[1]-=1;

					//---计算校验和
					byte crc8 = GenFunc.GenFuncCRC8Table(cmd, (cmd.Length-1));

					//---判断校验和信息
					if (crc8!=cmd[cmd.Length-1])
					{
						this.m_COMMPortErrMsg+="数据CRC8校验发生错误!\r\n";
						_return=5;
					}

					//---接收到的数据
					this.m_COMMPortReadData.usedCRC=(byte)USE_CRC.CRC_CRC8;
					this.m_COMMPortReadData.usedCRCVal=cmd[cmd.Length-1];
				}
				else if (this.m_COMMPortReadCRC==(byte)USE_CRC.CRC_CRC16)
				{
					//---修正数据的实际长度
					cmd[1]-=2;

					//---计算校验和
					UInt16 crc16 = GenFunc.GenFuncCRC16Table(cmd, (cmd.Length-2));

					//---crc16的值
					UInt16 crc16Val = cmd[cmd.Length-2];
					crc16Val=(UInt16)((crc16<<8)+cmd[cmd.Length-1]);

					//---判断校验和信息
					if (crc16!=crc16Val)
					{
						this.m_COMMPortErrMsg+="数据CRC16校验发生错误!\r\n";
						_return=6;
					}

					//---接收到的数据
					this.m_COMMPortReadData.usedCRC=(byte)USE_CRC.CRC_CRC16;
					this.m_COMMPortReadData.usedCRCVal=crc16Val;
				}
				else if (this.m_COMMPortReadCRC==(byte)USE_CRC.CRC_CRC32)
				{
					//---修正数据的实际大小
					cmd[1]-=4;
					UInt32 crc32Val = cmd[cmd.Length-4];
					crc32Val=(crc32Val<<8)+cmd[cmd.Length-3];
					crc32Val=(crc32Val<<8)+cmd[cmd.Length-2];
					crc32Val=(crc32Val<<8)+cmd[cmd.Length-1];

					//---获取CRC的校验和
					UInt32 crc32 = GenFunc.GenFuncCRC32Table(cmd, (cmd.Length-4));

					//---判断CRC32的校验信息
					if (crc32!=crc32Val)
					{
						this.m_COMMPortErrMsg+="数据CRC32校验发生错误!\r\n";
						_return=7;
					}

					//---接收到的数据
					this.m_COMMPortReadData.usedCRC=(byte)USE_CRC.CRC_CRC32;
					this.m_COMMPortReadData.usedCRCVal=crc32Val;
				}

				//---重新整理之后的数据
				if (_return==0)
				{
					int length = cmd[1]+2;
					int i = 0;
					this.m_COMMPortReadData.usedByte=new List<byte>();
					for (i=0 ; i<length ; i++)
					{
						this.m_COMMPortReadData.usedByte.Add(cmd[i]);
					}
					cmd=new byte[this.m_COMMPortReadData.usedByte.Count];
					this.m_COMMPortReadData.usedByte.CopyTo(cmd);
				}
			}

			//---工作状态是忙碌
			this.m_COMMPortSTATE=false;

			//---清空接收缓存区
			this.usedSerialPort.DiscardInBuffer();

			//---清空发送缓存区
			this.usedSerialPort.DiscardOutBuffer();

			//---计算本次读取的耗时时间
			this.m_UsedTime=DateTime.Now-nowTime;
			return _return;
		}

		/// <summary>
		/// 接收数据大小最大为65535
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="time"></param>
		/// <returns></returns>
		public int ReadResponse_16BitsTask(ref byte[] cmd, int time = 200)
		{
			int _return = 0;

			//---获取开始时间标签
			DateTime nowTime = DateTime.Now;

			//---接收缓存区
			this.m_COMMPortReadData=new COMMData();

			//---接收数据步序
			byte taskStep = 0;

			//---时间计数器
			DateTime startTime = DateTime.Now;

			//---数据存储的临时变量
			int temp = 0;

			//---清空错误消息
			this.m_COMMPortErrMsg=string.Empty;

			//---工作状态是忙碌
			this.m_COMMPortSTATE=true;
			int countSize = 0;

			//---数据的读取---阻塞读取
			while (this.m_COMMPortSTATE)
			{
				try
				{
					switch (taskStep)
					{
						case 0:         //---获取数据报头
							if (this.usedSerialPort.BytesToRead>0)
							{
								temp=this.usedSerialPort.ReadByte();

								//---读取报头
								if ((byte)temp==this.m_COMMPortReadID)
								{
									//---保存数据
									this.m_COMMPortReadData.usedByte.Add((byte)temp);

									//---进入下一任务
									taskStep=1;

									//---重置时间标签
									startTime=DateTime.Now;
								}
							}
							break;

						case 1:         //---获取数据长度高字节
							if (this.usedSerialPort.BytesToRead>0)
							{
								//---读取接收到的数据
								temp=this.usedSerialPort.ReadByte();
								countSize=(temp&0x00FF);

								//---数据长度合法，接收数据长度
								this.m_COMMPortReadData.usedByte.Add((byte)temp);

								//---进入下一任务
								taskStep=2;

								//---重置时间标签
								startTime=DateTime.Now;
							}
							break;

						case 2:         //---获取数据长度低字节
							if (this.usedSerialPort.BytesToRead>0)
							{
								//---读取接收到的数据
								temp=this.usedSerialPort.ReadByte();

								//---组合数据长度
								countSize=(countSize<<8)+(temp&0x00FF);

								//---数据长度的合法性验证
								if ((countSize>0)&&(countSize<(this.m_COMMPortReadBufferSize-2)))
								{
									//---数据长度合法，接收数据长度
									this.m_COMMPortReadData.usedByte.Add((byte)temp);

									//---进入下一任务
									taskStep=3;
								}
								else
								{
									//---数据长度不合法，重新接收数据
									this.m_COMMPortReadData.usedByte=new List<byte>();
									taskStep=0;
								}

								//---重置时间标签
								startTime=DateTime.Now;
							}
							break;

						case 3:         //---获取数据
							if (this.usedSerialPort.BytesToRead>0)
							{
								//---读取接收到的数据
								temp=this.usedSerialPort.ReadByte();
								this.m_COMMPortReadData.usedByte.Add((byte)temp);

								//---重置时间标签
								startTime=DateTime.Now;
							}
							break;

						default:
							this.m_COMMPortSTATE=false;
							this.m_COMMPortErrMsg+="接收数据的过程中发生错误!\r\n";
							_return=1;
							break;
					}

					//---计算时间
					TimeSpan endTime = DateTime.Now-startTime;

					//---判断是否发生超时错误
					if (endTime.TotalMilliseconds>time)
					{
						//---退出while循环
						this.m_COMMPortSTATE=false;
						_return=2;
						this.m_COMMPortErrMsg+="数据接收发生超时错误!\r\n";
						break;
					}

					//---判断接收到的数据
					if ((taskStep==3)&&(this.m_COMMPortReadData!=null)&&(this.m_COMMPortReadData.usedByte!=null)&&(this.m_COMMPortReadData.usedByte.Count>2)&&((this.m_COMMPortReadData.usedByte.Count-3)==countSize))
					{
						//---退出当前while循环
						this.m_COMMPortSTATE=false;
						_return=0;
						break;
					}
					Application.DoEvents();
				}
				catch (Exception e)   //---读取发生异常状态
				{
					//---退出当前while循环
					this.m_COMMPortSTATE=false;
					this.m_COMMPortErrMsg+=e.ToString();
					if (!this.usedSerialPort.IsOpen)
					{
						this.m_COMMPortErrMsg+="通信端口异常断开\r\n";
					}
					_return=3;
				}
			}

			//---判断接收的数据以及CRC校验
			if ((_return==0)&&(taskStep==3)&&(this.m_COMMPortSTATE==false)&&(this.m_COMMPortReadData.usedByte!=null)&&(this.m_COMMPortReadData.usedByte.Count>2))
			{
				cmd=new byte[this.m_COMMPortReadData.usedByte.Count];
				this.m_COMMPortReadData.usedByte.CopyTo(cmd);

				//---修正数据信息
				if (this.m_COMMPortReadCRC==(byte)USE_CRC.CRC_CHECKSUM)
				{
					//---修正数据的实际长度
					countSize-=1;
					cmd[1]=(byte)(countSize>>8);
					cmd[2]=(byte)(countSize&0xFF);

					//---计算校验和
					byte checkSum = GenFunc.GenFuncCheckSum(cmd, (cmd.Length-1));

					//---判断校验和信息
					if (checkSum!=cmd[cmd.Length-1])
					{
						this.m_COMMPortErrMsg+="数据校验和发生错误!\r\n";
						_return=4;
					}

					//---接收到的数据
					this.m_COMMPortReadData.usedCRC=(byte)USE_CRC.CRC_CHECKSUM;
					this.m_COMMPortReadData.usedCRCVal=cmd[cmd.Length-1];
				}
				else if (this.m_COMMPortReadCRC==(byte)USE_CRC.CRC_CRC8)
				{
					//---修正数据的实际长度
					countSize-=1;
					cmd[1]=(byte)(countSize>>8);
					cmd[2]=(byte)(countSize&0xFF);

					//---计算校验和
					byte crc8 = GenFunc.GenFuncCRC8Table(cmd, (cmd.Length-1));

					//---判断校验和信息
					if (crc8!=cmd[cmd.Length-1])
					{
						this.m_COMMPortErrMsg+="数据CRC8校验发生错误!\r\n";
						_return=5;
					}

					//---接收到的数据
					this.m_COMMPortReadData.usedCRC=(byte)USE_CRC.CRC_CRC8;
					this.m_COMMPortReadData.usedCRCVal=cmd[cmd.Length-1];
				}
				else if (this.m_COMMPortReadCRC==(byte)USE_CRC.CRC_CRC16)
				{
					//---修正数据的实际长度
					countSize-=2;
					cmd[1]=(byte)(countSize>>8);
					cmd[2]=(byte)(countSize&0xFF);

					//---计算校验和
					UInt16 crc16 = GenFunc.GenFuncCRC16Table(cmd, (cmd.Length-2));

					//---crc16的值
					UInt16 crc16Val = cmd[cmd.Length-2];
					crc16Val=(UInt16)((crc16<<8)+cmd[cmd.Length-1]);

					//---判断校验和信息
					if (crc16!=crc16Val)
					{
						this.m_COMMPortErrMsg+="数据CRC16校验发生错误!\r\n";
						_return=6;
					}

					//---接收到的数据
					this.m_COMMPortReadData.usedCRC=(byte)USE_CRC.CRC_CRC16;
					this.m_COMMPortReadData.usedCRCVal=crc16Val;
				}
				else if (this.m_COMMPortReadCRC==(byte)USE_CRC.CRC_CRC32)
				{
					//---修正数据的实际大小
					countSize-=4;
					cmd[1]=(byte)(countSize>>8);
					cmd[2]=(byte)(countSize&0xFF);
					UInt32 crc32Val = cmd[cmd.Length-4];
					crc32Val=(crc32Val<<8)+cmd[cmd.Length-3];
					crc32Val=(crc32Val<<8)+cmd[cmd.Length-2];
					crc32Val=(crc32Val<<8)+cmd[cmd.Length-1];

					//---获取CRC的校验和
					UInt32 crc32 = GenFunc.GenFuncCRC32Table(cmd, (cmd.Length-4));

					//---判断CRC32的校验信息
					if (crc32!=crc32Val)
					{
						this.m_COMMPortErrMsg+="数据CRC32校验发生错误!\r\n";
						_return=7;
					}

					//---接收到的数据
					this.m_COMMPortReadData.usedCRC=(byte)USE_CRC.CRC_CRC32;
					this.m_COMMPortReadData.usedCRCVal=crc32Val;
				}

				//---重新整理之后的数据
				if (_return==0)
				{
					int length = countSize+3;
					int i = 0;
					this.m_COMMPortReadData.usedByte=new List<byte>();
					for (i=0 ; i<length ; i++)
					{
						this.m_COMMPortReadData.usedByte.Add(cmd[i]);
					}
					cmd=new byte[this.m_COMMPortReadData.usedByte.Count];
					this.m_COMMPortReadData.usedByte.CopyTo(cmd);
				}
			}

			//---工作状态是忙碌
			this.m_COMMPortSTATE=false;

			//---清空接收缓存区
			this.usedSerialPort.DiscardInBuffer();

			//---清空发送缓存区
			this.usedSerialPort.DiscardOutBuffer();

			//---计算本次读取的耗时时间
			this.m_UsedTime=DateTime.Now-nowTime;
			return _return;
		}

		/// <summary>
		/// 获取当前设备的信息
		/// </summary>
		/// <returns></returns>
		public COMMPortInfo GetCOMMPortInfo()
		{
			COMMPortInfo _return = new COMMPortInfo();

			//---调用WMI，获取Win32_PnPEntity，即所有设备
			using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity"))
			{
				var hardInfos = searcher.Get();
				foreach (var hardInfo in hardInfos)
				{
					//---筛选出名称中包含COM的
					if ((hardInfo.Properties["Name"].Value!=null)&&(hardInfo.Properties["Name"].Value.ToString().Contains("COM"))&&(hardInfo.Properties["Name"].Value.ToString().ToUpper().Contains("USB")))
					{
						//---获取名称
						string s = hardInfo.Properties["Name"].Value.ToString();
						int p = s.IndexOf('(');

						//截取描述（名称）
						string des = s.Substring(0, p);

						//截取串口号
						_return.deviceNames.Add(s.Substring(p+1, s.Length-p-2));
					}
				}
				searcher.Dispose();
			}
			return _return;
		}

		#endregion 函数定义

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
			string[] deviceNames = null;
			if ((this.m_COMMPortInfo.deviceNames!=null)&&(this.m_COMMPortInfo.deviceNames.Count!=0))
			{
				deviceNames=this.m_COMMPortInfo.deviceNames.ToArray();
			}

			//---刷新当前设备
			string[] tempDeviceNames = SerialPort.GetPortNames();

			//---更新设备记录表
			string str = string.Empty;
			if (cbb!=null)
			{
				//---异步调用
				if (cbb.InvokeRequired)
				{
					cbb.Invoke((EventHandler)
							 (delegate
							 {
								 str=cbb.Text;
							 }));
				}
				else
				{
					str=cbb.Text;
				}
			}
			int _return = this.m_COMMPortInfo.Init(tempDeviceNames, str);
			if ((_return==0)&&(cbb!=null))
			{
				//---异步调用
				if (cbb.InvokeRequired)
				{
					cbb.Invoke((EventHandler)
							 (delegate
							 {
								 cbb.Items.Clear();
								 if ((this.m_COMMPortInfo.deviceNames!=null)&&(this.m_COMMPortInfo.deviceNames.Count!=0))
								 {
									 cbb.Items.AddRange(this.m_COMMPortInfo.deviceNames.ToArray());
								 }
								 cbb.SelectedIndex=this.m_COMMPortInfo.deviceUsedIndex;
							 }));
				}
				else
				{
					cbb.Items.Clear();
					if ((this.m_COMMPortInfo.deviceNames!=null)&&(this.m_COMMPortInfo.deviceNames.Count!=0))
					{
						cbb.Items.AddRange(this.m_COMMPortInfo.deviceNames.ToArray());
					}
					cbb.SelectedIndex=this.m_COMMPortInfo.deviceUsedIndex;
				}
				if (((deviceNames==null)||(deviceNames.Length==0))&&((tempDeviceNames==null)||(tempDeviceNames.Length==0)))
				{
					if (cbb!=null)
					{
						//---异步调用
						if (cbb.InvokeRequired)
						{
							cbb.Invoke((EventHandler)
									 (delegate
									 {
										 cbb.Items.Clear();
										 cbb.SelectedIndex=this.m_COMMPortInfo.deviceUsedIndex;
									 }));
						}
						else
						{
							cbb.Items.Clear();
							cbb.SelectedIndex=this.m_COMMPortInfo.deviceUsedIndex;
						}
					}
					return 0;
				}
				this.m_COMMPortErrMsg=string.Empty;
				for (_return=0 ; _return<tempDeviceNames.Length ; _return++)
				{
					if ((deviceNames==null)||(!deviceNames.Contains(tempDeviceNames[_return])))
					{
						this.m_COMMPortErrMsg+=
										string.Format("{0} {1}", System.DateTime.Now.ToString(), "：")+" 端口："+
										tempDeviceNames[_return]+"插入\r\n";
					}
				}
				if (cbb!=null)
				{
					//---异步调用
					if (cbb.InvokeRequired)
					{
						cbb.Invoke((EventHandler)
								 (delegate
								 {
									 if (((cbb.Text==null)||(cbb.Text==string.Empty)||(cbb.Text==""))&&(cbb.Items.Count!=0))
									 {
										 cbb.SelectedIndex=0;
									 }
								 }));
					}
					else
					{
						if (((cbb.Text==null)||(cbb.Text==string.Empty)||(cbb.Text==""))&&(cbb.Items.Count!=0))
						{
							cbb.SelectedIndex=0;
						}
					}
				}
				if ((msg!=null)&&((this.m_COMMPortErrMsg!=string.Empty)||(this.m_COMMPortErrMsg!=null)||(this.m_COMMPortErrMsg!="")))
				{
					RichTextBoxPlus.AppendTextInfoTopWithoutDateTime(msg, this.m_COMMPortErrMsg, Color.Black, false);
				}
			}
			else
			{
				if (msg!=null)
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
			return this.RemoveDevice(null, null);
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
			string[] deviceNames = null;
			if ((this.m_COMMPortInfo.deviceNames!=null)&&(this.m_COMMPortInfo.deviceNames.Count!=0))
			{
				deviceNames=this.m_COMMPortInfo.deviceNames.ToArray();
			}

			//---刷新当前设备
			string[] tempDeviceNames = SerialPort.GetPortNames();

			//---更新设备记录表
			string str = string.Empty;
			if (cbb!=null)
			{
				//---异步调用
				if (cbb.InvokeRequired)
				{
					cbb.Invoke((EventHandler)
							 (delegate
							 {
								 str=cbb.Text;
							 }));
				}
				else
				{
					str=cbb.Text;
				}
			}
			int _return = this.m_COMMPortInfo.Init(tempDeviceNames, str);
			if (((_return==0)||(_return==1))&&(cbb!=null))
			{
				//---异步调用
				if (cbb.InvokeRequired)
				{
					cbb.Invoke((EventHandler)
							 (delegate
							 {
								 cbb.Items.Clear();
								 if ((this.m_COMMPortInfo.deviceNames!=null)&&(this.m_COMMPortInfo.deviceNames.Count!=0))
								 {
									 cbb.Items.AddRange(this.m_COMMPortInfo.deviceNames.ToArray());
								 }
								 cbb.SelectedIndex=this.m_COMMPortInfo.deviceUsedIndex;
							 }));
				}
				else
				{
					cbb.Items.Clear();
					if ((this.m_COMMPortInfo.deviceNames!=null)&&(this.m_COMMPortInfo.deviceNames.Count!=0))
					{
						cbb.Items.AddRange(this.m_COMMPortInfo.deviceNames.ToArray());
					}
					cbb.SelectedIndex=this.m_COMMPortInfo.deviceUsedIndex;
				}
				if (((deviceNames==null)||(deviceNames.Length==0))&&((tempDeviceNames==null)||(tempDeviceNames.Length==0)))
				{
					if (cbb!=null)
					{
						//---异步调用
						if (cbb.InvokeRequired)
						{
							cbb.Invoke((EventHandler)
									 (delegate
									 {
										 cbb.Items.Clear();
										 cbb.SelectedIndex=this.m_COMMPortInfo.deviceUsedIndex;
									 }));
						}
						else
						{
							cbb.Items.Clear();
							cbb.SelectedIndex=this.m_COMMPortInfo.deviceUsedIndex;
						}
					}
					return 0;
				}
				this.m_COMMPortErrMsg=string.Empty;
				for (_return=0 ; _return<deviceNames.Length ; _return++)
				{
					if (!tempDeviceNames.Contains(deviceNames[_return]))
					{
						this.m_COMMPortErrMsg+=
										string.Format("{0} {1}", System.DateTime.Now.ToString(), "：")+" 端口："+
										deviceNames[_return]+"移除\r\n";
					}
				}

				if ((msg!=null)&&((this.m_COMMPortErrMsg!=string.Empty)||(this.m_COMMPortErrMsg!=null)||(this.m_COMMPortErrMsg!="")))
				{
					RichTextBoxPlus.AppendTextInfoTopWithoutDateTime(msg, this.m_COMMPortErrMsg, Color.Red, false);
				}

				///
				if (cbb!=null)
				{
					//---异步调用
					if (cbb.InvokeRequired)
					{
						cbb.Invoke((EventHandler)
								 (delegate
								 {
									 if (((cbb.Text==null)||(cbb.Text==string.Empty)||(cbb.Text==""))&&(cbb.Items.Count!=0))
									 {
										 cbb.SelectedIndex=0;
									 }
									 else if ((cbb.Items==null)||(cbb.Items.Count==0))
									 {
										 cbb.Text="";
									 }
								 }));
					}
					else
					{
						if (((cbb.Text==null)||(cbb.Text==string.Empty)||(cbb.Text==""))&&(cbb.Items.Count!=0))
						{
							cbb.SelectedIndex=0;
						}
						else if ((cbb.Items==null)||(cbb.Items.Count==0))
						{
							cbb.Text="";
						}
					}
				}
			}
			else
			{
				if (msg!=null)
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
			return this.RefreshDevice(null, null);
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
			string[] tempDeviceNames = SerialPort.GetPortNames();
			int _return = this.m_COMMPortInfo.Init(tempDeviceNames, cbb.Text);
			if ((_return==0)&&(cbb!=null))
			{
				cbb.Items.Clear();
				cbb.Items.AddRange(this.m_COMMPortInfo.deviceNames.ToArray());
				cbb.SelectedIndex=0;
				if (msg!=null)
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "设备刷新成功!\r\n", Color.Black, false);
				}
			}
			else
			{
				if (cbb!=null)
				{
					cbb.Items.Clear();
					cbb.Text=string.Empty;
					cbb.SelectedIndex=-1;
				}
				if (this.m_UsedForm!=null)
				{
					MessageBoxPlus.Show(this.m_UsedForm, "请插入设备!\r\n", "错误提示");
				}
				else
				{
					if (msg!=null)
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
		/// Writes the size of the buffer.
		/// </summary>
		/// <param name="bSize">Size of the b.</param>
		public override void WriteBufferSize(int bSize)
		{
			this.m_COMMPortWriteBufferSize=bSize;
		}

		/// <summary>
		/// Reads the size of the buffer.
		/// </summary>
		/// <param name="bSize">Size of the b.</param>
		public override void ReadBufferSize(int bSize)
		{
			this.m_COMMPortReadBufferSize=bSize;
		}

		/// <summary>
		/// Reads the size of an write buffer.
		/// </summary>
		/// <param name="bRSize">Size of the b r.</param>
		/// <param name="bWSize">Size of the b w.</param>
		public override void ReadAnWriteBufferSize(int bRSize, int bWSize)
		{
			this.m_COMMPortWriteBufferSize=bRSize;
			this.m_COMMPortReadBufferSize=bWSize;
		}

		/// <summary>
		///
		/// </summary>
		/// <returns></returns>
		public override int WriteToDevice(byte cmd, RichTextBox msg = null)
		{
			int _return = 0;
			try
			{
				if ((this.usedSerialPort!=null)&&(this.usedSerialPort.IsOpen))
				{
					//---等待发送完成
					while (this.usedSerialPort.BytesToWrite>0)
					{
						//---响应窗体函数
						Application.DoEvents();
					}
					byte[] tempCmd = new byte[] { cmd };
					this.usedSerialPort.Write(tempCmd, 0, tempCmd.Length);
					this.m_COMMPortErrMsg="数据发送成功\r\n";
					if (msg!=null)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.m_COMMPortErrMsg, Color.Black, false);
					}
				}
				else
				{
					if (this.m_UsedForm!=null)
					{
						MessageBoxPlus.Show(this.m_UsedForm, "端口初始化失败!!!", "错误提示");
					}
					else
					{
						MessageBox.Show("端口初始化失败!!!", "错误提示");
					}
				}
			}
			catch
			{
				_return=2;
				this.m_COMMPortErrMsg="数据发送出现异常\r\n";
			}
			return _return;
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
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int WriteToDevice(byte[] cmd, RichTextBox msg = null)
		{
			return this.WriteToDevice(cmd, 0, msg);
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
			int _return = this.WriteToDevice(cmd, msg);
			if (_return==0)
			{
				if ((this.m_COMMPortWriteData==null)||(this.m_COMMPortWriteData.usedByte==null)||(this.m_COMMPortWriteData.usedByte.Count==0))
				{
					_return=2;
					cmd=null;
				}
				else
				{
					//---重置缓存区
					cmd=new byte[this.m_COMMPortWriteData.usedByte.Count];

					//---数据拷贝到缓存区
					this.m_COMMPortWriteData.usedByte.CopyTo(cmd);
				}
			}
			return _return;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="cmd"></param>
		/// <returns></returns>
		public override int WriteToDevice(byte[] cmd, int deviceID, RichTextBox msg = null)
		{
			int _return = 1;
			try
			{
				if ((this.usedSerialPort!=null)&&(this.usedSerialPort.IsOpen))
				{
					//---等待发送完成
					while (this.usedSerialPort.BytesToWrite>0)
					{
						//---响应窗体函数
						Application.DoEvents();
					}
					_return=this.ProcessDataToDevice(ref cmd, deviceID);
					if (_return!=0)
					{
						if (this.m_UsedForm!=null)
						{
							MessageBoxPlus.Show(this.m_UsedForm, "数据解析错误，请检查数据格式!!!", "错误提示");
						}
						else
						{
							MessageBox.Show("数据解析错误，请检查数据格式!!!", "错误提示");
						}
					}
					else
					{
						this.usedSerialPort.Write(cmd, 0, cmd.Length);
						this.m_COMMPortErrMsg="数据发送成功\r\n";
					}
					if (msg!=null)
					{
						if (_return==0)
						{
							RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.m_COMMPortErrMsg, Color.Black, false);
						}
					}
				}
				else
				{
					if (this.m_UsedForm!=null)
					{
						MessageBoxPlus.Show(this.m_UsedForm, "端口初始化失败!!!", "错误提示");
					}
					else
					{
						MessageBox.Show("端口初始化失败!!!", "错误提示");
					}
				}
			}
			catch
			{
				_return=2;
				this.m_COMMPortErrMsg="数据发送出现异常\r\n";
			}
			return _return;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="deviceID"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int WriteToDevice(ref byte[] cmd, int deviceID, RichTextBox msg = null)
		{
			int _return = this.WriteToDevice(cmd, deviceID, msg);
			if (_return==0)
			{
				if (_return==0)
				{
					if ((this.m_COMMPortWriteData==null)||(this.m_COMMPortWriteData.usedByte==null)||(this.m_COMMPortWriteData.usedByte.Count==0))
					{
						_return=2;
						cmd=null;
					}
					else
					{
						//---重置缓存区
						cmd=new byte[this.m_COMMPortWriteData.usedByte.Count];

						//---数据拷贝到缓存区
						this.m_COMMPortWriteData.usedByte.CopyTo(cmd);
					}
				}
			}
			return _return;
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
			int _return = 1;
			if (this.m_COMMPortWriteBufferSize>250)
			{
				_return=this.ReadResponse_16BitsTask(ref cmd, timeout);
			}
			else
			{
				_return=this.ReadResponse_8BitsTask(ref cmd, timeout);
			}
			if (msg!=null)
			{
				if ((_return!=0)&&(this.m_COMMPortErrMsg!=string.Empty)&&(this.m_COMMPortErrMsg!="")&&(this.m_COMMPortErrMsg!=null))
				{
					RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.m_COMMPortErrMsg, Color.Black, false);
				}
			}
			return _return;
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
		///
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="res"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int SendCmdAndReadResponse(byte[] cmd, ref byte[] res, int timeout = 200, RichTextBox msg = null)
		{
			int _return = this.WriteToDevice(cmd, msg);
			if (_return==0)
			{
				_return=this.ReadFromDevice(ref res, timeout, msg);
			}
			return _return;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="res"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int SendCmdAndReadResponse(ref byte[] cmd, ref byte[] res, int timeout = 200, RichTextBox msg = null)
		{
			int _return = this.WriteToDevice(ref cmd, msg);
			if (_return==0)
			{
				_return=this.ReadFromDevice(ref res, timeout, msg);
			}
			return _return;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="res"></param>
		/// <param name="deviceID"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int SendCmdAndReadResponse(byte[] cmd, ref byte[] res, int deviceID, int timeout, RichTextBox msg = null)
		{
			int _return = this.WriteToDevice(cmd, deviceID, msg);
			if (_return==0)
			{
				_return=this.ReadFromDevice(ref res, timeout, msg);
			}
			return _return;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="res"></param>
		/// <param name="deviceID"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int SendCmdAndReadResponse(ref byte[] cmd, ref byte[] res, int deviceID, int timeout, RichTextBox msg = null)
		{
			int _return = this.WriteToDevice(ref cmd, deviceID, msg);
			if (_return==0)
			{
				_return=this.ReadFromDevice(ref res, timeout, msg);
			}
			return _return;
		}

		/// <summary>
		/// 打开设备
		/// </summary>
		/// <returns></returns>
		public override int OpenDevice()
		{
			if (this.usedSerialPort!=null)
			{
				return this.OpenDevice(this.usedSerialPort.PortName, null);
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
			string str = "COM"+portIndex.ToString();
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
			if (((portName!=string.Empty)&&(portName!=null)&&(portName!="")&&(portName.StartsWith("COM"))))
			{
				this.m_COMMPortErrMsg=string.Empty;

				//---判断串口类是否有效
				if (this.usedSerialPort==null)
				{
					this.usedSerialPort=new SerialPort();
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
						//---设置端口不可用
						this.m_COMMPortIsOpen=false;
					}
					catch
					{
						//---端口关闭出现错误
						this.m_COMMPortErrMsg+="端口："+this.usedSerialPort.PortName+"被其他应用占用，初始化失败!\r\n";
						_return=2;
						goto GoToExit;
					}
				}

				//---获取端口名称
				if (this.usedSerialPort.PortName!=portName)
				{
					this.usedSerialPort.PortName=portName;
					this.m_COMMPortName=portName;
				}

				//---获取端口序号
				this.m_COMMPortIndex=Convert.ToInt16(this.m_COMMPortName.Replace("COM", ""), 10);

				//---设置波特率
				if (this.usedSerialPort.BaudRate!=this.baudRate)
				{
					this.usedSerialPort.BaudRate=this.baudRate;
				}

				//---设置数据位
				if (this.usedSerialPort.DataBits!=this.dataBits)
				{
					this.usedSerialPort.DataBits=this.dataBits;
				}

				//---设置停止位
				if (this.usedSerialPort.StopBits!=this.stopBits)
				{
					this.usedSerialPort.StopBits=this.stopBits;
				}

				//---设置校验位
				if (this.usedSerialPort.Parity!=this.parityBits)
				{
					this.usedSerialPort.Parity=this.parityBits;
				}

				//---打开端口
				try
				{
					//---打开端口
					this.usedSerialPort.Open();

					//---判断端口打开是否成功
					if (this.usedSerialPort.IsOpen)
					{
						this.m_COMMPortErrMsg+="端口："+this.usedSerialPort.PortName+"打开成功!\r\n";

						//---清空接收缓存区
						this.usedSerialPort.DiscardInBuffer();

						//---清空发送缓存区
						this.usedSerialPort.DiscardOutBuffer();
						_return=0;

						//---置位端口可用
						this.m_COMMPortIsOpen=true;
					}
					else
					{
						this.m_COMMPortErrMsg+="端口："+this.usedSerialPort.PortName+"打开失败!\r\n";
						_return=3;
						goto GoToExit;
					}
				}
				catch
				{
					this.m_COMMPortErrMsg+="端口："+this.usedSerialPort.PortName+"端口被其他应用占用，打开失败!\r\n";
					_return=4;
					goto GoToExit;
				}
				GoToExit:
				if (msg!=null)
				{
					if (_return==0)
					{
						RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.m_COMMPortErrMsg, Color.Black, false);
					}
				}

				//---消息插件弹出
				if (_return!=0)
				{
					if (this.m_UsedForm!=null)
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
				if (this.m_UsedForm!=null)
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
			this.baudRate=Convert.ToInt32(baudRate);

			//---更新数据位
			this.dataBits=Convert.ToInt32(dataBits);

			//---更新停止位
			this.stopBits=this.GetStopBits(stopBits);

			//---更新校验位
			this.parityBits=this.GetParityBits(parityBits);

			//---打开设备
			return this.OpenDevice(portName, msg);
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
					//---设置端口不可用
					this.m_COMMPortIsOpen=false;
				}
				catch
				{
					_return=1;
					this.m_COMMPortErrMsg="串口关闭发生异常!\r\n";
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
			string str = "COM"+portIndex.ToString();
			return this.CloseDevice(str, msg);
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
				_return=this.CloseDevice();
				if (msg!=null)
				{
					if (_return==0)
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
			string str = "COM"+portIndex.ToString();
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

		#endregion 重载函数

		#region 事件定义

		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public override void DataReceivedHandler(object sender, EventArgs e)
		{
			if (e.ToString()=="SerialDataReceivedEventArgs")
			{
				if (this.m_DataReadEvent!=null)
				{
					//---执行定义的函数
					this.m_DataReadEvent();
				}
			}
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public override void WatcherPortEventHandler(Object sender, EventArrivedEventArgs e, ComboBox cbb = null, RichTextBox msg = null)
		{
			if (e.NewEvent.ClassPath.ClassName=="__InstanceCreationEvent")
			{
				//---设备插入
				this.AddDevice(cbb, msg);
			}
			else if (e.NewEvent.ClassPath.ClassName=="__InstanceDeletionEvent")
			{
				//---设备移除
				this.RemoveDevice(cbb, msg);
			}
		}

		#endregion 事件定义
	}
}