using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        }

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

        private void btnOpen_Click(object sender, EventArgs e)
        {

        }

        private void btbClose_Click(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            txtCommandLog.AppendText(txtCommand.Text + '\n');
            txtCommand.Clear();
        }

        private void txtCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCommandLog.AppendText(txtCommand.Text + '\n');
                txtCommand.Clear();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btnServerSend_Click(object sender, EventArgs e)
        {

        }

        private void btnServerConnect_Click(object sender, EventArgs e)
        {

        }
    }
}
