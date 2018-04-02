namespace modPro
{
    partial class ConnectView
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
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.grpStart = new System.Windows.Forms.GroupBox();
            this.groupBoxRTU = new System.Windows.Forms.GroupBox();
            this.comboBoxStopBits = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxDataBits = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxParity = new System.Windows.Forms.ComboBox();
            this.labelParity = new System.Windows.Forms.Label();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.comboBoxSerialPorts = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxMode = new System.Windows.Forms.GroupBox();
            this.radioButtonRTU = new System.Windows.Forms.RadioButton();
            this.radioButtonUDP = new System.Windows.Forms.RadioButton();
            this.radioButtonTCP = new System.Windows.Forms.RadioButton();
            this.groupBoxTCP = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxSlaveID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.grpStart.SuspendLayout();
            this.groupBoxRTU.SuspendLayout();
            this.groupBoxMode.SuspendLayout();
            this.groupBoxTCP.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(0, 47);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 3;
            this.btnDisconnect.Text = "disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(0, 15);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "conncet";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // grpStart
            // 
            this.grpStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpStart.Controls.Add(this.groupBoxRTU);
            this.grpStart.Controls.Add(this.groupBoxMode);
            this.grpStart.Controls.Add(this.groupBoxTCP);
            this.grpStart.Location = new System.Drawing.Point(81, 3);
            this.grpStart.Name = "grpStart";
            this.grpStart.Size = new System.Drawing.Size(672, 116);
            this.grpStart.TabIndex = 19;
            this.grpStart.TabStop = false;
            this.grpStart.Text = "Communication";
            // 
            // groupBoxRTU
            // 
            this.groupBoxRTU.Controls.Add(this.comboBoxStopBits);
            this.groupBoxRTU.Controls.Add(this.label10);
            this.groupBoxRTU.Controls.Add(this.comboBoxDataBits);
            this.groupBoxRTU.Controls.Add(this.label9);
            this.groupBoxRTU.Controls.Add(this.comboBoxParity);
            this.groupBoxRTU.Controls.Add(this.labelParity);
            this.groupBoxRTU.Controls.Add(this.comboBoxBaudRate);
            this.groupBoxRTU.Controls.Add(this.comboBoxSerialPorts);
            this.groupBoxRTU.Controls.Add(this.label4);
            this.groupBoxRTU.Controls.Add(this.label5);
            this.groupBoxRTU.Location = new System.Drawing.Point(291, 12);
            this.groupBoxRTU.Name = "groupBoxRTU";
            this.groupBoxRTU.Size = new System.Drawing.Size(377, 98);
            this.groupBoxRTU.TabIndex = 25;
            this.groupBoxRTU.TabStop = false;
            this.groupBoxRTU.Text = "RTU";
            // 
            // comboBoxStopBits
            // 
            this.comboBoxStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStopBits.FormattingEnabled = true;
            this.comboBoxStopBits.Items.AddRange(new object[] {
            "None",
            "1 Bit",
            "2 Bits"});
            this.comboBoxStopBits.Location = new System.Drawing.Point(280, 44);
            this.comboBoxStopBits.Name = "comboBoxStopBits";
            this.comboBoxStopBits.Size = new System.Drawing.Size(94, 20);
            this.comboBoxStopBits.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(208, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 12);
            this.label10.TabIndex = 26;
            this.label10.Text = "Stop Bits =";
            // 
            // comboBoxDataBits
            // 
            this.comboBoxDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataBits.FormattingEnabled = true;
            this.comboBoxDataBits.Items.AddRange(new object[] {
            "7 Bits",
            "8 Bits"});
            this.comboBoxDataBits.Location = new System.Drawing.Point(280, 18);
            this.comboBoxDataBits.Name = "comboBoxDataBits";
            this.comboBoxDataBits.Size = new System.Drawing.Size(94, 20);
            this.comboBoxDataBits.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(208, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 12);
            this.label9.TabIndex = 24;
            this.label9.Text = "Data Bits =";
            // 
            // comboBoxParity
            // 
            this.comboBoxParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxParity.FormattingEnabled = true;
            this.comboBoxParity.Location = new System.Drawing.Point(80, 68);
            this.comboBoxParity.Name = "comboBoxParity";
            this.comboBoxParity.Size = new System.Drawing.Size(94, 20);
            this.comboBoxParity.TabIndex = 23;
            // 
            // labelParity
            // 
            this.labelParity.AutoSize = true;
            this.labelParity.Location = new System.Drawing.Point(24, 72);
            this.labelParity.Name = "labelParity";
            this.labelParity.Size = new System.Drawing.Size(53, 12);
            this.labelParity.TabIndex = 22;
            this.labelParity.Text = "Parity =";
            // 
            // comboBoxBaudRate
            // 
            this.comboBoxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBaudRate.FormattingEnabled = true;
            this.comboBoxBaudRate.Items.AddRange(new object[] {
            "128000",
            "115200",
            "57600",
            "38400",
            "19200",
            "14400",
            "9600",
            "7200",
            "4800",
            "2400",
            "1800",
            "1200",
            "600",
            "300",
            "150"});
            this.comboBoxBaudRate.Location = new System.Drawing.Point(80, 43);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(94, 20);
            this.comboBoxBaudRate.TabIndex = 21;
            // 
            // comboBoxSerialPorts
            // 
            this.comboBoxSerialPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSerialPorts.FormattingEnabled = true;
            this.comboBoxSerialPorts.Location = new System.Drawing.Point(80, 18);
            this.comboBoxSerialPorts.Name = "comboBoxSerialPorts";
            this.comboBoxSerialPorts.Size = new System.Drawing.Size(94, 20);
            this.comboBoxSerialPorts.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "Port Name =";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "Baud =";
            // 
            // groupBoxMode
            // 
            this.groupBoxMode.Controls.Add(this.radioButtonRTU);
            this.groupBoxMode.Controls.Add(this.radioButtonUDP);
            this.groupBoxMode.Controls.Add(this.radioButtonTCP);
            this.groupBoxMode.Location = new System.Drawing.Point(6, 18);
            this.groupBoxMode.Name = "groupBoxMode";
            this.groupBoxMode.Size = new System.Drawing.Size(81, 92);
            this.groupBoxMode.TabIndex = 0;
            this.groupBoxMode.TabStop = false;
            this.groupBoxMode.Text = "Mode";
            // 
            // radioButtonRTU
            // 
            this.radioButtonRTU.AutoSize = true;
            this.radioButtonRTU.Checked = true;
            this.radioButtonRTU.Location = new System.Drawing.Point(6, 54);
            this.radioButtonRTU.Name = "radioButtonRTU";
            this.radioButtonRTU.Size = new System.Drawing.Size(41, 16);
            this.radioButtonRTU.TabIndex = 3;
            this.radioButtonRTU.TabStop = true;
            this.radioButtonRTU.Text = "RTU";
            this.radioButtonRTU.UseVisualStyleBackColor = true;
            // 
            // radioButtonUDP
            // 
            this.radioButtonUDP.AutoSize = true;
            this.radioButtonUDP.Enabled = false;
            this.radioButtonUDP.Location = new System.Drawing.Point(6, 36);
            this.radioButtonUDP.Name = "radioButtonUDP";
            this.radioButtonUDP.Size = new System.Drawing.Size(41, 16);
            this.radioButtonUDP.TabIndex = 2;
            this.radioButtonUDP.Text = "UDP";
            this.radioButtonUDP.UseVisualStyleBackColor = true;
            // 
            // radioButtonTCP
            // 
            this.radioButtonTCP.AutoSize = true;
            this.radioButtonTCP.Enabled = false;
            this.radioButtonTCP.Location = new System.Drawing.Point(6, 18);
            this.radioButtonTCP.Name = "radioButtonTCP";
            this.radioButtonTCP.Size = new System.Drawing.Size(41, 16);
            this.radioButtonTCP.TabIndex = 1;
            this.radioButtonTCP.Text = "TCP";
            this.radioButtonTCP.UseVisualStyleBackColor = true;
            // 
            // groupBoxTCP
            // 
            this.groupBoxTCP.Controls.Add(this.label8);
            this.groupBoxTCP.Controls.Add(this.txtIP);
            this.groupBoxTCP.Controls.Add(this.label6);
            this.groupBoxTCP.Controls.Add(this.textBoxPort);
            this.groupBoxTCP.Enabled = false;
            this.groupBoxTCP.Location = new System.Drawing.Point(93, 12);
            this.groupBoxTCP.Name = "groupBoxTCP";
            this.groupBoxTCP.Size = new System.Drawing.Size(192, 98);
            this.groupBoxTCP.TabIndex = 0;
            this.groupBoxTCP.TabStop = false;
            this.groupBoxTCP.Text = "TCP";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(9, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "IP Address";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(79, 43);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(97, 21);
            this.txtIP.TabIndex = 10;
            this.txtIP.Text = "127.0.0.1";
            this.txtIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(9, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Port";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(79, 18);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(44, 21);
            this.textBoxPort.TabIndex = 8;
            this.textBoxPort.Text = "502";
            this.textBoxPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxSlaveID
            // 
            this.textBoxSlaveID.Location = new System.Drawing.Point(35, 98);
            this.textBoxSlaveID.Name = "textBoxSlaveID";
            this.textBoxSlaveID.Size = new System.Drawing.Size(40, 21);
            this.textBoxSlaveID.TabIndex = 29;
            this.textBoxSlaveID.Text = "1";
            this.textBoxSlaveID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(2, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Slave ID:";
            // 
            // ConnectView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxSlaveID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.grpStart);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Name = "ConnectView";
            this.Size = new System.Drawing.Size(776, 125);
            this.grpStart.ResumeLayout(false);
            this.groupBoxRTU.ResumeLayout(false);
            this.groupBoxRTU.PerformLayout();
            this.groupBoxMode.ResumeLayout(false);
            this.groupBoxMode.PerformLayout();
            this.groupBoxTCP.ResumeLayout(false);
            this.groupBoxTCP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        protected System.Windows.Forms.GroupBox grpStart;
        protected System.Windows.Forms.GroupBox groupBoxRTU;
        protected System.Windows.Forms.ComboBox comboBoxStopBits;
        protected System.Windows.Forms.Label label10;
        protected System.Windows.Forms.ComboBox comboBoxDataBits;
        protected System.Windows.Forms.Label label9;
        protected System.Windows.Forms.ComboBox comboBoxParity;
        protected System.Windows.Forms.Label labelParity;
        protected System.Windows.Forms.ComboBox comboBoxBaudRate;
        protected System.Windows.Forms.ComboBox comboBoxSerialPorts;
        protected System.Windows.Forms.Label label4;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.GroupBox groupBoxMode;
        protected System.Windows.Forms.RadioButton radioButtonRTU;
        protected System.Windows.Forms.RadioButton radioButtonUDP;
        protected System.Windows.Forms.RadioButton radioButtonTCP;
        protected System.Windows.Forms.GroupBox groupBoxTCP;
        protected System.Windows.Forms.Label label8;
        protected System.Windows.Forms.TextBox txtIP;
        protected System.Windows.Forms.Label label6;
        protected System.Windows.Forms.TextBox textBoxPort;
        protected System.Windows.Forms.TextBox textBoxSlaveID;
        protected System.Windows.Forms.Label label7;
    }
}
