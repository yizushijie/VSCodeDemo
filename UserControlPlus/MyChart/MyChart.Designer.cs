namespace UserControlPlusLib.MyChart
{
	partial class MyChart
	{
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region 组件设计器生成的代码

		/// <summary> 
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.zedGraphControl_myChart = new ZedGraph.ZedGraphControl();
			this.SuspendLayout();
			// 
			// zedGraphControl_myChart
			// 
			this.zedGraphControl_myChart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.zedGraphControl_myChart.Location = new System.Drawing.Point(0, 0);
			this.zedGraphControl_myChart.Name = "zedGraphControl_myChart";
			this.zedGraphControl_myChart.ScrollGrace = 0D;
			this.zedGraphControl_myChart.ScrollMaxX = 0D;
			this.zedGraphControl_myChart.ScrollMaxY = 0D;
			this.zedGraphControl_myChart.ScrollMaxY2 = 0D;
			this.zedGraphControl_myChart.ScrollMinX = 0D;
			this.zedGraphControl_myChart.ScrollMinY = 0D;
			this.zedGraphControl_myChart.ScrollMinY2 = 0D;
			this.zedGraphControl_myChart.Size = new System.Drawing.Size(519, 391);
			this.zedGraphControl_myChart.TabIndex = 0;
			// 
			// MyChart
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.zedGraphControl_myChart);
			this.Name = "MyChart";
			this.Size = new System.Drawing.Size(519, 391);
			this.ResumeLayout(false);

		}

		#endregion

		private ZedGraph.ZedGraphControl zedGraphControl_myChart;
	}
}
