## Component_1
### 기본 입력 / 명령 컨트롤
#### **Label** : 화면에 읽기 전용 텍스트를 표시하는 컨트롤.
```C#
/* ==== Code (form.cs) ==== */
label.Text = "Text";
// 글자 색상 변경 (SystemColors.ControlText는 기본 색상)
label.ForeColor = isError ? Color.Red : SystemColors.ControlText; 
// 배경 색상 변경
label.BackColor = Color.Red; 
```

#### **TextBox** : 사용자가 문자/숫자를 입력하는 한 줄(또는 멀티라인) 입력 컨트롤.
```C#
/* ==== Designer ==== */
// Multiline = true  // 여러 줄 입력 허용
// ReadOnly = false  // 입력 허용 여부
// ScrollBars = Vertical  // 스크롤바

/* ==== Code (form.cs) ==== */
textBox.Text = "Text";
textBox.AppendText("Text" + Environment.NewLine);
textBox.Clear();
textBox.SelectionStart = 5;   // 시작 위치
textBox.SelectionLength = 3;  // 길이
textBox.SelectAll();
int index = textBox.Text.IndexOf("Text"); // 특정 문자열 찾기
int lineLength = textBox.Lines[index].Length;
textBox.SelectedText = ""; // 마우스 드래그로 선택
```

#### **RichTextBox** : **서식(폰트/색/정렬)**이 적용된 텍스트를 입력·표시하는 컨트롤.
```C#
/* ==== Code (form.cs) ==== */
richTextBox.AppendText("Text" + Environment.NewLine);
richTextBox.Clear();
richTextBox.SelectionStart = 5;   // 시작 위치
richTextBox.SelectionLength = 3;  // 길이
richTextBox.SelectAll();
int index = richTextBox.Text.IndexOf("Text"); // 특정 문자열 찾기
int lineLength = richTextBox.Lines[index].Length;
richTextBox.SelectedText = ""; // 마우스 드래그로 선택

// 색/서식 적용(예: 에러 로그는 빨간색)
void AppendLogWithColor(string msg, Color color)
{
    // 현재 커서 위치로 이동
    richTextBox.SelectionStart = richTextBox.TextLength;
    richTextBox.SelectionLength = 0;

    // 색 적용
    richTextBox.SelectionColor = color;

    // 텍스트 추가
    richTextBox.AppendText(msg + "\r\n");

    // 기본색 복구(다음 로그에 영향 방지)
    richTextBox.SelectionColor = richTextBoxLog.ForeColor;
}

// 마지막 라인 텍스트 제거
void RemoveLastLine(RichTextBox rtb)
{
    int lastIndex = rtb.Text.LastIndexOf(Environment.NewLine);
    if (lastIndex >= 0)
    {
        rtb.Text = rtb.Text.Substring(0, lastIndex);
    }
}
```

#### **MaskedTextBox** : 전화번호, 날짜 등 **입력 형식을 강제**하는 텍스트 입력 컨트롤.
```C#
/* ==== Designer ==== */
// Mask            = "000-0000-0000"   // 전화번호 형식 (숫자만)
// PromptChar      = '_'               // 미입력 시 표시 문자
// TextMaskFormat  = MaskFormat.IncludeLiterals
// CutCopyMaskFormat = MaskFormat.IncludeLiterals
// ValidatingType  = typeof(System.DateTime) // 날짜 입력일 경우

/* ==== Code (form.cs) ==== */
// 현재 입력된 값 (마스크 문자 포함)
string rawText = maskedTextBox.Text;

// 마스크가 완전히 채워졌는지 확인
bool isCompleted = maskedTextBox.MaskCompleted;

// 숫자만 추출하고 싶을 때 
maskedTextBox.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
string numberOnly = maskedTextBox.Text;

// 다시 원래 상태로 복구
maskedTextBox.TextMaskFormat = MaskFormat.IncludeLiterals;

// 입력값 유효성 검사 (예: 날짜)
bool isValid = DateTime.TryParse(maskedTextBox.Text, out DateTime dateValue);

// 입력 초기화
maskedTextBox.Clear();

// 마스크 변경 (런타임에서 형식 변경)
maskedTextBox.Mask = "0000-00-00"; // YYYY-MM-DD

// TextMaskFormat에 MaskFormat이라는 “열거형(enum) 값” 입력
//  - maskedTextBox.Text(읽기)에서 "마스크 리터럴/프롬프트를 포함할지" 결정
//  - IncludeLiterals         : '-' '/' ':' 같은 구분 문자는 포함, '_' 같은 PromptChar는 제외
//  - IncludePrompt           : '_' 같은 PromptChar는 포함, '-' 같은 리터럴은 제외
//  - IncludePromptAndLiterals: 리터럴 + PromptChar 모두 포함
//  - ExcludePromptAndLiterals: 리터럴 + PromptChar 모두 제외 (숫자/문자 값만)
// 예) Mask="000-0000-0000", 입력="010-1234-____" 일 때
//    IncludeLiterals          -> "010-1234-"      (리터럴 '-' 유지, 미입력 '_' 제거)
//    ExcludePromptAndLiterals -> "0101234"        (숫자만)
```

#### **Button** : **클릭/탭**으로 특정 동작(명령/이벤트)을 실행하는 컨트롤.
```C#
/* ==== Designer ==== */
// Text         = 버튼의 글씨
// DialogResult = 모달 폼에서 OK / Cancel 설정 가능

/* ==== Code (form.cs) ==== */
// 버튼 비활성/활성
button.Enabled = false;
button.Enabled = true;

void button_Click(object sender, EventArgs e)
{
    // 명령 실행 로직
    button.Text = "처리 중..."; // 버튼 텍스트 변경
}
```

#### **MessageBox** : **알림/경고/확인(Yes·No 등)** 메시지를 모달 창으로 표시하고 사용자 응답을 받는 컨트롤.
```C#
/* ==== Code (form.cs) ==== */
DialogResult result = MessageBox.Show(
    "정말 종료하시겠습니까?", // 내용  
    "종료 확인",            // 제목
    MessageBoxButtons.YesNo, // OKCancel, YesNoCancel, RetryCancel
    MessageBoxIcon.Question  // None, Information, Warning, Error, Question
);

if (result == DialogResult.No)
{
    e.Cancel = true; // 폼 닫기 취소
}
```

#### **LinkLabel** : 웹 링크처럼 클릭 가능한 텍스트를 표시하는 컨트롤.
```C#
/* ==== Designer ==== */
// Text      = "공식 홈페이지"
// AutoSize  = true
// LinkColor = Blue
// ActiveLinkColor = Red
// VisitedLinkColor = Purple

/* ==== Code (form.cs) ==== */
void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
{
    // 기본 브라우저로 URL 열기
    System.Diagnostics.Process.Start(
        new System.Diagnostics.ProcessStartInfo
        {
            FileName = "https://example.com",
            UseShellExecute = true
        }
    );

    // 방문 처리
    linkLabel.LinkVisited = true;
}
```

#### **ToolTip** : 컨트롤에 마우스를 올렸을 때 보조 설명을 표시하는 컴포넌트.
```C#
/* ==== Designer ==== */
// ToolTip 컴포넌트(toolTip1) 추가
// AutoPopDelay = 5000  : 툴팁이 표시된 후 자동으로 사라지기까지의 시간 (ms)
// InitialDelay = 500   : 마우스를 컨트롤 위에 올린 후 툴팁이 처음 나타나기까지의 지연 시간 (ms)
// ReshowDelay  = 100   : 다른 컨트롤로 이동했을 때 다시 표시되기까지의 지연 시간 (ms)
// ShowAlways   = false : 폼이 비활성화(비포커스) 상태여도 툴팁 표시 여부

/* ==== Code (form.cs) ==== */
// ToolTip 1개를 공유하고 SetToolTip()으로 관리
// 버튼에 툴팁 설정
toolTip.SetToolTip(button_Connect, "클릭하면 작업을 시작합니다.");

// 텍스트박스에 툴팁 설정
toolTip.SetToolTip(textBox_Log, "숫자만 입력 가능합니다.");

// 런타임에서 변경
toolTip.SetToolTip(button_Disconnect, "현재 비활성 상태입니다.");
```