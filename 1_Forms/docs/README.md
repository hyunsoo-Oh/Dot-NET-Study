## 계산기 Calculator
### UI Component
1. 계산할 숫자 칸 Label
  - Label Name : lblDisplay
  - lblDisplay.AutoSize = False
  - lblDisplay.dock = Top
  - + font, size 등

2. 버튼의 배치할 위치 지정 TableLayoutPanel
  - > 아이콘을 클릭하여 -> 행 및 열 편집 -> 4행과 4열로 변경 (백분율 25%)

3. 계산기의 숫자 및 연산자 Button
  - Button Name : btnOne
  - btnOne.Text : 1
  - Event 항목 (번개) : Click 항목 더블클릭

### Code
```C#
using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        enum Operators
        {
            None,
            Add,
            Subtract,
            Multiply,
            Divide,
            Result
        }

        Operators currentOperator = Operators.None;
        Boolean operatorChangeFlag = false;
        int firstOperand = 0;
        int secondOperand = 0;

        public Form1()
        {
            InitializeComponent();
        }
        private void btnResult_Click(object sender, EventArgs e)
        {
            secondOperand = Int32.Parse(lblDisplay.Text);
            if(currentOperator == Operators.Add)
            {
                firstOperand += secondOperand;
                lblDisplay.Text = firstOperand.ToString();
            }
            else if(currentOperator == Operators.Subtract)
            {
                firstOperand -= secondOperand;
                lblDisplay.Text = firstOperand.ToString();
            }
            else if (currentOperator == Operators.Multiply)
            {
                firstOperand *= secondOperand;
                lblDisplay.Text = firstOperand.ToString();
            }
            else if (currentOperator == Operators.Divide)
            {
                if(secondOperand == 0)
                {
                    lblDisplay.Text = "0으로 나눌 수 없습니다";
                }
                else
                {
                    firstOperand /= secondOperand;
                    lblDisplay.Text = firstOperand.ToString();
                }
            }
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            string strNumber = lblDisplay.Text += "1";
            int intNumber = Int32.Parse(strNumber);
            lblDisplay.Text = intNumber.ToString();
        }
    }
}
```
```C#

```
