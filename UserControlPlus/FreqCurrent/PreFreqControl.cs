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
    public partial class PreFreqControl : UserControl
    {

        #region 变量定义

        #endregion

        #region 属性定义

        /// <summary>
        /// 重命名控件
        /// </summary>
        [Description("修改当前控件的命名"), Category("自定义属性")]
        public virtual string m_FuncName
        {
            get
            {
                return this.groupBox_preFreq.Text;
            }
            set
            {
                this.groupBox_preFreq.Text = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("预设的第一个频率点"), Category("自定义属性")]
        public virtual float m_PreFreqOne
        {
            get
            {
                return (float)this.numericUpDown_freqOne.Value;
            }
            set
            {
                this.numericUpDown_freqOne.Value = (decimal)value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("预设的第二个频率点"), Category("自定义属性")]
        public virtual float m_PreFreqTwo
        {
            get
            {
                return (float)this.numericUpDown_freqTwo.Value;
            }
            set
            {
                this.numericUpDown_freqTwo.Value = (decimal)value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("预设的第三个频率点"), Category("自定义属性")]
        public virtual float m_PreFreqThree
        {
            get
            {
                return (float)this.numericUpDown_freqThree.Value;
            }
            set
            {
                this.numericUpDown_freqThree.Value = (decimal)value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("预设的第四个频率点"), Category("自定义属性")]
        public virtual float m_PreFreqFour
        {
            get
            {
                return (float)this.numericUpDown_freqFour.Value;
            }
            set
            {
                this.numericUpDown_freqFour.Value = (decimal)value;
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
        public delegate void UserButtonClickHandle(int index = 0,int freqIndex=0);

        [Description("当点击控件时发生，调用选中按钮控件逻辑"), Category("自定义事件")]
        public event UserButtonClickHandle UserButtonClick;
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

            //---注册按钮事件
            this.button_readPreFreq.Click += new EventHandler(this.button_Click);
            this.button_writePreFreq.Click += new EventHandler(this.button_Click);

            //---注册值变化事件
            this.numericUpDown_preFreqIndex.ValueChanged += new EventHandler(this.numericUpDown_ValueChanged);

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
                case "button_readPreFreq":
                    index = 1;
                    break;
                case "button_writePreFreq":
                    index = 2;
                    break;
                default:
                    break;
            }
            //---执行委托函数
            if ((this.UserButtonClick != null) && (index != 0))
            {
                this.UserButtonClick(index,(int)this.numericUpDown_preFreqIndex.Value);
            }
            btn.Enabled = true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            int index = (int)nud.Value;
            switch (nud.Name)
            {
                case "numericUpDown_preFreqIndex":
                    if (index>5)
                    {
                        this.button_writePreFreq.Text = "频率输出";
                        if (this.button_readPreFreq.Enabled==true)
                        {
                            this.button_readPreFreq.Enabled = false;
                        }
                    }
                    else
                    {
                        this.button_writePreFreq.Text = "写入频率";
                        if (this.button_readPreFreq.Enabled == false)
                        {
                            this.button_readPreFreq.Enabled = true;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region 函数定义

        /// <summary>
        /// 设置预设频率
        /// </summary>
        /// <param name="index"></param>
        /// <param name="freq"></param>
        public virtual void SetPreFreqYSEL(int index,float freq)
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
        /// 设置参数
        /// </summary>
        /// <param name="cmd"></param>
        public virtual void SetPreFreqYSEL(float[] cmd)
        {
            if ((cmd==null)||(cmd.Length<4))
            {
                return;
            }
            this.m_PreFreqOne = cmd[0];
            this.m_PreFreqTwo = cmd[1];
            this.m_PreFreqThree = cmd[2];
            this.m_PreFreqFour = cmd[3];
        }

        /// <summary>
        /// 读取预设频率点
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public virtual float GetPreFreqYSEL(int index)
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

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <returns></returns>
        public virtual float[] GetPreFreqYSEL()
        {
            float[] _return = new float[4] { this.m_PreFreqOne,this.m_PreFreqTwo,this.m_PreFreqThree,this.m_PreFreqFour };
            return _return;
        }
        #endregion


    }
}
