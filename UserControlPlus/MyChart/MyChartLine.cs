using System.Windows.Forms;
using ZedGraph;

namespace UserControlPlusLib.MyChart
{
	public partial class MyChartLine : UserControl
	{
		#region 构造函数

		/// <summary>
		///
		/// </summary>
		public MyChartLine()
		{
			InitializeComponent();

			//---初始化
			this.InitZedGraph();
		}

		#endregion 构造函数

		#region 初始化

		/// <summary>
		/// 初始化
		/// </summary>
		private void InitZedGraph()
		{
			//---垂直参考线
			//---显示大网格
			this.zedGraphControl_myLine.GraphPane.YAxis.MajorGrid.IsVisible=true;

			//---显示小网格
			this.zedGraphControl_myLine.GraphPane.YAxis.MinorGrid.IsVisible=true;

			//---大网格实线显示
			this.zedGraphControl_myLine.GraphPane.YAxis.MajorGrid.DashOff=0;

			//---小网格虚线显示
			this.zedGraphControl_myLine.GraphPane.YAxis.MinorGrid.DashOff=1;

			this.zedGraphControl_myLine.GraphPane.YAxis.Scale.Min=0;
			this.zedGraphControl_myLine.GraphPane.YAxis.Scale.Max=10;

			//---步长
			this.zedGraphControl_myLine.GraphPane.YAxis.Scale.MajorStep=2;
			this.zedGraphControl_myLine.GraphPane.YAxis.Scale.MinorStep=this.zedGraphControl_myLine.GraphPane.YAxis.Scale.MajorStep/5.0;

			//---水平参考线
			//---显示大网格
			this.zedGraphControl_myLine.GraphPane.XAxis.MajorGrid.IsVisible=true;

			//---显示小网格
			this.zedGraphControl_myLine.GraphPane.XAxis.MinorGrid.IsVisible=true;

			//---大网格实线显示
			this.zedGraphControl_myLine.GraphPane.XAxis.MajorGrid.DashOff=0;

			//---小网格虚线显示
			this.zedGraphControl_myLine.GraphPane.XAxis.MinorGrid.DashOff=1;

			this.zedGraphControl_myLine.GraphPane.XAxis.Scale.Min=0;
			this.zedGraphControl_myLine.GraphPane.XAxis.Scale.Max=10;

			//---步长
			this.zedGraphControl_myLine.GraphPane.XAxis.Scale.MajorStep=2;
			this.zedGraphControl_myLine.GraphPane.XAxis.Scale.MinorStep=this.zedGraphControl_myLine.GraphPane.XAxis.Scale.MajorStep/5.0;

			// Enable scrollbars if needed
			this.zedGraphControl_myLine.IsShowHScrollBar=true;
			this.zedGraphControl_myLine.IsShowVScrollBar=true;
			this.zedGraphControl_myLine.IsAutoScrollRange=true;
			this.zedGraphControl_myLine.IsShowPointValues=true;
		}

		#endregion 初始化

		#region 函数定义

		/// <summary>
		/// 刷新控件的值
		/// </summary>
		public virtual void RefreshZedGraph()
		{
			this.zedGraphControl_myLine.AxisChange();
			this.zedGraphControl_myLine.Refresh();
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="serise"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public virtual void AddXY(string serise, double x, double y)
		{
			//---增加坐标XY轴的点
			IPointListEdit ip = this.zedGraphControl_myLine.GraphPane.CurveList[serise].Points as IPointListEdit;
			if (ip!=null)
			{
				ip.Add(x, y);

				//---刷新显示
				RefreshZedGraph();
			}
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="serise"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public virtual void AddXY(string serise, double[] x, double[] y)
		{
			//---增加坐标XY轴的点
			IPointListEdit ip = this.zedGraphControl_myLine.GraphPane.CurveList[serise].Points as IPointListEdit;
			if ((ip!=null)&&(x.Length==y.Length))
			{
				for (int i = 0 ; i<x.Length ; i++)
				{
					ip.Add(x[i], y[i]);
				}

				//---刷新显示
				RefreshZedGraph();
			}
		}

		#endregion 函数定义
	}
}