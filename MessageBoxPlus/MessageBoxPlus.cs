using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MessageBoxPlusLib
{
	
	/// <summary>
	/// 显示函数居中显示
	/// </summary>
	public static class MessageBoxPlus
	{
		/*------------------------------------
		* MessageBox自动显示在父窗体的中心位置
		* ----------------------------------*/

		public static DialogResult Show(Form owner, String msg)
		{
			MessageBoxPlusHelp.MessageBoxCenterTask(owner);
			return MessageBox.Show(msg);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="owner"></param>
		/// <param name="text"></param>
		/// <param name="caption"></param>
		/// <returns></returns>
		public static DialogResult Show(Form owner, String text, String caption)
		{
			MessageBoxPlusHelp.MessageBoxCenterTask(owner);
			return MessageBox.Show(text, caption);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="owner"></param>
		/// <param name="text"></param>
		/// <param name="caption"></param>
		/// <param name="buttons"></param>
		/// <returns></returns>
		public static DialogResult Show(Form owner, String text, String caption, MessageBoxButtons buttons)
		{
			MessageBoxPlusHelp.MessageBoxCenterTask(owner);
			return MessageBox.Show(text, caption, buttons);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="owner"></param>
		/// <param name="text"></param>
		/// <param name="caption"></param>
		/// <param name="buttons"></param>
		/// <param name="icon"></param>
		/// <returns></returns>
		public static DialogResult Show(Form owner, String text, String caption, MessageBoxButtons buttons, MessageBoxIcon icon)
		{
			MessageBoxPlusHelp.MessageBoxCenterTask(owner);
			return MessageBox.Show(text, caption, buttons, icon);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="owner"></param>
		/// <param name="text"></param>
		/// <param name="caption"></param>
		/// <param name="buttons"></param>
		/// <param name="icon"></param>
		/// <param name="defButton"></param>
		/// <returns></returns>
		public static DialogResult Show(Form owner, String text, String caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defButton)
		{
			MessageBoxPlusHelp.MessageBoxCenterTask(owner);
			return MessageBox.Show(text, caption, buttons, icon, defButton);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="owner"></param>
		/// <param name="text"></param>
		/// <param name="caption"></param>
		/// <param name="buttons"></param>
		/// <param name="icon"></param>
		/// <param name="defButton"></param>
		/// <param name="options"></param>
		/// <returns></returns>
		public static DialogResult Show(Form owner, String text, String caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defButton, MessageBoxOptions options)
		{
			MessageBoxPlusHelp.MessageBoxCenterTask(owner);
			return MessageBox.Show(text, caption, buttons, icon, defButton, options);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="owner"></param>
		/// <param name="text"></param>
		/// <param name="caption"></param>
		/// <param name="buttons"></param>
		/// <param name="icon"></param>
		/// <param name="defaultButton"></param>
		/// <param name="options"></param>
		/// <param name="helpFilePath"></param>
		/// <returns></returns>
		public static DialogResult Show(Form owner, String text, String caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, String helpFilePath)
		{
			MessageBoxPlusHelp.MessageBoxCenterTask(owner);
			return MessageBox.Show(text, caption, buttons, icon, defaultButton, options, helpFilePath);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="owner"></param>
		/// <param name="text"></param>
		/// <param name="caption"></param>
		/// <param name="buttons"></param>
		/// <param name="icon"></param>
		/// <param name="defaultButton"></param>
		/// <param name="options"></param>
		/// <param name="helpFilePath"></param>
		/// <param name="keyword"></param>
		/// <returns></returns>
		public static DialogResult Show(Form owner, String text, String caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, String helpFilePath, String keyword)
		{
			MessageBoxPlusHelp.MessageBoxCenterTask(owner);
			return MessageBox.Show(text, caption, buttons, icon, defaultButton, options, helpFilePath, keyword);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="owner"></param>
		/// <param name="text"></param>
		/// <param name="caption"></param>
		/// <param name="buttons"></param>
		/// <param name="icon"></param>
		/// <param name="defaultButton"></param>
		/// <param name="options"></param>
		/// <param name="helpFilePath"></param>
		/// <param name="navigator"></param>
		/// <returns></returns>
		public static DialogResult Show(Form owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, HelpNavigator navigator)
		{
			MessageBoxPlusHelp.MessageBoxCenterTask(owner);
			return MessageBox.Show(text, caption, buttons, icon, defaultButton, options, helpFilePath, navigator);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="owner"></param>
		/// <param name="text"></param>
		/// <param name="caption"></param>
		/// <param name="buttons"></param>
		/// <param name="icon"></param>
		/// <param name="defaultButton"></param>
		/// <param name="options"></param>
		/// <param name="helpFilePath"></param>
		/// <param name="navigator"></param>
		/// <param name="param"></param>
		/// <returns></returns>
		public static DialogResult Show(Form owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, HelpNavigator navigator, Object param)
		{
			MessageBoxPlusHelp.MessageBoxCenterTask(owner);
			return MessageBox.Show(text, caption, buttons, icon, defaultButton, options, helpFilePath, navigator, param);
		}
	}
}