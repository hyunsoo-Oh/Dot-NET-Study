### Form
```C#
public partial class MainForm : Form
{
    // Form 속성(Text, StartPosition, Icon, KeyPreview, CancelButton) 설정
    public MainForm()
    {
        InitializeComponent();

        // 타이틀 바에 표시되는 폼 제목
        this.Text = "Main Form";

        // 폼 최초 표시 위치 (CenterScreen, Manual 등)
        this.StartPosition = FormStartPosition.CenterScreen;

        // 타이틀 바 및 작업 표시줄 아이콘
        this.Icon = Properties.Resources.AppIcon;

        // 자식 컨트롤보다 Form이 먼저 키 이벤트를 받음 (단축키 필수)
        this.KeyPreview = true;

        // ESC 키와 연결될 버튼
        this.CancelButton = btnCancel;
    }

    // 폼이 처음 로드될 때 → 컨트롤 초기값 세팅
    private void MainForm_Load(object sender, EventArgs e)
    {
        // 초기 UI 상태 설정
        // 예: TextBox 기본값, CheckBox 상태 등
    }

    // 폼이 실제 화면에 표시된 직후 → 무거운 작업 시작 시점
    private void MainForm_Shown(object sender, EventArgs e)
    {
        // 시간이 걸리는 초기화 작업
        // 예: 장비 연결, 파일 로드, 데이터 초기화
    }

    // 닫히기 직전 → 종료 확인 / 리소스 해제
    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        DialogResult result = MessageBox.Show(
            "정말 종료하시겠습니까?",
            "종료 확인",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );

        if (result == DialogResult.No)
        {
            e.Cancel = true; // 폼 닫기 취소
        }
    }

    // 완전히 닫힌 후 → 객체 정리
    private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        // 리소스 정리
        // 예: Timer.Dispose(), 통신 포트 Close 등
    }
}
```