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
        Boolean CurrentClientFlag = false;
        byte[] recv_buff = new byte[1024];
        private void btnClientConnect_Click(object sender, EventArgs e)
        {
            if (CurrentClientFlag == false)
            {
                CurrentClientFlag = true;

                btnClientConnect.Text = "Disconnect";
                C_point = new IPEndPoint(IPAddress.Parse(txtClientIP.Text), Int32.Parse(txtClientPort.Text));
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                client.Connect(C_point);

                Thread clientThread = new Thread(ClientToServer);
                clientThread.IsBackground = true;
                clientThread.Start();
            }
            else if (CurrentClientFlag == true)
            {
                CurrentClientFlag = false;

                byte[] send_data = Encoding.Default.GetBytes("클라이언트와의 연결이 끊어졌습니다.\n");
                client.Send(send_data, send_data.Length, SocketFlags.None);

                client.Close();
                btnClientConnect.Text = "Connect";
            }
        }
        private void ClientToServer()
        {
            client.Receive(recv_buff);
            txtClientLog.AppendText(Encoding.Default.GetString(recv_buff) + '\n');
        }
        private void btnClientSend_Click(object sender, EventArgs e)
        {
            client.Send(Encoding.Default.GetBytes(txtClientCommand.Text + '\n'));
        }
    }
}
