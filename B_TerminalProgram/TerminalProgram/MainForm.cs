using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TerminalProgram
{
    public partial class MainForm : Form
    {
        private TerminalController _controller;

        public MainForm()
        {
            InitializeComponent();

            // 컨트롤러 생성 (통신 중재자)
            _controller = new TerminalController();
            
            // 컨트롤러 이벤트 연결 (로그 및 데이터 수신 처리)
            _controller.OnMessageLogged += (msg) => UiLog(GetCurrentLogBox(), msg + Environment.NewLine);
            _controller.OnPacketReceived += (data) => 
            {
                // 패널에 따라 인코딩 결정 (Serial은 ASCII, TCP는 Default -> 상황에 맞게 변경 가능)
                Encoding encoding = Encoding.Default;
                RichTextBox targetBox = GetCurrentLogBox();
                if (targetBox == txtCommandLog) encoding = Encoding.ASCII;

                string msg = encoding.GetString(data);
                UiLog(targetBox, msg);
            };
            _controller.OnStatusUpdated += () => 
            {
                // 상태 변경 시 UI 업데이트 (필요 시 구현)
            };

            // 초기 전송 방식 설정 (Serial Port 기본)
            // _serialPort 객체는 Designer에서 생성됨
            var transport = new TerminalProgram.Core.Transports.SerialTransport(_serialPort);
            _controller.Initialize(transport, null); // 프레이머 미사용 (일단 null)

            // 콤보 박스 초기값 설정
            cmbCom.SelectedIndex = 0;
            cmbBaud.SelectedItem = "9600";
            cmbData.SelectedItem = "8";
            cmbParity.SelectedItem = "None";
            cmbStop.SelectedItem = "1";
        }

        // 현재 활성화된 패널에 맞는 로그 텍스트박스를 반환하는 헬퍼 메서드
        private RichTextBox GetCurrentLogBox()
        {
            if (panelSerial.Visible) return txtCommandLog;
            if (panelTCPServer.Visible) return txtServerLog;
            if (panelTCPClient.Visible) return txtClientLog;
            return txtCommandLog;
        }

        IPEndPoint serverIP;
        IPEndPoint clientIP;
        IPEndPoint ip;

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = "Terminal - Serial";
        }

        // --- Tab Control Page 변경 이벤트: 모드 전환 ---
        private void tabControl_Transport_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 현재 선택된 탭에 따라 창 제목(Title) 업데이트입니다.
            switch (tabControl_Transport.SelectedIndex)
            {
                case 0:
                    this.Text = "Terminal - Serial";
                    break;
                case 1:
                    this.Text = "Terminal - TCP/IP Server";
                    break;
                case 2:
                    this.Text = "Terminal - TCP/IP Client";
                    break;
            }
        }

        // 스레드 안전(Thread-Safe)한 로그 출력 메서드
        private void UiLog(RichTextBox box, string msg)
        {
            if (box.InvokeRequired)
            {
                box.Invoke(new Action<RichTextBox, string>(UiLog), box, msg);
            }
            else
            {
                box.AppendText(msg);
            }
        }

        // ======== SerialPort (시리얼 포트 제어) =========//
        
        // 포트 열기 버튼
        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (_serialPort.IsOpen)
                {
                    MessageBox.Show("[INFO] 이미 포트가 열려 있습니다.\n", "Error");
                    return;
                }

                if (cmbCom.SelectedItem == null) { MessageBox.Show("[ERR] COM 포트를 선택하세요.\n", "Error"); return; }
                if (cmbBaud.SelectedItem == null) { MessageBox.Show("[ERR] BaudRate를 선택하세요.\n", "Error"); return; }
                if (cmbData.SelectedItem == null) { MessageBox.Show("[ERR] DataBits를 선택하세요.\n", "Error"); return; }
                if (cmbParity.SelectedItem == null) { MessageBox.Show("[ERR] Parity를 선택하세요.\n", "Error"); return; }
                if (cmbStop.SelectedItem == null) { MessageBox.Show("[ERR] StopBits를 선택하세요.\n", "Error"); return; }

                // 포트 설정 적용
                _serialPort.PortName = cmbCom.SelectedItem.ToString();
                _serialPort.BaudRate = Convert.ToInt32(cmbBaud.SelectedItem);
                _serialPort.DataBits = Convert.ToInt32(cmbData.SelectedItem);
                _serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), cmbParity.SelectedItem.ToString());
                _serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cmbStop.SelectedItem.ToString());

                // SerialTransport 생성 및 컨트롤러에 주입 후 연결 시도
                var transport = new TerminalProgram.Core.Transports.SerialTransport(_serialPort);
                _controller.Initialize(transport, null);
                _controller.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERR] 포트 열기 실패: {ex.Message}\n", "Error");
            }
        }

        // 포트 닫기 버튼
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERR] 포트 닫기 실패: {ex.Message}\n", "Error");
            }
        }

        // 데이터 전송 버튼 (Serial)
        private async void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = txtCommand.Text;
                await _controller.SendTextAsync(msg + "\n");
                txtCommand.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERR] 데이터 전송 실패: {ex.Message}\n", "Error");
            }
        }

        private async void txtCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    // 엔터 입력 시 실제 데이터 전송 로직 추가  
                    string msg = txtCommand.Text;
                    await _controller.SendTextAsync(msg + "\n");
                    txtCommand.Clear();
                    
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"[ERR] 데이터 전송 실패: {ex.Message}\n", "Error");
                }
            }
        }

        // ======== TCP Client (클라이언트 제어) =========//
        Boolean CurrentClientFlag = false;
        
        // 연결/해제 버튼 (Toggle 방식)
        private void btnClientConnect_Click(object sender, EventArgs e)
        {
            if (CurrentClientFlag == false)
            {
                // 연결 시도
                CurrentClientFlag = true;
                btnClientConnect.Text = "Disconnect";

                var transport = new TerminalProgram.Core.Transports.TcpClientTransport(txtClientIP.Text, int.Parse(txtClientPort.Text));
                _controller.Initialize(transport, null);
                _controller.Open();
            }
            else if (CurrentClientFlag == true)
            {
                // 연결 종료
                CurrentClientFlag = false;
                btnClientConnect.Text = "Connect";

                _controller.Close();
            }
        }

        // 데이터 전송 버튼 (Client)
        private async void btnClientSend_Click(object sender, EventArgs e)
        {
            await _controller.SendTextAsync("[Client] " + txtClientCommand.Text + Environment.NewLine);
            txtClientCommand.Clear();
        }

        private async void txtClientCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;  // 엔터키 소리 방지입니다.

                // 비동기 데이터 송신 (await 사용 시 예외 처리 권장)입니다.
                try
                {
                    await _controller.SendTextAsync("[Client] " + txtClientCommand.Text + Environment.NewLine);
                    txtClientCommand.Clear(); // txtServerCommand에서 오타 수정입니다.
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"[ERR] 데이터 전송 실패: {ex.Message}\n", "Error");
                }
            }
        }

        // ======== TCP Server (서버 제어) =========//
        Boolean CurrentServerFlag = false;

        // 서버 시작/중지 버튼 (Toggle 방식)
        private void btnServerConnect_Click(object sender, EventArgs e)
        {
            if (CurrentServerFlag == false)
            {
                // 서버 시작
                CurrentServerFlag = true;
                btnServerConnect.Text = "Disconnect";

                var transport = new TerminalProgram.Core.Transports.TcpServerTransport(txtServerIP.Text, int.Parse(txtServerPort.Text));
                _controller.Initialize(transport, null);
                _controller.Open();
            }
            else if (CurrentServerFlag == true)
            {
                // 서버 중지
                CurrentServerFlag = false;
                btnServerConnect.Text = "Connect";

                _controller.Close();
                UiLog(txtServerLog, "서버 종료\n");
            }
        }

        // 데이터 전송 버튼 (Server -> Client)
        private async void btnServerSend_Click(object sender, EventArgs e)
        {
            await _controller.SendTextAsync("[Server] " + txtServerCommand.Text + Environment.NewLine);
            txtServerCommand.Clear();
        }
        // 데이터 전송 버튼 (Server -> Client)
        private async void txtServerCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;  // 엔터키 소리 방지

                // 비동기 데이터 송신 (await 사용 시 예외 처리 권장)
                try
                {
                    await _controller.SendTextAsync("[Server] " + txtServerCommand.Text + Environment.NewLine);
                    txtServerCommand.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"[ERR] 데이터 전송 실패: {ex.Message}\n", "Error");
                }
            }
        }
    }
}
