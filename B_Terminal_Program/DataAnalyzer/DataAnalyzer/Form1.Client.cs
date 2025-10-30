using System;
using System.Collections.Generic;
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
        TcpClient _client;
        NetworkStream _clientStream;

        Boolean CurrentClientFlag = false;
        private void btnClientConnect_Click(object sender, EventArgs e)
        {
            if (CurrentClientFlag == false)
            {
                CurrentClientFlag = true;
                btnClientConnect.Text = "Disconnect";

                Thread thread = new Thread(clientConnect);
                thread.IsBackground = true;
                thread.Start();
            }
            else if (CurrentClientFlag == true)
            {
                CurrentClientFlag = false;
                btnClientConnect.Text = "Connect";

                _clientStream.Close();
                _client.Close();
            }
        }
        private void btnClientSend_Click(object sender, EventArgs e)
        {
            byte[] msg = System.Text.Encoding.UTF8.GetBytes(txtClientCommand.Text + '\n');
            _clientStream.Write(msg, 0, msg.Length);

            txtClientCommand.Clear();
        }

        private void clientConnect()
        {
            _client = new TcpClient();
            clientIP = new IPEndPoint(IPAddress.Parse(txtClientIP.Text), int.Parse(txtClientPort.Text));
            _client.Connect(clientIP);

            _clientStream = _client.GetStream();

            while (_client.Connected)
            {
                int length;
                byte[] buffer = new byte[1024];

                while ((length = _clientStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    String msg = Encoding.Default.GetString(buffer, 0, length);

                    UiLog(txtClientLog, msg);
                }
            }
        }
    }
}
