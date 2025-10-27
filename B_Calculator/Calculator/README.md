```C#
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        enum Operators
        {
            None, Add, Subtract, Multiply, Divide, Result
        }

        Operators CurrentOperator = Operators.None;
        Boolean OperatorFlag = false;
        int firstOperand = 0;
        int secondOperand = 0;

        private void btn0_Click(object sender, EventArgs e)
        {
            if (OperatorFlag == true)
            {
                OperatorFlag = false;
                lblResult.Text = "0";
            }
            string strNumber = lblResult.Text += "0";
            int number = Int32.Parse(strNumber);
            lblResult.Text = number.ToString();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (OperatorFlag == true)
            {
                OperatorFlag = false;
                lblResult.Text = "0";
            }
            string strNumber = lblResult.Text += "1";
            int number = Int32.Parse(strNumber);
            lblResult.Text = number.ToString();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (OperatorFlag == true)
            {
                OperatorFlag = false;
                lblResult.Text = "0";
            }
            string strNumber = lblResult.Text += "2";
            int number = Int32.Parse(strNumber);
            lblResult.Text = number.ToString();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (OperatorFlag == true)
            {
                OperatorFlag = false;
                lblResult.Text = "0";
            }
            string strNumber = lblResult.Text += "3";
            int number = Int32.Parse(strNumber);
            lblResult.Text = number.ToString();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (OperatorFlag == true)
            {
                OperatorFlag = false;
                lblResult.Text = "0";
            }
            string strNumber = lblResult.Text += "4";
            int number = Int32.Parse(strNumber);
            lblResult.Text = number.ToString();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (OperatorFlag == true)
            {
                OperatorFlag = false;
                lblResult.Text = "0";
            }
            string strNumber = lblResult.Text += "5";
            int number = Int32.Parse(strNumber);
            lblResult.Text = number.ToString();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (OperatorFlag == true)
            {
                OperatorFlag = false;
                lblResult.Text = "0";
            }
            string strNumber = lblResult.Text += "6";
            int number = Int32.Parse(strNumber);
            lblResult.Text = number.ToString();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (OperatorFlag == true)
            {
                OperatorFlag = false;
                lblResult.Text = "0";
            }
            string strNumber = lblResult.Text += "7";
            int number = Int32.Parse(strNumber);
            lblResult.Text = number.ToString();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (OperatorFlag == true)
            {
                OperatorFlag = false;
                lblResult.Text = "0";
            }
            string strNumber = lblResult.Text += "8";
            int number = Int32.Parse(strNumber);
            lblResult.Text = number.ToString();
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (OperatorFlag == true)
            {
                OperatorFlag = false;
                lblResult.Text = "0";
            }

            string strNumber = lblResult.Text += "9";
            int number = Int32.Parse(strNumber);
            lblResult.Text = number.ToString();
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            OperatorFlag = true;
            secondOperand = Int32.Parse(lblResult.Text);
            switch (CurrentOperator)
            {
                case Operators.Add:
                    firstOperand += secondOperand;
                    break;
                case Operators.Subtract:
                    firstOperand -= secondOperand;
                    break;
                case Operators.Multiply:
                    firstOperand *= secondOperand;
                    break;
                case Operators.Divide:
                    firstOperand /= secondOperand;
                    break;
            }
            lblResult.Text = firstOperand.ToString();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            firstOperand = Int32.Parse(lblResult.Text);
            CurrentOperator = Operators.Add;
            OperatorFlag = true;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            firstOperand = Int32.Parse(lblResult.Text);
            CurrentOperator = Operators.Subtract;
            OperatorFlag = true;
        }

        private void btnMultiple_Click(object sender, EventArgs e)
        {
            firstOperand = Int32.Parse(lblResult.Text);
            CurrentOperator = Operators.Multiply;
            OperatorFlag = true;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            firstOperand = Int32.Parse(lblResult.Text);
            CurrentOperator = Operators.Divide;
            OperatorFlag = true;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {

        }

        private void btnDot_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void btnClearEntry_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (OperatorFlag == true)
            {
                OperatorFlag = false;
                lblResult.Text = "0";
            }

            string strNumber = "";
            int number = 0;

            switch (e.KeyChar)
            {
                case '0':
                    strNumber = lblResult.Text += "0";
                    break;
                case '1':
                    strNumber = lblResult.Text += "1";
                    break;
                case '2':
                    strNumber = lblResult.Text += "2";
                    break;
                case '3':
                    strNumber = lblResult.Text += "3";
                    break;
                case '4':
                    strNumber = lblResult.Text += "4";
                    break;
                case '5':
                    strNumber = lblResult.Text += "5";
                    break;
                case '6':
                    strNumber = lblResult.Text += "6";
                    break;
                case '7':
                    strNumber = lblResult.Text += "7";
                    break;
                case '8':
                    strNumber = lblResult.Text += "8";
                    break;
                case '9':
                    strNumber = lblResult.Text += "9";
                    break;
            }
            e.Handled = true;
            number = Int32.Parse(strNumber);
            lblResult.Text = number.ToString();
        }
    }
}
```
