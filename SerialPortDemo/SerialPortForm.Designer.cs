namespace SerialPortDemo
{
    partial class SerialPortForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl_FuncMenu = new System.Windows.Forms.TabControl();
            this.tabPage_SerialPort = new System.Windows.Forms.TabPage();
            this.panel_serialPort = new System.Windows.Forms.Panel();
            this.groupBox_tx = new System.Windows.Forms.GroupBox();
            this.richTextBoxEx1 = new RichTextBoxPlusLib.RichTextBoxEx();
            this.groupBox_rx = new System.Windows.Forms.GroupBox();
            this.richTextBoxEx_rx = new RichTextBoxPlusLib.RichTextBoxEx();
            this.serialPortControl = new COMMPortLib.SerialPortControl();
            this.tabControl_FuncMenu.SuspendLayout();
            this.tabPage_SerialPort.SuspendLayout();
            this.panel_serialPort.SuspendLayout();
            this.groupBox_tx.SuspendLayout();
            this.groupBox_rx.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_FuncMenu
            // 
            this.tabControl_FuncMenu.Controls.Add(this.tabPage_SerialPort);
            this.tabControl_FuncMenu.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabControl_FuncMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_FuncMenu.Location = new System.Drawing.Point(0, 0);
            this.tabControl_FuncMenu.Name = "tabControl_FuncMenu";
            this.tabControl_FuncMenu.Padding = new System.Drawing.Point(6, 8);
            this.tabControl_FuncMenu.SelectedIndex = 0;
            this.tabControl_FuncMenu.Size = new System.Drawing.Size(716, 445);
            this.tabControl_FuncMenu.TabIndex = 0;
            // 
            // tabPage_SerialPort
            // 
            this.tabPage_SerialPort.Controls.Add(this.panel_serialPort);
            this.tabPage_SerialPort.Location = new System.Drawing.Point(4, 32);
            this.tabPage_SerialPort.Margin = new System.Windows.Forms.Padding(1);
            this.tabPage_SerialPort.Name = "tabPage_SerialPort";
            this.tabPage_SerialPort.Size = new System.Drawing.Size(708, 409);
            this.tabPage_SerialPort.TabIndex = 0;
            this.tabPage_SerialPort.Text = "串口调试助手";
            this.tabPage_SerialPort.UseVisualStyleBackColor = true;
            // 
            // panel_serialPort
            // 
            this.panel_serialPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_serialPort.Controls.Add(this.groupBox_tx);
            this.panel_serialPort.Controls.Add(this.groupBox_rx);
            this.panel_serialPort.Controls.Add(this.serialPortControl);
            this.panel_serialPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_serialPort.Location = new System.Drawing.Point(0, 0);
            this.panel_serialPort.Margin = new System.Windows.Forms.Padding(2);
            this.panel_serialPort.Name = "panel_serialPort";
            this.panel_serialPort.Size = new System.Drawing.Size(708, 409);
            this.panel_serialPort.TabIndex = 0;
            // 
            // groupBox_tx
            // 
            this.groupBox_tx.Controls.Add(this.richTextBoxEx1);
            this.groupBox_tx.Location = new System.Drawing.Point(10, 281);
            this.groupBox_tx.Name = "groupBox_tx";
            this.groupBox_tx.Size = new System.Drawing.Size(532, 100);
            this.groupBox_tx.TabIndex = 2;
            this.groupBox_tx.TabStop = false;
            this.groupBox_tx.Text = "数据发送";
            // 
            // richTextBoxEx1
            // 
            this.richTextBoxEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxEx1.Location = new System.Drawing.Point(3, 17);
            this.richTextBoxEx1.Name = "richTextBoxEx1";
            this.richTextBoxEx1.Size = new System.Drawing.Size(526, 80);
            this.richTextBoxEx1.TabIndex = 0;
            this.richTextBoxEx1.Text = "";
            // 
            // groupBox_rx
            // 
            this.groupBox_rx.Controls.Add(this.richTextBoxEx_rx);
            this.groupBox_rx.Location = new System.Drawing.Point(7, 3);
            this.groupBox_rx.Name = "groupBox_rx";
            this.groupBox_rx.Size = new System.Drawing.Size(535, 272);
            this.groupBox_rx.TabIndex = 1;
            this.groupBox_rx.TabStop = false;
            this.groupBox_rx.Text = "数据接收";
            // 
            // richTextBoxEx_rx
            // 
            this.richTextBoxEx_rx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxEx_rx.Location = new System.Drawing.Point(3, 17);
            this.richTextBoxEx_rx.Name = "richTextBoxEx_rx";
            this.richTextBoxEx_rx.Size = new System.Drawing.Size(529, 252);
            this.richTextBoxEx_rx.TabIndex = 0;
            this.richTextBoxEx_rx.Text = "";
            // 
            // serialPortControl
            // 
            this.serialPortControl.Location = new System.Drawing.Point(547, 1);
            this.serialPortControl.Margin = new System.Windows.Forms.Padding(2);
            this.serialPortControl.Name = "serialPortControl";
            this.serialPortControl.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.serialPortControl.Size = new System.Drawing.Size(157, 191);
            this.serialPortControl.TabIndex = 0;
            // 
            // SerialPortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 445);
            this.Controls.Add(this.tabControl_FuncMenu);
            this.Name = "SerialPortForm";
            this.Text = "调试助手";
            this.Load += new System.EventHandler(this.SerialPortForm_Load);
            this.tabControl_FuncMenu.ResumeLayout(false);
            this.tabPage_SerialPort.ResumeLayout(false);
            this.panel_serialPort.ResumeLayout(false);
            this.groupBox_tx.ResumeLayout(false);
            this.groupBox_rx.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_FuncMenu;
        private System.Windows.Forms.TabPage tabPage_SerialPort;
        private System.Windows.Forms.Panel panel_serialPort;
        private COMMPortLib.SerialPortControl serialPortControl;
        private System.Windows.Forms.GroupBox groupBox_tx;
        private RichTextBoxPlusLib.RichTextBoxEx richTextBoxEx1;
        private System.Windows.Forms.GroupBox groupBox_rx;
        private RichTextBoxPlusLib.RichTextBoxEx richTextBoxEx_rx;
    }
}

