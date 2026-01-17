## Component_4
### 표시 / 미디어 컨트롤
#### **ProgressBar** : **작업 진행 상태**를 막대 형태로 표시하는 컨트롤.
```C#
/* ==== Designer ==== */
// Minimum = 0
// Maximum = 100
// Value   = 0
// Style   = Blocks          // Blocks, Continuous, Marquee
// MarqueeAnimationSpeed = 30 // Style=Marquee 일 때 애니메이션 속도(ms)
// Style 종류
//  “얼마나 진행됐는지 알 수 있을 때”
//  - Blocks : 네모 칸(블록) 단위로 채워짐, 진행률이 “단계적으로” 보임
//  - Continuous : 블록 구분 없이 부드럽게 채워짐
//  “진행 중이라는 사실만 알려줄 때”
//  - Marquee : 좌 ←→ 우로 움직이는 애니메이션, 진행률 값(Value) 사용 안 함

/* ==== Code (form.cs) ==== */
// 진행률 갱신 (결정적 진행률)
progressBar.Minimum = 0;
progressBar.Maximum = 100;
progressBar.Value   = 0;

progressBar.Value = 50; // 50%

// 진행률 증가
progressBar.Increment(1);
```

#### **StatusStrip** : **폼 하단에 상태 메시지**를 표시하는 바 컨트롤.
```C#
/* ==== Designer ==== */
// StatusStrip 추가
// toolStripStatusLabel(텍스트 표시용) 추가
// SizingGrip = false        // 우하단 크기 조절 그립 표시 여부

/* ==== Code (form.cs) ==== */
toolStripStatusLabel.Text = "준비됨";

// 진행/오류 상태 표시 패턴
toolStripStatusLabel.Text = "저장 중...";
toolStripStatusLabel.Text = "완료";
toolStripStatusLabel.Text = "오류: 통신 실패";

// 시간 표시(예: 타이머로 주기 갱신)
timer.Tick += (s,e) => toolStripStatusLabelTime.Text = DateTime.Now.ToString("HH:mm:ss");
```

#### **ToolStrip** : 버튼, 드롭다운 등을 포함한 아이콘 중심 툴바 컨트롤 (자주 쓰는 명령의 빠른 접근(단축)).
```C#
/* ==== Designer ==== */
// ToolStrip 추가
// ToolStripButton / ToolStripDropDownButton / ToolStripSeparator 배치
// GripStyle = Hidden        // 이동 핸들(점점이) 숨김
// RenderMode = System       // 시스템 스타일 렌더링

/* ==== Code (form.cs) ==== */
// 런타임 활성/비활성
toolStripButtonStart.Enabled = true;
toolStripButtonStop.Enabled  = false;

// 드롭다운 항목 추가
toolStripDropDownButtonMode.DropDownItems.Clear();
toolStripDropDownButtonMode.DropDownItems.Add("Mode A", null, (s, e) => ApplyMode("A"));
toolStripDropDownButtonMode.DropDownItems.Add("Mode B", null, (s, e) => ApplyMode("B"));
```

#### **MenuStrip** : **상단 메뉴(File, Edit 등)를** 구성하는 컨트롤 (기능 분류(구조)).
```C#
/* ==== Designer ==== */
// MenuStrip 추가
// File/Edit/Help 등의 ToolStripMenuItem 구성
// ShortcutKeys 설정 (예: Ctrl+S)

/* ==== Code (form.cs) ==== */
// === 미수정 함수 ===
void menuItemSave_Click(object sender, EventArgs e)
{
    SaveFile();
}

// 단축키(코드로도 가능)
menuItemSave.ShortcutKeys = Keys.Control | Keys.S;

// 메뉴 항목 런타임 제어
menuItemSave.Enabled = isDirty;
menuItemRecent.DropDownItems.Clear();
```

#### **PictureBox** : **이미지(비트맵 등)를 표시**하는 컨트롤.
```C#
/* ==== Designer ==== */
// SizeMode = Zoom           // Normal, StretchImage, AutoSize, CenterImage, Zoom
// BorderStyle = FixedSingle // None, FixedSingle, Fixed3D

/* ==== Code (form.cs) ==== */
pictureBox.Image = Image.FromFile(filePath);

// 메모리 누수 방지: 기존 이미지 Dispose 후 교체
if (pictureBox.Image != null)
{
    // === 추가할 코드 ===
    pictureBox.Image.Dispose();
    pictureBox.Image = null;
    // === 완료 ===
}
pictureBox.Image = Image.FromFile(filePath);

// 표시 모드 변경
pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
```

