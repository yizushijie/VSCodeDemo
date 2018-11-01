using MessageBoxPlusLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RFASKFreqCurrentForm
{
    public partial class RFASKFreqCurrentForm : Form
    {

        #region 变量定义


        #endregion

        #region 属性定义

        #endregion

        #region 构造函数

        /// <summary>
        /// 
        /// </summary>
        public RFASKFreqCurrentForm()
        {
            InitializeComponent();

            //---限定尺寸,尺寸不可更改
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            //---窗体加载事件
            this.Load += new EventHandler(this.Form_Load);
            //---窗体关闭事件
            this.FormClosing += new FormClosingEventHandler(this.Form_Closing);

        }

        #endregion

        #region 初始化

        /// <summary>
        /// 
        /// </summary>
        /// <param name=""></param>
        public virtual void Start_Init()
        {
            this.RegisterEventHandle();
        }

        /// <summary>
        /// 注册事件处理
        /// </summary>
        public virtual void RegisterEventHandle()
        {
            //---定时器
            this.timer_SysTick.Tick += new EventHandler(this.timer_Tick);



        }

        /// <summary>
        /// 销毁事件处理
        /// </summary>
        public virtual void UnRegisterEventHandle()
        {

        }

        #endregion

        #region 事件定义

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void Form_Load(object sender, EventArgs e)
        {
            this.Start_Init();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.MdiFormClosing)
            {
                return;
            }
            else if (e.CloseReason == CloseReason.UserClosing)
            {
                if (DialogResult.OK == MessageBoxPlus.Show(this, "你确定要关闭应用程序吗？", "关闭提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {
                    //---为保证Application.Exit();时不再弹出提示，所以将FormClosing事件取消
                    this.FormClosing -= new FormClosingEventHandler(this.Form_Closing);
                    //---确认关闭事件
                    e.Cancel = false;
                    //---退出当前窗体
                    this.Dispose();
                }
                else
                {
                    //---取消关闭事件
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void timer_Tick(object sender, EventArgs e)
        {
            //---刷新时间
            this.toolStripLabel_SysTick.Text = System.DateTime.Now.ToString();
        }

        #endregion

        #region 函数定义

        #endregion


    }
}
