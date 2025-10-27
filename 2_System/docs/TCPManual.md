## 핵심 기능
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
