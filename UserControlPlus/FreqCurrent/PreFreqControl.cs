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
    public partial class PreFreqControl : UserControl
    {

        #region 变量定义

        #endregion

        #region 属性定义

        #endregion

        #region 委托定义

        #endregion

        #region 构造函数

        /// <summary>
        /// 
        /// </summary>
        public PreFreqControl()
        {
            InitializeComponent();

            //---限定尺寸,尺寸不可更改
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            //---注册事件
            this.button_readPreFreq.Click += new EventHandler(this.button_Click);
            this.button_writePreFreq.Click += new EventHandler(this.button_Click);

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

        /// <summary>
        /// 设置预设频率
        /// </summary>
        /// <param name="index"></param>
        /// <param name="freq"></param>
        public virtual void  SetPreFreq(int index,float freq)
        {
            switch (index)
            {
                case 1:
                    this.numericUpDown_freqOne.Value =(decimal)freq;
                    break;
                case 2:
                    this.numericUpDown_freqTwo.Value = (decimal)freq;
                    break;
                case 3:
                    this.numericUpDown_freqThree.Value = (decimal)freq;
                    break;
                case 4:
                    this.numericUpDown_freqFour.Value = (decimal)freq;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 读取预设频率点
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public virtual float GetPreFreq(int index)
        {
            float _return = 0;
            switch (index)
            {
                case 1:
                    _return=(float) this.numericUpDown_freqOne.Value;
                    break;
                case 2:
                    _return = (float)this.numericUpDown_freqTwo.Value;
                    break;
                case 3:
                    _return = (float)this.numericUpDown_freqThree.Value ;
                    break;
                case 4:
                    _return = (float)this.numericUpDown_freqFour.Value;
                    break;
                default:
                    break;
            }
            return _return;
        }

       
        #endregion


    }
}
