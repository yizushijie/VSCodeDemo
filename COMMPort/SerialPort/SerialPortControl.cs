using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using RichTextBoxPlusLib;
using MessageBoxPlusLib;

namespace COMMPortLib
{
	public partial class SerialPortControl : UserControl
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

        #endregion

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

        #endregion

        #region 委托定义

        /// <summary>
        /// 自定义事件的参数类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="orther"></param>
        public delegate void UserDataReceivedHandle(object sender, EventArgs e, int index = 0);

        [Description("当点击控件时发生，调用数据接收处理逻辑"), Category("自定义事件")]
        public event UserDataReceivedHandle UserDataReceivedEvent;

        #endregion

        #region 构造函数
        /// <summary>
        /// 
        /// </summary>
        public SerialPortControl()
		{
			InitializeComponent();
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="usePort"></param>

		public SerialPortControl(COMMPort usePort, RichTextBox msg = null)
		{
			InitializeComponent();

			//---初始化变量
			this.Init();
			//---消息控件
			if (msg != null)
			{
				if (this.usedMsg == null)
				{
					this.usedMsg = new RichTextBox();
				}
				this.usedMsg = msg;
			}
			//---端口信息
			if (usePort != null)
			{
				//---判断对象
				if (this.usedPort == null)
				{
					this.usedPort = new COMMPortLib.COMMPort();
				}
				//---注册端口
				this.usedPort = usePort;
				//---检查当前设备存在的端口信息
				this.usedPort.RefreshDevice(this.comboBox_portName, this.usedMsg);
			}
		}

		#endregion

		#region 初始化

		/// <summary>
		/// 初始化
		/// </summary>
		public void Init()
		{
			this.usedPort = null;
			this.usedMsg = null;
			this.usedForm = null;
			this.pictureBox_portState.Tag = 0;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="usePort"></param>
		/// <param name="msg"></param>
		public void Init(COMMPort usePort, RichTextBox msg = null)
		{
			if (usePort != null)
			{
				//---判断对象
				if (this.usedPort == null)
				{
					this.usedPort = new COMMPortLib.COMMPort();
				}
				//---注册端口
				this.usedPort = usePort;
				//---检查当前设备存在的端口信息
				this.usedPort.RefreshDevice(this.comboBox_portName, this.usedMsg);
				//---添加监控端口拔插事件
				this.usedPort.AddWatcherPortEvent(this.WatcherPortEventHandler, this.WatcherPortEventHandler, new TimeSpan(0, 0, 1));
			}

			if (msg != null)
			{
				if (this.usedMsg == null)
				{
					this.usedMsg = new RichTextBox();
				}
				this.usedMsg = msg;
			}
			if (this.usedPort != null)
			{
				//---注册按钮事件
				this.button_initDevice.Click += new EventHandler(this.button_Click);
			}

			this.pictureBox_portState.Tag = 0;

			//---点击图片控件
			this.pictureBox_portState.Click += new System.EventHandler(this.pictureBox_Click);

            //---注册鼠标进入事件
            this.pictureBox_portState.MouseEnter += new System.EventHandler(this.pictureBox_MouseEnter);
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="useForm"></param>
		/// <param name="usePort"></param>
		/// <param name="msg"></param>
		public void Init(Form useForm, COMMPort usePort, RichTextBox msg = null)
		{
			if (useForm != null)
			{
				if (this.usedForm == null)
				{
					this.usedForm = new Form();
				}
				this.usedForm = useForm;
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
			btn.Enabled = false;
			switch (btn.Name)
			{
				case "button_initDevice":
					if (btn.Text == "打开端口")
					{
						if (this.usedPort.OpenDevice(this.comboBox_portName.Text, this.usedMsg) == 0)
						{
							this.pictureBox_portState.Tag = 1;
							btn.Text = "关闭端口";
							this.pictureBox_portState.Image = Properties.Resources.open;
							//---控件不使能
							this.ComboBoxPortInit(false);
							//---消息显示
							if (this.usedMsg != null)
							{
								RichTextBoxPlus.AppendTextInfoTopWithDataTime(this.usedMsg, "端口"+this.comboBox_portName.Text+"打开成功!\r\n", Color.Black, false);
							}
						}
						else
						{
							this.pictureBox_portState.Tag = 2;
							this.pictureBox_portState.Image = Properties.Resources.error;
							if (this.usedMsg != null)
							{

								RichTextBoxPlus.AppendTextInfoTopWithDataTime(this.usedMsg, "端口" + this.comboBox_portName.Text + "端口打开失败!\r\n", Color.Red, false);
							}
						}
					}
					else if (btn.Text == "关闭端口")
					{
						if (this.usedPort != null)
						{
							this.pictureBox_portState.Tag = 3;
							this.usedPort.CloseDevice();
							btn.Text = "打开端口";
							this.pictureBox_portState.Image = Properties.Resources.lost;
							//---控件不使能
							this.ComboBoxPortInit(true);
							//---消息显示
							if (this.usedMsg != null)
							{
								RichTextBoxPlus.AppendTextInfoTopWithDataTime(this.usedMsg, "端口" + this.comboBox_portName.Text + "关闭成功!\r\n", Color.Black, false);
							}
						}
					}
					else
					{
						if (this.usedForm != null)
						{
							MessageBoxPlus.Show(this.usedForm, "端口操作异常！错误操作：" + btn.Text, "错误提示");
						}
						else
						{
							MessageBox.Show("端口操作异常！错误操作：" + btn.Text, "错误提示");
						}
					}
					break;
				default:
					break;
			}
			btn.Enabled = true;
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
					if ((Convert.ToByte(pb.Tag) != 1) && (this.usedPort != null))
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void pictureBox_MouseEnter(object sender, EventArgs e)
        {
            if ((this.button_initDevice.Text == "打开端口"))
            {
                this.toolTip_msg.SetToolTip(this.pictureBox_portState, "点击刷新设备");
            }
        }


        /// <summary>
        /// 数据接收事件的处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void DataReceivedEventHandler(object sender, EventArgs e)
		{
			if (e.ToString() == "SerialDataReceivedEventArgs")
			{
				if (this.UserDataReceivedEvent != null)
				{
					//---执行数据接收事件
					this.UserDataReceivedEvent(sender,e);
				}
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
            if (this.usedPort != null)
            {
                //---设备拔插处理
                this.usedPort.WatcherPortEventHandler(sender, e, this.comboBox_portName, this.usedMsg);
                //---判断消息控件是否存在
                if (this.usedMsg != null)
                {
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
                if (Convert.ToByte(this.pictureBox_portState.Tag) == 1)
                {
                    if (this.comboBox_portName.InvokeRequired)
                    {
                        this.comboBox_portName.Invoke((EventHandler)
                               (delegate
                               {
                                   if (this.comboBox_portName.Text != this.usedPort.m_COMMPortName)
                                   {
                                       button_initDevice.Text = "打开端口";
                                       this.pictureBox_portState.Tag = 0;
                                       this.pictureBox_portState.Image = Properties.Resources.lost;
                                       //---控件不使能
                                       this.ComboBoxPortInit(true);
                                   }
                               }));
                    }
                    else
                    {
                        if (this.comboBox_portName.Text != this.usedPort.m_COMMPortName)
                        {
                            button_initDevice.Text = "打开端口";
                            this.pictureBox_portState.Tag = 0;
                            this.pictureBox_portState.Image = Properties.Resources.lost;
                            //---控件不使能
                            this.ComboBoxPortInit(true);
                        }
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
            this.comboBox_portName.Enabled = isEnable;
            this.comboBox_portBaudRate.Enabled = isEnable;
            this.comboBox_portDataBits.Enabled = isEnable;
            this.comboBox_portStopBits.Enabled = isEnable;
            this.comboBox_portParityBits.Enabled = isEnable;
        }

        #endregion 函数定义

    }
}
