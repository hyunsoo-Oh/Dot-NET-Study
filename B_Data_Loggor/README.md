## 데이터 분석기 Data Analyzer
### UI Component
```Plain Text
1. Serial & TCP/IP 선택 TabPage
2. 설정 그룹 GroupBox
- Serial Component
  - COM 표시 : Label.Text = COM
  - COM 선택 : TextBox.Text
  - BaudRate, Data Bits, Stop Bits, Parity 선택 : ComboBox.
  - Open port, Close port : btnPort
- TCP/IP Component
  - IP 주소 : textBox
  - Port : textBox
  - Server/Client : RadioBox
  - Connect : Button
  - Log : RichTextBox
  - cmd : textBox
  - Send : Button
```

#### SerialPort (IO.Ports)
```C# 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;  //시리얼통신을 위해 추가

private void Form1_Load(object sender, EventArgs e)
{
    cmbPort.DataSource = SerialPort.GetPortNames();  // 연결 가능한 COM 가져오기
}
```
#### TCP/IP (Net, Net.Sockets, IO)
