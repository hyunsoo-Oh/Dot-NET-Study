## 프로그램을 백그라운드 상주형으로 운영
- 시스템 트레이
    - 작업표시줄 오른쪽(시계 근처)에 있는 작은 아이콘 영역
    - 프로그램이 **“켜져 있지만 화면을 차지하지 않음”**을 표현하는 장소
- 트레이 아이콘(Tray Icon)
    - 트레이에 표시되는 프로그램 아이콘
    - WinForms에선 NotifyIcon 컴포넌트가 담당
- 트레이 메시지(Tray Notification / Balloon Tip)
    - 트레이 아이콘에서 나오는 알림(풍선/토스트)
    - WinForms에선 NotifyIcon.ShowBalloonTip() 또는 Windows 알림(토스트) 기반 방식으로 구현

-> 창을 숨겨도(트레이) 프로그램/장비 동작은 계속하기 위해 사용

### 핵심 요소
- NotifyIcon (필수)   
    - 트레이에 아이콘을 띄우는 본체  
    - 주요 속성
        - Icon : 표시 아이콘
        - Text : 마우스 올리면 나오는 툴팁(길이 제한 있음)
        - Visible : 트레이 표시/숨김
        - ContextMenuStrip : 우클릭 메뉴 연결
- ContextMenuStrip (강력 추천)
    - 트레이 우클릭 메뉴(“열기/종료/연결/로그 보기” 같은 메뉴)
    - 실무에선 “종료” 메뉴는 반드시 제공 (좀비 프로세스 방지)
- 이벤트(사용자 상호작용)
    - DoubleClick : 더블클릭 시 창 열기(가장 흔함)
    - MouseClick : 좌클릭/우클릭 구분 처리 가능
    - (컨텍스트 메뉴는 ContextMenuStrip로 처리)

```C#
public partial class MainForm : Form
{
    private NotifyIcon trayIcon;
    private ContextMenuStrip trayMenu;

    // 트레이로 숨길 때 1회 안내용 플래그
    private bool isTrayHintShown = false;

    public MainForm()
    {
        InitializeComponent();

        InitTrayComponents();
        this.Resize += MainForm_Resize;
        this.FormClosing += MainForm_FormClosing;
        // === 완료 ===
    }

    private void InitTrayComponents()
    {
        // === 추가할 코드 ===
        trayMenu = new ContextMenuStrip();
        trayMenu.Items.Add("열기", null, Tray_Open_Clicked);
        trayMenu.Items.Add("종료", null, Tray_Exit_Clicked);

        trayIcon = new NotifyIcon();
        trayIcon.Icon = this.Icon;                 // 폼 아이콘 재사용
        trayIcon.Text = "장비 제어 프로그램";       // 툴팁(길이 제한 주의)
        trayIcon.Visible = true;

        trayIcon.ContextMenuStrip = trayMenu;
        trayIcon.DoubleClick += Tray_DoubleClick;

        // 최초 실행 알림(원하면 제거)
        ShowTrayInfo("실행 중", "프로그램이 트레이에서 실행됩니다.");
        // === 완료 ===
    }

    private void Tray_DoubleClick(object sender, EventArgs e)
    {
        // === 추가할 코드 ===
        ShowMainWindow();
        // === 완료 ===
    }

    private void Tray_Open_Clicked(object sender, EventArgs e)
    {
        // === 추가할 코드 ===
        ShowMainWindow();
        // === 완료 ===
    }

    private void Tray_Exit_Clicked(object sender, EventArgs e)
    {
        // === 추가할 코드 ===
        // 여기서 장비 정지/통신 종료/로그 flush 같은 “안전 종료 시퀀스” 수행 권장
        CleanupTray();

        Application.Exit(); // 정상 종료
        // === 완료 ===
    }

    private void MainForm_Resize(object sender, EventArgs e)
    {
        // === 추가할 코드 ===
        // 최소화하면 트레이로 숨기기(선호 패턴)
        if (this.WindowState == FormWindowState.Minimized)
        {
            HideToTray();
        }
        // === 완료 ===
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        // === 추가할 코드 ===
        // X(닫기) 누르면 종료하지 말고 트레이로 숨김
        // 진짜 종료는 트레이 메뉴 "종료"에서만 하게 만들기
        e.Cancel = true;
        HideToTray();
        // === 완료 ===
    }

    private void HideToTray()
    {
        // === 추가할 코드 ===
        this.Hide();

        if (!isTrayHintShown)
        {
            isTrayHintShown = true;
            ShowTrayInfo("트레이로 이동", "프로그램은 계속 실행됩니다. 종료는 트레이 메뉴에서 하세요.");
        }
        // === 완료 ===
    }

    private void ShowMainWindow()
    {
        // === 추가할 코드 ===
        this.Show();
        this.WindowState = FormWindowState.Normal;
        this.Activate();
        // === 완료 ===
    }

    private void ShowTrayInfo(string title, string message)
    {
        // === 추가할 코드 ===
        // Windows 환경에 따라 표시 방식/시간이 다를 수 있음(알림 정책)
        trayIcon.BalloonTipTitle = title;
        trayIcon.BalloonTipText = message;
        trayIcon.BalloonTipIcon = ToolTipIcon.Info;
        trayIcon.ShowBalloonTip(2000);
        // === 완료 ===
    }

    private void CleanupTray()
    {
        // === 추가할 코드 ===
        if (trayIcon != null)
        {
            trayIcon.Visible = false;
            trayIcon.Dispose();
            trayIcon = null;
        }

        if (trayMenu != null)
        {
            trayMenu.Dispose();
            trayMenu = null;
        }
        // === 완료 ===
    }
}
```