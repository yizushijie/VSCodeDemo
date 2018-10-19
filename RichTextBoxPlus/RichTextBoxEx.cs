using GenFuncLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RichTextBoxPlusLib
{
    /// <summary>
    /// 功能拓展
    /// </summary>
    public class RichTextBoxEx:RichTextBox
    {

        #region 变量定义
        /// <summary>
        /// 
        /// </summary>
        private ContextMenuStrip usedContextMenuStrip = new ContextMenuStrip();

        /// <summary>
        /// 用户使用的点击事件
        /// </summary>
        public event EventHandler UserClick;

        #endregion

        #region 构造函数

        /// <summary>
        /// 
        /// </summary>
        public  RichTextBoxEx():base()
        {
            //加载contextMenuTrip的子项---消息显示的清楚和
            ToolStripItem tsItem;
            this.ContextMenuStrip = this.usedContextMenuStrip;
            //---添加清楚消息的功能
            tsItem = GenFunc.AddContextMenu("清除", this.usedContextMenuStrip.Items, new EventHandler(this.buttonClear_Click));
            this.ContextMenuStrip.Width = 64;

        }

        #endregion

        #region 事件定义

        /// <summary>
		/// 删除操作
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonClear_Click(object sender, EventArgs e)
        {
            this.Clear();
            if (this.UserClick!=null)
            {
                this.UserClick(sender, e);
            }
        }

        #endregion

        #region 函数定义

       
        #endregion
    }
}
