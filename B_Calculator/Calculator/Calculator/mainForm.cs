using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class mainForm : Form
    {
        private Calculator calc = new Calculator();
        public mainForm()
        {
            InitializeComponent();

            // 1) 폼이 키 입력을 먼저 가로채도록
            this.KeyPreview = true;

            // 2) 폼이 실제로 화면에 표시된 뒤에 포커스를 제거하기 위해 Shown 이벤트 등록
            this.Shown += MainForm_Shown;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            // 폼이 완전히 그려진 후 실행되므로,
            // 여기서 포커스를 없애면 0 버튼에 파란 포커스가 남지 않음
            this.ActiveControl = null;
        }

        private void UpdateDisplay()
        {
            lblResult.Text = calc.displayText;
            lblProcess.Text = calc.Get_Process();
            this.ActiveControl = null;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            calc.inputDigit(0);
            UpdateDisplay();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            calc.inputDigit(1);
            UpdateDisplay();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            calc.inputDigit(2);
            UpdateDisplay();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            calc.inputDigit(3);
            UpdateDisplay();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            calc.inputDigit(4);
            UpdateDisplay();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            calc.inputDigit(5);
            UpdateDisplay();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            calc.inputDigit(6);
            UpdateDisplay();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            calc.inputDigit(7);
            UpdateDisplay();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            calc.inputDigit(8);
            UpdateDisplay();
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            calc.inputDigit(9);
            UpdateDisplay();
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            calc.CalculateResult();
            UpdateDisplay();
            this.ActiveControl = null;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            calc.SetOperator(Calculator.Operators.Add);
            UpdateDisplay();
            this.ActiveControl = null;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            calc.SetOperator(Calculator.Operators.Subtract);
            UpdateDisplay();
            this.ActiveControl = null;
        }

        private void btnMultiple_Click(object sender, EventArgs e)
        {
            calc.SetOperator(Calculator.Operators.Multiply);
            UpdateDisplay();
            this.ActiveControl = null;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            calc.SetOperator(Calculator.Operators.Divide);
            UpdateDisplay();
            this.ActiveControl = null;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            calc.ApplyPercent();
            UpdateDisplay();
            this.ActiveControl = null;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (!calc.displayText.Contains("."))
            {
                calc.displayText += ".";
                UpdateDisplay();
            }
            this.ActiveControl = null;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            calc.Backspace();
            UpdateDisplay();
            this.ActiveControl = null;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            calc.ClearAll();
            UpdateDisplay();
        }

        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            calc.ClearCE();
            UpdateDisplay();
        }

        private void mainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D0:
                case Keys.NumPad0:
                    btn0.PerformClick();
                    break;
                case Keys.D1:
                case Keys.NumPad1:
                    btn1.PerformClick();
                    break;
                case Keys.D2:
                case Keys.NumPad2:
                    btn2.PerformClick();
                    break;
                case Keys.D3:
                case Keys.NumPad3:
                    btn3.PerformClick();
                    break;
                case Keys.D4:
                case Keys.NumPad4:
                    btn4.PerformClick();
                    break;
                case Keys.D5:
                case Keys.NumPad5:
                    if (e.Shift)
                    {
                        calc.ApplyPercent();
                        e.Handled = true;    // KeyDown 기준에서 처리 완료 표시
                        UpdateDisplay();
                        break;
                    }
                    btn5.PerformClick();
                    break;
                case Keys.D6:
                case Keys.NumPad6:
                    btn6.PerformClick();
                    break;
                case Keys.D7:
                case Keys.NumPad7:
                    btn7.PerformClick();
                    break;
                case Keys.D8:
                case Keys.NumPad8:
                    btn8.PerformClick();
                    break;
                case Keys.D9:
                case Keys.NumPad9:
                    btn9.PerformClick();
                    break;
                case Keys.Add:
                case Keys.Oemplus:
                    btnPlus.PerformClick();
                    break;
                case Keys.Subtract:
                case Keys.OemMinus:
                    btnMinus.PerformClick();
                    break;
                case Keys.Multiply:
                    btnMultiple.PerformClick();
                    break;
                case Keys.Divide:
                    btnDivide.PerformClick();
                    break;
                case Keys.Return:
                    btnResult.PerformClick();
                    break;
                case Keys.Back:
                    calc.Backspace();
                    UpdateDisplay();
                    break;
                case Keys.Decimal:
                case Keys.OemPeriod:
                    if (!calc.displayText.Contains("."))
                    {
                        calc.displayText += ".";
                        UpdateDisplay();
                    }
                    break;
                default:
                    e.Handled = false;
                    e.SuppressKeyPress = false;
                    break;
            }
        }
    }
}
