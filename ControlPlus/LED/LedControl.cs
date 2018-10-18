using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlPlusLib.LED
{
    public partial class LedControl : UserControl
    {

        #region 变量定义

        /// <summary>
        /// 判断是否注册了点击事件
        /// </summary>
        private bool isAddClickEven = false;
        
        #endregion


        #region 属性定义

        /// <summary>
        /// LED的颜色
        /// </summary>
        public virtual Color LedColor
        {
            get
            {
                return this.ledButtonControl_led.LedColor;
            }
            set
            {
                this.ledButtonControl_led.LedColor = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool Checked
        {
            get
            {
               return this.buttonCheckControl_led.Checked;
            }
            set
            {
                this.buttonCheckControl_led.Checked = value;
            }
        }


        /// <summary>
        /// 添加点击事件
        /// </summary>
        public virtual EventHandler AddClickEvent
        {
            set
            {
                this.buttonCheckControl_led.Click += value;
                this.isAddClickEven = true;
            }
        }

        /// <summary>
        /// 移除点击事件
        /// </summary>

        public virtual EventHandler RemoveClickEvent
        {
            set
            {
                if (this.isAddClickEven)
                {
                    this.buttonCheckControl_led.Click -= value;
                    this.isAddClickEven = false;
                }
                
            }
        }


        #endregion

        #region 构造函数

        /// <summary>
        /// 
        /// </summary>
        public LedControl()
        {
            InitializeComponent();

            //---限定尺寸,尺寸不可更改
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

        #endregion

        #region 事件定义

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void buttonCheckControl_Click(object sender, EventArgs e)
        {

            ButtonCheckControl bcc = (ButtonCheckControl)sender;
            switch(bcc.Name)
            {
                case "buttonCheckControl_led":
                    if (this.buttonCheckControl_led.Checked)
                    {
                        this.ledButtonControl_led.LedColor = Color.Red;
                    }
                    else
                    {
                        this.ledButtonControl_led.LedColor = Color.Black;
                    }
                    break;
                default:
                    break;
            }
        }

    }
}
