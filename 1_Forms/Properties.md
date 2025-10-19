## 컴포넌트의 중요한 속성

💬 Text, Name, Dock, Anchor → 거의 모든 폼에서 필수

🎨 BackColor, ForeColor, Font → UI 커스터마이징 핵심

⚙️ Enabled, Visible → 논리 제어 필수

🧭 DataSource / Items / Checked / Value → 입력·리스트형 컨트롤 핵심

🕹️ Click, TextChanged, CheckedChanged → 이벤트 3대장💬 Text, Name, Dock, Anchor → 거의 모든 폼에서 필수

🎨 BackColor, ForeColor, Font → UI 커스터마이징 핵심

⚙️ Enabled, Visible → 논리 제어 필수

🧭 DataSource / Items / Checked / Value → 입력·리스트형 컨트롤 핵심

🕹️ Click, TextChanged, CheckedChanged → 이벤트 3대장

### 공통 속성 (모든 컨트롤 공통적으로 중요)
| 속성명                  | 설명             | 자주 사용하는 이유           |
| -------------------- | -------------- | -------------------- |
| **Name**             | 코드에서 컨트롤 식별자   | 이벤트 핸들러, 코드 접근       |
| **Text**             | 표시되는 문자열       | 버튼/라벨 캡션, 입력 값       |
| **Enabled**          | 활성/비활성         | 조건부 입력 제한            |
| **Visible**          | 보임/숨김          | 상태에 따라 표시 제어         |
| **Dock**             | 부모 영역 기준 도킹    | 전체 채우기(Fill) 등 배치 고정 |
| **Anchor**           | 폼 리사이즈 시 위치 고정 | 반응형 레이아웃             |
| **Location**         | (X, Y) 좌표      | 수동 배치 제어             |
| **Size**             | (W, H) 크기      | 레이아웃 세밀 조정           |
| **BackColor**        | 배경색            | 강조·상태 구분             |
| **ForeColor**        | 글자색            | 강조·읽기성 향상            |
| **Font**             | 글꼴             | 크기·가독성 조정            |
| **TabIndex**         | 탭 순서           | 키보드 이동 순서 제어         |
| **TabStop**          | 탭 포커스 허용 여부    | UI 흐름 제어             |
| **Margin / Padding** | 여백             | 컨테이너 내 정렬            |


### 컨테이너류 (Panel, GroupBox, FlowLayoutPanel, TableLayoutPanel 등)
| 속성명               | 설명            | 특징          |
| ----------------- | ------------- | ----------- |
| **AutoScroll**    | 스크롤 자동 생성     | 내용이 넘칠 때 유용 |
| **Dock / Anchor** | 크기 조절 대응      | 폼 리사이즈 반응형  |
| **Controls**      | 포함된 자식 컨트롤 목록 | 코드에서 접근·추가  |
| **BackColor**     | 배경색           | 구분·시각적 영역화  |
| **BorderStyle**   | 테두리 스타일       | 영역 시각화      |

### 입력 컨트롤류 (TextBox, ComboBox, NumericUpDown 등)
| 속성명                                         | 설명              | 특징          |
| ------------------------------------------- | --------------- | ----------- |
| **Text**                                    | 현재 값            | 주 입력 데이터    |
| **ReadOnly**                                | 읽기 전용           | 수정 불가 모드    |
| **MaxLength**                               | 입력 최대 길이        | 검증 간편화      |
| **Multiline (TextBox)**                     | 여러 줄 허용         | 로그창 등       |
| **ScrollBars (TextBox)**                    | 스크롤 허용          | 긴 텍스트 표시    |
| **SelectedIndex / SelectedItem (ComboBox)** | 선택 항목           | 데이터 처리 시 핵심 |
| **DropDownStyle (ComboBox)**                | DropDown / List | 입력 가능 여부 결정 |
| **Value (NumericUpDown)**                   | 현재 숫자 값         | 수치 입력       |

### 버튼/체크류 (Button, CheckBox, RadioButton)
| 속성명                                | 설명         | 특징              |
| ---------------------------------- | ---------- | --------------- |
| **Text**                           | 표시 텍스트     | 버튼/라벨 이름        |
| **Checked (CheckBox/RadioButton)** | 선택 여부      | 로직 분기용          |
| **AutoCheck**                      | 클릭 시 자동 토글 | 직접 제어시 False로 둠 |
| **FlatStyle**                      | 평면/3D 스타일  | 디자인 커스터마이징      |
| **Image / ImageAlign / TextAlign** | 아이콘 + 정렬   | GUI 강화          |

### 표시/출력류 (Label, PictureBox, ProgressBar 등)
| 속성명                       | 설명        | 특징               |
| ------------------------- | --------- | ---------------- |
| **Text (Label)**          | 표시 텍스트    | 상태·결과 출력         |
| **Image (PictureBox)**    | 표시 이미지    | 시각 자료            |
| **SizeMode (PictureBox)** | 이미지 크기 조정 | Zoom / Stretch 등 |
| **Value (ProgressBar)**   | 진행률 값     | 상태 시각화           |
| **Minimum / Maximum**     | 진행 범위     | ProgressBar 기준선  |

### 리스트/트리류 (ListBox, ListView, TreeView, DataGridView)
| 속성명                                          | 설명            | 특징           |
| -------------------------------------------- | ------------- | ------------ |
| **Items / Nodes / Rows**                     | 항목 목록         | 데이터 추가/삭제    |
| **SelectedIndex / SelectedItem**             | 선택 항목         | 이벤트 트리거      |
| **MultiSelect (ListView)**                   | 다중 선택 허용      | UI 선택 유연화    |
| **View (ListView)**                          | 아이콘 / 상세 / 타일 | 보기 형식        |
| **Columns (ListView/DataGridView)**          | 열 정의          | 테이블 형식       |
| **DataSource / DisplayMember / ValueMember** | 데이터 바인딩       | DB/리스트 자동 표시 |

### 타이머/프로세스/비시각 구성요소
| 속성명                     | 설명        | 특징          |
| ----------------------- | --------- | ----------- |
| **Enabled**             | 동작 여부     | 시작/정지 제어    |
| **Interval (Timer)**    | 주기(ms)    | Tick 이벤트 주기 |
| **StartInfo (Process)** | 실행정보      | 외부 실행 설정    |
| **SynchronizingObject** | UI 스레드 연결 | UI 업데이트 안전성 |

### 데이터 및 바인딩 (BindingSource, DataGridView)
| 속성명                     | 설명       | 특징                    |
| ----------------------- | -------- | --------------------- |
| **DataSource**          | 연결 데이터   | List, DataTable, DB 등 |
| **DataMember**          | 연결된 멤버   | 특정 테이블/뷰              |
| **Filter / Sort**       | 필터링/정렬   | 표시 데이터 제어             |
| **AutoGenerateColumns** | 열 자동 생성  | 수동 정의 시 False         |
| **ReadOnly**            | 수정 가능 여부 | 표시 전용 모드              |
| **SelectionMode**       | 선택 단위    | Row / Cell 단위 설정      |

### 이벤트(공통적으로 자주 연결)
| 이벤트명                     | 설명       | 자주 쓰는 컨트롤                     |
| ------------------------ | -------- | ----------------------------- |
| **Click**                | 클릭 시     | Button, Label                 |
| **CheckedChanged**       | 체크 상태 변경 | CheckBox, RadioButton         |
| **TextChanged**          | 텍스트 변경 시 | TextBox, ComboBox             |
| **SelectedIndexChanged** | 선택 변경    | ComboBox, ListBox             |
| **ValueChanged**         | 수치/날짜 변경 | NumericUpDown, DateTimePicker |
| **Tick**                 | 주기 실행    | Timer                         |
| **Load**                 | 폼 로드시 실행 | Form                          |
| **FormClosing**          | 폼 닫기 전   | Form                          |
