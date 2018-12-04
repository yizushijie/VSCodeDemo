using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UserControlPlusLib
{
    public partial class DeviceTypeControl : UserControl
    {

		#region 变量定义

		#endregion

		#region 属性定义

		/// <summary>
		/// 控件是够启用
		/// </summary>
		[Description("是否启用控件"), Category("自定义属性")]
		public virtual bool m_Enabled
		{
			get
			{
				return this.panel_deviceType.Enabled;
			}
			set
			{
				this.panel_deviceType.Enabled = value;
			}
		}

		/// <summary>
		/// 重命名控件
		/// </summary>
		[Description("修改当前控件的命名"), Category("自定义属性")]
        public virtual string m_FuncName
        {
            get
            {
                return this.groupBox_deviceType.Text;
            }
            set
            {
                this.groupBox_deviceType.Text = value;
            }
        }

        /// <summary>
        /// 设备类型
        /// </summary>
        [Description("设备的类型"), Category("自定义属性")]
        public virtual string m_DeviceType
        {
            get
            {
                return this.comboBox_deviceType.Text;
            }
            set
            {
                this.comboBox_deviceType.Text=value;
            }
        }

        /// <summary>
        /// 采样电阻的值
        /// </summary>
        [Description("采样电阻的大小"), Category("自定义属性")]
        public virtual float m_SampleRes
        {
            get
            {
                return (float)this.numericUpDown_sampleRes.Value;
            }
            set
            {
                this.numericUpDown_sampleRes.Value=(decimal)value;
            }
        }

        /// <summary>
        /// 放大倍数
        /// </summary>
        [Description("放大倍数"), Category("自定义属性")]
        public virtual float m_AmpTimes
        {
            get
            {
                return (float)this.numericUpDown_ampTimes.Value;
            }
            set
            {
                this.numericUpDown_ampTimes.Value = (decimal)value;
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
        public delegate void UserButtonClickHandle(object sender, EventArgs e,int index=0);

        [Description("当点击控件时发生，调用选中按钮控件逻辑"), Category("自定义事件")]
        public event UserButtonClickHandle UserButtonClick;

        #endregion

        #region 构造函数

        /// <summary>
        /// 
        /// </summary>
        public DeviceTypeControl()
        {
            InitializeComponent();

			//---设置Style支持透明背景色并且双缓冲
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			this.SetStyle(ControlStyles.ResizeRedraw, true);
			this.SetStyle(ControlStyles.Selectable, true);
			this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			this.SetStyle(ControlStyles.UserPaint, true);

			//---限定尺寸,尺寸不可更改
			this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            //---注册事件
            this.button_readDeviceConfig.Click += new EventHandler(this.button_Click);
            this.button_writeDeviceConfig.Click += new EventHandler(this.button_Click);

        
        }
        #endregion

        #region 初始化

        #endregion

        #region 事件定义


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Enabled = false;
            int index = 0;
            switch (btn.Name)
            {
                case "button_readDeviceConfig":
                    index = 1;
                    break;
                case "button_writeDeviceConfig":
                    index = 2;
                    break;
                default:
                    break;
            }
            //---执行委托函数
            if ((this.UserButtonClick != null) && (index != 0))
            {
                this.UserButtonClick(sender,e,index);
            }
            btn.Enabled = true;
        }

        #endregion

        #region 函数定义

        /// <summary>
        /// 设置设备的类型
        /// </summary>
        /// <param name="index"></param>
        public bool SetDeviceType(int index)
        {
            if ((this.comboBox_deviceType.Items == null) || (this.comboBox_deviceType.Items.Count == 0) || (this.comboBox_deviceType.Items.Count < index))
            {
                return false;

            }
            switch (index)
            {
                case 1:
                    this.comboBox_deviceType.Text = "SYN4XXR";
                    break;
                case 2:
                    this.comboBox_deviceType.Text = "SYN5XXR";
                    break;
                case 3:
                    this.comboBox_deviceType.Text = "CRUX";
                    break;
                case 4:
                    this.comboBox_deviceType.Text = "F11XT";
                    break;
                case 5:
                    this.comboBox_deviceType.Text = "CRATER";
                    break;
                case 6:
                    this.comboBox_deviceType.Text = "ARA";
                    break;
                default:
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 获取设备类型
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int GetDeviceType(string str)
        {
            if ((this.comboBox_deviceType.Items == null) || (this.comboBox_deviceType.Items.Count == 0) || (this.comboBox_deviceType.Text == null)|| (this.comboBox_deviceType.Text == "")|| (this.comboBox_deviceType.Text == string.Empty))
            {
                return 0;

            }
            int _return = 0;
            switch (str)
            {
                case "SYN4XXR":
                    _return = 1;
                    break;
                case "SYN5XXR":
                    _return = 2;
                    break;
                case "CRUX":
                    _return = 3;
                    break;
                case "F11XT":
                    _return = 4;
                    break;
                case "CRATER":
                    _return = 5;
                    break;
                case "ARA":
                    _return = 6;
                    break;
                default:
                    _return = 0;
                    break;
            }
            return _return;
        }

        #endregion

    }
}
