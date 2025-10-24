## SerialPort
[SerialPort Docs](https://learn.microsoft.com/ko-kr/dotnet/api/system.io.ports.serialport?view=netframework-4.7.2)
#### 직렬 통신의 물리적 인터페이스 (RS-232 표준)
USB에 들어온 데이터를 드라이버가 SerialPort(가상 COM 포트)에 맞는 데이터로 변환하여 운영 체제와 프로그램에 전달

#### 적용 대상
**제품	버전**

.NET Framework : 2.0, 3.0, 3.5, 4.0, 4.5, 4.5.1, 4.5.2, 4.6, 4.6.1, 4.6.2, 4.7, 4.7.1, 4.7.2, 4.8, 4.8.1

cf).NET : 7.0, 8.0, 9.0 에서 사용하려면 ```dotnet add package System.IO.Ports``` 필요

### using System.IO.Ports
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
using System.IO.Ports;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCmd_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText("[Send] : " + textCmd.Text + '\n');
            textCmd.Text = string.Empty;
        }

        private void textCmd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                richTextBox1.AppendText("[Send] : " + textCmd.Text + '\n');
                textCmd.Text = string.Empty;
                e.SuppressKeyPress = true;
            }
        }

        private void toolSerial_Click(object sender, EventArgs e)
        {
            serialPanel.Visible = true;
            tcpPanel.Visible = false;
        }

        private void toolTcp_Click(object sender, EventArgs e)
        {
            serialPanel.Visible = false;
            tcpPanel.Visible = true;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort.PortName = cmbCom.Text;
                serialPort.BaudRate = int.Parse(cmbBaud.Text);
                serialPort.DataBits = int.Parse(cmbData.Text);
                serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), cmbParity.Text, true);
                serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cmbStop.Text, true);

                serialPort.Open();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            serialPort.Close();
        }
    }
}
```
