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
        Boolean CurrentServerFlag = false;
        byte[] recv_data = new byte[1024];
        private void btnServerConnect_Click(object sender, EventArgs e)
        {
            if (CurrentServerFlag == false)
            {
                CurrentServerFlag = true;

                btnServerConnect.Text = "Disconnect";
                S_point = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server.Bind(S_point);
                server.Listen(10);

                client = server.Accept();

                ip = (IPEndPoint)client.RemoteEndPoint;

                byte[] send_data = Encoding.Default.GetBytes("서버에 접속되었습니다.\n");
                client.Send(send_data, send_data.Length, SocketFlags.None);
                txtServerLog.AppendText($"클라이언트 {ip}가 접속되었습니다.\n");

                Thread thread1 = new Thread(ServerToClient);
                thread1.IsBackground = true;
                thread1.Start();
            }
            else if (CurrentServerFlag == true)
            {
                CurrentServerFlag = false;

                btnServerConnect.Text = "Connect";
                byte[] send_data = Encoding.Default.GetBytes("서버와의 연결이 끊어졌습니다.\n");
                server.Send(send_data, send_data.Length, SocketFlags.None);

                client.Close();
                server.Close();
            }
        }
        private void ServerToClient()
        {
            while (true)
            {
                if (client.Receive(recv_data) != 0)
                {
                    txtServerLog.AppendText(Encoding.Default.GetString(recv_data) + '\n');
                }
            }
        }
        private void btnServerSend_Click(object sender, EventArgs e)
        {

        }
    }
}
