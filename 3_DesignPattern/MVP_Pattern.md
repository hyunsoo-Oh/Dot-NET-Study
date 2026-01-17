```bash
사용자 → View → Presenter → Model
                  ↑         ↓
                  └── Presenter가 View 업데이트
```

### Presenter

---

<aside>

**View**와 **Model**을 변화시키는 소스코드 (알고리즘)

</aside>

<aside>

**장점** : View 인터페이스를 통해 결합도가 더 낮아짐, → 재사용/교체 쉬움

**단점** : 인터페이스(IView) 추가로 구조가 약간 복잡해짐

</aside>

```
MVP
├── Models/    : 데이터/도메인 로직
├── Presenter/ : 흐름/이벤트 처리 - Model 변경 + View 인터페이스 갱신
└── Views/
    ├── IView    : Presenter가 바라보는 View 인터페이스
    └── View     : UI(Form) - 인터페이스 구현

Button 클릭 → View 이벤트 발생 → Presenter가 구독 → Model 변경 → View 갱신
1. 사용자가 버튼을 클릭
2. WinForms 내부에서 btnInc.Click 이벤트 발생
3. View(Form) 내부 코드 실행
4. View가 IncClicked 이벤트를 발생시킴
5. Presenter가 해당 이벤트를 구독하여 처리
6. Presenter가 Model을 변경
7. Presenter가 View 인터페이스를 통해 화면 갱신
```

**Model/CounterModel.cs**

```csharp
public class CounterModel
{
    // 현재 카운트 값**
    public int Count { get; private set; } = 0;
    
    public void Increment() **// 값 증가**
    {
        Count++;
    }

    public void Reset() **// 값 초기화**
    {
        Count = 0;
    }
}
```

**View/MainForm**

```csharp
public partial class MainForm : Form
{
    // Model
    CounterModel model;
    // Presenter
    CounterPresenter presenter;
    
    // View 이벤트 (Controller가 구독)
    public event EventHandler IncClicked;
    public event EventHandler ResetClicked;
    
    public MainForm()
    {
		InitializeComponent();
		    
	    model = new CounterModel();
	    presenter= new CounterPresenter(this, model);
        
        // View는 "버튼 클릭"을 직접 처리하지 않고 이벤트만 던진다.**
        btnInc.Click += (s, e) => IncClicked?.Invoke(this, EventArgs.Empty);
        btnReset.Click += btnReset_Click;
		}
    // 컨트롤러가 호출하는 "화면 갱신" 함수**
    public void SetCountText(int count)
    {
        lblCount.Text = $"Count: {count}";
    }
    private void btnReset_Click(object sender, EventArgs e)
    {
	    ResetClicked?.Invoke(this, EventArgs.Empty);
	}
}
```

**Controller/CounterController.cs**

```csharp
public class CounterPresenter
{
    private readonly IMainForm _view;
    private readonly CounterModel _model;

    public CounterController(MainForm view, CounterModel model)
    {
        _view = view;
        _model = model;

        // View 이벤트 연결**
        _view.IncClicked += OnIncClicked;
        _view.ResetClicked += OnResetClicked;

        // 초기 화면 갱신**
        UpdateView();
    }

    private void OnIncClicked(object sender, EventArgs e)
    {
        _model.Increment();
        UpdateView();
    }

    private void OnResetClicked(object sender, EventArgs e)
    {
        _model.Reset();
        UpdateView();
    }

    private void UpdateView()
    {
        _view.SetCountText(_model.Count);
    }
}
```