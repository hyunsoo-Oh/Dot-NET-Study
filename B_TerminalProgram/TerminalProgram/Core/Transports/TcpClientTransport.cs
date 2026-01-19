using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace TerminalProgram.Core.Transports
{
    /// <summary>
    /// TCP 클라이언트 통신을 담당하는 클래스
    /// 비동기 방식(Async/Await)을 사용하여 데이터 수신 루프를 실행
    /// </summary>
    public class TcpClientTransport : ITransport
    {
        private TcpClient _client;
        private NetworkStream _stream;
        private CancellationTokenSource _cts; // 비동기 작업 취소(종료)를 위한 토큰 소스
        private readonly string _ip;
        private readonly int _port;

        public TransportState State { get; private set; } = TransportState.Closed;

        public event Action<TransportState> OnStateChanged;
        public event Action<byte[]> OnDataReceived;
        public event Action<string> OnError;

        public TcpClientTransport(string ip, int port)
        {
            _ip = ip;
            _port = port;
        }

        /// <summary>
        /// 서버에 연결을 시도. 별도의 Task에서 실행되어 UI를 차단하지 않음
        /// </summary>
        public void Open()
        {
            if (State == TransportState.Open || State == TransportState.Opening) return;

            Task.Run(async () =>
            {
                try
                {
                    SetState(TransportState.Opening);
                    
                    _client = new TcpClient();
                    // 비동기 연결 시도
                    await _client.ConnectAsync(IPAddress.Parse(_ip), _port);
                    _stream = _client.GetStream();
                    
                    SetState(TransportState.Open);
                    
                    // 연결 성공 후, 수신 루프 시작
                    _cts = new CancellationTokenSource();
                    _ = ReceiveLoop(_cts.Token);
                }
                catch (Exception ex)
                {
                    OnError?.Invoke($"Connect Error: {ex.Message}");
                    Close();
                }
            });
        }

        /// <summary>
        /// 데이터를 지속적으로 읽어오는 비동기 루프
        /// </summary>
        private async Task ReceiveLoop(CancellationToken token)
        {
            byte[] buffer = new byte[4096];
            try
            {
                while (!token.IsCancellationRequested && _client != null && _client.Connected)
                {
                    // 비동기로 데이터 읽기
                    int bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length, token);
                    if (bytesRead == 0) break; // 0바이트 수신은 연결 종료를 의미

                    // 실제 읽은 만큼 배열 복사하여 전달
                    byte[] receivedData = new byte[bytesRead];
                    Array.Copy(buffer, receivedData, bytesRead);
                    OnDataReceived?.Invoke(receivedData);
                }
            }
            catch (Exception ex)
            {
                if (!token.IsCancellationRequested)
                    OnError?.Invoke($"Receive Error: {ex.Message}");
            }
            finally
            {
                Close(); // 루프 종료 시 정리
            }
        }

        public void Close()
        {
            _cts?.Cancel(); // 수신 루프 중단 요청
            _stream?.Close();
            _client?.Close();
            
            SetState(TransportState.Closed);
        }

        public async Task SendAsync(byte[] data)
        {
            if (State != TransportState.Open || _stream == null) return;

            try
            {
                await _stream.WriteAsync(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                OnError?.Invoke($"Send Error: {ex.Message}");
                Close();
            }
        }

        private void SetState(TransportState newState)
        {
            if (State != newState)
            {
                State = newState;
                OnStateChanged?.Invoke(State);
            }
        }
    }
}
