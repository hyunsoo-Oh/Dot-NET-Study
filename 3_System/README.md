## WinForms 장비 제어: 시스템 프로그래밍 옵션
### Modbus : RTU (RS-485), TCP (TCP/IP)
```
┌───────────────────────────────┐
│ Application Layer             │
│  ↳ Modbus RTU / Modbus TCP    │  ← 프로토콜 정의 (주소, 함수코드, CRC)
├───────────────────────────────┤
│ Transport Layer               │
│  ↳ SerialPort / TCP Socket    │  ← 전송 매체
├───────────────────────────────┤
│ Physical Layer                │
│  ↳ RS-232 / RS-485 / Ethernet │ ← 하드웨어
└───────────────────────────────┘
```
### USB-CDC

### .NET Core vs .NET Framework
| 항목        | Framework WPF   | .NET 6/7/8 WPF |
| --------- | --------------- | -------------- |
| OS        | Windows         | Windows        |
| 성능        | 안정적             | 더 빠름           |
| 배포        | Framework 설치 필요 | 단일 exe 가능      |
| 최신 기능     | 제한적             | 지속 업데이트        |
| NuGet 생태계 | 일부 구형           | 최신 지원          |
