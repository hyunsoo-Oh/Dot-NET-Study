using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAnalyzer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // 이벤트 중복 연결 방지 후 재연결
            _serialPort.DataReceived -= _serialPort_DataReceived;
            _serialPort.DataReceived += _serialPort_DataReceived;

            // 수신 설정: 아두이노 println 기준
            _serialPort.Encoding = Encoding.ASCII;
            _serialPort.NewLine = "\n";
            _serialPort.ReceivedBytesThreshold = 1; // 1바이트만 와도 이벤트 발생
        }
        IPEndPoint serverIP;
        IPEndPoint clientIP;
        IPEndPoint ip;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Terminal - Serial";
        }

        private void toolSerial_Click(object sender, EventArgs e)
        {
            this.Text = "Terminal - Serial";

            panelSerial.Visible = true;
            panelTCPServer.Visible = false;
            panelTCPClient.Visible = false;
        }

        private void toolTCPServer_Click(object sender, EventArgs e)
        {
            this.Text = "Terminal - TCP/IP Server";

            panelSerial.Visible = false;
            panelTCPServer.Visible = true;
            panelTCPClient.Visible = false;
        }

        private void toolTCPClient_Click(object sender, EventArgs e)
        {
            this.Text = "Terminal - TCP/IP Client";

            panelSerial.Visible = false;
            panelTCPServer.Visible = false;
            panelTCPClient.Visible = true;
        }
        private void UiLog(RichTextBox box, string msg)
        {
            if (box.InvokeRequired)
            {
                box.Invoke(new Action<RichTextBox, string>(UiLog), box, msg);
            }
            else
            {
                box.AppendText(msg);
            }
        }
    }
}
