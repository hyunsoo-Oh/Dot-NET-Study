# User Control 사용법

여러 표준 컨트롤을 하나의 단위로 묶어 독자적인 기능을 수행하도록 만든 
**커스텀 UI 컴포넌트**

## User Control (MyComponent.cs) 코드 구성
#### 컨트롤 내부에는 외부와 통신하기 위한 **Property(속성)**와 Event(이벤트) 정의가 핵심
```C#
namespace MyProject.Controls
{
    public partial class MyComponent : UserControl
    {
        // 이벤트 정의 (외부 MainForm에서 구독할 수 있도록 선언)
        public event EventHandler ProcessCompleted;

        // 속성(Property) 정의: 외부에서 컨트롤의 내부 데이터를 조작
        private string _statusText = "Ready";

        public MyComponent()
        {
            InitializeComponent(); // 하드웨어 가속 및 컴포넌트 초기화
        }

        // 내부 로직 (버튼 클릭 시 이벤트 발생 예시)
        private void btnAction_Click(object sender, EventArgs e)
        {
            // 비즈니스 로직 수행 (예: 장비 로그 분석 시작)
            PerformAction();

            // 이벤트 전파 (MainForm에 알림)
            ProcessCompleted?.Invoke(this, EventArgs.Empty);
        }

        private void PerformAction()
        {
            // 여기에는 데이터 처리 로직을 모듈화하여 작성
        }
    }
}
```

## MainForm.cs 에 필요한 코드 구성
#### 컨트롤 배치 및 이벤트 핸들링
```C#
namespace MyProject
{
    public partial class MainForm : Form
    {
        // 컨트롤 참조 변수
        private MyComponent _deviceController;

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm_Load()
        {
            // User Control 초기화 및 이벤트 바인딩
            // 인스턴스 생성
            _deviceController = new MyComponent();

            // 이벤트 구독 (Event Subscription)
            _deviceController.ProcessCompleted += OnDeviceProcessCompleted;
        }

        /// <summary>
        /// User Control에서 발생한 이벤트를 처리하는 콜백 메서드
        /// </summary>
        private void OnDeviceProcessCompleted(object sender, EventArgs e)
        {
            // UI Thread 세이프티 고려 (Invoke 체크 권장)
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => OnDeviceProcessCompleted(sender, e)));
                return;
            }

            MessageBox.Show("장비 제어 컴포넌트로부터 작업 완료 신호를 수신했습니다.");
        }
    }
}
```