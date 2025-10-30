using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAnalyzer
{
    public partial class Form1
    {
        TcpListener _serverListener;
        TcpClient _serverClient;
        NetworkStream _serverStream;

        Boolean CurrentServerFlag = false;
        private void btnServerConnect_Click(object sender, EventArgs e)
        {
            if (CurrentServerFlag == false)
            {
                CurrentServerFlag = true;
                btnServerConnect.Text = "Disconnect";

                Thread thread = new Thread(ServerConnect);
                thread.IsBackground = true;
                thread.Start();
            }
            else if (CurrentServerFlag == true)
            {
                CurrentServerFlag = false;
                btnServerConnect.Text = "Connect";

                _serverStream.Close();
                _serverClient.Close();
                UiLog(txtServerLog, "클라이언트와의 연결 종료\n");
            }
        }
        private void btnServerSend_Click(object sender, EventArgs e)
        {
            byte[] msg = System.Text.Encoding.UTF8.GetBytes(txtServerCommand.Text + '\n');
            _serverStream.Write(msg, 0, msg.Length);

            txtServerCommand.Clear();
        }
        private void ServerConnect()
        {
            _serverListener = new TcpListener(IPAddress.Parse(txtServerIP.Text), int.Parse(txtServerPort.Text));
            _serverListener.Start();
            UiLog(txtServerLog, "클라이언트와의 연결 대기 중\n");

            _serverClient = _serverListener.AcceptTcpClient();
            UiLog(txtServerLog, "클라이언트와의 연결\n");

            _serverStream = _serverClient.GetStream();

            while (_serverClient.Connected)
            {
                int length;
                byte[] buffer = new byte[1024];

                while ((length = _serverStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    String msg = Encoding.Default.GetString(buffer, 0, length);

                    UiLog(txtServerLog, msg);
                }
            }
        }
    }
}
