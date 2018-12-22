using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace UserControlPlusLib.MyChart
{
	public partial class MyChart : UserControl
	{

		#region 属性定义

		/// <summary>
		/// 标题栏
		/// </summary>
		[Description("标题栏"), Category("自定义属性")]
		public virtual string  m_Title
		{
			get
			{
				return this.zedGraphControl_myChart.GraphPane.Title.Text;
			}

			set
			{
				this.zedGraphControl_myChart.GraphPane.Title.Text=value;
			}
		}

		/// <summary>
		/// X轴标题栏
		/// </summary>
		[Description("X轴标题栏"), Category("自定义属性")]
		public virtual string m_XAxisTitle
		{
			get
			{
				return this.zedGraphControl_myChart.GraphPane.XAxis.Title.Text;
			}

			set
			{
				this.zedGraphControl_myChart.GraphPane.XAxis.Title.Text=value;
			}
		}

		/// <summary>
		/// Y轴标题栏
		/// </summary>
		[Description("Y轴标题栏"), Category("自定义属性")]
		public virtual string m_YAxisTitle
		{
			get
			{
				return this.zedGraphControl_myChart.GraphPane.YAxis.Title.Text;
			}

			set
			{
				this.zedGraphControl_myChart.GraphPane.YAxis.Title.Text=value;
			}
		}

		#endregion

		#region 构造函数

		/// <summary>
		///
		/// </summary>
		public MyChart()
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
			this.zedGraphControl_myChart.GraphPane.YAxis.MajorGrid.IsVisible = true;

			//---显示小网格
			this.zedGraphControl_myChart.GraphPane.YAxis.MinorGrid.IsVisible = true;

			//---大网格实线显示
			this.zedGraphControl_myChart.GraphPane.YAxis.MajorGrid.DashOff = 0;

			//---小网格虚线显示
			this.zedGraphControl_myChart.GraphPane.YAxis.MinorGrid.DashOff = 1;

			//---网格点的步进刻度
			//this.zedGraphControl_myChart.GraphPane.YAxis.Scale.MajorStep = 2;
			//this.zedGraphControl_myChart.GraphPane.YAxis.Scale.MinorStep = this.zedGraphControl_myChart.GraphPane.YAxis.Scale.MajorStep / 5.0;

			//---Y轴扫描的最大值和最小值
			//this.zedGraphControl_myChart.GraphPane.YAxis.Scale.Min = (this.zedGraphControl_myChart.GraphPane.YAxis.Scale.MinorStep*(-1.00));
			//this.zedGraphControl_myChart.GraphPane.YAxis.Scale.Max = 10;

			//---水平参考线
			//---显示大网格
			this.zedGraphControl_myChart.GraphPane.XAxis.MajorGrid.IsVisible = true;

			//---显示小网格
			this.zedGraphControl_myChart.GraphPane.XAxis.MinorGrid.IsVisible = true;

			//---大网格实线显示
			this.zedGraphControl_myChart.GraphPane.XAxis.MajorGrid.DashOff = 0;

			//---小网格虚线显示
			this.zedGraphControl_myChart.GraphPane.XAxis.MinorGrid.DashOff = 1;

			//---网格点的步进刻度
			//this.zedGraphControl_myChart.GraphPane.XAxis.Scale.MajorStep = 2;
		    //this.zedGraphControl_myChart.GraphPane.XAxis.Scale.MinorStep = this.zedGraphControl_myChart.GraphPane.XAxis.Scale.MajorStep / 5.0;

			//---X轴扫描的最大值和最小值
			//this.zedGraphControl_myChart.GraphPane.XAxis.Scale.Min = (this.zedGraphControl_myChart.GraphPane.XAxis.Scale.MinorStep * (-1.00));
			//this.zedGraphControl_myChart.GraphPane.XAxis.Scale.Max = 10;
			//---滚动条自动滚动到最右边
			//this.zedGraphControl_myChart.ScrollMaxX = this.zedGraphControl_myChart.GraphPane.XAxis.Scale.Max;

			//---是否显示横向滚动条
			this.zedGraphControl_myChart.IsShowHScrollBar = true;
			//---是否显示纵向滚动条
			this.zedGraphControl_myChart.IsShowVScrollBar = true;
			this.zedGraphControl_myChart.IsAutoScrollRange = true;

			//---是否显示右键菜单，如果指定了ContextMenuStrip会一直显示指定的ContextMenu
			this.zedGraphControl_myChart.IsShowContextMenu = true;

			//--- 复制图像时是否显示提示信息
			//zedGraph.IsShowCopyMessage
			///---鼠标在图表上移动时是否显示鼠标所在点对应的坐标值
			//zedGraph.IsShowCursorValues

			//---鼠标经过图表上的点时是否气泡显示该点所对应的值
			this.zedGraphControl_myChart.IsShowPointValues = true;
			//---处理鼠标经过图表上的点时是否气泡显示该点所对应的值的事件
			this.zedGraphControl_myChart.PointValueEvent += new ZedGraphControl.PointValueHandler(PointValueEventHandler);

			//---是否允许横向缩放
			this.zedGraphControl_myChart.IsEnableHZoom = true;
			//使用滚轮时以鼠标所在点进行缩放还是以图形中心进行缩放
			//this.zedGraphControl_myChart.IsZoomOnMouseCenter=false;
			//---是否允许纵向缩放
			this.zedGraphControl_myChart.IsEnableVZoom = true;
			//---放大缩小
			this.zedGraphControl_myChart.ZoomStepFraction = 0.1;
			//---是否允许缩放
			this.zedGraphControl_myChart.IsEnableZoom = true;
			//---缩放事件处理
			this.zedGraphControl_myChart.ZoomEvent += new ZedGraphControl.ZoomEventHandler(ZoomEventHandler);

			//---在图表是添加一些文本
			//---左键拖拽放大\n鼠标中键滚放缩\n右键菜单
			//TextObj text = new TextObj( "Zoom: left mouse & drag\nPan: middle mouse & drag\nContext Menu: right mouse",
			//							0.05f, 0.95f, CoordType.ChartFraction, AlignH.Left, AlignV.Bottom);
			//text.FontSpec.StringAlignment = StringAlignment.Near;
			//this.zedGraphControl_myChart.GraphPane.GraphObjList.Add(text);

			//---处理自定义X轴刻度格式事件
			///this.zedGraphControl_myChart.GraphPane.XAxis.ScaleFormatEvent += new Axis.ScaleFormatHandler(XAxisScaleFormatEventHandler);
			//---处理自定义Y轴刻度格式事件
			///this.zedGraphControl_myChart.GraphPane.YAxis.ScaleFormatEvent += new Axis.ScaleFormatHandler(YScaleFormatEventHandler);

			//---将刷新图形控件
			this.RefreshZedGraph();
		}

		#endregion 初始化

		#region 事件定义

		/// <summary>
		/// 处理鼠标经过图表上的点时是否气泡显示该点所对应的值
		/// </summary>
		/// <param name="control"></param>
		/// <param name="pane"></param>
		/// <param name="curve"></param>
		/// <param name="iPt"></param>
		/// <returns></returns>
		private string PointValueEventHandler(ZedGraphControl control, GraphPane pane, CurveItem curve, int iPt)
		{
			//---获取点的值
			PointPair pt = curve[iPt];
			//---返回的结果
			string _return = "X:" + pt.X.ToString("f2") + "\r\n" + "Y:" + pt.Y.ToString("f2") + "\r\n";
			return _return;
		}

		/// <summary>
		/// 缩放事件处理
		/// </summary>
		/// <param name="control"></param>
		/// <param name="oldState"></param>
		/// <param name="newState"></param>
		private void ZoomEventHandler(ZedGraphControl control, ZoomState oldState,ZoomState newState)
		{
			
		}
		
		/// <summary>
		/// 处理自定义X轴刻度格式
		/// </summary>
		/// <param name="pane"></param>
		/// <param name="axis"></param>
		/// <param name="val"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public string XAxisScaleFormatEventHandler(GraphPane pane, Axis axis, double val, int index)
		{
			return (val + 50).ToString();
		}

		/// <summary>
		/// 适应右键菜单使用中文
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="menuStrip"></param>
		/// <param name="mousePt"></param>
		/// <param name="objState"></param>
		private void ContextMenuBuilderHandler(ZedGraphControl sender, ContextMenuStrip menuStrip, Point mousePt, ZedGraphControl.ContextMenuObjectState objState)
		{
			try
			{
				//每次循环只能遍历一个键
				foreach (ToolStripMenuItem item in menuStrip.Items)
				{
					if ((string)item.Tag=="copy")
					{
						item.Text="复制";
						item.Visible=true;
						break;
					}
				}
				foreach (ToolStripMenuItem item in menuStrip.Items)
				{
					if ((string)item.Tag=="save_as")
					{
						item.Text="另存图表";
						item.Visible=true;
						break;
					}
				}

				foreach (ToolStripMenuItem item in menuStrip.Items)
				{
					if ((string)item.Tag=="show_val")
					{
						item.Text="显示XY值";
						item.Visible=true;
						break;
					}
				}
				foreach (ToolStripMenuItem item in menuStrip.Items)
				{
					if ((string)item.Tag=="unzoom")
					{
						item.Text="上一视图";
						item.Visible=true;
						break;
					}
				}
				foreach (ToolStripMenuItem item in menuStrip.Items)
				{
					if ((string)item.Tag=="undo_all")
					{
						item.Text="还原缩放/移动";
						item.Visible=true;
						break;
					}
				}
				foreach (ToolStripMenuItem item in menuStrip.Items)
				{
					if ((string)item.Tag=="print")
					{
						menuStrip.Items.Remove(item);
						item.Visible=false; //不显示
						break;
					}
				}
				foreach (ToolStripMenuItem item in menuStrip.Items)
				{
					if ((string)item.Tag=="page_setup")
					{
						menuStrip.Items.Remove(item);//移除菜单项
						item.Visible=false; //不显示
						break;
					}
				}
				foreach (ToolStripMenuItem item in menuStrip.Items)
				{
					if ((string)item.Tag=="set_default")
					{
						menuStrip.Items.Remove(item);//移除菜单项
						item.Visible=false; //不显示
						break;
					}
				}

			}
			catch (System.Exception ex)
			{
				MessageBox.Show("初始化右键菜单错误"+ex.ToString());
			}
		}

		/// <summary>
		/// 处理自定义Y轴刻度格式
		/// </summary>
		/// <param name="pane"></param>
		/// <param name="axis"></param>
		/// <param name="val"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public string YAxisScaleFormatEventHandler(GraphPane pane, Axis axis, double val, int index)
		{
			return (val + 50).ToString();
		}

		#endregion

		#region 函数定义

		/// <summary>
		/// 创建控件
		/// </summary>
		/// <param name="zedGraph"></param>
		public virtual void  CreateZedGraph(ZedGraphControl zedGraph )
		{
			//---垂直参考线
			//---显示大网格
			zedGraph.GraphPane.YAxis.MajorGrid.IsVisible = true;

			//---显示小网格
			zedGraph.GraphPane.YAxis.MinorGrid.IsVisible = true;

			//---大网格实线显示
			zedGraph.GraphPane.YAxis.MajorGrid.DashOff = 0;

			//---小网格虚线显示
			zedGraph.GraphPane.YAxis.MinorGrid.DashOff = 1;

			//---Y轴扫描的最大值和最小值
			//zedGraph.GraphPane.YAxis.Scale.Min = 0;
			//zedGraph.GraphPane.YAxis.Scale.Max = 10;

			//---步长
			//zedGraph.GraphPane.YAxis.Scale.MajorStep = 2;
			//zedGraph.GraphPane.YAxis.Scale.MinorStep = zedGraph.GraphPane.YAxis.Scale.MajorStep / 5.0;

			//---水平参考线
			//---显示大网格
			zedGraph.GraphPane.XAxis.MajorGrid.IsVisible = true;

			//---显示小网格
			zedGraph.GraphPane.XAxis.MinorGrid.IsVisible = true;

			//---大网格实线显示
			zedGraph.GraphPane.XAxis.MajorGrid.DashOff = 0;

			//---小网格虚线显示
			zedGraph.GraphPane.XAxis.MinorGrid.DashOff = 1;

			//---X轴扫描的最大值和最小值
			//zedGraph.GraphPane.XAxis.Scale.Min = 0;
			//zedGraph.GraphPane.XAxis.Scale.Max = 10;

			//---步长
			//zedGraph.GraphPane.XAxis.Scale.MajorStep = 2;
			//zedGraph.GraphPane.XAxis.Scale.MinorStep = zedGraph.GraphPane.XAxis.Scale.MajorStep / 5.0;

			//---是否显示横向滚动条
			zedGraph.IsShowHScrollBar = true;
			//---是否显示纵向滚动条
			zedGraph.IsShowVScrollBar = true;
			zedGraph.IsAutoScrollRange = true;
			
			//---是否显示右键菜单，如果指定了ContextMenuStrip会一直显示指定的ContextMenu
			zedGraph.IsShowContextMenu = true;

			//--- 复制图像时是否显示提示信息
			//zedGraph.IsShowCopyMessage
			///---鼠标在图表上移动时是否显示鼠标所在点对应的坐标值
			//zedGraph.IsShowCursorValues

			//---鼠标经过图表上的点时是否气泡显示该点所对应的值
			zedGraph.IsShowPointValues = true;
			//---处理鼠标经过图表上的点时是否气泡显示该点所对应的值的事件
			zedGraph.PointValueEvent += new ZedGraphControl.PointValueHandler(PointValueEventHandler);

			//---是否允许横向缩放
			zedGraph.IsEnableHZoom = true;
			//---是否允许纵向缩放
			zedGraph.IsEnableVZoom = true;
			//---是否允许缩放
			zedGraph.IsEnableZoom = true;

			//---缩放事件处理
			zedGraph.ZoomEvent += new ZedGraphControl.ZoomEventHandler(ZoomEventHandler);

			// Add a text box with instructions
			////---左键拖拽放大\n鼠标中键滚放缩\n右键菜单
			//TextObj text = new TextObj("Zoom: left mouse & drag\nPan: middle mouse & drag\nContext Menu: right mouse",
			//							0.05f, 0.95f, CoordType.ChartFraction, AlignH.Left, AlignV.Bottom);
			//text.FontSpec.StringAlignment = StringAlignment.Near;
			//zedGraph.GraphPane.GraphObjList.Add(text);
			//---将刷新图形控件
			this.RefreshZedGraph();
		}

		/// <summary>
		/// 刷新控件的值
		/// </summary>
		public virtual void RefreshZedGraph()
		{
			this.zedGraphControl_myChart.AxisChange();
			//---异步调用
			if (this.zedGraphControl_myChart.InvokeRequired)
			{
				this.zedGraphControl_myChart.Invoke((EventHandler)
								 (delegate
								 {
									 this.zedGraphControl_myChart.Refresh();
								 }));
			}
			else
			{
				this.zedGraphControl_myChart.Refresh();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public virtual  ZedGraphControl GetZedGraphControl()
		{
			return this.zedGraphControl_myChart;
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual void ClearChart()
		{
			this.zedGraphControl_myChart.GraphPane.CurveList.Clear();
		}

		/// <summary>
		/// 添加数据点
		/// </summary>
		/// <param name="curveName"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public virtual void AddXYPoint(string curveName, double x, double y)
		{
			//---异步调用
			if (this.zedGraphControl_myChart.InvokeRequired)
			{
				this.zedGraphControl_myChart.Invoke((EventHandler)
								 (delegate
								 {
									 //---增加坐标XY轴的点
									 IPointListEdit ip = this.zedGraphControl_myChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
									 if (ip != null)
									 {
										 ip.Add(x, y);

										 //---刷新显示
										 this.RefreshZedGraph();
									 }
								 }));
			}
			else
			{
				//---增加坐标XY轴的点
				IPointListEdit ip = this.zedGraphControl_myChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
				if (ip != null)
				{
					ip.Add(x, y);

					//---刷新显示
					this.RefreshZedGraph();
				}
			}
			
		}
		/// <summary>
		/// 添加数据点
		/// </summary>
		/// <param name="curveName"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public virtual void AddXYPoint(string curveName, PointPair xypoint)
		{
			//---异步调用
			if (this.zedGraphControl_myChart.InvokeRequired)
			{
				this.zedGraphControl_myChart.Invoke((EventHandler)
								 (delegate
								 {
									 //---增加坐标XY轴的点
									 IPointListEdit ip = this.zedGraphControl_myChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
									 if (ip != null)
									 {
										 ip.Add(xypoint);

										 //---刷新显示
										 this.RefreshZedGraph();
									 }
								 }));
			}
			else
			{
				//---增加坐标XY轴的点
				IPointListEdit ip = this.zedGraphControl_myChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
				if (ip != null)
				{
					ip.Add(xypoint);

					//---刷新显示
					this.RefreshZedGraph();
				}
			}
		}
		/// <summary>
		/// 添加数据点
		/// </summary>
		/// <param name="curveName"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public virtual void AddXYPoint(string curveName, double[] x, double[] y)
		{
			//---异步调用
			if (this.zedGraphControl_myChart.InvokeRequired)
			{
				this.zedGraphControl_myChart.Invoke((EventHandler)
								 (delegate
								 {
									 //---增加坐标XY轴的点
									 IPointListEdit ip = this.zedGraphControl_myChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
									 if ((ip != null) && (x.Length == y.Length))
									 {
										 for (int i = 0; i < x.Length; i++)
										 {
											 ip.Add(x[i], y[i]);
										 }

										 //---刷新显示
										 this.RefreshZedGraph();
									 }
								 }));
			}
			else
			{
				//---增加坐标XY轴的点
				IPointListEdit ip = this.zedGraphControl_myChart.GraphPane.CurveList[curveName].Points as IPointListEdit;
				if ((ip != null) && (x.Length == y.Length))
				{
					for (int i = 0; i < x.Length; i++)
					{
						ip.Add(x[i], y[i]);
					}

					//---刷新显示
					this.RefreshZedGraph();
				}
			}
			
		}

		
		/// <summary>
		/// 设置标题栏
		/// </summary>
		/// <param name="xAxisTitle"></param>
		/// <param name="yAxisTitle"></param>
		public virtual void SetTitle(string title)
		{
			this.zedGraphControl_myChart.GraphPane.Title.Text = title;
		}

		/// <summary>
		/// 设置XY轴标题
		/// </summary>
		/// <param name="xAxisTitle"></param>
		/// <param name="yAxisTitle"></param>
		public virtual void SetXYAxisTitle(string xAxisTitle,string yAxisTitle)
		{
			this.zedGraphControl_myChart.GraphPane.XAxis.Title.Text = xAxisTitle;
			this.zedGraphControl_myChart.GraphPane.YAxis.Title.Text = yAxisTitle;
		}

		/// <summary>
		/// X轴的扫描最大值
		/// </summary>
		/// <param name="xAxisScaleMajorStep"></param>
		public virtual void SetXAxisScaleMajorStep(double xAxisScaleMajorStep)
		{
			this.zedGraphControl_myChart.GraphPane.XAxis.Scale.MajorStep = xAxisScaleMajorStep;
			this.zedGraphControl_myChart.GraphPane.XAxis.Scale.MinorStep = this.zedGraphControl_myChart.GraphPane.XAxis.Scale.MajorStep/5.0;
		}

		/// <summary>
		/// 设置X坐标的最小值
		/// </summary>
		/// <param name="xAxisScaleMin"></param>
		public virtual void SetXAxisScaleMin(double xAxisScaleMin)
		{
			this.zedGraphControl_myChart.GraphPane.XAxis.Scale.Min = xAxisScaleMin;
		}

		/// <summary>
		/// 设置X坐标的最大值
		/// </summary>
		/// <param name="yAxisScaleMax"></param>
		public virtual void SetXAxisScaleMax(double yAxisScaleMax)
		{
			this.zedGraphControl_myChart.GraphPane.XAxis.Scale.Max = yAxisScaleMax;
		}

		/// <summary>
		/// Y轴的扫描最大值
		/// </summary>
		/// <param name="xAxisScaleMajorStep"></param>
		public virtual void SetYAxisScaleMajorStep(double yAxisScaleMajorStep)
		{
			this.zedGraphControl_myChart.GraphPane.YAxis.Scale.MajorStep = yAxisScaleMajorStep;
			this.zedGraphControl_myChart.GraphPane.YAxis.Scale.MinorStep = this.zedGraphControl_myChart.GraphPane.YAxis.Scale.MajorStep / 5.0;
		}

		/// <summary>
		/// 设置Y坐标的最大值
		/// </summary>
		/// <param name="xAxisScaleMin"></param>
		public virtual void SetYAxisScaleMin(double xAxisScaleMin)
		{
			this.zedGraphControl_myChart.GraphPane.YAxis.Scale.Min = xAxisScaleMin;
		}

		/// <summary>
		/// 设置Y坐标的最小值
		/// </summary>
		/// <param name="yAxisScaleMax"></param>
		public virtual void SetYAxisScaleMax(double yAxisScaleMax)
		{
			this.zedGraphControl_myChart.GraphPane.YAxis.Scale.Max = yAxisScaleMax;
		}

		/// <summary>
		/// 显示曲线
		/// </summary>
		/// <param name="addCurve"></param>
		/// <param name="curveColor"></param>
		/// <param name="curveType"></param>
		public virtual LineItem AddShowCurve(string addCurve,Color curveColor,SymbolType curveType, bool isFillColor = true)
		{
			LineItem myCurve = this.zedGraphControl_myChart.GraphPane.AddCurve(addCurve,
				null, curveColor, curveType);
			if (isFillColor)
			{
				myCurve.Symbol.Fill = new Fill(curveColor);
			}
			return myCurve;
		}

		/// <summary>
		/// 显示曲线
		/// </summary>
		/// <param name="addCurve"></param>
		/// <param name="list"></param>
		/// <param name="curveColor"></param>
		/// <param name="curveType"></param>
		/// <returns></returns>
		public virtual LineItem AddShowCurve(string addCurve, PointPairList list, Color curveColor, SymbolType curveType,bool isFillColor=true)
		{
			LineItem myCurve = this.zedGraphControl_myChart.GraphPane.AddCurve(addCurve,
				list, curveColor, curveType);
			if (isFillColor)
			{
				myCurve.Symbol.Fill = new Fill(curveColor);
			}
			return myCurve;
		}

		/// <summary>
		/// 显示曲线
		/// </summary>
		/// <param name="addCurve"></param>
		/// <param name="curveColor"></param>
		/// <returns></returns>
		public virtual LineItem AddShowCurve(string addCurve, Color curveColor, bool isFillColor = true)
		{
			LineItem myCurve = this.zedGraphControl_myChart.GraphPane.AddCurve(addCurve,
				null, curveColor, SymbolType.Circle);
			if (isFillColor)
			{
				myCurve.Symbol.Fill = new Fill(curveColor);
			}
			return myCurve;
		}

		/// <summary>
		/// 显示图标
		/// </summary>
		/// <param name="addCurve"></param>
		/// <param name="list"></param>
		/// <param name="curveColor"></param>
		/// <returns></returns>
		public virtual LineItem AddShowCurve(string addCurve, PointPairList list, Color curveColor, bool isFillColor = true)
		{
			LineItem myCurve = this.zedGraphControl_myChart.GraphPane.AddCurve(addCurve,
				list, curveColor, SymbolType.Circle);
			if (isFillColor)
			{
				myCurve.Symbol.Fill = new Fill(curveColor);
			}
			return myCurve;
		}

		/// <summary>
		/// 设置曲线的颜色
		/// </summary>
		/// <param name="curveColor"></param>
		public virtual void SetCurveColor( string curveName,Color curveColor)
		{
			try
			{
				this.zedGraphControl_myChart.GraphPane.CurveList[curveName].Color = curveColor;
				//---刷新显示
				this.RefreshZedGraph();
			}
			catch (System.Exception ex)
			{
				MessageBox.Show(ex.ToString()+"!\r\n" + "曲线颜色设置错误!\r\n", "错误提示");
			}
			
		}

		/// <summary>
		/// 获取曲线的颜色
		/// </summary>
		/// <param name="curveName"></param>
		/// <returns></returns>
		public virtual Color GetCurveColor(string curveName)
		{
			try
			{
				return this.zedGraphControl_myChart.GraphPane.CurveList[curveName].Color;
			}
			catch (System.Exception ex)
			{
				MessageBox.Show(ex.ToString() + "!\r\n"+"曲线颜色读取错误!\r\n", "错误提示");
				return Color.Black;
			}
			
		}

		/// <summary>
		/// 设置控件的尺寸
		/// </summary>
		/// <param name="width"></param>
		/// <param name="heigh"></param>
		public virtual void SetZedGraphSize(int width,int heigh)
		{
			this.zedGraphControl_myChart.Location=new Point(10, 10);
			zedGraphControl_myChart.Size=new Size(width-0, heigh-20);

		}

		#endregion 函数定义
	}
}