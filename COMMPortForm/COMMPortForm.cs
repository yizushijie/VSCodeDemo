using COMMPortLib;
using RichTextBoxPlusLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Windows.Forms;

namespace COMMPortForm
{
	public partial class COMMPortForm : UserControl
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

        #endregion

        #region 构造函数

        /// <summary>
        /// 
        /// </summary>
        public COMMPortForm()
		{
			InitializeComponent();
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usePort"></param>

        public COMMPortForm(COMMPort usePort,RichTextBox msg=null)
        {
            InitializeComponent();

            //---初始化变量
            this.Init();
            //---判断对象
            if (this.usedPort==null)
            {
                this.usedPort = new COMMPort();
            }
            this.usedPort = usePort;
            if (msg!=null)
            {
                if (this.usedMsg == null)
                {
                    this.usedMsg = new RichTextBox();
                }
                this.usedMsg = msg;
            }
        }

        #endregion
        
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            if (this.usedPort != null)
            {
                //---检查当前设备存在的端口信息
                this.usedPort.RefreshDevice(this.comboBox_portName, this.usedMsg);
            }
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
                    this.usedPort = new COMMPort();
                }
                //---注册端口
                this.usedPort = usePort;
                //---检查当前设备存在的端口信息
                this.usedPort.RefreshDevice(this.comboBox_portName, this.usedMsg);
                //---添加监控端口拔插事件
                this.usedPort.AddWatcherPortEvent(this.WatcherPortEventHandler, this.WatcherPortEventHandler, new TimeSpan(0, 0, 3));
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
                this.button_openDevice.Click += new EventHandler(this.button_Click);
            }

            this.pictureBox_portState.Tag = 0;

            //---点击图片控件
            this.pictureBox_portState.Click += new System.EventHandler(this.pictureBox_Click);

        }


        #endregion

        #region 函数定义

        /// <summary>
        /// 监控端口处理函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="msg"></param>
        public virtual void WatcherPortEventHandler(Object sender, EventArrivedEventArgs e)
        {
            if (this.usedPort!=null)
            {
                this.usedPort.WatcherPortEventHandler(sender, e, this.usedMsg);
            }
        }

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
            switch (btn.Text)
            {
                case "打开端口":
                    if (this.usedPort.OpenDevice(this.comboBox_portName.Text, this.usedMsg)==1)
                    {
                        this.pictureBox_portState.Tag =0;
                        btn.Text = "关闭端口";
                        this.pictureBox_portState.Image = Properties.Resources.open;
                        RichTextBoxPlus.AppendTextInfoTopWithDataTime(this.usedMsg, "端口打开成功!\r\n", Color.Black, false);
                    }
                    else
                    {
                        this.pictureBox_portState.Tag = 2;
                        this.pictureBox_portState.Image = Properties.Resources.error;
                        RichTextBoxPlus.AppendTextInfoTopWithDataTime(this.usedMsg, "端口打开失败!\r\n", Color.Red, false);
                    }
                    break;
                case "关闭端口":
                    if (this.usedPort!=null)
                    {
                        this.pictureBox_portState.Tag = 1;
                        this.usedPort.CloseDevice();
                        btn.Text = "打开端口";
                        this.pictureBox_portState.Image = Properties.Resources.lost;
                        RichTextBoxPlus.AppendTextInfoTopWithDataTime(this.usedMsg, "端口关闭成功!\r\n", Color.Black, false);
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
                case"pictureBox_portState":
                    //if(((new Bitmap(pb.Image)) !=Properties.Resources.open))
                    if ((Convert.ToByte(pb.Tag)!=0)&&(this.usedPort!=null))
                    {
                        //---刷新设备
                        this.usedPort.RefreshDevice(this.comboBox_portName, this.usedMsg);
                    }
                    break;
                default:
                    break;      
            }
        }

        #endregion

        #endregion


    }
}
