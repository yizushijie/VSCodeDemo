using COMMPortLib;
using MessageBoxPlusLib;
using RFASKFreqCurrentScanLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RFASKFreqCurrentScanForm
{
    public partial class RFASKFreqCurrentScanForm : Form
    {
        #region 变量定义

        private RFASKFreqCurrentScan usedRFASKFreqCurrentScan = null;

        #endregion

        public RFASKFreqCurrentScanForm()
        {
            InitializeComponent();
        }
        #region 函数重载
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if (this.usedRFASKFreqCurrentScan!=null)
            {
                //---检查设备是否发生变化
                int _return= this.usedRFASKFreqCurrentScan.DevicesChangedEvent(ref m, null, this.richTextBox_msg);
                if (_return!=0)
                {
                    //---设备发生变化
                    this.usedRFASKFreqCurrentScan.m_COMMPort.m_COMMPortRefresh = true;
                    return;
                }
            }
            base.WndProc(ref m);
        }

        #endregion

        /// <summary>
        /// 窗体关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RFASKFreqCurrentScanForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.MdiFormClosing)
            {
                return;
            }
            else if (e.CloseReason == CloseReason.UserClosing)
            {
                if (DialogResult.OK == MessageBoxPlus.Show(this, "你确定要关闭应用程序吗？", "关闭提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {
                    //---为保证Application.Exit();时不再弹出提示，所以将FormClosing事件取消
                    this.FormClosing -= new FormClosingEventHandler(this.RFASKFreqCurrentScanForm_FormClosing);
                    //---确认关闭事件
                    e.Cancel = false;
                    //退出当前应用---如果是MDI窗体,会导致整个应用退出
                    //Application.Exit();
                    //---退出当前窗体
                    this.Dispose();
                }
                else
                {
                    //---取消关闭事件
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// 船体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RFASKFreqCurrentScanForm_Load(object sender, EventArgs e)
        {
            this.Startup_Init();

            if (this.usedRFASKFreqCurrentScan==null)
            {
                this.usedRFASKFreqCurrentScan = new RFASKFreqCurrentScan(this, new SerialCOMMPort(this));
                //---刷新当前设备
                this.usedRFASKFreqCurrentScan.m_COMMPort.Init(this.comboBox_portName);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        private void Startup_Init()
        {
            this.RegistrationEvent();
        }

        #region 事件初始化

        /// <summary>
		/// 事件注册
		/// </summary>
		private void RegistrationEvent()
        {
            //---加载contextMenuTrip的子项---消息显示的清除按钮
            ToolStripItem tsItem;
            tsItem = this.AddContextMenu("清除", this.contextMenuStrip_richTextBox_msg.Items, new EventHandler(this.button_Click));

            //---注册时间控件
            this.timer_SysTick.Tick += new System.EventHandler(this.timer_Tick);

			//---按键功能注册
			this.button_openDevice.Click += new EventHandler(this.button_Click);
			this.button_closeDevice.Click += new EventHandler(this.button_Click);
			this.button_writeFreqHz.Click += new EventHandler(this.button_Click);
			this.button_readFreqHz.Click+= new EventHandler(this.button_Click);
			this.button_resetFreqHz.Click+= new EventHandler(this.button_Click); 
			this.button_setFreqChannel.Click += new EventHandler(this.button_Click);

			//---checkBox事件注册
			this.checkBox_freqChannelA.MouseClick += new MouseEventHandler(this.checkBox_MouseClick);
			this.checkBox_freqChannelB.MouseClick += new MouseEventHandler(this.checkBox_MouseClick);
			this.checkBox_freqChannelC.MouseClick += new MouseEventHandler(this.checkBox_MouseClick);
			this.checkBox_freqChannelD.MouseClick += new MouseEventHandler(this.checkBox_MouseClick);
		}

        /// <summary>
        /// 
        /// </summary>
        private void UnRegistrationEvent()
        {
        }
		#endregion

		#region 控件事件

		#region button 按钮事件

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button_Click(object sender, EventArgs e)
		{
			string str = sender.ToString();
			if (str == "清除")
			{
				this.richTextBox_msg.Clear();
			}
			else
			{
				if (this.usedRFASKFreqCurrentScan == null)
				{
					MessageBoxPlus.Show(this, "应用发生配置错误，请重新启动！", "错误提示!", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				Button btn = (Button)sender;
				btn.Enabled = false;
				DialogResult dgTemp;
				int _return = 0;
				//---检查那个按钮使用
				switch (btn.Name)
				{
					case "button_openDevice":
						_return = this.usedRFASKFreqCurrentScan.OpenDevice(this.comboBox_portName.Text, this.richTextBox_msg);
						if (_return == 0)
						{
							return;
						}
						break;
					case "button_closeDevice":
						_return = this.usedRFASKFreqCurrentScan.CloseDevice(this.comboBox_portName.Text, this.richTextBox_msg);
						if(this.button_openDevice.Enabled==false)
						{
							this.button_openDevice.Enabled = true;
						}
						break;
					case "button_writeFreqHz":
						_return = this.usedRFASKFreqCurrentScan.WriteFreqHzToDevice(this.numericUpDown_freqHz, this.richTextBox_msg);
						break;
					case "button_readFreqHz":
						_return = this.usedRFASKFreqCurrentScan.ReadFreqHzFromDevice(this.numericUpDown_freqHz, this.richTextBox_msg);
						break;
					case "button_resetFreqHz":
						_return = this.usedRFASKFreqCurrentScan.ResetFreqHzToDevice(this.numericUpDown_freqHz, this.richTextBox_msg);
						break;
					case "button_setFreqChannel":
						break;
					default:
						break;
				}
				btn.Enabled = true;
			}
		}
        #endregion

        #region 定时器事件
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            if ((this.usedRFASKFreqCurrentScan!=null)&&(this.usedRFASKFreqCurrentScan.m_COMMPort!=null))
            {
                if (this.usedRFASKFreqCurrentScan.m_COMMPort.m_COMMPortRefresh)
                {
                    //---刷新当前设备
                    this.usedRFASKFreqCurrentScan.m_COMMPort.Init(this.comboBox_portName);
                    //---置位设备为未刷新状态
                    this.usedRFASKFreqCurrentScan.m_COMMPort.m_COMMPortRefresh = false;
					//---判断按键
					if ((this.usedRFASKFreqCurrentScan.m_COMMPort.m_COMMPortName != this.comboBox_portName.Text) && (this.button_openDevice.Enabled == false))
					{
						this.button_openDevice.Enabled = true;
					}
                }
            }
            this.toolStripLabel_SysTick.Text = System.DateTime.Now.ToString();
        }
		#endregion

		#region checkBox 鼠标点击事件
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void checkBox_MouseClick(object sender, MouseEventArgs e)
		{
			CheckBox cb = (CheckBox)sender;
			switch (cb.Name)
			{
				case "checkBox_freqChannelA":
					if (cb.Checked)
					{
						cb.Text = "通道A使能";
					}
					else
					{
						cb.Text = "通道A不使能";
					}
					break;
				case "checkBox_freqChannelB":
					if (cb.Checked)
					{
						cb.Text = "通道B使能";
					}
					else
					{
						cb.Text = "通道B不使能";
					}
					break;
				case "checkBox_freqChannelC":
					if (cb.Checked)
					{
						cb.Text = "通道C使能";
					}
					else
					{
						cb.Text = "通道C不使能";
					}
					break;
				case "checkBox_freqChannelD":
					if (cb.Checked)
					{
						cb.Text = "通道D使能";
					}
					else
					{
						cb.Text = "通道D不使能";
					}
					break;
				default:
					break;
			}
		}
		#endregion

		#endregion

		#region 函数定义

		/// <summary>  
		/// 添加子菜单  
		/// </summary>
		/// <param name="text">要显示的文字，如果为 - 则显示为分割线</param>
		/// <param name="cms">要添加到的子菜单集合</param>
		/// <param name="callback">点击时触发的事件</param>
		/// <returns>生成的子菜单，如果为分隔条则返回null</returns>
		private ToolStripMenuItem AddContextMenu(string text, ToolStripItemCollection cms, EventHandler callback)
        {
            if (text == "-")
            {
                ToolStripSeparator tsp = new ToolStripSeparator();
                cms.Add(tsp);
                return null;
            }
            else if (!string.IsNullOrEmpty(text))
            {
                ToolStripMenuItem tsmi = new ToolStripMenuItem(text);
                if (callback != null)
                {
                    tsmi.Click += callback;
                }
                cms.Add(tsmi);
                return tsmi;
            }
            return null;
        }

		#endregion
	}
}
