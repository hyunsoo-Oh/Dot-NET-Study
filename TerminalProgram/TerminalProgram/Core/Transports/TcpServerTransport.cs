using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace TerminalProgram.Core.Transports
{
    /// <summary>
    /// TCP 서버 통신을 담당하는 클래스
    /// TcpListener를 사용하여 클라이언트 연결을 대기
    /// 현재 구조는 1:1 채팅을 가정하여 하나의 클라이언트만 허용
    /// </summary>
    public class TcpServerTransport : ITransport
    {
        private TcpListener _listener;
        private TcpClient _client;
        private NetworkStream _stream;
        private CancellationTokenSource _cts;
        private readonly string _ip;
        private readonly int _port;

        public TransportState State { get; private set; } = TransportState.Closed;

        public event Action<TransportState> OnStateChanged;
        public event Action<byte[]> OnDataReceived;
        public event Action<string> OnError;

        public TcpServerTransport(string ip, int port)
        {
            _ip = ip;
            _port = port;
        }

        /// <summary>
        /// 서버 리스너를 시작하고 클라이언트 접속 대기 작업을 비동기로 수행
        /// </summary>
        public void Open()
        {
            if (State != TransportState.Closed) return;

            try
            {
                _listener = new TcpListener(IPAddress.Parse(_ip), _port);
                _listener.Start();
                SetState(TransportState.Listening); // 수신 대기 상태

                Task.Run(AcceptClientAsync);
            }
            catch (Exception ex)
            {
                OnError?.Invoke($"Start Server Error: {ex.Message}");
                Close();
            }
        }

        /// <summary>
        /// 클라이언트의 접속을 비동기적으로 기다림
        /// </summary>
        private async Task AcceptClientAsync()
        {
            try
            {
                // 하나의 클라이언트만 연결을 수락 (Simple 1:1)
                _client = await _listener.AcceptTcpClientAsync();
                _stream = _client.GetStream();
                
                SetState(TransportState.Open); // 연결 완료
                
                _cts = new CancellationTokenSource();
                _ = ReceiveLoop(_cts.Token);
            }
            catch (Exception ex)
            {
                if (State != TransportState.Closed)
                    OnError?.Invoke($"Accept Error: {ex.Message}");
            }
        }

        /// <summary>
        /// 연결된 클라이언트로부터 데이터를 읽어오는 루프
        /// </summary>
        private async Task ReceiveLoop(CancellationToken token)
        {
            byte[] buffer = new byte[4096];
            try
            {
                while (!token.IsCancellationRequested && _client != null && _client.Connected)
                {
                    int bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length, token);
                    if (bytesRead == 0) break; // 연결 종료

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
                // 클라이언트가 끊어지면
                _client?.Close();
                _client = null;
                _stream = null;
                
                // 만약 서버 자체가 닫힌게 아니라면, 다시 Listening 상태로 돌아가 재접속을 기다릴 수 있음
                if (State != TransportState.Closed)
                {
                     SetState(TransportState.Listening); 
                     _ = AcceptClientAsync(); // 다시 대기 시작
                }
            }
        }

        public void Close()
        {
            _cts?.Cancel();
            _client?.Close();
            _listener?.Stop(); // 리스너 종료
            
            SetState(TransportState.Closed);
        }

        public async Task SendAsync(byte[] data)
        {
            if (_client == null || !_client.Connected || _stream == null)
            {
                 // 연결된 클라이언트가 없을 때
                 return; 
            }

            try
            {
                await _stream.WriteAsync(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                OnError?.Invoke($"Send Error: {ex.Message}");
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
