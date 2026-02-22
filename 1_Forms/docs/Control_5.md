## Component_5
### 레이아웃 / 컨테이너 컨트롤
#### **Panel** : 여러 컨트롤을 묶어 관리하는 기본 컨테이너.
```C#
/* ==== Designer ==== */
// BorderStyle = None         // None, FixedSingle, Fixed3D
// AutoScroll  = false        // true 시 내용 넘치면 스크롤
// Dock        = None         // Top, Bottom, Left, Right, Fill
// BorderStyle 종류
//  - None : 테두리 없음
//  - FixedSingle : 1픽셀 단선 테두리, 입력/표시 영역 강조용
//  - Fixed3D : 입체감 있는 3D 테두리, 레거시/구형 Windows 스타일

/* ==== Code (form.cs) ==== */
// 표시/숨김 (화면 전환용)
panel.Visible = true;
panel.Visible = false;

// 배경색 변경 (구역 구분)
panel.BackColor = Color.LightGray;
```

#### **GroupBox** : 제목이 있는 컨트롤 묶음 컨테이너.
```C#
/* ==== Designer ==== */
// Text = "통신 설정"
// Enabled = true             // false 시 내부 컨트롤 일괄 비활성

/* ==== Code (form.cs) ==== */
// 제목 변경
groupBox.Text = "고급 설정";

// 그룹 전체 활성/비활성
groupBox.Enabled = false;
groupBox.Enabled = true;
```

#### **TabControl** : 탭(Tab)으로 화면을 분리하는 컨테이너.
```C#
/* ==== Designer ==== */
// TabPages 추가 (TabPage 1, 2…)
// Alignment = Top            // Top, Bottom, Left, Right
// Multiline = false

/* ==== Code (form.cs) ==== */
// 탭 전환
tabControl.SelectedIndex = 0;

void tabControl_SelectedIndexChanged(object sender, EventArgs e)
{
    LoadTab(tabControl.SelectedTab.Name);
}

// 탭 동적 추가
TabPage page = new TabPage("로그");
tabControl.TabPages.Add(page);
```

#### **SplitContainer** : 화면을 분할하고 사용자가 크기를 조절할 수 있는 컨테이너.
```C#
/* ==== Designer ==== */
// Orientation = Vertical     // Vertical(좌/우), Horizontal(상/하)
// SplitterDistance = 200     // 초기 분할 위치
// IsSplitterFixed = false   // true 시 사용자 이동 불가

/* ==== Code (form.cs) ==== */
// 패널 접근
splitContainer.Panel1.BackColor = Color.White;
splitContainer.Panel2.BackColor = Color.LightGray;

// 분할 고정/해제
splitContainer.IsSplitterFixed = true;
```

#### **FlowLayoutPanel** : 컨트롤을 자동으로 흐름 배치하는 레이아웃 컨테이너.
```C#
/* ==== Designer ==== */
// FlowDirection = LeftToRight   // TopDown, RightToLeft
// WrapContents  = true          // 줄바꿈 여부
// AutoScroll    = true
```

#### **TableLayoutPanel** : 행/열(Grid) 기반으로 컨트롤을 정렬하는 레이아웃 컨테이너.
```C#
/* ==== Designer ==== */
// ColumnCount = 2
// RowCount    = 3
// ColumnStyles / RowStyles = Percent / Absolute / AutoSize
// Dock = Fill
// ListView 배치 (2×2) : ListView에서 설정
//  - Dock        = Fill
//  - ColumnSpan  = 2
//  - RowSpan     = 2

/* ==== Code (form.cs) ==== */
// 컨트롤 배치
tableLayoutPanel.Controls.Add(new Label { Text = "속도" }, 0, 0);
tableLayoutPanel.Controls.Add(new TextBox(), 1, 0);

// 특정 셀 크기 조정
tableLayoutPanel.SetColumnSpan(buttonSave, 2);
```