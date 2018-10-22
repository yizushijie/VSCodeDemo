using COMMPortLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SerialPortDemo
{
    public partial class SerialPortForm : Form
    {
        #region 变量定义

        private COMMPort useCOMMPort = null;

        #endregion

        #region 属性定义

        #endregion

        #region 构造函数

        /// <summary>
        /// 
        /// </summary>
        public SerialPortForm()
        {
            InitializeComponent();

            //---限定最小尺寸
            this.MinimumSize = this.Size;
        }


        #endregion

        #region 事件定义
        /// <summary>
        /// 窗体加载定义
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerialPortForm_Load(object sender, EventArgs e)
        {
            if (this.useCOMMPort == null)
            {
                this.useCOMMPort = new SerialCOMMPort();
            }
            //---初始化串口控件
            this.serialPortControl.Init(this, this.useCOMMPort, null);
        }
        #endregion

        #region 初始化

        #endregion


    }
}
