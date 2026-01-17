## Component_2
### 선택 / 옵션 컨트롤
#### **CheckBox** : 켜짐/꺼짐(다중 선택 가능) 상태를 선택하는 컨트롤.
```C#
/* ==== Designer ==== */
// Checked     = false        // 초기 상태
// AutoCheck   = true         // 클릭 시 자동 토글
// ThreeState  = false        // true 시 Checked / Unchecked / Indeterminate

/* ==== Code (form.cs) ==== */
void checkBox_CheckedChanged(object sender, EventArgs e)
{
    bool isEnabled = checkBox.Checked;
    ApplyAutoStart(isEnabled);
}

// 상태 직접 제어 (런타임)
checkBox.Checked = true;
checkBox.Enabled = false;
```

#### **RadioButton** : 같은 그룹(panel, GroupBox)에서 하나만 선택하는 단일 선택 컨트롤.
```C#
/* ==== Designer ==== */
// Checked  = true            // 그룹 내 기본 선택
// AutoCheck = true
// Group은 소속한 Panel / GroupBox 기준

/* ==== Code (form.cs) ==== */
void radioMode_CheckedChanged(object sender, EventArgs e)
{
    if (radioAuto.Checked)
    {
        SetModeAuto();
    }
    else if (radioManual.Checked)
    {
        SetModeManual();
    }
}
```

#### **ComboBox** : **드롭다운 목록 + 직접 입력(옵션)**을 지원하는 선택 컨트롤.
```C#
/* ==== Designer ==== */
// DropDownStyle = DropDownList  // 목록에서만 선택 (권장)
// Sorted        = false
// MaxDropDownItems = 10
// DropDownStyle 종류
//  - DropDown : 드롭다운 목록 + 사용자가 직접 텍스트 입력 가능
//  - DropDownList : 드롭다운 목록에서만 선택 가능 (직접 입력 불가)
//  - Simple : 항상 펼쳐진 리스트 + 입력창 표시

/* ==== Code (form.cs) ==== */
// 항목 추가
comboBox.Items.Add("모드 A");
comboBox.Items.Add("모드 B");

// 인덱스 선택
comboBox.SelectedIndex = 0;

// 데이터 바인딩 (권장)
comboBox.DataSource = modeList;
```

#### **NumericUpDown** : 숫자만 입력하고 증감 버튼으로 값 변경하는 컨트롤.
```C#
/* ==== Designer ==== */
// Minimum   = 0
// Maximum   = 100
// Increment = 1
// DecimalPlaces = 0
// Value     = 10

/* ==== Code (form.cs) ==== */
void numericUpDown_ValueChanged(object sender, EventArgs e)
{
    int value = (int)numericUpDown.Value;
    UpdateSpeed(value);
}

// 값 직접 설정
numericUpDown.Value = 50;
```

#### **TrackBar** : 슬라이더를 드래그해서 범위 내 값을 연속/단계적으로 조절하는 컨트롤.
```C#
/* ==== Designer ==== */
// Minimum   = 0
// Maximum   = 100
// TickFrequency = 10
// SmallChange   = 1
// LargeChange   = 10

/* ==== Code (form.cs) ==== */
void trackBar_ValueChanged(object sender, EventArgs e)
{
    int value = trackBar.Value;
    UpdateLevel(value);
}

// NumericUpDown과 연동
numericUpDown.Value = trackBar.Value;
```