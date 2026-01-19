using System;
using System.IO.Ports;
using System.Threading.Tasks;

namespace TerminalProgram.Core.Transports
{
    /// <summary>
    /// 시리얼 포트 통신을 담당하는 클래스
    /// System.IO.Ports.SerialPort를 래핑하여 ITransport 인터페이스를 구현
    /// </summary>
    public class SerialTransport : ITransport
    {
        private SerialPort _serialPort;

        // 현재 연결 상태를 나타냄
        public TransportState State { get; private set; } = TransportState.Closed;

        // 상태 변경, 데이터 수신, 에러 발생 시 발생하는 이벤트들
        public event Action<TransportState> OnStateChanged;
        public event Action<byte[]> OnDataReceived;
        public event Action<string> OnError;

        /// <summary>
        /// 생성자에서 사용할 SerialPort 객체를 주입
        /// </summary>
        /// <param name="serialPort">설정이 완료된 SerialPort 객체</param>
        public SerialTransport(SerialPort serialPort)
        {
            _serialPort = serialPort;
            // 시리얼 포트의 이벤트를 구독하여 데이터를 처리
            _serialPort.DataReceived += SerialPort_DataReceived;
            _serialPort.ErrorReceived += SerialPort_ErrorReceived;
        }

        /// <summary>
        /// 시리얼 포트에서 데이터가 수신되었을 때 호출
        /// </summary>
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (!_serialPort.IsOpen) return;
                
                // 수신된 바이트 수만큼 버퍼를 만들고 데이터를 읽기
                int bytesToRead = _serialPort.BytesToRead;
                byte[] buffer = new byte[bytesToRead];
                _serialPort.Read(buffer, 0, bytesToRead);
                
                // 데이터를 구독자(Controller)에게 전달
                OnDataReceived?.Invoke(buffer);
            }
            catch (Exception ex)
            {
                OnError?.Invoke($"Read Error: {ex.Message}");
            }
        }

        private void SerialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            OnError?.Invoke($"Serial Error: {e.EventType}");
        }

        /// <summary>
        /// 포트를 열기 (이미 열려있다면 에러를 발생시키지 않고 로그만 남김)
        /// </summary>
        public void Open()
        {
            try
            {
                if (_serialPort.IsOpen)
                {
                   OnError?.Invoke("Port is already open.");
                   return;
                }

                SetState(TransportState.Opening);
                _serialPort.Open();
                SetState(TransportState.Open);
            }
            catch (Exception ex)
            {
                SetState(TransportState.Closed);
                OnError?.Invoke($"Open Error: {ex.Message}");
                throw; // 호출자가 예외를 알 수 있도록 다시 던짐
            }
        }

        /// <summary>
        /// 포트를 닫기 (이벤트 구독도 해제하여 중복 구독을 방지)
        /// </summary>
        public void Close()
        {
            try
            {
                // SerialPort 객체가 재사용될 수 있으므로, 이벤트를 해제
                _serialPort.DataReceived -= SerialPort_DataReceived;
                _serialPort.ErrorReceived -= SerialPort_ErrorReceived;

                if (_serialPort.IsOpen)
                {
                    _serialPort.Close();
                }
                SetState(TransportState.Closed);
            }
            catch (Exception ex)
            {
                OnError?.Invoke($"Close Error: {ex.Message}");
            }
        }

        /// <summary>
        /// 데이터를 비동기적으로 전송 (SerialPort.Write는 동기 메서드이나 인터페이스 규격을 맞춤)
        /// </summary>
        public async Task SendAsync(byte[] data)
        {
             if (!_serialPort.IsOpen)
            {
                OnError?.Invoke("Cannot send: Port is not open.");
                return;
            }

            try
            {
                _serialPort.Write(data, 0, data.Length);
                await Task.CompletedTask; // SerialPort.Write는 동기식이므로 완료된 Task 반환
            }
            catch (Exception ex)
            {
                OnError?.Invoke($"Send Error: {ex.Message}");
                SetState(TransportState.Broken);
            }
        }

        // 상태를 변경하고 이벤트를 알리는 헬퍼 메서드
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
