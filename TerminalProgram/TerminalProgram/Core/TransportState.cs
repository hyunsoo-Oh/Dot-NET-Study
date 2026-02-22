namespace TerminalProgram.Core
{
    /// <summary>
    /// 전송(Transport) 계층의 연결 상태를 정의하는 열거형
    /// </summary>
    public enum TransportState
    {
        /// <summary>닫힘 (초기 상태)</summary>
        Closed,
        /// <summary>연결 시도 중</summary>
        Opening,
        /// <summary>수신 대기 중 (서버)</summary>
        Listening,
        /// <summary>연결됨 (데이터 송수신 가능)</summary>
        Open,
        /// <summary>연결 끊김 (오류 발생 등)</summary>
        Broken,
        /// <summary>알 수 없음</summary>
        Unknown
    }
}
