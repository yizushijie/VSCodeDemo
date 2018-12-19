using MessageBoxPlusLib;
using RichTextBoxPlusLib;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Management;
using System.Windows.Forms;

namespace COMMPortLib
{
	/// <summary>
	/// 用户控件类，用于实现一些简单的操作，比如自动获取端口，自动打开端口
	/// </summary>

	public partial class COMMPortControl : UserControl
	{
		#region 变量定义

		/// <summary>
		/// 使用的端口对象
		/// </summary>
		private COMMPort usedPort = null;

		/// <summary>
		/// 使用的消息对象
		/// </summary>
		private RichTextBox usedMsg = null;

		/// <summary>
		/// 使用的窗体对象
		/// </summary>
		private Form usedForm = null;

		#region 委托定义

		/// <summary>
		/// 自定义事件的参数类型
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <param name="orther"></param>
		public delegate void UserDataReceivedHandle(int index = 0);

		[Description("当点击控件时发生，调用数据接收处理逻辑"), Category("自定义事件")]
		public event UserDataReceivedHandle UserDataReceivedEvent;

		#endregion 委托定义

		#endregion 变量定义

		#region 属性定义

		/// <summary>
		/// 重命名控件
		/// </summary>
		[Description("初始化端口的按键的名称"), Category("自定义属性")]
		public virtual string m_ButtonName
		{
			get
			{
				return this.button_initDevice.Text;
			}
		}

		/// <summary>
		/// 重命名控件
		/// </summary>
		[Description("端口是否可用"), Category("自定义属性")]
		public virtual bool  m_COMMMPortIsOpen
		{
			get
			{
				if (this.usedPort!=null)
				{
					return this.usedPort.m_COMMPortIsOpen;
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
		public COMMPortControl()
		{
			InitializeComponent();
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="usePort"></param>

		public COMMPortControl(COMMPort usePort, RichTextBox msg = null)
		{
			InitializeComponent();

			//---初始化变量
			this.Init();

			//---消息控件
			if (msg!=null)
			{
				if (this.usedMsg==null)
				{
					this.usedMsg=new RichTextBox();
				}
				this.usedMsg=msg;
			}

			//---端口信息
			if (usePort!=null)
			{
				//---判断对象
				if (this.usedPort==null)
				{
					this.usedPort=new COMMPortLib.COMMPort();
				}

				//---注册端口
				this.usedPort=usePort;

				//---检查当前设备存在的端口信息
				this.usedPort.RefreshDevice(this.comboBox_portName, this.usedMsg);
			}
		}

		#endregion 构造函数

		#region 初始化

		/// <summary>
		/// 初始化
		/// </summary>
		public void Init()
		{
			this.usedPort=null;
			this.usedMsg=null;
			this.usedForm=null;
			this.pictureBox_portState.Tag=0;
		}

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="usePort"></param>
		/// <param name="msg"></param>
		public void Init(COMMPort usePort, RichTextBox msg = null)
		{
			if (usePort!=null)
			{
				//---判断对象
				if (this.usedPort==null)
				{
					this.usedPort=new COMMPortLib.COMMPort();
				}

				//---注册端口
				this.usedPort=usePort;

				//---检查当前设备存在的端口信息
				this.usedPort.RefreshDevice(this.comboBox_portName, this.usedMsg);

				//---添加监控端口拔插事件
				this.usedPort.AddWatcherPortEvent(this.WatcherPortEventHandler, this.WatcherPortEventHandler, new TimeSpan(0, 0, 3));
			}

			if (msg!=null)
			{
				if (this.usedMsg==null)
				{
					this.usedMsg=new RichTextBox();
				}
				this.usedMsg=msg;
			}
			if (this.usedPort!=null)
			{
				//---注册按钮事件
				this.button_initDevice.Click+=new EventHandler(this.button_Click);
			}

			this.pictureBox_portState.Tag=0;

			//---点击图片控件
			this.pictureBox_portState.Click+=new System.EventHandler(this.pictureBox_Click);

			//---注册鼠标进入事件
			this.pictureBox_portState.MouseEnter+=new System.EventHandler(this.pictureBox_MouseEnter);
		}

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="useForm"></param>
		/// <param name="usePort"></param>
		/// <param name="msg"></param>
		public void Init(Form useForm, COMMPort usePort, RichTextBox msg = null)
		{
			if (useForm!=null)
			{
				if (this.usedForm==null)
				{
					this.usedForm=new Form();
				}
				this.usedForm=useForm;
			}
			this.Init(usePort, msg);
		}

		#endregion 初始化

		#region 事件定义

		/// <summary>
		/// 点击按钮事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public virtual void button_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			btn.Enabled=false;
			switch (btn.Name)
			{
				case "button_initDevice":
					if (btn.Text=="打开端口")
					{
						if (this.usedPort.OpenDevice(this.comboBox_portName.Text, this.usedMsg)==0)
						{
							this.pictureBox_portState.Tag=1;
							btn.Text="关闭端口";
							this.pictureBox_portState.Image=Properties.Resources.open;

							//---控件不使能
							this.ComboBoxPortInit(false);

							//---消息显示
							if (this.usedMsg!=null)
							{
								RichTextBoxPlus.AppendTextInfoTopWithDataTime(this.usedMsg, "端口打开成功!\r\n", Color.Black, false);
							}
						}
						else
						{
							this.pictureBox_portState.Tag=2;
							this.pictureBox_portState.Image=Properties.Resources.error;
							if (this.usedMsg!=null)
							{
								RichTextBoxPlus.AppendTextInfoTopWithDataTime(this.usedMsg, "端口打开失败!\r\n", Color.Red, false);
							}
						}
					}
					else if (btn.Text=="关闭端口")
					{
						if (this.usedPort!=null)
						{
							this.pictureBox_portState.Tag=3;
							this.usedPort.CloseDevice();
							btn.Text="打开端口";
							this.pictureBox_portState.Image=Properties.Resources.lost;

							//---控件不使能
							this.ComboBoxPortInit(true);

							//---消息显示
							if (this.usedMsg!=null)
							{
								RichTextBoxPlus.AppendTextInfoTopWithDataTime(this.usedMsg, "端口关闭成功!\r\n", Color.Black, false);
							}
						}
					}
					else
					{
						if (this.usedForm!=null)
						{
							MessageBoxPlus.Show(this.usedForm, "端口操作异常！错误操作："+btn.Text, "错误提示");
						}
						else
						{
							MessageBox.Show("端口操作异常！错误操作："+btn.Text, "错误提示");
						}
					}
					break;

				default:
					break;
			}
			btn.Enabled=true;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public virtual void pictureBox_Click(object sender, EventArgs e)
		{
			PictureBox pb = (PictureBox)sender;
			switch (pb.Name)
			{
				case "pictureBox_portState":

					//---判断端口是否打开
					if ((Convert.ToByte(pb.Tag)!=1)&&(this.usedPort!=null))
					{
						//---刷新设备
						this.usedPort.RefreshDevice(this.comboBox_portName, this.usedMsg);
					}
					break;

				default:
					break;
			}
		}

		/// <summary>
		/// 显示消息窗体---说明功能使用
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public virtual void pictureBox_MouseEnter(object sender, EventArgs e)
		{
			if ((this.button_initDevice.Text=="打开端口"))
			{
				this.toolTip_msg.SetToolTip(this.pictureBox_portState, "点击刷新设备");
			}
			else if ((this.button_initDevice.Text=="关闭端口"))
			{
				this.toolTip_msg.SetToolTip(this.pictureBox_portState, "设备已打开");
			}
		}

		/// <summary>
		/// 数据接收事件的处理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public virtual void DataReceivedEventHandler(object sender, EventArgs e)
		{
			if (this.UserDataReceivedEvent!=null)
			{
				this.UserDataReceivedEvent();
			}
		}

		#endregion 事件定义

		#region 函数定义

		/// <summary>
		/// 监控端口处理函数
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <param name="msg"></param>
		public virtual void WatcherPortEventHandler(Object sender, EventArrivedEventArgs e)
		{
			//---设备拔插处理
			this.usedPort.WatcherPortEventHandler(sender, e, this.comboBox_portName, this.usedMsg);

			//---判断消息控件是否存在
			if (this.usedMsg!=null)
			{
				//---异步调用
				if (this.usedMsg.InvokeRequired)
				{
					this.usedMsg.Invoke((EventHandler)
					   (delegate
					   {
						   //---设置鼠标焦点
						   this.usedMsg.Focus();
					   }));
				}
				else
				{
					//---设置鼠标焦点
					this.usedMsg.Focus();
				}
			}

			//---端口处于打开状态
			if (Convert.ToByte(this.pictureBox_portState.Tag)==1)
			{
				if (this.comboBox_portName.InvokeRequired)
				{
					//---异步调用
					this.comboBox_portName.Invoke((EventHandler)
						   (delegate
						   {
							   if (this.comboBox_portName.Text!=this.usedPort.m_COMMPortName)
							   {
								   button_initDevice.Text="打开端口";
								   this.pictureBox_portState.Tag=0;
								   this.pictureBox_portState.Image=Properties.Resources.lost;

								   //---控件不使能
								   this.ComboBoxPortInit(true);
							   }
						   }));
				}
				else
				{
					if (this.comboBox_portName.Text!=this.usedPort.m_COMMPortName)
					{
						button_initDevice.Text="打开端口";
						this.pictureBox_portState.Tag=0;
						this.pictureBox_portState.Image=Properties.Resources.lost;

						//---控件不使能
						this.ComboBoxPortInit(true);
					}
				}
			}
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="isEnable"></param>
		public virtual void ComboBoxPortInit(bool isEnable)
		{
			this.comboBox_portName.Enabled=isEnable;
		}

		#endregion 函数定义
	}
}