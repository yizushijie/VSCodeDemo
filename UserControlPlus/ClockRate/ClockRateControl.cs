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

        /// <summary>
        /// 用户使用的点击事件1
        /// </summary>
        public event EventHandler UserButtonCheckControlClickChannel1=null;

        /// <summary>
        /// 用户使用的点击事件2
        /// </summary>
        public event EventHandler UserButtonCheckControlClickChannel2=null;

        /// <summary>
        /// 用户使用的点击事件3
        /// </summary>
        public event EventHandler UserButtonCheckControlClickChannel3=null;

        /// <summary>
        /// 用户使用的点击事件4
        /// </summary>
        public event EventHandler UserButtonCheckControlClickChannel4=null;

		/// <summary>
		/// 用户设置点击事件
		/// </summary>
		public event EventHandler UserButtonSetClick=null;

		// <summary>
		/// 用户复位点击事件
		/// </summary>
		public event EventHandler UserButtonResetClick=null;

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
			this.button_setClockRate.Click += new EventHandler(button_Click);
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
            switch (bcc.Name)
            {
                case "buttonCheckControl_Channel1":
                    //---用户事件
                    if (this.UserButtonCheckControlClickChannel1 != null)
                    {
                        this.UserButtonCheckControlClickChannel1(sender, e);
                    }
                    break;
                case "buttonCheckControl_Channel2":
                    //---用户事件
                    if (this.UserButtonCheckControlClickChannel2 != null)
                    {
                        this.UserButtonCheckControlClickChannel2(sender, e);
                    }
                    break;
                case "buttonCheckControl_Channel3":
                    //---用户事件
                    if (this.UserButtonCheckControlClickChannel3 != null)
                    {
                        this.UserButtonCheckControlClickChannel3(sender, e);
                    }
                    break;
                case "buttonCheckControl_Channel4":
                    //---用户事件
                    if (this.UserButtonCheckControlClickChannel4 != null)
                    {
                        this.UserButtonCheckControlClickChannel4(sender, e);
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
		public virtual void button_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			btn.Enabled = false;
			switch (btn.Name)
			{
				case "button_setClockRate":
					//---处理时钟设置事件
					if (this.UserButtonSetClick!=null)
					{
						this.UserButtonSetClick(sender, e);
					}
					break;
				case "button_resetClockRate":
					//---处理时钟复位事件
					if (this.UserButtonResetClick != null)
					{
						this.UserButtonResetClick(sender, e);
					}
					break;
				default:
					break;
			}
			btn.Enabled = true;
		}

		#endregion


	}
}
