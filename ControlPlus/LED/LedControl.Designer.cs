namespace ControlPlusLib.LED
{
    partial class LedControl
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
            this.ledButtonControl_led = new ControlPlusLib.LedButton.LedButtonControl();
            this.buttonCheckControl_led = new ControlPlusLib.ButtonCheckControl();
            this.SuspendLayout();
            // 
            // ledButtonControl_led
            // 
            this.ledButtonControl_led.BackColor = System.Drawing.Color.Transparent;
            this.ledButtonControl_led.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ledButtonControl_led.LedColor = System.Drawing.Color.Black;
            this.ledButtonControl_led.Location = new System.Drawing.Point(9, 0);
            this.ledButtonControl_led.Margin = new System.Windows.Forms.Padding(2);
            this.ledButtonControl_led.Name = "ledButtonControl_led";
            this.ledButtonControl_led.Size = new System.Drawing.Size(27, 27);
            this.ledButtonControl_led.TabIndex = 0;
            // 
            // buttonCheckControl_led
            // 
            this.buttonCheckControl_led.BackColor = System.Drawing.Color.Transparent;
            this.buttonCheckControl_led.Checked = false;
            this.buttonCheckControl_led.CheckStylePlus = ControlPlusLib.CheckStyle.style1;
            this.buttonCheckControl_led.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCheckControl_led.Location = new System.Drawing.Point(0, 31);
            this.buttonCheckControl_led.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCheckControl_led.Name = "buttonCheckControl_led";
            this.buttonCheckControl_led.Size = new System.Drawing.Size(44, 14);
            this.buttonCheckControl_led.TabIndex = 1;
            this.buttonCheckControl_led.Click += new System.EventHandler(this.buttonCheckControl_Click);
            // 
            // LedControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonCheckControl_led);
            this.Controls.Add(this.ledButtonControl_led);
            this.Name = "LedControl";
            this.Size = new System.Drawing.Size(46, 49);
            this.ResumeLayout(false);

        }

        #endregion

        private LedButton.LedButtonControl ledButtonControl_led;
        private ButtonCheckControl buttonCheckControl_led;
    }
}
