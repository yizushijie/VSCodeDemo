using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ControlPlusLib.LedButton
{

	/// <summary>
	/// LED指示灯
	/// </summary>
	public partial class LedButtonControl : UserControl
	{

		#region 变量定义

		private Color usedColor = Color.Red;

		#endregion

		#region 属性定义

		/// <summary>
		/// 设置LED的颜色
		/// </summary>
		public Color LedColor
		{
			get
			{
				return this.usedColor;
			}
			set
			{
				this.usedColor = value;
				this.Invalidate();
			}
		}

        #endregion

        #region 构造函数

        /// <summary>
        /// 
        /// </summary>
        public LedButtonControl()
		{
			InitializeComponent();

			//---设置Style支持透明背景色并且双缓冲
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			this.SetStyle(ControlStyles.ResizeRedraw, true);
			this.SetStyle(ControlStyles.Selectable, true);
			this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			this.SetStyle(ControlStyles.UserPaint, true);
			this.BackColor = Color.Transparent;

			this.Cursor = Cursors.Hand;
			this.Size = new System.Drawing.Size(27, 27);
		}

		#endregion

		#region 绘制函数
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPaint(PaintEventArgs e)
		{
			int ledSize;
			// 获取LED的大小,为正圆
			if (this.Width > this.Height)
			{
				ledSize = this.Height - 4;
			}
			else
			{
				ledSize = this.Width - 4;
			}

			// 设置GDI+模式为精细模式
			e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
			// 创建一个变色圆形的区域
			GraphicsPath path = new GraphicsPath();
			path.AddEllipse(2, 2, ledSize, ledSize);

			PathGradientBrush pthGrBrush = new PathGradientBrush(path);

			// 设置中间颜色
			pthGrBrush.CenterColor = this.usedColor;

			// 设置边缘颜色
			Color[] colors = { this.usedColor };
			pthGrBrush.SurroundColors = colors;

			// 绘制变色圆形
			e.Graphics.FillEllipse(pthGrBrush, 2, 2, ledSize, ledSize);

			// 绘制圆形边框
			Pen p = new Pen(new SolidBrush(this.usedColor), 2);
			e.Graphics.DrawEllipse(p, 2, 2, ledSize, ledSize);

			// 控件区域为圆形
			GraphicsPath gp = new GraphicsPath();
			gp.AddEllipse(0, 0, (ledSize + 4), (ledSize + 4));
			this.Region = new Region(gp);//这句就是设置圆形的规格区域的 
		}
		#endregion

		#region 事件定义
		
		#endregion

		#region 函数定义

		#endregion

	}
}
