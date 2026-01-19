using System;
using System.Threading.Tasks;

namespace TerminalProgram.Core
{
    /// <summary>
    /// 모든 통신 방식(Serial, TCP Client, TCP Server)이 구현해야 하는 공통 인터페이스
    /// </summary>
    public interface ITransport
    {
        /// <summary>현재 연결 상태</summary>
        TransportState State { get; }
        
        /// <summary>상태 변경 시 발생 (예: Closed -> Opening)</summary>
        event Action<TransportState> OnStateChanged;
        
        /// <summary>데이터 수신 시 발생</summary>
        event Action<byte[]> OnDataReceived;
        
        /// <summary>오류 발생 시 발생</summary>
        event Action<string> OnError;

        /// <summary>연결 시작 (비동기 처리는 내부에서 수행)</summary>
        void Open();
        
        /// <summary>연결 종료</summary>
        void Close();
        
        /// <summary>데이터 비동기 전송</summary>
        Task SendAsync(byte[] data);
    }
}
