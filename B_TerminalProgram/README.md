# C# Terminal Program Template (Serial + TCP, Text + Byte[]) — 설계 README

> 목적: 현업에서 통신 파트를 “매번 새로 만들지 않기” 위해  
> **Serial / TCP(Client/Server)** 를 재사용 가능한 클래스로 묶고,  
> **byte[] 스트림 + 프레이밍 + 요청/응답 + 로깅/계측** 까지 포함한 재사용 템플릿을 만든다.

## 1) 목적 (Why)

- 실무 통신은 결국 **byte 스트림**(Serial/TCP)이며, 텍스트는 그 위의 표현(Encoding)일 뿐이다.
- 프로젝트마다 반복되는 코드:
  - 연결/재연결/오픈/클로즈/예외 처리
  - 수신 조립(메시지 경계), CRC, sequence, timeout/retry
  - 로그/덤프/통계, UI thread marshal
- 목표는 “복붙 가능한 통신 코어”:
  - **Transport(Serial/TCP)** + **Framing(패킷화)** + **Protocol(요청/응답)** 을 레이어로 고정
  - 앱/장비별 차이는 옵션/플러그인으로 흡수

## 2) 핵심 개념 (What)

### 2.1 레이어 3단 고정
1) **Transport**: 바이트 송수신 스트림 (SerialPort / Socket)
2) **Framing**: 스트림을 “패킷”으로 자르기/붙이기 (STX/ETX, LenPrefix, Line, COBS 등)
3) **Protocol**: 패킷 의미 처리 (CMD/ACK/NACK, seq, CRC, timeout, retry)

### 2.2 공통 인터페이스의 기준은 “byte[]”
- 텍스트는 `byte[] <-> string` 변환 어댑터로만 제공(옵션)
- 수신 조립은 `byte[]` 기반이 기본이며, 성능/예측가능성이 좋다.

## 3) 시스템 관점 (Architecture)

### 3.1 전체 구조

```
Transport (byte stream)
├─ SerialRawChannel (SerialPort 기반)
├─ TcpClientRawChannel (TcpClient 기반)
└─ TcpServerHost (다중 세션 관리)

Framer (stream <-> packet)
├─ LineFramer (text line; 내부는 bytes)
├─ StxEtxFramer (delimiter)
├─ LengthPrefixFramer (2/4byte length) + 길이 값이 깨질 때 resync 정책
└─ CustomFramer (프로토콜별)

Protocol (packet 의미 해석 / 요청-응답)
└─ RequestDispatcher (seq/reqId + timeout + retry + matcher)

EchoServer
└─ 하나의 PC 단에서 **loopback 테스트**를 생성
```

### 3.2 핵심 설계 포인트
- Transport는 “연결”만 책임진다. 메시지 경계는 모른다.
- Framer가 “패킷 경계”를 책임진다. (가장 중요한 분리)
- Protocol은 “ACK/응답 매칭/재시도”를 책임진다.

## 4) 실무 포인트 (Pitfalls / Trade-off)

### 4.1 byte[] 통신에서 진짜로 터지는 지점
- **TCP는 메시지 경계가 없다** → 반드시 Framing 필요
- Serial/TCP 모두 수신이 쪼개져 들어옴 → “조립 버퍼” 필수
- CRC/Checksum 미적용 시 현장 노이즈/EMI에서 디버깅 지옥
- Timeout/Retry는 장비 동작을 망가뜨릴 수 있음
  - 멱등성 없는 명령(예: “모터 start”)은 retry 정책을 다르게 해야 함

### 4.2 성능/안정성
- 수신 버퍼는 `ArrayPool<byte>` 사용 (GC 폭발 방지)
- 패킷 파싱은 `Span<byte>` 기반 (Substring/Encoding 난사 금지)
- 이벤트 콜백은 UI thread에서 처리하지 않음
  - UI는 `SynchronizationContext`/`IProgress`/Dispatcher로 별도 marshal

### 4.3 상태 모델
- `Closed -> Opening -> Open -> Closing -> Faulted`
- TCP Client는 `Reconnecting` 상태 추가 권장
- 서버는 Session별 상태/큐/백프레셔(전송 폭주 방지) 필요

## 5) 기능 범위 (Scope)

### 5.1 기본 포함
- Serial Raw Channel (byte stream)
- TCP Client Raw Channel
- TCP Server Host (multi-session)
- Framer 인터페이스 + 기본 3종:
  - LengthPrefixFramer (추천: 가장 안전/일반적)
  - StxEtxFramer
  - LineFramer(텍스트 호환)
- 공통 이벤트:
  - `OnStateChanged`, `OnPacketReceived`, `OnError`
- 로깅/덤프/통계:
  - Tx/Rx bytes, packet count, error count, reconnect count, latency(옵션)

### 5.2 선택 확장
- RequestDispatcher (reqId/seq 기반 요청-응답)
- CRC16/CRC32 모듈
- PacketRouter (prefix/cmd 기반 분기)
- Wireshark-friendly hex dump, pcap export(가능하면)

## 6) 폴더 / 네임스페이스 구조 (Simple MVC)

프로젝트의 유지보수와 재사용성을 위해 다음과 같은 계층을 권장합니다.

```text
TerminalProgram/
├── Mainform.cs
├── CommunicationSettings/ # 통신 설정
│   ├── TCPClient.cs    # TCP Client
│   ├── TCPServer.cs    # TCP Server
│   ├── SerialPort.cs   # Serial Port
├── Core/               # 통신 코어 (인터페이스, 추상 클래스)
│   ├── Transports/     # Serial, TCP Client/Server 실체 구현
│   ├── Framing/        # 패킷 조립/분해 엔진
│   └── Protocols/      # Req-Res 처리, Dispatcher
└── Shared/             # 공통 유틸리티 (Logger, ByteHelper)
```

## 8) 추천 기본 프레이밍 정책

실무에서 가장 많이 쓰이는 방식 2가지를 기본으로 포함합니다.

1.  **LengthPrefix (가장 안정적)**:
    - 구조: `[Length(2 or 4 bytes)]` + `[Payload]`
    - 장점: 중간에 데이터가 깨져도 길이만큼만 무시하면 되어 Resync가 빠름.
2.  **STX/ETX (전통적)**:
    - 구조: `0x02 (STX)` + `[Payload]` + `0x03 (ETX)`
    - 주의: Payload 내부에 0x03이 나올 경우 Escape 처리가 필요할 수 있음.

## 9) 실패/오류 처리 정책 (실무 기본값)

- **Open 실패**: 즉시 `Faulted` 상태로 전환 후 `Error` 이벤트 발생 및 재시도 대기.
- **Read/Write 예외**: 해당 세션/채널을 즉시 Close하고 통계치(Error Count) 기록.
- **TCP Client 재연결**:
  - 지수 백오프 전략 사용 (1s, 2s, 4s, 8s … max 30s).
  - 최대 연속 실패 횟수 도달 시 사용자에게 알림.
- **Packet Decode 실패**:
  - `LengthPrefix`: 비정상적인 길이(예: 64KB 초과) 수신 시 버퍼 강제 Flush.
  - `STX/ETX`: 다음 STX가 나올 때까지 기존 버퍼 드롭.

## 10) 로깅 및 계측 (Logging & Telemetry)

- **Hex Dump**: 모든 Tx/Rx raw bytes는 `debug` 레벨로 로깅.
- **Counters**: `SuccessCount`, `ErrorCount`, `TotalBytes`를 실시간 UI 업데이트.
- **Latency**: 요청 송신 시각과 응답 수신 시각을 매칭하여 `LastResponseTime` 측정.

## 11) Simple MVC 흐름도

1.  **User Interaction**: View에서 연결 버튼 클릭.
2.  **Controller**: View의 입력을 받아 `Core.Transport`를 초기화 및 `Open()`.
3.  **Core**: 데이터 수신 시 `Transport` -> `Framer` -> `Controller` 순으로 전달.
4.  **Model**: `Controller`가 수신 데이터를 해석하여 `Model` 업데이트.
5.  **View**: `Model`의 변경 사항을 화면에 반영 (Data Binding 또는 Event).

## 12) 빌드/테스트 전략 (권장)

- **Framer 단위 테스트**: 조립/분할/노이즈/부분수신 케이스 검증.
- **가상 Loopback**: Transport 테스트를 위해 `TcpClient`와 `TcpServer`를 로컬에서 연동.
- **현장 재현 테스트 벡터**:
  - **패킷 분할**: 1byte씩 쪼개서 들어오는 극한의 상황.
  - **패킷 뭉침**: 여러 패킷이 한 Buffer에 들어오는 상황.
  - **노이즈**: 중간에 유효하지 않은 바이트 삽입 시 Resync 여부.

