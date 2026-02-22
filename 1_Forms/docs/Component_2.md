# Component_2
### 사용자 입력 기반 시스템 다이얼로그

#### **Open FileDialog** : 파일 열기 경로를 선택하는 표준 다이얼로그.
```C#
/* ==== Designer ==== */
// Filter = "텍스트 파일 (*.txt)|*.txt|모든 파일 (*.*)|*.*"
// Multiselect = false
// InitialDirectory = "C:\\

/* ==== Code (form.cs) ==== */
using (OpenFileDialog dlg = new OpenFileDialog())
{
    dlg.Filter = "텍스트 파일 (*.txt)|*.txt|모든 파일 (*.*)|*.*";
    dlg.Multiselect = false;

    if (dlg.ShowDialog() == DialogResult.OK)
    {
        string filePath = dlg.FileName;
        LoadFile(filePath);
    }
}
```

#### **Save FileDialog** : 파일 저장 경로를 선택하는 표준 다이얼로그.
```C#
/* ==== Designer ==== */
// Filter = "CSV 파일 (*.csv)|*.csv"
// DefaultExt = "csv"
// AddExtension = true

/* ==== Code (form.cs) ==== */
using (SaveFileDialog dlg = new SaveFileDialog())
{
    dlg.Filter = "CSV 파일 (*.csv)|*.csv";
    dlg.DefaultExt = "csv";

    if (dlg.ShowDialog() == DialogResult.OK)
    {
        string filePath = dlg.FileName;
        SaveFile(filePath);
    }
}
```

#### **FolderBrowserDialog** : 폴더 선택 다이얼로그
```C#
// Description = "저장할 폴더를 선택하세요"
// ShowNewFolderButton = true

using (FolderBrowserDialog dlg = new FolderBrowserDialog())
{
    dlg.Description = "로그 저장 폴더 선택";

    if (dlg.ShowDialog() == DialogResult.OK)
    {
        string folderPath = dlg.SelectedPath;
        SetLogDirectory(folderPath);
    }
}
```