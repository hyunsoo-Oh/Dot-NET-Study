## TCP Client
#### 능동적으로 서버에 연결을 요청하는 역할
- 연결 시도(Connecting): 통신을 시작하기 위해 접속하고자 하는 서버의 IP 주소와 포트 번호 체크
- 데이터 송수신: 연결이 성공적으로 이루어지면 서버와 마찬가지로 데이터를 송수신할 수 있는 상태
- 세션 종료: 클라이언트의 역할이 끝나면 연결을 끊어 자원을 해제
- 단방향 통신: 클라이언트는 서버에 요청을 보내고, 서버는 해당 요청에 대한 응답

```C#
private void btnClientConnect_Click(object sender, EventArgs e)
{
    IPEndPoint point = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
    Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

    client.Connect(point);

    byte[] recv_buff = new byte[1024];
    client.Receive(recv_buff);
    txtClientLog.AppendText(Encoding.Default.GetString(recv_buff));

    client.Send(Encoding.Default.GetBytes("안녕하세요"));

    client.Close();
}
```

```C#
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

       client.Receive(recv_buff);
       txtClientLog.AppendText(Encoding.Default.GetString(recv_buff) + '\n');
   }
   else if (CurrentClientFlag == true)
   {
       CurrentClientFlag = false;

       client.Close();
       btnClientConnect.Text = "Connect";
   }
}

private void btnClientSend_Click(object sender, EventArgs e)
{
    client.Send(Encoding.Default.GetBytes(txtClientCommand.Text + '\n'));
}   
```
