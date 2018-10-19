using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlPlusLib.ClockRate
{
	public partial class ClockRateControl : UserControl
	{

        #region 变量定义

        /// <summary>
        /// 用户使用的点击事件1
        /// </summary>
        public event EventHandler UserClickChannel1;

        /// <summary>
        /// 用户使用的点击事件2
        /// </summary>
        public event EventHandler UserClickChannel2;

        /// <summary>
        /// 用户使用的点击事件3
        /// </summary>
        public event EventHandler UserClickChannel3;

        /// <summary>
        /// 用户使用的点击事件4
        /// </summary>
        public event EventHandler UserClickChannel4;

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
                    if (this.UserClickChannel1 != null)
                    {
                        this.UserClickChannel1(sender, e);
                    }
                    break;
                case "buttonCheckControl_Channel2":
                    //---用户事件
                    if (this.UserClickChannel2 != null)
                    {
                        this.UserClickChannel2(sender, e);
                    }
                    break;
                case "buttonCheckControl_Channel3":
                    //---用户事件
                    if (this.UserClickChannel3 != null)
                    {
                        this.UserClickChannel3(sender, e);
                    }
                    break;
                case "buttonCheckControl_Channel4":
                    //---用户事件
                    if (this.UserClickChannel4 != null)
                    {
                        this.UserClickChannel4(sender, e);
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion


    }
}
