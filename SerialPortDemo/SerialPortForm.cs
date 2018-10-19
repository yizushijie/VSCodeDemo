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


    }
}
