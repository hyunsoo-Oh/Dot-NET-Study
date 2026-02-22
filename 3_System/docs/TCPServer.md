## TCP Server
#### 수동적으로 클라이언트의 연결 요청을 기다리는 역할
- 리스닝(Listening): 특정 IP 주소와 포트 번호에 바인딩(묶여)되어 클라이언트의 접속 요청이 들어오기를 대기
- 연결 수락(Accepting): 클라이언트의 연결 요청이 오면 이를 수락하고, 해당 클라이언트와 통신할 수 있는 새로운 소켓(Socket)을 생성
- 다중 연결 처리: 실제 서버는 여러 클라이언트의 접속을 동시에 처리
- 신뢰성 보장: TCP 프로토콜의 특성상 서버는 클라이언트로부터 데이터 패킷을 모두 받고, 올바른 순서로 재조립되었음을 보장

## 제어 방법 
### TcpClient/TcpListener & Socket 직접 제어

#### TcpClient/TcpListener 방식
```C#
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

        stream.Close();
        client.Close();
        UiLog(txtServerLog, "클라이언트와의 연결 종료\n");
    }
}
private void btnServerSend_Click(object sender, EventArgs e)
{
    byte[] msg = System.Text.Encoding.UTF8.GetBytes(txtServerCommand.Text + '\n');
    stream.Write(msg, 0, msg.Length);

    txtServerCommand.Clear();
}
private void ServerConnect()
{
    server = new TcpListener(IPAddress.Parse(txtServerIP.Text), int.Parse(txtServerPort.Text));
    server.Start();
    UiLog(txtServerLog, "클라이언트와의 연결 대기 중\n");

    client = server.AcceptTcpClient();
    UiLog(txtServerLog, "클라이언트와의 연결\n");

    stream = client.GetStream();

    while (client.Connected)
    {
        int length;
        byte[] buffer = new byte[1024];

        while ((length = stream.Read(buffer, 0, buffer.Length)) != 0)
        {
            String msg = Encoding.Default.GetString(buffer, 0, length);

            UiLog(txtServerLog, msg);
        }
    }
}
```

#### Socket 직접 제어 방식 
```C#
IPEndPoint point = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
server.Bind(point);
server.Listen(10);

byte[] buff = new byte[1024];

Socket client = server.Accept();

IPEndPoint ip = (IPEndPoint)client.RemoteEndPoint;

byte[] send_Data = Encoding.Default.GetBytes("서버에 접속되었습니다.");
client.Send(send_Data, send_Data.Length, SocketFlags.None);
txtServerLog.AppendText($"클라이언트 {ip}가 접속되었습니다.");

byte[] recv_Data = new byte[1024];
if (client.Receive(recv_Data) != 0)
{
    txtServerLog.AppendText(Encoding.Default.GetString(recv_Data));
}
client.Close();
server.Close();
```

```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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
```
