using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Calculator
    {
        private int firstOperand = 0;
        private int secondOperand = 0;
        private bool operatorFlag = false;
        private string processText = "0";
        // 내부 구현용은 class 내부여 Enum을 구현
        public enum Operators
        {
            None,
            Add,
            Subtract,
            Multiply,
            Divide
        }
        public Operators currentOperator { get; set; } = Operators.None;

        public string displayText { get; set; } = "0";

        /// <summary>
        /// 버튼을 클릭하면 숫자를 입력
        /// </summary>
        /// <param name="digit"></param>
        public void inputDigit(int digit)
        {
            if (operatorFlag)
            {
                displayText = digit.ToString();
                operatorFlag = false;
            }
            else
            {
                if (displayText == "0")
                {
                    displayText = digit.ToString();
                }
                else
                {
                    displayText += digit.ToString();
                }
            }
        }

        /// <summary>
        /// 연산자 선택 (+, -, *, /)
        /// </summary>
        /// <param name="op"></param>
        public void SetOperator(Operators op)
        {
            firstOperand = Int32.Parse(displayText);
            currentOperator = op;
            operatorFlag = true;
        }

        /// <summary>
        /// = 버튼을 눌렀을 때 계산 수행
        /// </summary>
        public void CalculateResult()
        {
            secondOperand = Int32.Parse(displayText);

            switch (currentOperator)
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
                    if (secondOperand != 0)
                    {
                        firstOperand /= secondOperand;
                    }
                    else
                    {
                        displayText = "0으로 나눌수 없습니다.";
                        operatorFlag = true;
                        return;
                    }
                    break;
                case Operators.None:
                default:
                    return;
            }
            displayText = firstOperand.ToString();
            currentOperator = Operators.None;
            operatorFlag = true;
        }

        /// <summary>
        /// 전체 초기화 (C 버튼)
        /// </summary>
        public void ClearAll()
        {
            firstOperand = 0;
            secondOperand = 0;
            currentOperator = Operators.None;
            operatorFlag = false;
            displayText = "0";
        }

        /// <summary>
        /// 바로 직전 입력한 값만 제거 (CE 버튼)
        /// </summary>
        public void ClearCE()
        {
            if (operatorFlag)
            {
                firstOperand = 0;
            }
            else
            {
                if (currentOperator == Operators.None)
                {
                    secondOperand = 0;
                }
                else
                {
                    operatorFlag = false;
                    return;
                }
            }
            displayText = "0";
        }

        /// <summary>
        /// 현재 상태(firstOperand, currentOperator, displayText, operatorFlag)를 기준으로
        /// processText를 다시 구성
        /// </summary>
        public string Get_Process()
        {
            if (currentOperator == Operators.None)
            {
                processText = displayText;
                return processText;
            }

            string opSymbol = "";
            switch (currentOperator)
            {
                case Operators.Add: opSymbol = " + "; break;
                case Operators.Subtract: opSymbol = " - "; break;
                case Operators.Multiply: opSymbol = " × "; break;
                case Operators.Divide: opSymbol = " ÷ "; break;
            }
            if (operatorFlag)
            {
                return processText = firstOperand.ToString() + opSymbol;
            }
            else
            {
                return processText = firstOperand.ToString() + opSymbol + displayText;
            }
        }
    }
}
