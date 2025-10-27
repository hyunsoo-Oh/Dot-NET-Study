## TCP Server
#### 수동적으로 클라이언트의 연결 요청을 기다리는 역할
- 리스닝(Listening): 특정 IP 주소와 포트 번호에 바인딩(묶여)되어 클라이언트의 접속 요청이 들어오기를 대기
- 연결 수락(Accepting): 클라이언트의 연결 요청이 오면 이를 수락하고, 해당 클라이언트와 통신할 수 있는 새로운 소켓(Socket)을 생성
- 다중 연결 처리: 실제 서버는 여러 클라이언트의 접속을 동시에 처리
- 신뢰성 보장: TCP 프로토콜의 특성상 서버는 클라이언트로부터 데이터 패킷을 모두 받고, 올바른 순서로 재조립되었음을 보장

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
