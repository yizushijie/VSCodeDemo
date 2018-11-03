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

        /// <summary>
        /// 重命名控件
        /// </summary>
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

        /// <summary>
        /// 设备类型
        /// </summary>
        [Description("扫描的起始频率"), Category("自定义属性")]
        public virtual float m_StartFreq
        {
            get
            {
                return (float) this.numericUpDown_startFreq.Value ;
            }
            set
            {
                this.numericUpDown_startFreq.Value=(decimal)value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("扫描频率的步进"), Category("自定义属性")]
        public virtual float m_StepFreq
        {
            get
            {
                return (float)this.numericUpDown_stepFreq.Value;
            }
            set
            {
                this.numericUpDown_stepFreq.Value = (decimal)value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("扫描的点数"), Category("自定义属性")]
        public virtual int m_StepPointNum
        {
            get
            {
                return (int)this.numericUpDown_stepPointNum.Value;
            }
            set
            {
                this.numericUpDown_stepPointNum.Value = (decimal)value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("起始点的电流合格下线（最小值），单位mA"), Category("自定义属性")]
        public virtual float m_StartPassMin
        {
            get
            {
                return (float)this.numericUpDown_startPassMin.Value;
            }
            set
            {
                this.numericUpDown_startPassMin.Value = (decimal)value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("起始点的电流合格上线（最大值），单位mA"), Category("自定义属性")]
        public virtual float m_StartPassMax
        {
            get
            {
                return (float)this.numericUpDown_startPassMax.Value;
            }
            set
            {
                this.numericUpDown_startPassMax.Value = (decimal)value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("终止点的电流合格下线（最小值），单位mA"), Category("自定义属性")]
        public virtual float m_StopPassMin
        {
            get
            {
                return (float)this.numericUpDown_stopPassMin.Value;
            }
            set
            {
                this.numericUpDown_stopPassMin.Value = (decimal)value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("终止点的电流合格上线（最大值），单位mA"), Category("自定义属性")]
        public virtual float m_StopPassMax
        {
            get
            {
                return (float)this.numericUpDown_stopPassMax.Value;
            }
            set
            {
                this.numericUpDown_stopPassMax.Value = (decimal)value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("合格条件的点数"), Category("自定义属性")]
        public virtual int m_PassSpacePointNum
        {
            get
            {
                return (int)this.numericUpDown_passSpacePointNum.Value;
            }
            set
            {
                this.numericUpDown_passSpacePointNum.Value = (decimal)value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("合格条件的上线(最大值),几个ADC数字量"), Category("自定义属性")]
        public virtual int m_PassSpacePointMax
        {
            get
            {
                return (int)this.numericUpDown_passSpacePointMax.Value;
            }
            set
            {
                this.numericUpDown_passSpacePointMax.Value = (decimal)value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("合格条件的下线(最小值),几个ADC数字量"), Category("自定义属性")]
        public virtual int m_PassSpacePointMin
        {
            get
            {
                return (int)this.numericUpDown_passSpacePointMin.Value;
            }
            set
            {
                this.numericUpDown_passSpacePointMin.Value = (decimal)value;
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
        public delegate void UserButtonClickHandle(object sender, EventArgs e, int index = 0);

        [Description("当点击控件时发生，调用选中按钮控件逻辑"), Category("自定义事件")]
        public event UserButtonClickHandle UserButtonClick;

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
            Button btn = (Button)sender;
            btn.Enabled = false;
            int index = 0;
            switch (btn.Name)
            {
                case "button_readFreqConfig":
                    index = 1;
                    break;
                case "button_writeFreqConfig":
                    index = 2;
                    break;
                case "button_readPassConfig":
                    index = 3;
                    break;
                case "button_writePassConfig":
                    index = 3;
                    break;
                case "button_startDo":
                    index = 3;
                    break;
                default:
                    break;
            }
            //---执行委托函数
            if ((this.UserButtonClick != null) && (index != 0))
            {
                this.UserButtonClick(sender,e,index);
            }
            btn.Enabled = true;
        }
        #endregion

        #region 函数定义

        /// <summary>
        /// 设置用户控件参数
        /// </summary>
        public void SetUserControlParameter(float[] cmd)
        {

        }

        /// <summary>
        /// 获取用户控件参数
        /// </summary>
        /// <returns></returns>
        public float[] GetUserControlParameter()
        {
            float[] _return=new float[10] {this.m_StartFreq,this.m_StepFreq,this.m_StepPointNum,this.m_StartPassMin,this.m_StartPassMax,this.m_PassSpacePointNum,this.m_PassSpacePointMin,this.m_PassSpacePointMax,this.m_StopPassMin,this.m_StopPassMax };
            return _return;
        }

        #endregion

    }
}
