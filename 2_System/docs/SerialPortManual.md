## 핵심 기능
### 핵심 클래스(Classes)
| 클래스                            | 설명                                              | 자주 함께 쓰는 것                               |
| ------------------------------ | ----------------------------------------------- | ---------------------------------------- |
| `SerialPort`                   | 직렬 통신의 본체. 포트 열기/닫기, 읽기/쓰기, 이벤트, 제어선(DTR/RTS) 등 | `Parity`, `StopBits`, `Handshake`, 이벤트들  |
| `SerialDataReceivedEventArgs`  | `DataReceived` 이벤트 인자                           | `SerialData` (수신 원인: `Chars`, `Eof`)     |
| `SerialErrorReceivedEventArgs` | `ErrorReceived` 이벤트 인자                          | `SerialError` (프레이밍/패리티/오버런 등)           |
| `SerialPinChangedEventArgs`    | `PinChanged` 이벤트 인자                             | `SerialPinChange` (CTS/DSR/Break/Ring 등) |

### 주요 속성(Properties)
| 속성                       | 형식          | 설명                       | 예시                                        |
| ------------------------ | ----------- | ------------------------ | ----------------------------------------- |
| `PortName`               | `string`    | 포트 이름                    | `"COM3"`                                  |
| `BaudRate`               | `int`       | 보드레이트                    | `9600`, `115200`                          |
| `DataBits`               | `int`       | 데이터 비트                   | `7`, `8`                                  |
| `Parity`                 | `Parity`    | 패리티 비트                   | `Parity.None`                             |
| `StopBits`               | `StopBits`  | 스톱 비트                    | `StopBits.One`                            |
| `Handshake`              | `Handshake` | 흐름제어                     | `Handshake.None` / `Handshake.RtsXOnXOff` |
| `ReadTimeout`            | `int`       | 읽기 타임아웃(ms)              | `500`                                     |
| `WriteTimeout`           | `int`       | 쓰기 타임아웃(ms)              | `500`                                     |
| `Encoding`               | `Encoding`  | 문자열 인코딩                  | `Encoding.ASCII`, `Encoding.UTF8`         |
| `NewLine`                | `string`    | `ReadLine/WriteLine` 구분자 | `"\r\n"`, `"\n"`                          |
| `IsOpen`                 | `bool`      | 포트 오픈 여부                 | `true/false`                              |
| `BytesToRead`            | `int`       | 수신 버퍼에 남은 바이트 수          | 모니터링/폴링                                   |
| `BytesToWrite`           | `int`       | 송신 버퍼에 남은 바이트 수          | 전송 큐 확인                                   |
| `ReceivedBytesThreshold` | `int`       | `DataReceived` 발생 임계치    | 기본 `1`                                    |
| `DtrEnable`              | `bool`      | DTR 제어선                  | `true` 로 켜기                               |
| `RtsEnable`              | `bool`      | RTS 제어선                  | 하드웨어 흐름제어 시                               |
| `CDHolding`              | `bool`      | Carrier Detect 상태        | 모뎀 라인 읽기                                  |
| `CtsHolding`             | `bool`      | CTS 상태                   | 하드웨어 흐름제어                                 |
| `DsrHolding`             | `bool`      | DSR 상태                   | 장치 준비 여부                                  |
| `BaseStream`             | `Stream`    | 기본 스트림(access 하위 API)    | 고급 사용자용                                   |
| `ReadBufferSize`         | `int`       | 내부 읽기 버퍼 크기              | 필요시 조정                                    |
| `WriteBufferSize`        | `int`       | 내부 쓰기 버퍼 크기              | 필요시 조정                                    |
| `DiscardNull`            | `bool`      | `0x00` 폐기 여부             | 특수 장치 대응                                  |
| `ParityReplace`          | `byte`      | 패리티 에러 바이트 대체            | 데이터 정합성                                   |

### 주요 메서드(Methods)
| 메서드                                 | 시그니처(요약)                                        | 설명             | 비고/예시         |
| ----------------------------------- | ----------------------------------------------- | -------------- | ------------- |
| `Open()`                            | `void Open()`                                   | 포트 열기          | 속성 먼저 설정 후 호출 |
| `Close()`                           | `void Close()`                                  | 포트 닫기          | 이벤트 핸들러 해제 권장 |
| `Read`                              | `int Read(byte[] buf, int offset, int count)`   | 바이트 읽기         | 블로킹/타임아웃 영향   |
| `ReadByte()`                        | `int ReadByte()`                                | 1바이트 읽기        | -1이면 없음       |
| `ReadChar()`                        | `int ReadChar()`                                | 1문자 읽기         | 인코딩 영향        |
| `ReadExisting()`                    | `string ReadExisting()`                         | 현재 수신 버퍼의 문자열  | 빠른 덤프용        |
| `ReadLine()`                        | `string ReadLine()`                             | `NewLine`까지 읽기 | `NewLine` 필수  |
| `ReadTo()`                          | `string ReadTo(string value)`                   | 지정 구분자까지 읽기    | 프로토콜 토큰화      |
| `Write`                             | `void Write(byte[] buf, int offset, int count)` | 바이트 쓰기         | 바이너리 전송       |
| `Write`                             | `void Write(string text)`                       | 문자열 쓰기         | 인코딩 적용        |
| `WriteLine()`                       | `void WriteLine(string text)`                   | 문자열+`NewLine`  | 텍스트 프로토콜      |
| `DiscardInBuffer()`                 | `void DiscardInBuffer()`                        | 수신 버퍼 폐기       | 재동기화 용        |
| `DiscardOutBuffer()`                | `void DiscardOutBuffer()`                       | 송신 버퍼 폐기       | 취소/초기화        |
| `GetPortNames()`                    | `static string[]`                               | 사용 가능한 포트 나열   | 포트 스캔         |
| *(확장)* `BaseStream.BeginRead/Write` | `IAsyncResult …`                                | 고급 비동기 I/O     | 고급/권장 아님      |

### 이벤트(Events)
| 이벤트             | 인자                             | 설명                          | 핸들링 팁                   |
| --------------- | ------------------------------ | --------------------------- | ----------------------- |
| `DataReceived`  | `SerialDataReceivedEventArgs`  | 수신 버퍼에 데이터가 들어왔을 때          | UI 스레드 아님 → `Invoke` 사용 |
| `ErrorReceived` | `SerialErrorReceivedEventArgs` | 프레이밍/패리티/오버런/TxFull 등 오류    | 로그+복구(버퍼 폐기 등)          |
| `PinChanged`    | `SerialPinChangedEventArgs`    | CTS/DSR/CD/Break/Ring 상태 변화 | 하드웨어 흐름제어/모뎀 제어         |
