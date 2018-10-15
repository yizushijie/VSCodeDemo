using MessageBoxPlusLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MdiForm
{
	public partial class MdiForm : Form
	{
		#region 初始化
		/// <summary>
		/// 
		/// </summary>
		public MdiForm()
		{
			InitializeComponent();
		}
		#endregion


		#region 窗体

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MdiForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			//---判断是Mdi窗体
			if (e.CloseReason == CloseReason.MdiFormClosing)
			{
				if (DialogResult.OK == MessageBoxPlus.Show(this, "你确定要关闭应用程序吗？", "关闭提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
				{
					//----为保证Application.Exit();时不再弹出提示，所以将FormClosing事件取消
					this.FormClosing -= new System.Windows.Forms.FormClosingEventHandler(this.MdiForm_FormClosing);
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
		#endregion

	}
}
