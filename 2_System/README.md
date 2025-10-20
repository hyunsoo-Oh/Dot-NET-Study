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
