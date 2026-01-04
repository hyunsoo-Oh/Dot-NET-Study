# Design Pattern
## .NET Framework

<aside>

- **Winform** : GDI+ 기반의 이벤트 중심 UI 구성 방식
    - OOP + 이벤트 기반 구조 + **MVP 패턴** (Model, View, Presenter)
- **WPF** : XAML 기반 선언형 UI + DirectX 렌더링
    - **MVVM 패턴** (Model, View, ViewModel)
- **ASP.NET** : 서버 사이드 렌더링 + Web Forms/MVC를 통한 웹 앱 개발
    - **MVC 패턴** (Model, View, Controller)
</aside>

**.NET Framework**는 Windows 전용 옛 세대 Framework

**.NET 5~8**는 크로스 플랫폼 Windows, Linux, macOS

### Model, View + @(Pressenter, Controller, View Model)

| MVC 패턴 | MVP 패턴 | MVVM 패턴 |
| --- | --- | --- |
| Model-View-Controller | Model-View-Presenter | Model-View-ViewModel |
| View → Controller 직접 호출 | View → Presenter에게 이벤트 전달 | 바인딩이 자동 처리 |
**MVC 패턴과 MVP 패턴 차이**
```
MVC 패턴 : Controller가 View(구현체)를 직접 참조하여 접근
    - Controller → View   
MVP 패턴 : Presenter가 View 구현체가 아닌 IView 인터페이스를 통해 접근
    - Presenter → IView → View

요약 :
    MVC는 Controller가 View 구현체를 직접 다루고,
    MVP는 Presenter가 View 인터페이스만 다룬다.
```