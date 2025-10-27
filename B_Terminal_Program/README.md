## 데이터 분석기 Data Analyzer
### UI Component
```Plain Text
1. Serial & TCP/IP 선택 TabPage
  - 화면 전환 : Panel Visible 방식
2. 설정 그룹 GroupBox
- Common Component
  - TextBox : cmd
  - RichTextBox : Log
- Serial Component
  - Label : COM 표시
  - Button : Open port, Close port, Send
  - ComboBox : COM, BaudRate, Data Bits, Stop Bits, Parity 선택
- TCP/IP Component
  - TextBox : IP 주소, Port
  - Button : Connect/Disconnect, Send
```

#### Common Component Code
```C#
// ComboBox 사용법
// item 추가 1
comboBox.Items.Add("Item1");
// item 추가 2
String[] group = { "Item1", "Item2", "Item3" };
comboBox.Items.AddRange(group);
// item 제거 1
comboBox.Items.Remove("Item1");
// item 제거 2
comboBox.Items.RemoveAt(0);
// item Clear
comboBox.Items.Clear();
// item의 index와 value 가져오기
comboBox.Items[sel] == value
// List로부터 추가
List<string> itemList = new List<string> { "Item1", "Item2", "Item3" };
comboBox.DataSource = itemList;

// TextBox 사용법
// Enter Key Event
private void textBox_KeyDown(object sender, KeyEventArgs e)
{
    if (e.KeyCode == Keys.Enter)
    {
        Debug.WriteLine("Enter!");
    }
    return;
}
private void button_Click(object sender, EventArgs e)
{
    string message = string.Empty;
    message = string.Format(textBox.Text);
}
```

### SerialPort (IO.Ports)
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
### TCP/IP (Net, Net.Sockets, IO)


