namespace UserControlPlusLib.MyChart
{
	partial class MyChartLine
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
			this.zedGraphControl_myLine = new ZedGraph.ZedGraphControl();
			this.SuspendLayout();
			// 
			// zedGraphControl_myLine
			// 
			this.zedGraphControl_myLine.Dock = System.Windows.Forms.DockStyle.Fill;
			this.zedGraphControl_myLine.Location = new System.Drawing.Point(0, 0);
			this.zedGraphControl_myLine.Name = "zedGraphControl_myLine";
			this.zedGraphControl_myLine.ScrollMaxX = 0D;
			this.zedGraphControl_myLine.ScrollMaxY = 0D;
			this.zedGraphControl_myLine.ScrollMaxY2 = 0D;
			this.zedGraphControl_myLine.ScrollMinX = 0D;
			this.zedGraphControl_myLine.ScrollMinY = 0D;
			this.zedGraphControl_myLine.ScrollMinY2 = 0D;
			this.zedGraphControl_myLine.Size = new System.Drawing.Size(519, 391);
			this.zedGraphControl_myLine.TabIndex = 0;
			// 
			// MyChartLine
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.zedGraphControl_myLine);
			this.Name = "MyChartLine";
			this.Size = new System.Drawing.Size(519, 391);
			this.ResumeLayout(false);

		}

		#endregion

		private ZedGraph.ZedGraphControl zedGraphControl_myLine;
	}
}
