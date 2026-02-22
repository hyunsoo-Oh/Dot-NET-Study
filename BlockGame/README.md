# Block Game 만들기
#### C# .NET Framework에서 “올바른 객체지향 구조” 설계를 연습하기 위한 프로젝트

## 목표
- .NET Framework 4.8 + C#
- UI는 WinForms  

    → 화면/입력만 담당, 도메인 로직과 완전히 분리  
- 디자인 원칙 중심 개발
    - 올바른 객체지향 (도메인 로직과 UI 분리)

    - 폴더/프로젝트 구조
    - 최소한의 디자인 패턴 적용 (State / Strategy / Factory / Observer 등)

## 구현할 기능
- 10x20 보드 (위 추가 영역 2칸(블록 등장용))

- Game Rule 만들기
- 기본 7개의 Block 및 회전
- 라인 클리어 + 점수
- 레벨(속도 증가) 간단히
- 일시정지 / 게임오버

## 프로젝트 구조
```
BlockGame
├── mainForm.cs     // UI 이벤트 처리, Timer, 입력(KEY) → Game 로직 호출
│   ├── mainForm.Designer.cs
│   └── mainForm.resx
├── Program.cs      // WinForms 진입점
└── BlockGame.cs    // 게임 도메인 로직(모든 클래스 포함 단일 파일)
```

## 구조 설명
- mainForm.cs  

    - UI 이벤트 처리, Timer, 입력(KEY) → Game 로직 호출  

    - 렌더링(Graphics.Draw) 전담

- BlockGame.cs

    - 게임 로직 전용 단일 파일, 내부는 클래스 단위로 구조화

        - Position (좌표 구조체)

        - BlockType / GameState (Enum)
        - Block (Tetromino)
        - Board (게임 보드/충돌/라인 계산)
        - Game (게임 전체 흐름 제어)

- Program.cs

    - WinForms 진입점

    - 앱이 시작할 때 한 번만 해야 하는 일 (설정, 로그인 등)

## 과정 중 알게 된것
```
1. UI 사이즈 고정 
    → MinimumSize, MaximumSize를 사이즈와 동일하게 하기 및 MaximizeBox False
2. 
```