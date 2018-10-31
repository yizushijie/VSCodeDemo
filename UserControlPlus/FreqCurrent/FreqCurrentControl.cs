using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UserControlPlusLib.FreqCurrent
{
    public partial class FreqCurrentControl : UserControl
    {
        #region 变量定义

        #endregion

        #region 属性定义
        [Description("修改当前控件的命名"), Category("自定义属性")]
        public virtual string  m_FuncName
        {
            get
            {
                return this.groupBox_funcName.Text;
            }
            set
            {
                this.groupBox_funcName.Text = value;
            }
        }

        #endregion

        #region 委托定义

        #endregion

        #region 构造函数

        /// <summary>
        /// 
        /// </summary>
        public FreqCurrentControl()
        {
            InitializeComponent();

            //---限定尺寸,尺寸不可更改
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            //---注册事件
            this.button_readFreqConfig.Click += new EventHandler(this.button_Click);
            this.button_writeFreqConfig.Click += new EventHandler(this.button_Click);

            //---注册事件
            this.button_readPassConfig.Click += new EventHandler(this.button_Click);
            this.button_writePassConfig.Click += new EventHandler(this.button_Click);

            //---注册事件
            this.button_startDo.Click += new EventHandler(this.button_Click);
           
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
