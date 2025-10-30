namespace DataAnalyzer
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolSerial = new System.Windows.Forms.ToolStripButton();
            this.toolTCPServer = new System.Windows.Forms.ToolStripButton();
            this.toolTCPClient = new System.Windows.Forms.ToolStripButton();
            this.panelSerial = new System.Windows.Forms.Panel();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.txtCommandLog = new System.Windows.Forms.RichTextBox();
            this.grpConfig = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbCom = new System.Windows.Forms.ComboBox();
            this.cmbBaud = new System.Windows.Forms.ComboBox();
            this.cmbData = new System.Windows.Forms.ComboBox();
            this.cmbParity = new System.Windows.Forms.ComboBox();
            this.cmbStop = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCom = new System.Windows.Forms.Label();
            this.lblBaud = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.lblParity = new System.Windows.Forms.Label();
            this.lblStop = new System.Windows.Forms.Label();
            this.panelTCPServer = new System.Windows.Forms.Panel();
            this.btnServerConnect = new System.Windows.Forms.Button();
            this.btnServerSend = new System.Windows.Forms.Button();
            this.txtServerCommand = new System.Windows.Forms.TextBox();
            this.txtServerLog = new System.Windows.Forms.RichTextBox();
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.lblServerPort = new System.Windows.Forms.Label();
            this.lblServerAddress = new System.Windows.Forms.Label();
            this.panelTCPClient = new System.Windows.Forms.Panel();
            this.btnClientConnect = new System.Windows.Forms.Button();
            this.btnClientSend = new System.Windows.Forms.Button();
            this.txtClientCommand = new System.Windows.Forms.TextBox();
            this.txtClientLog = new System.Windows.Forms.RichTextBox();
            this.txtClientPort = new System.Windows.Forms.TextBox();
            this.txtClientIP = new System.Windows.Forms.TextBox();
            this.lblClientPort = new System.Windows.Forms.Label();
            this.lblClientIP = new System.Windows.Forms.Label();
            this._serialPort = new System.IO.Ports.SerialPort(this.components);
            this.toolStrip1.SuspendLayout();
            this.panelSerial.SuspendLayout();
            this.grpConfig.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelTCPServer.SuspendLayout();
            this.panelTCPClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSerial,
            this.toolTCPServer,
            this.toolTCPClient});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolSerial
            // 
            this.toolSerial.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolSerial.Image = ((System.Drawing.Image)(resources.GetObject("toolSerial.Image")));
            this.toolSerial.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSerial.Name = "toolSerial";
            this.toolSerial.Size = new System.Drawing.Size(40, 22);
            this.toolSerial.Text = "Serial";
            this.toolSerial.Click += new System.EventHandler(this.toolSerial_Click);
            // 
            // toolTCPServer
            // 
            this.toolTCPServer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolTCPServer.Image = ((System.Drawing.Image)(resources.GetObject("toolTCPServer.Image")));
            this.toolTCPServer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolTCPServer.Name = "toolTCPServer";
            this.toolTCPServer.Size = new System.Drawing.Size(84, 22);
            this.toolTCPServer.Text = "TCP/IP Server";
            this.toolTCPServer.ToolTipText = "TCP/IP Server";
            this.toolTCPServer.Click += new System.EventHandler(this.toolTCPServer_Click);
            // 
            // toolTCPClient
            // 
            this.toolTCPClient.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolTCPClient.Image = ((System.Drawing.Image)(resources.GetObject("toolTCPClient.Image")));
            this.toolTCPClient.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolTCPClient.Name = "toolTCPClient";
            this.toolTCPClient.Size = new System.Drawing.Size(82, 22);
            this.toolTCPClient.Text = "TCP/IP Client";
            this.toolTCPClient.Click += new System.EventHandler(this.toolTCPClient_Click);
            // 
            // panelSerial
            // 
            this.panelSerial.Controls.Add(this.btnSend);
            this.panelSerial.Controls.Add(this.txtCommand);
            this.panelSerial.Controls.Add(this.btnClose);
            this.panelSerial.Controls.Add(this.btnOpen);
            this.panelSerial.Controls.Add(this.txtCommandLog);
            this.panelSerial.Controls.Add(this.grpConfig);
            this.panelSerial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSerial.Location = new System.Drawing.Point(0, 0);
            this.panelSerial.Name = "panelSerial";
            this.panelSerial.Size = new System.Drawing.Size(800, 450);
            this.panelSerial.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(713, 215);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 25);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtCommand
            // 
            this.txtCommand.Location = new System.Drawing.Point(347, 215);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(358, 25);
            this.txtCommand.TabIndex = 4;
            this.txtCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCommand_KeyDown);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(211, 228);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(130, 228);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txtCommandLog
            // 
            this.txtCommandLog.Location = new System.Drawing.Point(15, 257);
            this.txtCommandLog.Name = "txtCommandLog";
            this.txtCommandLog.Size = new System.Drawing.Size(773, 169);
            this.txtCommandLog.TabIndex = 1;
            this.txtCommandLog.Text = "";
            // 
            // grpConfig
            // 
            this.grpConfig.Controls.Add(this.flowLayoutPanel2);
            this.grpConfig.Controls.Add(this.flowLayoutPanel1);
            this.grpConfig.Location = new System.Drawing.Point(12, 39);
            this.grpConfig.Name = "grpConfig";
            this.grpConfig.Size = new System.Drawing.Size(277, 183);
            this.grpConfig.TabIndex = 0;
            this.grpConfig.TabStop = false;
            this.grpConfig.Text = "Port Config";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.cmbCom);
            this.flowLayoutPanel2.Controls.Add(this.cmbBaud);
            this.flowLayoutPanel2.Controls.Add(this.cmbData);
            this.flowLayoutPanel2.Controls.Add(this.cmbParity);
            this.flowLayoutPanel2.Controls.Add(this.cmbStop);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(122, 21);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(152, 159);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // cmbCom
            // 
            this.cmbCom.FormattingEnabled = true;
            this.cmbCom.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13",
            "COM14",
            "COM15",
            "COM16",
            "COM17"});
            this.cmbCom.Location = new System.Drawing.Point(3, 3);
            this.cmbCom.Name = "cmbCom";
            this.cmbCom.Size = new System.Drawing.Size(121, 23);
            this.cmbCom.TabIndex = 0;
            // 
            // cmbBaud
            // 
            this.cmbBaud.FormattingEnabled = true;
            this.cmbBaud.Items.AddRange(new object[] {
            "4800",
            "9600",
            "19200",
            "38400",
            "115200"});
            this.cmbBaud.Location = new System.Drawing.Point(3, 32);
            this.cmbBaud.Name = "cmbBaud";
            this.cmbBaud.Size = new System.Drawing.Size(121, 23);
            this.cmbBaud.TabIndex = 1;
            // 
            // cmbData
            // 
            this.cmbData.FormattingEnabled = true;
            this.cmbData.Items.AddRange(new object[] {
            "7",
            "8",
            "9"});
            this.cmbData.Location = new System.Drawing.Point(3, 61);
            this.cmbData.Name = "cmbData";
            this.cmbData.Size = new System.Drawing.Size(121, 23);
            this.cmbData.TabIndex = 2;
            // 
            // cmbParity
            // 
            this.cmbParity.FormattingEnabled = true;
            this.cmbParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even"});
            this.cmbParity.Location = new System.Drawing.Point(3, 90);
            this.cmbParity.Name = "cmbParity";
            this.cmbParity.Size = new System.Drawing.Size(121, 23);
            this.cmbParity.TabIndex = 3;
            // 
            // cmbStop
            // 
            this.cmbStop.FormattingEnabled = true;
            this.cmbStop.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cmbStop.Location = new System.Drawing.Point(3, 119);
            this.cmbStop.Name = "cmbStop";
            this.cmbStop.Size = new System.Drawing.Size(121, 23);
            this.cmbStop.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblCom);
            this.flowLayoutPanel1.Controls.Add(this.lblBaud);
            this.flowLayoutPanel1.Controls.Add(this.lblData);
            this.flowLayoutPanel1.Controls.Add(this.lblParity);
            this.flowLayoutPanel1.Controls.Add(this.lblStop);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 21);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(113, 159);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // lblCom
            // 
            this.lblCom.AutoSize = true;
            this.lblCom.Location = new System.Drawing.Point(3, 7);
            this.lblCom.Margin = new System.Windows.Forms.Padding(3, 7, 3, 14);
            this.lblCom.Name = "lblCom";
            this.lblCom.Size = new System.Drawing.Size(41, 15);
            this.lblCom.TabIndex = 0;
            this.lblCom.Text = "COM";
            // 
            // lblBaud
            // 
            this.lblBaud.AutoSize = true;
            this.lblBaud.Location = new System.Drawing.Point(3, 36);
            this.lblBaud.Margin = new System.Windows.Forms.Padding(3, 0, 3, 14);
            this.lblBaud.Name = "lblBaud";
            this.lblBaud.Size = new System.Drawing.Size(71, 15);
            this.lblBaud.TabIndex = 1;
            this.lblBaud.Text = "BaudRate";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(3, 65);
            this.lblData.Margin = new System.Windows.Forms.Padding(3, 0, 3, 14);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(65, 15);
            this.lblData.TabIndex = 2;
            this.lblData.Text = "Data bits";
            // 
            // lblParity
            // 
            this.lblParity.AutoSize = true;
            this.lblParity.Location = new System.Drawing.Point(3, 94);
            this.lblParity.Margin = new System.Windows.Forms.Padding(3, 0, 3, 14);
            this.lblParity.Name = "lblParity";
            this.lblParity.Size = new System.Drawing.Size(44, 15);
            this.lblParity.TabIndex = 3;
            this.lblParity.Text = "Parity";
            // 
            // lblStop
            // 
            this.lblStop.AutoSize = true;
            this.lblStop.Location = new System.Drawing.Point(3, 123);
            this.lblStop.Margin = new System.Windows.Forms.Padding(3, 0, 3, 14);
            this.lblStop.Name = "lblStop";
            this.lblStop.Size = new System.Drawing.Size(66, 15);
            this.lblStop.TabIndex = 4;
            this.lblStop.Text = "Stop bits";
            // 
            // panelTCPServer
            // 
            this.panelTCPServer.Controls.Add(this.btnServerConnect);
            this.panelTCPServer.Controls.Add(this.btnServerSend);
            this.panelTCPServer.Controls.Add(this.txtServerCommand);
            this.panelTCPServer.Controls.Add(this.txtServerLog);
            this.panelTCPServer.Controls.Add(this.txtServerPort);
            this.panelTCPServer.Controls.Add(this.txtServerIP);
            this.panelTCPServer.Controls.Add(this.lblServerPort);
            this.panelTCPServer.Controls.Add(this.lblServerAddress);
            this.panelTCPServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTCPServer.Location = new System.Drawing.Point(0, 0);
            this.panelTCPServer.Name = "panelTCPServer";
            this.panelTCPServer.Size = new System.Drawing.Size(800, 450);
            this.panelTCPServer.TabIndex = 2;
            this.panelTCPServer.Visible = false;
            // 
            // btnServerConnect
            // 
            this.btnServerConnect.Location = new System.Drawing.Point(602, 67);
            this.btnServerConnect.Name = "btnServerConnect";
            this.btnServerConnect.Size = new System.Drawing.Size(166, 47);
            this.btnServerConnect.TabIndex = 7;
            this.btnServerConnect.Text = "Connect";
            this.btnServerConnect.UseVisualStyleBackColor = true;
            this.btnServerConnect.Click += new System.EventHandler(this.btnServerConnect_Click);
            // 
            // btnServerSend
            // 
            this.btnServerSend.Location = new System.Drawing.Point(693, 401);
            this.btnServerSend.Name = "btnServerSend";
            this.btnServerSend.Size = new System.Drawing.Size(75, 25);
            this.btnServerSend.TabIndex = 6;
            this.btnServerSend.Text = "Send";
            this.btnServerSend.UseVisualStyleBackColor = true;
            this.btnServerSend.Click += new System.EventHandler(this.btnServerSend_Click);
            // 
            // txtServerCommand
            // 
            this.txtServerCommand.Location = new System.Drawing.Point(30, 401);
            this.txtServerCommand.Name = "txtServerCommand";
            this.txtServerCommand.Size = new System.Drawing.Size(657, 25);
            this.txtServerCommand.TabIndex = 5;
            // 
            // txtServerLog
            // 
            this.txtServerLog.Location = new System.Drawing.Point(30, 125);
            this.txtServerLog.Name = "txtServerLog";
            this.txtServerLog.Size = new System.Drawing.Size(738, 256);
            this.txtServerLog.TabIndex = 4;
            this.txtServerLog.Text = "";
            // 
            // txtServerPort
            // 
            this.txtServerPort.Location = new System.Drawing.Point(312, 89);
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(100, 25);
            this.txtServerPort.TabIndex = 3;
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(30, 89);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(235, 25);
            this.txtServerIP.TabIndex = 2;
            // 
            // lblServerPort
            // 
            this.lblServerPort.AutoSize = true;
            this.lblServerPort.Location = new System.Drawing.Point(309, 64);
            this.lblServerPort.Name = "lblServerPort";
            this.lblServerPort.Size = new System.Drawing.Size(34, 15);
            this.lblServerPort.TabIndex = 1;
            this.lblServerPort.Text = "Port";
            // 
            // lblServerAddress
            // 
            this.lblServerAddress.AutoSize = true;
            this.lblServerAddress.Location = new System.Drawing.Point(27, 64);
            this.lblServerAddress.Name = "lblServerAddress";
            this.lblServerAddress.Size = new System.Drawing.Size(78, 15);
            this.lblServerAddress.TabIndex = 0;
            this.lblServerAddress.Text = "IP Address";
            // 
            // panelTCPClient
            // 
            this.panelTCPClient.Controls.Add(this.btnClientConnect);
            this.panelTCPClient.Controls.Add(this.btnClientSend);
            this.panelTCPClient.Controls.Add(this.txtClientCommand);
            this.panelTCPClient.Controls.Add(this.txtClientLog);
            this.panelTCPClient.Controls.Add(this.txtClientPort);
            this.panelTCPClient.Controls.Add(this.txtClientIP);
            this.panelTCPClient.Controls.Add(this.lblClientPort);
            this.panelTCPClient.Controls.Add(this.lblClientIP);
            this.panelTCPClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTCPClient.Location = new System.Drawing.Point(0, 0);
            this.panelTCPClient.Name = "panelTCPClient";
            this.panelTCPClient.Size = new System.Drawing.Size(800, 450);
            this.panelTCPClient.TabIndex = 3;
            this.panelTCPClient.Visible = false;
            // 
            // btnClientConnect
            // 
            this.btnClientConnect.Location = new System.Drawing.Point(602, 67);
            this.btnClientConnect.Name = "btnClientConnect";
            this.btnClientConnect.Size = new System.Drawing.Size(166, 47);
            this.btnClientConnect.TabIndex = 15;
            this.btnClientConnect.Text = "Connect";
            this.btnClientConnect.UseVisualStyleBackColor = true;
            this.btnClientConnect.Click += new System.EventHandler(this.btnClientConnect_Click);
            // 
            // btnClientSend
            // 
            this.btnClientSend.Location = new System.Drawing.Point(693, 401);
            this.btnClientSend.Name = "btnClientSend";
            this.btnClientSend.Size = new System.Drawing.Size(75, 25);
            this.btnClientSend.TabIndex = 14;
            this.btnClientSend.Text = "Send";
            this.btnClientSend.UseVisualStyleBackColor = true;
            this.btnClientSend.Click += new System.EventHandler(this.btnClientSend_Click);
            // 
            // txtClientCommand
            // 
            this.txtClientCommand.Location = new System.Drawing.Point(30, 401);
            this.txtClientCommand.Name = "txtClientCommand";
            this.txtClientCommand.Size = new System.Drawing.Size(657, 25);
            this.txtClientCommand.TabIndex = 13;
            // 
            // txtClientLog
            // 
            this.txtClientLog.Location = new System.Drawing.Point(30, 125);
            this.txtClientLog.Name = "txtClientLog";
            this.txtClientLog.Size = new System.Drawing.Size(738, 256);
            this.txtClientLog.TabIndex = 12;
            this.txtClientLog.Text = "";
            // 
            // txtClientPort
            // 
            this.txtClientPort.Location = new System.Drawing.Point(312, 89);
            this.txtClientPort.Name = "txtClientPort";
            this.txtClientPort.Size = new System.Drawing.Size(100, 25);
            this.txtClientPort.TabIndex = 11;
            // 
            // txtClientIP
            // 
            this.txtClientIP.Location = new System.Drawing.Point(30, 89);
            this.txtClientIP.Name = "txtClientIP";
            this.txtClientIP.Size = new System.Drawing.Size(235, 25);
            this.txtClientIP.TabIndex = 10;
            // 
            // lblClientPort
            // 
            this.lblClientPort.AutoSize = true;
            this.lblClientPort.Location = new System.Drawing.Point(309, 64);
            this.lblClientPort.Name = "lblClientPort";
            this.lblClientPort.Size = new System.Drawing.Size(34, 15);
            this.lblClientPort.TabIndex = 9;
            this.lblClientPort.Text = "Port";
            // 
            // lblClientIP
            // 
            this.lblClientIP.AutoSize = true;
            this.lblClientIP.Location = new System.Drawing.Point(27, 64);
            this.lblClientIP.Name = "lblClientIP";
            this.lblClientIP.Size = new System.Drawing.Size(78, 15);
            this.lblClientIP.TabIndex = 8;
            this.lblClientIP.Text = "IP Address";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panelSerial);
            this.Controls.Add(this.panelTCPClient);
            this.Controls.Add(this.panelTCPServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelSerial.ResumeLayout(false);
            this.panelSerial.PerformLayout();
            this.grpConfig.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panelTCPServer.ResumeLayout(false);
            this.panelTCPServer.PerformLayout();
            this.panelTCPClient.ResumeLayout(false);
            this.panelTCPClient.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolSerial;
        private System.Windows.Forms.ToolStripButton toolTCPServer;
        private System.Windows.Forms.ToolStripButton toolTCPClient;
        private System.Windows.Forms.Panel panelSerial;
        private System.Windows.Forms.GroupBox grpConfig;
        private System.Windows.Forms.Panel panelTCPServer;
        private System.Windows.Forms.Panel panelTCPClient;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox cmbCom;
        private System.Windows.Forms.ComboBox cmbBaud;
        private System.Windows.Forms.ComboBox cmbData;
        private System.Windows.Forms.ComboBox cmbParity;
        private System.Windows.Forms.ComboBox cmbStop;
        private System.Windows.Forms.Label lblCom;
        private System.Windows.Forms.Label lblBaud;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblParity;
        private System.Windows.Forms.Label lblStop;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.RichTextBox txtCommandLog;
        private System.Windows.Forms.TextBox txtServerPort;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.Label lblServerPort;
        private System.Windows.Forms.Label lblServerAddress;
        private System.Windows.Forms.Button btnServerSend;
        private System.Windows.Forms.TextBox txtServerCommand;
        private System.Windows.Forms.RichTextBox txtServerLog;
        private System.Windows.Forms.Button btnServerConnect;
        private System.Windows.Forms.Button btnClientConnect;
        private System.Windows.Forms.Button btnClientSend;
        private System.Windows.Forms.TextBox txtClientCommand;
        private System.Windows.Forms.RichTextBox txtClientLog;
        private System.Windows.Forms.TextBox txtClientPort;
        private System.Windows.Forms.TextBox txtClientIP;
        private System.Windows.Forms.Label lblClientPort;
        private System.Windows.Forms.Label lblClientIP;
        private System.IO.Ports.SerialPort _serialPort;
    }
}

