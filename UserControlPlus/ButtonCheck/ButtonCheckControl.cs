using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace UserControlPlusLib
{
	public enum CheckStyle
	{
		style1 = 0,
		style2 = 1,
		style3 = 2,
		style4 = 3,
		style5 = 4,
		style6 = 5
	};

	/// <summary>
	/// 用户控件
	/// </summary>
	public partial class ButtonCheckControl : UserControl
	{
		#region 变量定义

		/// <summary>
		///
		/// </summary>
		private bool isCheck = false;

		/// <summary>
		///
		/// </summary>
		private CheckStyle checkStyle = CheckStyle.style1;

		#endregion 变量定义

		#region 属性定义

		/// <summary>
		/// 是否选中
		/// </summary>
		/// <summary>
		/// 设置LED的颜色
		/// </summary>
		[Description("修改此值，可修改选中的状态"), Category("自定义属性")]
		public bool Checked
		{
			get
			{
				return this.isCheck;
			}

			set
			{
				this.isCheck=value;
				this.Invalidate();
			}
		}

		/// <summary>
		/// 样式
		/// </summary>
		/// <summary>
		/// 设置LED的颜色
		/// </summary>
		[Description("修改此值，可修改选中的样式"), Category("自定义属性")]
		public CheckStyle CheckStylePlus
		{
			get
			{
				return this.checkStyle;
			}

			set
			{
				this.checkStyle=value;
				this.Invalidate();
			}
		}

		#endregion 属性定义

		#region 构造函数

		/// <summary>
		///
		/// </summary>
		public ButtonCheckControl()
		{
			InitializeComponent();

			//设置Style支持透明背景色并且双缓冲
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			this.SetStyle(ControlStyles.ResizeRedraw, true);
			this.SetStyle(ControlStyles.Selectable, true);
			this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			this.SetStyle(ControlStyles.UserPaint, true);
			this.BackColor=Color.Transparent;

			this.Cursor=Cursors.Hand;

			this.Size=new System.Drawing.Size(87, 27);

			//---限定尺寸,尺寸不可更改
			//this.MinimumSize = this.Size;
			//this.MaximumSize = this.Size;
		}

		#endregion 构造函数

		#region 重载函数

		/// <summary>
		///
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitMapOn = null;
			Bitmap bitMapOff = null;

			if (checkStyle==CheckStyle.style1)
			{
				bitMapOn=global::UserControlPlusLib.Properties.Resources.btncheckon1;
				bitMapOff=global::UserControlPlusLib.Properties.Resources.btncheckoff1;
			}
			else if (checkStyle==CheckStyle.style2)
			{
				bitMapOn=global::UserControlPlusLib.Properties.Resources.btncheckon2;
				bitMapOff=global::UserControlPlusLib.Properties.Resources.btncheckoff2;
			}
			else if (checkStyle==CheckStyle.style3)
			{
				bitMapOn=global::UserControlPlusLib.Properties.Resources.btncheckon3;
				bitMapOff=global::UserControlPlusLib.Properties.Resources.btncheckoff3;
			}
			else if (checkStyle==CheckStyle.style4)
			{
				bitMapOn=global::UserControlPlusLib.Properties.Resources.btncheckon4;
				bitMapOff=global::UserControlPlusLib.Properties.Resources.btncheckoff4;
			}
			else if (checkStyle==CheckStyle.style5)
			{
				bitMapOn=global::UserControlPlusLib.Properties.Resources.btncheckon5;
				bitMapOff=global::UserControlPlusLib.Properties.Resources.btncheckoff5;
			}
			else if (checkStyle==CheckStyle.style6)
			{
				bitMapOn=global::UserControlPlusLib.Properties.Resources.btncheckon6;
				bitMapOff=global::UserControlPlusLib.Properties.Resources.btncheckoff6;
			}

			Graphics g = e.Graphics;
			Rectangle rec = new Rectangle(0, 0, this.Size.Width, this.Size.Height);

			if (this.isCheck)
			{
				g.DrawImage(bitMapOn, rec);
			}
			else
			{
				g.DrawImage(bitMapOff, rec);
			}
		}

		#endregion 重载函数

		#region 事件定义

		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonCheckControl_Click(object sender, EventArgs e)
		{
			this.isCheck=!this.isCheck;
			this.Invalidate();
		}

		#endregion 事件定义
	}
}