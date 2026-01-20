## Component_6
### 추가적인 기능
#### **Open & Save FileDialog** : 파일 열기/저장 경로를 선택하는 표준 다이얼로그.
**OpenFileDialog**
```C#
/* ==== Designer ==== */
// Filter = "텍스트 파일 (*.txt)|*.txt|모든 파일 (*.*)|*.*"
// Multiselect = false
// InitialDirectory = "C:\\

/* ==== Code (form.cs) ==== */
// bin\Debug 또는 bin\Release 경로가 반환됩니다.
string baseDir = AppDomain.CurrentDomain.BaseDirectory;

// 생성하고자 하는 하위 폴더명 정의 (예: "Logs" 또는 "Data")
string targetFolderName = "ProjectData";
string targetPath = Path.Combine(baseDir, targetFolderName);

// 디렉토리 존재 여부 확인 및 생성 (Directory.CreateDirectory는 이미 존재하면 무시함)
if (!Directory.Exists(targetPath))
{
    Directory.CreateDirectory(targetPath);
}

// TextBox에 최종 경로 할당
txtPath.Text = targetPath;

using (OpenFileDialog dlg = new OpenFileDialog())
{
    dlg.Filter = "텍스트 파일 (*.txt)|*.txt|모든 파일 (*.*)|*.*";
    dlg.Multiselect = false;

    if (dlg.ShowDialog() == DialogResult.OK)
    {
        string filePath = dlg.FileName;
        LoadFile(filePath);
    }
}
```

**SaveFileDialog**
```C#
/* ==== Designer ==== */
// Filter = "CSV 파일 (*.csv)|*.csv"
// DefaultExt = "csv"
// AddExtension = true

/* ==== Code (form.cs) ==== */
using (SaveFileDialog dlg = new SaveFileDialog())
{
    dlg.Filter = "CSV 파일 (*.csv)|*.csv";
    dlg.DefaultExt = "csv";

    if (dlg.ShowDialog() == DialogResult.OK)
    {
        string filePath = dlg.FileName;
        SaveFile(filePath);
    }
}
```

#### **FolderBrowserDialog** : 폴더 선택 다이얼로그
```C#
// Description = "저장할 폴더를 선택하세요"
// ShowNewFolderButton = true

using (FolderBrowserDialog dlg = new FolderBrowserDialog())
{
    dlg.Description = "로그 저장 폴더 선택";

    if (dlg.ShowDialog() == DialogResult.OK)
    {
        string folderPath = dlg.SelectedPath;
        SetLogDirectory(folderPath);
    }
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