## Component_1
### 핵심 기능

#### **SerialPort** : PC와 외부 장치를 COM 포트(UART, USB)로 연결해 통신
```C#

```

#### **TcpListener** : 특정 IP와 Port에서 클라이언트 접속을 대기(Accept) 하는 클래스
```C#

```

#### **TcpClient** : 서버에 연결하고 데이터 송수신하는 클래스
```C#

```

#### **Timer** : 일정 시간 간격으로 이벤트를 발생시켜 주기 작업을 돌리는 컴포넌트.
- System.Windows.Forms.Timer : WinForms 전용 UI 타이머
- System.Timers.Timer : 서버/백그라운드용 (Invoke 필요)
```C#
using System.Windows.Forms.Timer

/* ==== Designer ==== */
// Timer 컴포넌트(timer1) 추가
// Interval = 1000      // Tick 이벤트 발생 주기 (ms)
// Enabled = false      // true면 폼 로드 시 자동 시작

/* ==== Code (form.cs) ==== */
// 시작/정지
timer.Interval = 200; // 200ms
timer.Start();
timer.Stop();

void timer_Tick(object sender, EventArgs e)
{
    // 주기 작업 (UI 스레드에서 실행됨)
    UpdateUiStatus();
}
```
```C#
using System.Timers.Timer

private System.Timers.Timer _timer;

public form()
{
    _timer = new System.Timers.Timer();

    _timer.Interval = 1000;
    _timer.AutoReset = true; // AutoReset = true → 반복 실행
    _timer.Elapsed += Timer_Elapsed; // 이벤트 연결
    _timer.Enabled = false; // 시작 시 자동 실행 여부
}

/* ==== 시작 / 정지 ==== */
private void StartTimer()
{
    _timer.Interval = 200; // 200ms
    _timer.Start();
}

private void StopTimer()
{
    _timer.Stop();
}

/* ==== Tick (Elapsed) ==== */
private void Timer_Elapsed(object sender, ElapsedEventArgs e)
{
    // ⚠ ThreadPool 스레드에서 실행됨
    // UI 접근 시 반드시 Invoke 필요
    if (this.InvokeRequired)
    {
        this.Invoke(new Action(UpdateUiStatus));
    }
    else
    {
        UpdateUiStatus();
    }
}

private void UpdateUiStatus()
{
    label1.Text = DateTime.Now.ToString();
}
```


#### **Timer** : 일정 시간 간격으로 이벤트를 발생시켜 주기 작업을 돌리는 컴포넌트.
```C#
/* ==== Designer ==== */
// Timer 컴포넌트(timer1) 추가
// Interval = 1000      // Tick 이벤트 발생 주기 (ms)
// Enabled = false      // true면 폼 로드 시 자동 시작

/* ==== Code (form.cs) ==== */
// 시작/정지
timer.Interval = 200; // 200ms
timer.Start();
timer.Stop();

void timer_Tick(object sender, EventArgs e)
{
    // 주기 작업 (UI 스레드에서 실행됨)
    UpdateUiStatus();
}
```

#### **H/V ScrollBar** : 화면/값을 수평(H)/수직(V)으로 스크롤하는 바 컨트롤.
```C#
/* ==== Designer ==== */
// Minimum = 0
// Maximum = 100
// Value   = 0
// SmallChange = 1   // 키보드/작은 이동 단위
// LargeChange = 10  // PageUp/Down 같은 큰 이동 단위

/* ==== Code (form.cs) ==== */
void scrollBar_Scroll(object sender, ScrollEventArgs e)
{
    int value = e.NewValue; // 변경된 값
    ApplyScrollValue(value);
}

// 값 직접 제어
hScrollBar.Value = 50;
vScrollBar.Value = 20;
```

#### **Web Browser** : 폼 안에서 웹 페이지를 렌더링/탐색하는 컨트롤.
```C#
/* ==== Designer ==== */
// ScriptErrorsSuppressed = true   // 스크립트 에러 팝업 억제
// Dock = Fill

/* ==== Code (form.cs) ==== */
// URL 이동
webBrowser.Navigate("https://example.com");

// HTML 직접 표시
webBrowser.DocumentText = "<html><body><h2>Hello</h2></body></html>";

void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
{
    // 로드 완료 후 처리 (DOM 접근 가능)
    // 예: webBrowser.Document.GetElementById("id");
    OnWebLoaded(e.Url.ToString());
}
```

#### **Drawing** : Graphics로 화면/이미지에 도형·텍스트 등을 직접 그리는 작업(렌더링).
```C#
/* ==== Designer ==== */
// (특정 컨트롤 Panel/PictureBox 등을 캔버스로 사용)
// DoubleBuffered 설정이 가능한 컨트롤이면 true 권장 (깜빡임 감소)

/* ==== Code (form.cs) ==== */
void panelCanvas_Paint(object sender, PaintEventArgs e)
{
    Graphics g = e.Graphics;

    // 사각형
    g.DrawRectangle(Pens.Black, 10, 10, 200, 100);

    // 문자열
    g.DrawString(
        "Status: OK",
        this.Font,
        Brushes.Black,
        20,
        20
    );

    // 선
    g.DrawLine(Pens.Black, 10, 130, 300, 130);
}

panelCanvas.Invalidate(); // 다시 그려야 한다고 "요청" (빈번한 갱신)
panelCanvas.Refresh();    // Invalidate + 즉시 Paint (즉시 반영 필요)
```