## 컴포넌트 종류
### 공용 컨트롤
| 컨트롤            | 용도            | 언제 사용        |
| -------------- | ------------- | ------------ |
| Button         | 클릭 명령         | 액션 트리거       |
| CheckBox       | On/Off 토글(다중) | 독립 옵션        |
| CheckedListBox | 리스트+체크        | 여러 항목 선택     |
| ComboBox       | 드롭다운 선택/입력    | 공간 절약, 제한 선택 |
| DateTimePicker | 날짜/시간 입력      | 유효 날짜 보장     |
| Label          | 설명 텍스트        | 캡션/상태 표시     |
| LinkLabel      | 링크 라벨         | URL/문서 이동    |
| ListBox        | 리스트 선택        | 단/다중 간단 선택   |
| ListView       | 파일탐색기형 리스트    | 아이콘/자세히/타일   |
| MaskedTextBox  | 형식 제한 입력      | 전화/주민번호 등    |
| MonthCalendar  | 달력 UI         | 날짜/범위 선택     |
| NotifyIcon     | 트레이 아이콘       | 백그라운드 앱      |
| NumericUpDown  | 숫자 스핀         | 범위·증분 강제     |
| PictureBox     | 이미지 표시        | 아이콘/프리뷰      |
| ProgressBar    | 진행률 표시        | 작업 상태        |
| RadioButton    | 상호배타 선택       | 한 가지만 선택     |
| RichTextBox    | 서식 텍스트        | 로그/문서 편집     |
| TextBox        | 텍스트 입력        | 단/다중 줄 입력    |
| ToolTip        | 풍선 도움말        | 사용성 향상       |
| TreeView       | 계층 표시         | 폴더/트리 구조     |


### 컨테이너
| 컨트롤              | 용도      | 언제 사용        |
| ---------------- | ------- | ------------ |
| FlowLayoutPanel  | 흐름 배치   | 가변 개수 자동 정렬  |
| GroupBox         | 시각 그룹   | 옵션 묶기/라디오 그룹 |
| Panel            | 경량 컨테이너 | 스크롤/도킹 영역    |
| SplitContainer   | 분할창     | 리사이즈 가능한 2영역 |
| TabControl       | 탭 전환    | 기능 구역화       |
| TableLayoutPanel | 그리드 배치  | 정렬·반응형 레이아웃  |


### 메뉴 및 도구 모음
| 컨트롤                | 용도      | 언제 사용         |
| ------------------ | ------- | ------------- |
| MenuStrip          | 상단 메뉴바  | 파일/편집 등 표준 메뉴 |
| ContextMenuStrip   | 우클릭 메뉴  | 컨텍스트 명령       |
| StatusStrip        | 하단 상태바  | 진행/모드/메시지     |
| ToolStrip          | 아이콘 툴바  | 자주 쓰는 명령      |
| ToolStripContainer | 스트립 배치용 | 복수 스트립 레이아웃   |


### 구성요소
| 컴포넌트              | 용도         | 언제 사용                 |
| ----------------- | ---------- | --------------------- |
| BackgroundWorker  | 백그라운드 작업   | UI 멈춤 방지(구형)          |
| ErrorProvider     | 입력 오류 표시   | 검증 피드백                |
| FileSystemWatcher | 파일 변경 감시   | 실시간 동기화               |
| HelpProvider      | F1 도움말     | 컨텍스트 헬프               |
| ImageList         | 아이콘 묶음     | ListView/TreeView와 함께 |
| Process           | 외부 프로세스 실행 | 도구/스크립트 호출            |
| Timer             | 주기 이벤트     | 주기 갱신/폴링              |

### 인쇄
| 항목                         | 용도        | 언제 사용      |
| -------------------------- | --------- | ---------- |
| PrintDocument              | 출력 렌더링 핵심 | 그리기 이벤트 구현 |
| PageSetupDialog            | 페이지 설정    | 여백/방향      |
| PrintDialog                | 프린터 선택    | 인쇄 전 설정    |
| PrintPreviewControl/Dialog | 미리보기      | 출력 확인      |


### 데이터
| 컨트롤                 | 용도    | 언제 사용    |
| ------------------- | ----- | -------- |
| ColorDialog         | 색상 선택 | 테마/펜 색   |
| FolderBrowserDialog | 폴더 선택 | 저장 위치 선택 |
| FontDialog          | 글꼴 선택 | 편집기/표시   |
| OpenFileDialog      | 파일 열기 | 입력 파일 선택 |
| SaveFileDialog      | 파일 저장 | 내보내기 저장  |

### 대화
| 컨트롤           | 용도     | 언제 사용       |
| ------------- | ------ | ----------- |
| BindingSource | 바인딩 허브 | 데이터/컨트롤 동기화 |
| DataGridView  | 표 데이터  | 레코드 표시·편집   |
