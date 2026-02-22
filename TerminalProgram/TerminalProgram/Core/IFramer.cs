using System.Collections.Generic;

namespace TerminalProgram.Core
{
    /// <summary>
    /// 데이터 패킷의 프레이밍(Framing)을 담당하는 인터페이스
    /// (예: STX/ETX, 길이 기반, 고정 길이 등)
    /// </summary>
    public interface IFramer
    {
        /// <summary>
        /// 원본 데이터를 전송 가능한 패킷 형태로 포장 (예: 앞뒤에 STX, ETX 추가)
        /// </summary>
        byte[] Pack(byte[] data);

        /// <summary>
        /// 수신된 스트림 데이터에서 완성된 패킷들을 추출
        /// </summary>
        IEnumerable<byte[]> Unpack(byte[] data);
    }
}
