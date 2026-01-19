using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TerminalProgram.Core;

namespace TerminalProgram
{
    /// <summary>
    /// Model(상태)과 Controller(로직)가 통합된 클래스
    /// UI와 실제 통신(Transport) 사이의 중재자 역할을 수행
    /// </summary>
    public class TerminalController
    {
        // --- Model 역할: 상태 관리 ---
        
        /// <summary>현재 통신 상태 (Closed, Open 등)</summary>
        public TransportState State { get; private set; } = TransportState.Closed;
        
        /// <summary>총 수신 바이트 수</summary>
        public long TotalReceivedBytes { get; private set; } = 0;
        
        /// <summary>총 송신 바이트 수</summary>
        public long TotalSentBytes { get; private set; } = 0;
        
        /// <summary>발생한 오류 횟수</summary>
        public int ErrorCount { get; private set; } = 0;

        // --- Controller 역할: 로직 및 통신 관리 ---
        private ITransport _transport;
        private IFramer _framer;

        // UI 업데이트를 위한 이벤트 정의

        /// <summary>로그 메시지 발생 시 호출 (UI 로그창 출력용)</summary>
        public event Action<string> OnMessageLogged;
        
        /// <summary>데이터 패킷 수신 시 호출</summary>
        public event Action<byte[]> OnPacketReceived;
        
        /// <summary>상태값(State, 통계 등) 변경 시 호출 (UI 갱신용)</summary>
        public event Action OnStatusUpdated;

        /// <summary>
        /// 사용할 전송 방식(Transport)과 프레이머(Framer)를 초기화하고 이벤트를 연결
        /// </summary>
        /// <param name="transport">사용할 통신 객체 (Serial, TCP 등)</param>
        /// <param name="framer">데이터 패킷 처리를 위한 프레이머 (없으면 null)</param>
        public void Initialize(ITransport transport, IFramer framer)
        {
            // 이전에 연결된 전송 객체가 있다면 닫아서 정리
            _transport?.Close();

            _transport = transport;
            _framer = framer;

            // Transport 상태 변경 이벤트 구독
            _transport.OnStateChanged += (state) => 
            {
                State = state;
                OnMessageLogged?.Invoke($"[STATE] {state}");
                OnStatusUpdated?.Invoke();
            };

            // 데이터 수신 이벤트 구독
            _transport.OnDataReceived += (data) =>
            {
                TotalReceivedBytes += data.Length;
                
                // 프레이머가 설정되어 있다면 패킷 단위로 잘라서 처리
                if (_framer != null)
                {
                    foreach (var packet in _framer.Unpack(data))
                    {
                        OnPacketReceived?.Invoke(packet);
                    }
                }
                else
                {
                    // 프레이머가 없으면 받은 데이터 그대로 전달
                    OnPacketReceived?.Invoke(data);
                }
                OnStatusUpdated?.Invoke();
            };

            // 에러 발생 이벤트 구독
            _transport.OnError += (error) =>
            {
                ErrorCount++;
                OnMessageLogged?.Invoke($"[ERR] {error}");
                OnStatusUpdated?.Invoke();
            };
        }

        /// <summary>
        /// 설정된 전송 방식(Transport)을 엶
        /// </summary>
        public void Open()
        {
            try
            {
                _transport?.Open();
            }
            catch (Exception ex)
            {
                OnMessageLogged?.Invoke($"[EXCEPTION] Open 실패: {ex.Message}");
            }
        }

        /// <summary>
        /// 전송 방식(Transport)을 닫음
        /// </summary>
        public void Close()
        {
            _transport?.Close();
        }

        /// <summary>
        /// 데이터를 프레이밍하여 전송
        /// </summary>
        public async Task SendAsync(byte[] data)
        {
            if (_transport == null || State != TransportState.Open) return;

            // 프레이머가 있다면 데이터를 감싸서(Pack) 전송, 없다면 그대로 전송
            byte[] packet = _framer != null ? _framer.Pack(data) : data;
            await _transport.SendAsync(packet);
            
            TotalSentBytes += packet.Length;
            OnStatusUpdated?.Invoke();
        }

        /// <summary>
        /// 문자열을 바이트로 변환하여 전송 (편의 메서드)
        /// </summary>
        public async Task SendTextAsync(string text, Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.UTF8;
            byte[] data = encoding.GetBytes(text);
            await SendAsync(data);
        }
    }
}
