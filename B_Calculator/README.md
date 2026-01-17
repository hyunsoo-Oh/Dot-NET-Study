# Calculator 만들기
#### C# .NET Framework에서 “UI와 도메인 로직 분리”를 연습하기 위한 프로젝트
## 목표
#### .NET Framework 4.8 + C#
 - UI는 WinForms
→ 화면/입력만 담당, 실제 계산 로직은 별도 클래스로 분리

#### 설계 관점 목표
 - 버튼/키보드 입력 → 계산 로직 호출 구조 연습

 - Form(mainForm) 과 도메인 로직(Calculator) 분리
 - WinForms의 포커스/키 입력(KeyDown) 흐름 이해 및 제어

## 구현 기능
- 정수 기반 기본 사칙연산

 - +, -, ×, ÷ (0으로 나누기 예외 메시지 처리 포함) 
 - Calculator
 - 숫자 입력 
    - 버튼 클릭으로 0~9 입력
    - 키보드 상단 숫자 키 + 숫자패드(NumPad) 숫자 키 입력 지원 
 - 결과 출력
    - = 버튼 클릭 또는 Enter(키보드 / 숫자패드)로 계산 수행
    - Clear 기능
    - C : 전체 초기화 (피연산자, 연산자, 표시값 모두 0으로) 
    - CE : 바로 직전 입력만 0으로 초기화 (표시값만 0으로) 
 - UI 표시
    - lblResult 라벨 결과값 출력 (우측 정렬, 숫자 길어지면 오른쪽 정렬 유지)
    - lblProcess 라벨 FirstOperand Operator SecondOperand 출력

## 프로젝트 구조
```
Calculator
├── mainForm.cs          // UI 이벤트 처리, 키보드/버튼 입력 → Calculator 호출
│   ├── mainForm.Designer.cs
│   └── mainForm.resx
├── Program.cs           // WinForms 진입점
└── Calculator.cs        // 계산 도메인 로직 (피연산자, 연산자, C/CE, 결과 계산)
```

## 문제 해결
### 키패드로만 시작할 때 3 + 20 = 200 이 되는 문제 (WinForms 포커스/Enter 처리)
#### 증상
 - 프로그램을 실행한 직후, **숫자패드로만 입력**해서 계산하면 이상 동작 발생

    - 예) 3 → + → 2 → 0 → Enter

    - 기대값: 23, 20, 결과 23 + 20 = 43 또는 3 + 20 = 23 (구현에 따라)

    - 실제: 200, 300 등 엉뚱한 값

**버튼을 한 번 클릭한 이후**에는  
같은 키패드 입력으로도 **정상 계산**됨
→ **“처음 키패드로 시작할 때만”** 깨지는 패턴
#### 원인
WinForms에서 폼이 처음 뜰 때:

 - 디자이너에서 만든 **첫 번째 버튼(예: btn0)**이 기본 포커스를 가짐

 - 이 상태에서 키보드를 누르면:
    1. Form의 KeyDown 또는 KeyPress 이벤트
    2. 포커스를 가진 버튼의 키 처리 / Click 처리
가 둘 다 실행될 수 있음

#### 해결 방법: 초기 포커스 제거 + KeyPreview 사용
```C#
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
```