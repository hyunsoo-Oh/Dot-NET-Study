# Console 창 띄우기
```C#
public partial class MainForm : Form
{
    [DllImport("kernel32.dll")]
    public static extern bool AllocConsole();

    public MainForm()
    {
        InitializeComponent();

        AllocConsole();
    }
}
```