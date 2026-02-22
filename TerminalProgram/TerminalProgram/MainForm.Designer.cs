namespace TerminalProgram
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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
            this.txtClientCommand = new System.Windows.Forms.TextBox();
            this.btnClientConnect = new System.Windows.Forms.Button();
            this.txtClientLog = new System.Windows.Forms.RichTextBox();
            this.txtClientPort = new System.Windows.Forms.TextBox();
            this.txtClientIP = new System.Windows.Forms.TextBox();
            this.btnClientSend = new System.Windows.Forms.Button();
            this.lblClientPort = new System.Windows.Forms.Label();
            this.lblClientIP = new System.Windows.Forms.Label();
            this._serialPort = new System.IO.Ports.SerialPort(this.components);
            this.tabControl_Transport = new System.Windows.Forms.TabControl();
            this.tabPage_Serial = new System.Windows.Forms.TabPage();
            this.tabPage_Server = new System.Windows.Forms.TabPage();
            this.tabPage_Client = new System.Windows.Forms.TabPage();
            this.toolStrip1.SuspendLayout();
            this.panelSerial.SuspendLayout();
            this.grpConfig.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelTCPServer.SuspendLayout();
            this.panelTCPClient.SuspendLayout();
            this.tabControl_Transport.SuspendLayout();
            this.tabPage_Serial.SuspendLayout();
            this.tabPage_Server.SuspendLayout();
            this.tabPage_Client.SuspendLayout();
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
            this.toolStrip1.Size = new System.Drawing.Size(1000, 34);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolSerial
            // 
            this.toolSerial.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolSerial.Image = ((System.Drawing.Image)(resources.GetObject("toolSerial.Image")));
            this.toolSerial.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSerial.Name = "toolSerial";
            this.toolSerial.Size = new System.Drawing.Size(59, 29);
            this.toolSerial.Text = "Serial";
            // 
            // toolTCPServer
            // 
            this.toolTCPServer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolTCPServer.Image = ((System.Drawing.Image)(resources.GetObject("toolTCPServer.Image")));
            this.toolTCPServer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolTCPServer.Name = "toolTCPServer";
            this.toolTCPServer.Size = new System.Drawing.Size(126, 29);
            this.toolTCPServer.Text = "TCP/IP Server";
            this.toolTCPServer.ToolTipText = "TCP/IP Server";
            // 
            // toolTCPClient
            // 
            this.toolTCPClient.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolTCPClient.Image = ((System.Drawing.Image)(resources.GetObject("toolTCPClient.Image")));
            this.toolTCPClient.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolTCPClient.Name = "toolTCPClient";
            this.toolTCPClient.Size = new System.Drawing.Size(120, 29);
            this.toolTCPClient.Text = "TCP/IP Client";
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
            this.panelSerial.Location = new System.Drawing.Point(3, 3);
            this.panelSerial.Margin = new System.Windows.Forms.Padding(4);
            this.panelSerial.Name = "panelSerial";
            this.panelSerial.Size = new System.Drawing.Size(986, 468);
            this.panelSerial.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(876, 231);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(94, 30);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtCommand
            // 
            this.txtCommand.Location = new System.Drawing.Point(419, 231);
            this.txtCommand.Margin = new System.Windows.Forms.Padding(4);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(446, 28);
            this.txtCommand.TabIndex = 4;
            this.txtCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCommand_KeyDown);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(520, 195);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 28);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(418, 195);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(94, 28);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txtCommandLog
            // 
            this.txtCommandLog.Location = new System.Drawing.Point(15, 269);
            this.txtCommandLog.Margin = new System.Windows.Forms.Padding(4);
            this.txtCommandLog.Name = "txtCommandLog";
            this.txtCommandLog.Size = new System.Drawing.Size(955, 179);
            this.txtCommandLog.TabIndex = 1;
            this.txtCommandLog.Text = "";
            // 
            // grpConfig
            // 
            this.grpConfig.Controls.Add(this.flowLayoutPanel2);
            this.grpConfig.Controls.Add(this.flowLayoutPanel1);
            this.grpConfig.Location = new System.Drawing.Point(11, 8);
            this.grpConfig.Margin = new System.Windows.Forms.Padding(4);
            this.grpConfig.Name = "grpConfig";
            this.grpConfig.Padding = new System.Windows.Forms.Padding(4);
            this.grpConfig.Size = new System.Drawing.Size(346, 235);
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
            this.flowLayoutPanel2.Location = new System.Drawing.Point(152, 25);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(190, 206);
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
            this.cmbCom.Location = new System.Drawing.Point(4, 4);
            this.cmbCom.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCom.Name = "cmbCom";
            this.cmbCom.Size = new System.Drawing.Size(150, 26);
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
            this.cmbBaud.Location = new System.Drawing.Point(4, 38);
            this.cmbBaud.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBaud.Name = "cmbBaud";
            this.cmbBaud.Size = new System.Drawing.Size(150, 26);
            this.cmbBaud.TabIndex = 1;
            // 
            // cmbData
            // 
            this.cmbData.FormattingEnabled = true;
            this.cmbData.Items.AddRange(new object[] {
            "7",
            "8",
            "9"});
            this.cmbData.Location = new System.Drawing.Point(4, 72);
            this.cmbData.Margin = new System.Windows.Forms.Padding(4);
            this.cmbData.Name = "cmbData";
            this.cmbData.Size = new System.Drawing.Size(150, 26);
            this.cmbData.TabIndex = 2;
            // 
            // cmbParity
            // 
            this.cmbParity.FormattingEnabled = true;
            this.cmbParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even"});
            this.cmbParity.Location = new System.Drawing.Point(4, 106);
            this.cmbParity.Margin = new System.Windows.Forms.Padding(4);
            this.cmbParity.Name = "cmbParity";
            this.cmbParity.Size = new System.Drawing.Size(150, 26);
            this.cmbParity.TabIndex = 3;
            // 
            // cmbStop
            // 
            this.cmbStop.FormattingEnabled = true;
            this.cmbStop.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cmbStop.Location = new System.Drawing.Point(4, 140);
            this.cmbStop.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStop.Name = "cmbStop";
            this.cmbStop.Size = new System.Drawing.Size(150, 26);
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
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 25);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(141, 206);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // lblCom
            // 
            this.lblCom.AutoSize = true;
            this.lblCom.Location = new System.Drawing.Point(4, 8);
            this.lblCom.Margin = new System.Windows.Forms.Padding(4, 8, 4, 17);
            this.lblCom.Name = "lblCom";
            this.lblCom.Size = new System.Drawing.Size(48, 18);
            this.lblCom.TabIndex = 0;
            this.lblCom.Text = "COM";
            // 
            // lblBaud
            // 
            this.lblBaud.AutoSize = true;
            this.lblBaud.Location = new System.Drawing.Point(4, 43);
            this.lblBaud.Margin = new System.Windows.Forms.Padding(4, 0, 4, 17);
            this.lblBaud.Name = "lblBaud";
            this.lblBaud.Size = new System.Drawing.Size(85, 18);
            this.lblBaud.TabIndex = 1;
            this.lblBaud.Text = "BaudRate";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(4, 78);
            this.lblData.Margin = new System.Windows.Forms.Padding(4, 0, 4, 17);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(78, 18);
            this.lblData.TabIndex = 2;
            this.lblData.Text = "Data bits";
            // 
            // lblParity
            // 
            this.lblParity.AutoSize = true;
            this.lblParity.Location = new System.Drawing.Point(4, 113);
            this.lblParity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 17);
            this.lblParity.Name = "lblParity";
            this.lblParity.Size = new System.Drawing.Size(53, 18);
            this.lblParity.TabIndex = 3;
            this.lblParity.Text = "Parity";
            // 
            // lblStop
            // 
            this.lblStop.AutoSize = true;
            this.lblStop.Location = new System.Drawing.Point(4, 148);
            this.lblStop.Margin = new System.Windows.Forms.Padding(4, 0, 4, 17);
            this.lblStop.Name = "lblStop";
            this.lblStop.Size = new System.Drawing.Size(79, 18);
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
            this.panelTCPServer.Location = new System.Drawing.Point(3, 3);
            this.panelTCPServer.Margin = new System.Windows.Forms.Padding(4);
            this.panelTCPServer.Name = "panelTCPServer";
            this.panelTCPServer.Size = new System.Drawing.Size(986, 468);
            this.panelTCPServer.TabIndex = 2;
            // 
            // btnServerConnect
            // 
            this.btnServerConnect.Location = new System.Drawing.Point(743, 24);
            this.btnServerConnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnServerConnect.Name = "btnServerConnect";
            this.btnServerConnect.Size = new System.Drawing.Size(208, 56);
            this.btnServerConnect.TabIndex = 7;
            this.btnServerConnect.Text = "Connect";
            this.btnServerConnect.UseVisualStyleBackColor = true;
            this.btnServerConnect.Click += new System.EventHandler(this.btnServerConnect_Click);
            // 
            // btnServerSend
            // 
            this.btnServerSend.Location = new System.Drawing.Point(857, 408);
            this.btnServerSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnServerSend.Name = "btnServerSend";
            this.btnServerSend.Size = new System.Drawing.Size(94, 30);
            this.btnServerSend.TabIndex = 6;
            this.btnServerSend.Text = "Send";
            this.btnServerSend.UseVisualStyleBackColor = true;
            this.btnServerSend.Click += new System.EventHandler(this.btnServerSend_Click);
            // 
            // txtServerCommand
            // 
            this.txtServerCommand.Location = new System.Drawing.Point(29, 408);
            this.txtServerCommand.Margin = new System.Windows.Forms.Padding(4);
            this.txtServerCommand.Name = "txtServerCommand";
            this.txtServerCommand.Size = new System.Drawing.Size(820, 28);
            this.txtServerCommand.TabIndex = 5;
            this.txtServerCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtServerCommand_KeyDown);
            // 
            // txtServerLog
            // 
            this.txtServerLog.Location = new System.Drawing.Point(29, 94);
            this.txtServerLog.Margin = new System.Windows.Forms.Padding(4);
            this.txtServerLog.Name = "txtServerLog";
            this.txtServerLog.Size = new System.Drawing.Size(922, 306);
            this.txtServerLog.TabIndex = 4;
            this.txtServerLog.Text = "";
            // 
            // txtServerPort
            // 
            this.txtServerPort.Location = new System.Drawing.Point(381, 51);
            this.txtServerPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(124, 28);
            this.txtServerPort.TabIndex = 3;
            this.txtServerPort.Text = "5000";
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(29, 51);
            this.txtServerIP.Margin = new System.Windows.Forms.Padding(4);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(293, 28);
            this.txtServerIP.TabIndex = 2;
            this.txtServerIP.Text = "127.0.0.1";
            // 
            // lblServerPort
            // 
            this.lblServerPort.AutoSize = true;
            this.lblServerPort.Location = new System.Drawing.Point(377, 21);
            this.lblServerPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServerPort.Name = "lblServerPort";
            this.lblServerPort.Size = new System.Drawing.Size(41, 18);
            this.lblServerPort.TabIndex = 1;
            this.lblServerPort.Text = "Port";
            // 
            // lblServerAddress
            // 
            this.lblServerAddress.AutoSize = true;
            this.lblServerAddress.Location = new System.Drawing.Point(25, 21);
            this.lblServerAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServerAddress.Name = "lblServerAddress";
            this.lblServerAddress.Size = new System.Drawing.Size(155, 18);
            this.lblServerAddress.TabIndex = 0;
            this.lblServerAddress.Text = "Server IP Address";
            // 
            // panelTCPClient
            // 
            this.panelTCPClient.Controls.Add(this.txtClientCommand);
            this.panelTCPClient.Controls.Add(this.btnClientConnect);
            this.panelTCPClient.Controls.Add(this.txtClientLog);
            this.panelTCPClient.Controls.Add(this.txtClientPort);
            this.panelTCPClient.Controls.Add(this.txtClientIP);
            this.panelTCPClient.Controls.Add(this.btnClientSend);
            this.panelTCPClient.Controls.Add(this.lblClientPort);
            this.panelTCPClient.Controls.Add(this.lblClientIP);
            this.panelTCPClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTCPClient.Location = new System.Drawing.Point(0, 0);
            this.panelTCPClient.Margin = new System.Windows.Forms.Padding(4);
            this.panelTCPClient.Name = "panelTCPClient";
            this.panelTCPClient.Size = new System.Drawing.Size(992, 474);
            this.panelTCPClient.TabIndex = 3;
            // 
            // txtClientCommand
            // 
            this.txtClientCommand.Location = new System.Drawing.Point(35, 414);
            this.txtClientCommand.Margin = new System.Windows.Forms.Padding(4);
            this.txtClientCommand.Name = "txtClientCommand";
            this.txtClientCommand.Size = new System.Drawing.Size(820, 28);
            this.txtClientCommand.TabIndex = 13;
            this.txtClientCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtClientCommand_KeyDown);
            // 
            // btnClientConnect
            // 
            this.btnClientConnect.Location = new System.Drawing.Point(749, 30);
            this.btnClientConnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnClientConnect.Name = "btnClientConnect";
            this.btnClientConnect.Size = new System.Drawing.Size(208, 56);
            this.btnClientConnect.TabIndex = 15;
            this.btnClientConnect.Text = "Connect";
            this.btnClientConnect.UseVisualStyleBackColor = true;
            this.btnClientConnect.Click += new System.EventHandler(this.btnClientConnect_Click);
            // 
            // txtClientLog
            // 
            this.txtClientLog.Location = new System.Drawing.Point(35, 100);
            this.txtClientLog.Margin = new System.Windows.Forms.Padding(4);
            this.txtClientLog.Name = "txtClientLog";
            this.txtClientLog.Size = new System.Drawing.Size(922, 306);
            this.txtClientLog.TabIndex = 12;
            this.txtClientLog.Text = "";
            // 
            // txtClientPort
            // 
            this.txtClientPort.Location = new System.Drawing.Point(387, 57);
            this.txtClientPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtClientPort.Name = "txtClientPort";
            this.txtClientPort.Size = new System.Drawing.Size(124, 28);
            this.txtClientPort.TabIndex = 11;
            this.txtClientPort.Text = "5000";
            // 
            // txtClientIP
            // 
            this.txtClientIP.Location = new System.Drawing.Point(35, 57);
            this.txtClientIP.Margin = new System.Windows.Forms.Padding(4);
            this.txtClientIP.Name = "txtClientIP";
            this.txtClientIP.Size = new System.Drawing.Size(293, 28);
            this.txtClientIP.TabIndex = 10;
            this.txtClientIP.Text = "127.0.0.1";
            // 
            // btnClientSend
            // 
            this.btnClientSend.Location = new System.Drawing.Point(863, 414);
            this.btnClientSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnClientSend.Name = "btnClientSend";
            this.btnClientSend.Size = new System.Drawing.Size(94, 30);
            this.btnClientSend.TabIndex = 14;
            this.btnClientSend.Text = "Send";
            this.btnClientSend.UseVisualStyleBackColor = true;
            this.btnClientSend.Click += new System.EventHandler(this.btnClientSend_Click);
            // 
            // lblClientPort
            // 
            this.lblClientPort.AutoSize = true;
            this.lblClientPort.Location = new System.Drawing.Point(383, 27);
            this.lblClientPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClientPort.Name = "lblClientPort";
            this.lblClientPort.Size = new System.Drawing.Size(41, 18);
            this.lblClientPort.TabIndex = 9;
            this.lblClientPort.Text = "Port";
            // 
            // lblClientIP
            // 
            this.lblClientIP.AutoSize = true;
            this.lblClientIP.Location = new System.Drawing.Point(31, 27);
            this.lblClientIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClientIP.Name = "lblClientIP";
            this.lblClientIP.Size = new System.Drawing.Size(145, 18);
            this.lblClientIP.TabIndex = 8;
            this.lblClientIP.Text = "Client IP Address";
            // 
            // tabControl_Transport
            // 
            this.tabControl_Transport.Controls.Add(this.tabPage_Serial);
            this.tabControl_Transport.Controls.Add(this.tabPage_Server);
            this.tabControl_Transport.Controls.Add(this.tabPage_Client);
            this.tabControl_Transport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_Transport.Location = new System.Drawing.Point(0, 34);
            this.tabControl_Transport.Name = "tabControl_Transport";
            this.tabControl_Transport.SelectedIndex = 0;
            this.tabControl_Transport.Size = new System.Drawing.Size(1000, 506);
            this.tabControl_Transport.TabIndex = 6;
            this.tabControl_Transport.SelectedIndexChanged += new System.EventHandler(this.tabControl_Transport_SelectedIndexChanged);
            // 
            // tabPage_Serial
            // 
            this.tabPage_Serial.Controls.Add(this.panelSerial);
            this.tabPage_Serial.Location = new System.Drawing.Point(4, 28);
            this.tabPage_Serial.Name = "tabPage_Serial";
            this.tabPage_Serial.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Serial.Size = new System.Drawing.Size(992, 474);
            this.tabPage_Serial.TabIndex = 0;
            this.tabPage_Serial.Text = "Serial";
            this.tabPage_Serial.UseVisualStyleBackColor = true;
            // 
            // tabPage_Server
            // 
            this.tabPage_Server.Controls.Add(this.panelTCPServer);
            this.tabPage_Server.Location = new System.Drawing.Point(4, 28);
            this.tabPage_Server.Name = "tabPage_Server";
            this.tabPage_Server.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Server.Size = new System.Drawing.Size(992, 474);
            this.tabPage_Server.TabIndex = 1;
            this.tabPage_Server.Text = "TCP Server";
            this.tabPage_Server.UseVisualStyleBackColor = true;
            // 
            // tabPage_Client
            // 
            this.tabPage_Client.Controls.Add(this.panelTCPClient);
            this.tabPage_Client.Location = new System.Drawing.Point(4, 28);
            this.tabPage_Client.Name = "tabPage_Client";
            this.tabPage_Client.Size = new System.Drawing.Size(992, 474);
            this.tabPage_Client.TabIndex = 2;
            this.tabPage_Client.Text = "TCP Client";
            this.tabPage_Client.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 540);
            this.Controls.Add(this.tabControl_Transport);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
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
            this.tabControl_Transport.ResumeLayout(false);
            this.tabPage_Serial.ResumeLayout(false);
            this.tabPage_Server.ResumeLayout(false);
            this.tabPage_Client.ResumeLayout(false);
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
        private System.Windows.Forms.TabControl tabControl_Transport;
        private System.Windows.Forms.TabPage tabPage_Serial;
        private System.Windows.Forms.TabPage tabPage_Server;
        private System.Windows.Forms.TabPage tabPage_Client;
    }
}

