using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UserControlPlusLib.ClockRate
{
	public partial class ClockRateControl : UserControl
	{

        #region 变量定义

        #endregion

        #region 属性定义

        #endregion

        #region 委托函数

        /// <summary>
        /// 自定义事件的参数类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="orther"></param>
        public delegate void UserButtonClickHandle(int index=0);

        [Description("当点击控件时发生，调用选中按钮控件逻辑"), Category("自定义事件")]
        public event UserButtonClickHandle UserButtonClick;

        /// <summary>
        /// 自定义事件的参数类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="orther"></param>
        public delegate void UserButtonCheckControlClickHandle(int index = 0);

        [Description("当点击控件时发生，调用选中当前控件逻辑"), Category("自定义事件")]
        public event UserButtonCheckControlClickHandle UserButtonCheckControlClick;

        #endregion

        #region 构造函数

        /// <summary>
        /// 
        /// </summary>
        public ClockRateControl()
        {
            InitializeComponent();

            //---注册事件
            this.buttonCheckControl_Channel1.Click += new EventHandler(buttonCheckControl_Click);
            this.buttonCheckControl_Channel2.Click += new EventHandler(buttonCheckControl_Click);
            this.buttonCheckControl_Channel3.Click += new EventHandler(buttonCheckControl_Click);
            this.buttonCheckControl_Channel4.Click += new EventHandler(buttonCheckControl_Click);

			//---注册按键事件
			this.button_writeClockRate.Click += new EventHandler(button_Click);
            this.button_readClockRate.Click  += new EventHandler(button_Click);
            this.button_resetClockRate.Click += new EventHandler(button_Click);
		}

        #endregion

        #region 事件定义

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void buttonCheckControl_Click(object sender, EventArgs e)
        {

            ButtonCheckControl bcc = (ButtonCheckControl)sender;
            int index = 0;
            switch (bcc.Name)
            {
                case "buttonCheckControl_Channel1":
                    index = 1;
                    break;
                case "buttonCheckControl_Channel2":
                    index = 2;
                    break;
                case "buttonCheckControl_Channel3":
                    index = 3;
                    break;
                case "buttonCheckControl_Channel4":
                    index = 4;
                    break;
                default:
                    break;
            }
            //---执行委托函数
            if ((this.UserButtonCheckControlClick!=null)&&(index!=0))
            {
                this.UserButtonCheckControlClick(index);
            }
        }


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
				case "button_writeClockRate":
                    index = 1;
					break;
                case "button_readClockRate":
                    index = 2;
                    break;
                case "button_resetClockRate":
                    index = 3;
                    break;
                default:
					break;
			}
            //---执行委托函数
            if ((this.UserButtonClick != null) && (index != 0))
            {
                this.UserButtonClick(index);
            }
            btn.Enabled = true;
		}

		#endregion


	}
}
