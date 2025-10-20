## C# .NET-Study
[.NET API Browser](https://learn.microsoft.com/ko-kr/dotnet/api/?view=net-9.0-pp)

#### C# .NET Frameworrk 학습
- IDE : Visual Studio 2022
- Framework : .NET 혹은 .NET Framework
- API : Winforms

## IDE 설치 및 실행
- Visual Studio 2022 
  - .NET 데스크톱 개발 추가
- 프로젝트 만들기 (.NET vs .NET Framework)
  - 콘솔 앱
  - Windows Forms (추천)
  - 콘솔 앱 (.NET Framework)
  - Windows Forms 앱 (.NET Framework) 

## 프로젝트 구조
보기 (View) -> 솔루션 탐색기 (Solution Explorer) & 도구상자 (Toolbox)
- Solution Folder
  - Form.cs : 개발자 코드(이벤트 핸들러, 로직)
    - Form1.Designer.cs : InitializeComponent() 자동 생성(UI 배치/속성)
    - Form1.resx : 리소스(아이콘, 지역화 문자열 등)
  - Program.cs : 프로세스 시작점 Main() + 메시지 루프 시작
