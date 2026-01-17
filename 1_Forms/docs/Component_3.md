## Component_3
### 리스트 / 구조 컨트롤
#### **ListBox** : 여러 항목 중 하나/여러 개를 선택하는 단순 리스트 컨트롤.
```C#
/* ==== Designer ==== */
// SelectionMode = One        // One, MultiSimple, MultiExtended
// Sorted        = false
// HorizontalScrollbar = true

/* ==== Code (form.cs) ==== */
// 항목 추가
listBox.Items.Add("Item A");
listBox.Items.Add("Item B");

void listBox_SelectedIndexChanged(object sender, EventArgs e)
{
    if (listBox.SelectedItem == null) return;

    string selected = listBox.SelectedItem.ToString();
    HandleSelection(selected);
}

// 다중 선택 접근
foreach (var item in listBox.SelectedItems)
{
    ProcessItem(item.ToString());
}
```

#### **CheckedListBox** : 리스트 항목마다 체크 상태를 개별로 선택할 수 있는 리스트 컨트롤.
```C#
/* ==== Designer ==== */
// CheckOnClick = true        // 클릭 즉시 체크/해제
// SelectionMode = One

/* ==== Code (form.cs) ==== */
// 항목 추가
checkedListBox.Items.Add("Option A");
checkedListBox.Items.Add("Option B");

void checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
{
    string item = checkedListBox.Items[e.Index].ToString();
    bool isChecked = (e.NewValue == CheckState.Checked);

    ApplyOption(item, isChecked);
}

// 체크된 항목 가져오기
foreach (var item in checkedListBox.CheckedItems)
{
    UseCheckedItem(item.ToString());
}
```

#### **ListView** : 아이콘/열(Column) 등 다양한 보기로 리스트를 고급 표시하는 컨트롤.
```C#
/* ==== Designer ==== */
// View = Details             // LargeIcon, SmallIcon, List, Tile
// FullRowSelect = true
// GridLines     = true
// HideSelection = false

/* ==== Code (form.cs) ==== */
// 컬럼 추가
listView.Columns.Add("이름", 150);
listView.Columns.Add("상태", 100);

// 아이템 추가
ListViewItem item = new ListViewItem("Device A");
item.SubItems.Add("Online");
listView.Items.Add(item);

void listView_SelectedIndexChanged(object sender, EventArgs e)
{
    if (listView.SelectedItems.Count == 0) return;

    ListViewItem selected = listView.SelectedItems[0];
    HandleItem(selected.Text);
}
```

#### **DataGridView** : 데이터를 행/열로 표시하고, 정렬/편집/선택/바인딩을 지원
```C#
/* ==== Designer ==== */
// AutoGenerateColumns = false  // DataSource 바인딩 시 컬럼을 자동 생성하지 않음
// ReadOnly            = true   // 셀 편집을 전면 차단
// AllowUserToAddRows  = false  // 사용자가 UI에서 임의로 행을 추가하지 못하게 함
// SelectionMode       = FullRowSelect  // 셀 클릭 시 해당 행 전체를 선택
// MultiSelect         = false  // 동시에 여러 행 선택 불가
// CellBorderStyle     = None
// RowHeadersVisible   = false
// TabStop             = False  // DataGridView를 포커스 대상에서 제외
// AllowUserToResizeColumns     = false   // 사용자가 컬럼 폭 조절(드래그) 금지
// AllowUserToOrderColumns      = false   // 사용자가 컬럼 순서 드래그 변경 금지
// ColumnHeadersHeightSizeMode  = DisableResizing // 헤더 높이 변경 금지

/* ==== Code (form.cs) ==== */
// 컬럼 정의
dataGridView.Columns.Add("Name", "이름");
dataGridView.Columns.Add("Value", "값");

// 행 추가
dataGridView.Rows.Add("Speed", 1200);

// 데이터 바인딩 (권장)
dataGridView.DataSource = dataList;

// 바인딩한 데이터 컬럼 헤더 클릭 시 정렬되는 기능 끄기
foreach (DataGridViewColumn column in dataGridView.Columns)
{
    column.SortMode = DataGridViewColumnSortMode.NotSortable;
}

void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
{
    if (e.RowIndex < 0) return;

    string name = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
    HandleRow(name);
}

// Tab 키를 눌러도 DataGridView로 포커스가 이동하지 않음
dataGridView.SelectionChanged += (s, e) =>
{
    dataGridView.ClearSelection();
};
```

#### **TreeView** : 폴더 구조처럼 계층(트리) 데이터를 펼치고 선택하는 컨트롤.
```C#
/* ==== Designer ==== */
// HideSelection = false    // TreeView가 포커스를 잃어도 선택된 노드를 강조 표시
// ShowLines     = true     // 노드 간 연결선 표시, 계층 구조를 시각적으로 명확하게 표현
// ShowPlusMinus = true     // 자식 노드 확장/축소 버튼(+/-) 표시

/* ==== Code (form.cs) ==== */
// 노드 구성
TreeNode root = new TreeNode("장비");
TreeNode child1 = new TreeNode("센서");
TreeNode child2 = new TreeNode("모터");

root.Nodes.Add(child1);
root.Nodes.Add(child2);
treeView.Nodes.Add(root);

// 사용자가 노드를 클릭 & 키보드(↑↓)로 선택 이동 & 코드에서 SelectedNode 변경
void treeView_AfterSelect(object sender, TreeViewEventArgs e)
{
    string selectedPath = e.Node.FullPath;
    HandleNode(selectedPath);
}
```