﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UserControlPlusLib.DeviceType
{
    public partial class DeviceTypeControl : UserControl
    {

        #region 变量定义

        #endregion

        #region 属性定义

        /// <summary>
        /// 
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
                this.comboBox_deviceType.Items.Add(value);
            }
        }

        #endregion

        #region 委托定义

        #endregion

        #region 构造函数

        /// <summary>
        /// 
        /// </summary>
        public DeviceTypeControl()
        {
            InitializeComponent();

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
            
        }

        #endregion

        #region 函数定义

        #endregion

    }
}
