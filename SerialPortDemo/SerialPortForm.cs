using COMMPortLib;
using System;
using System.Windows.Forms;

namespace SerialPortDemo
{
	public partial class SerialPortForm : Form
	{
		#region 变量定义

		private COMMPort useCOMMPort = null;

		#endregion 变量定义



		#region 构造函数

		/// <summary>
		///
		/// </summary>
		public SerialPortForm()
		{
			InitializeComponent();

			//---限定最小尺寸
			this.MinimumSize=this.Size;
		}

		#endregion 构造函数

		#region 事件定义

		/// <summary>
		/// 窗体加载定义
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SerialPortForm_Load(object sender, EventArgs e)
		{
			if (this.useCOMMPort==null)
			{
				this.useCOMMPort=new SerialCOMMPort();
			}

			//---初始化串口控件
			this.serialPortControl.Init(this, this.useCOMMPort, null);
		}

		#endregion 事件定义
	}
}