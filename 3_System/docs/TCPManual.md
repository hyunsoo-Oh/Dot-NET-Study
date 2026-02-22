## 핵심 기능
### 데이터 수신
| 메서드                                          | 데이터 단위  | 반환/출력                    | 개행 처리                                | 인코딩 사용                       | 블로킹/타임아웃          | 버퍼 소비     | 대표 용도               | 주의/함정                          |
| -------------------------------------------- | ------- | ------------------------ | ------------------------------------ | ---------------------------- | ----------------- | --------- | ------------------- | ------------------------------ |
| `Read(byte[] buffer, int offset, int count)` | **바이트** | `int`(읽은 바이트 수)          | 없음                                   | **아니오**                      | 타임아웃까지 블로킹        | 읽은 만큼 소비  | 바이너리 프로토콜, 길이/헤더 기반 | 패킷 경계 직접 처리 필요                 |
| `Read(char[] buffer, int offset, int count)` | **문자**  | `int`(읽은 문자 수)           | 없음                                   | **예**(`SerialPort.Encoding`) | 타임아웃까지 블로킹        | 읽은 만큼 소비  | 문자 스트림을 고정 길이로 읽기   | 멀티바이트 인코딩에서 경계 주의              |
| `ReadExisting()`                             | **문자**  | `string`(버퍼에 “지금 있는” 전부) | 없음                                   | **예**                        | **비블로킹**(즉시)      | 전부 소비     | 간단 로깅/디버깅, UI 즉시 표시 | 끊긴 프레임/부분 문자열 위험               |
| `ReadLine()`                                 | **문자**  | `string`(개행 앞까지)         | **예**(`NewLine` 기준으로 잘라서 반환, 개행은 소비) | **예**                        | 개행 or 타임아웃까지 블로킹  | 라인+개행 소비  | 텍스트 기반 명령/응답        | 송신측 개행 미일치 시 영원 대기 가능          |
| `ReadTo(string value)`                       | **문자**  | `string`(구분자 앞까지)        | **예**(지정 구분자까지 읽고 구분자는 소비)           | **예**                        | 구분자 or 타임아웃까지 블로킹 | 구분자 포함 소비 | 특정 토큰/테일마커 기반 프로토콜  | 구분자 누락 시 타임아웃                  |
| `BaseStream.Read(...)`                       | **바이트** | `int`                    | 없음                                   | 아니오                          | 타임아웃까지 블로킹        | 읽은 만큼 소비  | **저수준 제어**, 대용량/고성능 | 스트림 사용 패턴 필요                   |
| `BaseStream.ReadAsync(...)` *(플랫폼/버전별)*      | **바이트** | `Task<int>`              | 없음                                   | 아니오                          | **비동기**           | 읽은 만큼 소비  | WinForms UI 프리징 방지  | .NET 버전에 따라 가용성 차이 **확실하지 않음** |

### 데이터 송신
| 메서드                                                    | 데이터 단위  | 개행 처리                   | 인코딩 사용            | 동작 특성                      | 버퍼/플러시            | 대표 용도                  | 주의/함정                        |
| ------------------------------------------------------ | ------- | ----------------------- | ----------------- | -------------------------- | ----------------- | ---------------------- | ---------------------------- |
| `Write(byte[] buffer, int offset, int count)`          | **바이트** | 없음                      | **아니오**           | **블로킹** (`WriteTimeout`까지) | 드라이버 TX 버퍼로 밀어 넣음 | 바이너리 프레임, 헤더/길이/CRC 전송 | 인코딩 개입 無 → 바이너리에 안전          |
| `Write(char[] buffer, int offset, int count)`          | **문자**  | 없음                      | **예**(`Encoding`) | 블로킹                        | TX 버퍼             | 텍스트를 고정 길이로 전송         | 멀티바이트 경계에 주의                 |
| `Write(string text)`                                   | **문자열** | 없음                      | **예**             | 블로킹                        | TX 버퍼             | 텍스트 명령(개행 없이)          | 수신측이 `ReadLine()`이면 개행 누락 주의 |
| `WriteLine(string text)`                               | **문자열** | **예**(`NewLine` 자동 덧붙임) | **예**             | 블로킹                        | TX 버퍼             | 라인 기반 프로토콜(명령/응답)      | 송수신 `NewLine` 불일치 시 파싱 실패    |
| `BaseStream.Write(byte[] b, int off, int cnt)`         | **바이트** | 없음                      | 아니오               | 블로킹(스트림 레벨)                | 스트림 버퍼→드라이버       | 저수준/고성능 전송             | 스트림 패턴 이해 필요                 |
| `BaseStream.WriteAsync(byte[] b, int off, int cnt, …)` | **바이트** | 없음                      | 아니오               | **비동기**(`await`)           | 스트림 버퍼→드라이버       | UI 프리징 없이 연속 전송        | .NET 버전/플랫폼 가용성 **확실하지 않음**  |
| `DiscardOutBuffer()`                                   | (버퍼 제어) | 해당 없음                   | 해당 없음             | 즉시                         | **TX 버퍼 비우기**     | 오류 복구·취소               | 전송 중 데이터 유실에 유의              |
| `NewLine`(속성)                                          | (설정)    | `WriteLine`의 개행 문자열     | 인코딩과 무관           | –                          | –                 | 프로토콜 합의(예: `\r\n`)     | 송수신 측 값 **반드시 일치** 권장        |
| `Encoding`(속성)                                         | (설정)    | 문자→바이트 변환 방식            | –                 | –                          | –                 | UTF8/ASCII 등 지정        | 바이너리는 **Encoding 경로 사용 금지**  |


### 핵심 클래스(Classes)
| 클래스             | 용도                        | 함께 쓰는 것                                                   |
| --------------- | ------------------------- | --------------------------------------------------------- |
| `TcpClient`     | TCP 클라이언트(접속/송수신)         | `NetworkStream`, `IPAddress`, `IPEndPoint`, `Dns`         |
| `TcpListener`   | TCP 서버(수신 대기/Accept)      | `TcpClient`, `IPAddress`, `IPEndPoint`                    |
| `Socket`        | 저수준 소켓(TCP/UDP/RAW)       | `AddressFamily`, `SocketType`, `ProtocolType`             |
| `NetworkStream` | TCP 스트림(바이너리/텍스트 I/O)     | `StreamReader/Writer`, `BinaryReader/Writer`, `SslStream` |
| `UdpClient`     | UDP 송수신(바운드/브로드캐스트/멀티캐스트) | `IPEndPoint`, `IPAddress`                                 |
| `IPAddress`     | IP 주소 표현                  | `Parse`, `TryParse`, `Loopback`, `Any`                    |
| `IPEndPoint`    | (IP, Port) 엔드포인트          | 서버/클라 바인딩                                                 |
| `Dns`           | 호스트명↔IP 조회                | `GetHostEntry`, `GetHostAddresses`                        |
| `SslStream`     | TLS 암호화 스트림(선택)           | `AuthenticateAsClient/Server`                             |

## TCP 클라이언트 (TcpClient)
### 주요 속성(Properties)
| 속성               | 형식             | 설명              | 예시                          |
| ---------------- | -------------- | --------------- | --------------------------- |
| `Client`         | `Socket`       | 내부 소켓 접근(고급)    | 옵션/타임아웃 세팅                  |
| `Connected`      | `bool`         | 접속 여부           | `true/false`                |
| `ReceiveTimeout` | `int`          | 수신 타임아웃(ms)     | `5000`                      |
| `SendTimeout`    | `int`          | 송신 타임아웃(ms)     | `5000`                      |
| `LingerState`    | `LingerOption` | 종료 시 잔여 데이터 처리  | `new LingerOption(true, 2)` |
| `NoDelay`        | `bool`         | Nagle 끔(지연 최소화) | `true`                      |

### 주요 메서드(Methods)
| 메서드            | 시그니처(요약)                             | 설명                | 비고              |
| -------------- | ------------------------------------ | ----------------- | --------------- |
| `Connect`      | `void Connect(string host,int port)` | 동기 접속             | 실패 시 예외         |
| `ConnectAsync` | `Task ConnectAsync(host,port)`       | 비동기 접속(.NET 4.5+) | GUI 응답성 유지      |
| `GetStream()`  | `NetworkStream`                      | 송수신 스트림           | `Read/Write` 사용 |
| `Close()`      | `void`                               | 연결 종료             | `Dispose()` 포함  |

### TCP 서버 (TcpListener)
| 멤버                       | 시그니처(요약)                                  | 설명                | 비고                 |
| ------------------------ | ----------------------------------------- | ----------------- | ------------------ |
| 생성자                      | `TcpListener(IPAddress address,int port)` | 수신 대기 소켓          | `IPAddress.Any` 권장 |
| `Start()`                | `void`                                    | 수신 시작             | 대기열 생성             |
| `Stop()`                 | `void`                                    | 수신 중지             | 포트 해제              |
| `AcceptTcpClient()`      | `TcpClient`                               | 동기 연결 수락          | 블로킹                |
| `AcceptTcpClientAsync()` | `Task<TcpClient>`                         | 비동기 수락(.NET 4.5+) | 권장                 |

## 저수준 소켓 (Socket)
### 생성/기본
| 항목      | 값                                                                             |
| ------- | ----------------------------------------------------------------------------- |
| 생성자     | `new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)` |
| 바인드/리스닝 | `Bind(IPEndPoint)`, `Listen(backlog)`, `Accept()`                             |
| 접속      | `Connect(EndPoint)`, `BeginConnect/EndConnect`(구비동기)                          |

### 대표 속성/옵션
| 항목                           | 타입/값                                   | 설명                             |
| ---------------------------- | -------------------------------------- | ------------------------------ |
| `ReceiveTimeout/SendTimeout` | `int(ms)`                              | 블로킹 I/O 타임아웃                   |
| `Blocking`                   | `bool`                                 | 블로킹 모드 on/off                  |
| `SetSocketOption`            | `SocketOptionLevel`,`SocketOptionName` | 예: `ReuseAddress`, `KeepAlive` |
| `NoDelay`                    | `bool`                                 | Nagle 끔                        |

### 메서드
| 메서드                                            | 설명                |
| ---------------------------------------------- | ----------------- |
| `Send(byte[], ...)` / `Receive(byte[], ...)`   | 동기 송수신            |
| `BeginSend/EndSend`, `BeginReceive/EndReceive` | 구비동기 패턴(.NET 4.x) |
| `SendAsync/ReceiveAsync(SocketAsyncEventArgs)` | 고성능 비동기           |

## UDP (UdpClient)
| 멤버                   | 시그니처(요약)                                          | 설명        | 비고                       |
| -------------------- | ------------------------------------------------- | --------- | ------------------------ |
| 생성자                  | `UdpClient()` / `UdpClient(int port)`             | 비연결 UDP   | 바인딩 포트 선택                |
| `Send`               | `int Send(byte[] d,int len,string host,int port)` | 전송        | 대상 지정                    |
| `Receive`            | `byte[] Receive(ref IPEndPoint remoteEP)`         | 수신(블로킹)   | 발신자 EP 제공                |
| `JoinMulticastGroup` | `void`                                            | 멀티캐스트 가입  | TTL/IF 지정 가능             |
| `EnableBroadcast`    | `bool`                                            | 브로드캐스트 허용 | `true` 시 255.255.255.255 |

## NetworkStream / Stream 계열
| 멤버                     | 시그니처(요약)                                                   | 설명                 |
| ---------------------- | ---------------------------------------------------------- | ------------------ |
| `Read/Write`           | `int Read(byte[] buf,int off,int cnt)` / `void Write(...)` | 바이트 I/O            |
| `ReadAsync/WriteAsync` | `Task<int>` / `Task`                                       | 비동기 I/O(.NET 4.5+) |
| `DataAvailable`        | `bool`                                                     | 읽을 데이터 존재 여부       |
| `Flush()`              | `void`                                                     | 버퍼 비움(상황 제한)       |
| `CanRead/CanWrite`     | `bool`                                                     | 접근 가능성             |
