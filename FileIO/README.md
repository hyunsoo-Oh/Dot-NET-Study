# FileIO 프로그램

본 프로젝트는 **파일 IO와 직렬화의 차이**, **사용 목적**,  
그리고 **WinForms 기반 UI 설계 구조**를 명확히 이해하는 것을 목표로 합니다.

## 2. 기능 개요

## 2.1 파일 IO (문자열 파일 입출력)

**목적**  
사람이 읽고 확인하기 위한 텍스트 데이터를 파일로 저장/로드

**활용 사례**
- 로그 저장  
  - 장비 통신 로그  
  - 이벤트 로그  
  - 오류(Error) 로그  

- 리포트 / 덤프  
  - 결과 데이터 TXT / CSV 출력  

- 작업 메모 / 스크립트  
  - 사용자가 입력한 명령, 설정 문자열 보관  

**특징**
- 구조 없음 (자유 텍스트)
- 사람이 직접 열어 확인 가능
- UTF-8 기반 저장

---

## 2.2 직렬화 (Serialization)

**목적**  
프로그램의 상태를 **정확히 복원**하기 위한 데이터 저장

**핵심 개념**
- 필드 이름
- 데이터 타입
- 객체 구조(계층)

이 모두가 **의미를 가지는 저장 방식**

**활용 사례**
- 설정 저장 / 불러오기  
  - 마지막 사용 포트  
  - IP 주소  
  - 파일 경로  
  - 옵션 값  
  - UI 상태  

- 프로젝트 저장  
  - 사용자 입력 값 묶음  
  - 장비 파라미터 세트  
  - 측정 조건 프리셋  

- 작업 복원  
  - 프로그램 종료 후 재실행 시 이전 상태 유지  

**저장 포맷**
- JSON (가독성 + 확장성)

---

## 3. UI 구성
### 기본 레이아웃
```
MenuStrip
TabControl
├─ Text File IO
└─ Serialization (JSON)
```
## 3.1 MainForm

- 구성: MenuStrip (상단) + TabControl (중앙) + StatusStrip (하단)

- 폼 이름: MainForm

- 추천 속성

    - StartPosition = CenterScreen

    - MinimumSize = 900 x 600

    - Text = "File IO & Serialization Tool"

## 3.2 MenuStrip

- File  

    - menuNew : 새로 만들기(텍스트/프로필 초기화)  

    - menuOpen : 열기(현재 탭 기준)
    - menuSave : 저장(현재 탭 기준)
    - menuExit : 종료

#### TabControl

- TabControl: tabMain (Dock = Fill)

    - TabPage1: tabTextIO (Text = "Text File IO")

    - TabPage2: tabSerialize (Text = "Serialization (JSON)")

## 4. Text File IO 탭 설계

### 4.1 목적
- 문자열을 파일로 저장
- 파일 내용을 다시 불러와 표시

#### 상단 영역 (파일 경로 & 제어 버튼)
- Label: `File Path`
- TextBox: `txtTextPath`
  - ReadOnly
- Button
  - `Browse`
  - `New`
  - `Save`
  - `Load`

#### 중앙 영역 (텍스트 편집/미리보기)

- SplitContainer (좌/우)

##### 좌측: Editor
- GroupBox: `Editor`
- TextBox:
  - Multiline
  - ScrollBars: Both
  - WordWrap: false
  - Font: Consolas

##### 우측: Preview (Loaded)
- GroupBox: `Preview`
- TextBox:
  - ReadOnly
  - Multiline
  - ScrollBars: Both

  ### 4.3 사용 시나리오
1. 텍스트 입력
2. Save → 파일 생성 및 저장
3. Load → 파일 읽기
4. Preview 영역에 결과 표시

## 5. Serialization (JSON) 탭 설계

### 5.1 목적
- 구조화된 데이터를 JSON으로 저장/복원
- 프로그램 상태 관리 개념 학습


### 5.2 UI 구성

#### 상단 영역 (JSON 파일 경로)
- Label: `Profile File`
- TextBox: `txtJsonPath`
- Button
  - `Browse`
  - `New`
  - `Save JSON`
  - `Load JSON`

  #### 중앙 영역 (입력 + 객체 뷰)

- SplitContainer (좌/우)

##### 좌측: Profile Input
- Label + TextBox
  - `Var1`
  - `Var2`
- (선택)
  - Version
  - 옵션 값

##### 우측: Object View
- PropertyGrid
  - 현재 ProfileModel 표시
  - 실제 직렬화 대상 구조 확인용