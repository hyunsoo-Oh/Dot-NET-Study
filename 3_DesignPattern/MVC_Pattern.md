```bash
사용자 → View → Controller → Model → Controller → View
```

### Controller

---

<aside>

**View**와 **Model**을 변화시키는 소스코드 (알고리즘)

</aside>

<aside>

**장점** : 종속성이 적어지고 **View** 재사용하기 쉬워 다른 프로젝트에 적용하기 편함

**단점** : **Controller**에 소스코드가 집중되는 경향이 있음 (프로젝트가 복잡할수록 부적합)

</aside>

```
MVC
├── Controller/  : 흐름/이벤트 처리 - 화면 갱신
├── Models/      : 데이터/도메인 로직
└── View/        : UI 관련 - 컨트롤러가 붙을 이벤트만 노출 + UI 업데이트 함수 제공

Button 클릭 → View 이벤트 발생 → Controller가 구독 → Model 변경 → View 갱신
1. 사용자가 버튼을 클릭
2. WinForms 내부에서 btnInc.Click 이벤트 발생
3. 람다 함수 실행
4. View가 IncClicked 이벤트를 발생시킴

“WinForms MVC에서는
버튼 클릭 이벤트를 람다 또는 메서드로 View 이벤트에 연결할 수 있으며,
두 방식은 동등하고 Controller에는 UI 의존성이 없습니다.”
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
    // Controller (View + Model 연결)
    CounterController controller;
    
    // View 이벤트 (Controller가 구독)
    public event EventHandler IncClicked;
    public event EventHandler ResetClicked;
    
    public MainForm()
    {
	    InitializeComponent();
	    
	    model = new CounterModel();
	    controller = new CounterController(this, model);
        
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
public class CounterController
{
    private readonly MainForm _view;
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