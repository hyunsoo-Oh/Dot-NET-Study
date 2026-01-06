## .NET 개발 시작
1. 프로젝트 생성
    - 프로젝트 만들기 (.NET vs .NET Framework)
    - 콘솔 앱
    - Windows Forms (추천)
    - 콘솔 앱 (.NET Framework)
    - Windows Forms 앱 (.NET Framework) 

2. Form Designer 작성
[보기] -> 도구 상자
    - Form.cs : 디자인 UI
        - Form.Designer.cs : Form에 컨트롤을 추가하거나 수정하면 코드가 자동 생성되는 파일
        - Form.resx : 문자열, 이미지, 개체 데이터가 포함된 리소스 파일
[보기] -> 다른 창\문서 개요
    - Form 내부의 Component 부모 객체 지정
        - Panel1에 Form의 Component를 옮기기

3. Component 배치
     
   
5. Properties 설정
    - Design : Name (인스턴스 이름)
    - Event : Drag, Command, Mouse, Property, Click, Key, Focus

7. EventHandler에 들어갈 함수 작성

### 프로젝트 구조
```
ProjectRoot/
├── 종속성/
├── Form1.cs/   # [디자인] 및 코드 (이벤트 함수 생성)
│   ├── Form1.Designer.cs/ 
│   │   └── Form1
│   └── Form1.resx
└── Program.cs 
```

### Form1
```C#
namespace ProjectRoot
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  사용 중인 모든 리소스를 정리.
        /// </summary>
        /// <param name="disposing">
        ///  true인 경우 관리 리소스를 해제하고,
        ///  false인 경우 관리되지 않는 리소스만 해제.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";
        }

        #endregion
    }
}
```

### Program.cs
```C#
namespace ProjectRoot
{
    internal static class Program
    {
        /// <summary>
        ///  애플리케이션의 진입점(Main Entry Point).
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
```
