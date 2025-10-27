using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAnalyzer
{
	public partial class Form1
	{
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

				_serialPort.PortName = cmbCom.SelectedItem.ToString();
				_serialPort.BaudRate = Convert.ToInt32(cmbBaud.SelectedItem);
				_serialPort.DataBits = Convert.ToInt32(cmbData.SelectedItem);
				_serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), cmbParity.SelectedItem.ToString());
				_serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cmbStop.SelectedItem.ToString());

				// 버퍼/타임아웃 기본 설정 (필요 시 조정)
				_serialPort.ReadTimeout = 500;   // ms
				_serialPort.WriteTimeout = 500;

				_serialPort.Open();
				txtCommandLog.AppendText($"[OPEN] {_serialPort.PortName}, {_serialPort.BaudRate}bps, {_serialPort.DataBits}{_serialPort.Parity}/{_serialPort.StopBits}\n");
			}
			catch (Exception ex)
			{
				MessageBox.Show($"[ERR] 포트 열기 실패: {ex.Message}\n", "Error");
			}
		}
		private void btnClose_Click(object sender, EventArgs e)
		{
			try
			{
				if (_serialPort.IsOpen)
				{
					_serialPort.Close();
					MessageBox.Show("[CLOSE] 포트를 닫았습니다.\n", "Error");
				}
				else
				{
					MessageBox.Show("[INFO] 이미 닫혀 있습니다.\n", "Error");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"[ERR] 포트 닫기 실패: {ex.Message}\n", "Error");
			}
		}
		private void _serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
		{
			try
			{
				string data = _serialPort.ReadExisting();
				this.Invoke(new Action(() =>
				{
					txtCommandLog.AppendText(data);
				}));
			}
			catch (Exception ex)
			{
				this.Invoke(new Action(() =>
				{
					txtCommandLog.AppendText($"[ERR] 데이터 수신 실패: {ex.Message}\n");
				}));
			}
		}
		private void btnSend_Click(object sender, EventArgs e)
		{
			try
			{
				string msg = txtCommand.Text;
				_serialPort.WriteLine(msg);
				txtCommand.Clear();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"[ERR] 데이터 전송 실패: {ex.Message}\n", "Error");
			}
		}

		private void txtCommand_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				txtCommandLog.AppendText(txtCommand.Text + '\n');
				txtCommand.Clear();
				e.Handled = true;
				e.SuppressKeyPress = true;
			}
		}
	}
}
