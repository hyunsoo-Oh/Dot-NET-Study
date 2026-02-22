using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEdit
{
    internal class TextEditClass
    {
        // readonly : 생성할 때 한 번만 값이 설정되고, 이후에는 변경되면 안 되는 변수
        private readonly TabControl tabControl;
        private int documentIndex = 0;
        public TextEditClass(TabControl tabControl)
        {
            this.tabControl = tabControl;
        }

        /// <summary>
        /// 비어 있는 새 페이지 탭 생성
        /// 이름은 New Page, New Page (1), New Page (2) ... 자동 부여
        /// </summary>
        public void CreateEmptyPage()
        {
            string title = GetNextNewPageTitle();  // 자동 이름 생성
            CreateDocumentTabInternal(null, title);
        }

        /// <summary>
        /// 파일을 열어서 내용을 채운 탭 생성
        /// </summary>
        public void CreatePageFromFile(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            CreateDocumentTabInternal(filePath, fileName);
        }

        /// <summary>
        /// 실제 탭 생성 공통 함수
        /// - filePath == null이면 빈 문서
        /// - filePath != null이면 해당 파일 내용을 로드
        /// </summary>
        private void CreateDocumentTabInternal(string filePath, string tabTitle)
        {
            // 1) 새 TabPage 생성
            TabPage tabPage = new TabPage(tabTitle);

            // 2) 왼쪽 줄 번호/변경 라인 표시용 Panel
            Panel panelLine = new Panel();
            panelLine.Name = $"panelLine_{documentIndex}";
            panelLine.Dock = DockStyle.Left;
            panelLine.Width = 50;
            panelLine.BackColor = Color.FromArgb(240, 240, 240);

            // 3) 오른쪽 편집기 RichTextBox (txtLine 역할)
            RichTextBox txtLine = new RichTextBox();
            txtLine.Name = $"txtLine_{documentIndex}";
            txtLine.Dock = DockStyle.Fill;
            txtLine.BorderStyle = BorderStyle.None;
            txtLine.Font = new Font("Consolas", 11);
            txtLine.AcceptsTab = true;
            txtLine.WordWrap = false;                         // 줄 번호와 맞추기 위해 자동 줄바꿈 해제
            txtLine.ScrollBars = RichTextBoxScrollBars.Both;

            // 4) 파일 내용 로드 (filePath가 있는 경우만)
            if (!string.IsNullOrEmpty(filePath))
            {
                txtLine.LoadFile(filePath, RichTextBoxStreamType.PlainText);
            }

            // 5) 이벤트 연결 (줄 번호/변경 라인 표시용 틀)
            txtLine.VScroll += TxtLine_VScroll;
            txtLine.TextChanged += TxtLine_TextChanged;
            txtLine.Resize += TxtLine_Resize;
            panelLine.Paint += PanelLine_Paint;

            // 6) 생성한 Panel과 RichTextBox를 TabPage에 실제로 붙여야 화면에 보인다
            tabPage.Controls.Add(txtLine);     // Fill이 먼저
            tabPage.Controls.Add(panelLine);   // Left가 나중

            // 7) "+ 탭" 바로 앞에 삽입해서 항상 + 탭이 맨 오른쪽이 되도록 함
            TabPage plusTab = FindPlusTabPage();
            if (plusTab != null)
            {
                int insertIndex = tabControl.TabPages.IndexOf(plusTab);
                if (insertIndex < 0) insertIndex = tabControl.TabPages.Count;
                tabControl.TabPages.Insert(insertIndex, tabPage);
            }
            else
            {
                // + 탭이 없다면 그냥 맨 뒤에 추가
                tabControl.TabPages.Add(tabPage);
            }

            // 새 탭 선택
            tabControl.SelectedTab = tabPage;

            documentIndex++;
        }

        /// <summary>
        /// New Page, New Page (1), New Page (2) ... 중 다음 이름 반환
        /// </summary>
        private string GetNextNewPageTitle()
        {
            bool baseExists = false;
            int maxIndex = 0;

            foreach (TabPage page in tabControl.TabPages)
            {
                if (page.Text == "New Page")
                {
                    baseExists = true;
                }
                else if (page.Text.StartsWith("New Page (") && page.Text.EndsWith(")"))
                {
                    // 괄호 안 숫자만 파싱
                    string inner = page.Text.Substring("New Page (".Length,
                                      page.Text.Length - "New Page (".Length - 1);
                    if (int.TryParse(inner, out int n))
                    {
                        if (n > maxIndex) maxIndex = n;
                    }
                }
            }

            if (!baseExists)
                return "New Page";         // 최초 생성
            else
                return $"New Page ({maxIndex + 1})";
        }

        /// <summary>
        /// TabControl 안에서 "+" 탭 찾기
        /// (Text가 "+" 인 TabPage를 + 탭으로 간주)
        /// </summary>
        private TabPage FindPlusTabPage()
        {
            foreach (TabPage page in tabControl.TabPages)
            {
                if (page.Text == "+")
                    return page;
            }
            return null;
        }

        // --------- 아래는 줄 번호/변경 라인 표시용 이벤트 틀 ---------

        private void TxtLine_VScroll(object sender, EventArgs e)
        {
            // 스크롤 시 줄 번호 Panel을 다시 그리게 함
            var editor = sender as RichTextBox;
            Panel panel = FindPanelForEditor(editor);
            panel?.Invalidate();
        }

        private void TxtLine_TextChanged(object sender, EventArgs e)
        {
            // 텍스트 변경 시 변경 라인 표시를 위해 Panel 다시 그리기
            var editor = sender as RichTextBox;
            Panel panel = FindPanelForEditor(editor);
            panel?.Invalidate();
        }

        private void TxtLine_Resize(object sender, EventArgs e)
        {
            // 크기 변경 시 줄 번호/표시 다시 계산
            var editor = sender as RichTextBox;
            Panel panel = FindPanelForEditor(editor);
            panel?.Invalidate();
        }

        private void PanelLine_Paint(object sender, PaintEventArgs e)
        {
            // TODO:
            // 1) 연결된 RichTextBox의 첫 줄/마지막 줄 인덱스 계산
            // 2) e.Graphics.DrawString으로 줄 번호 그리기
            // 3) 변경 라인은 다른 색으로 배경/텍스트 표시
            // => 이후 단계에서 세부 로직 구현 예정
        }

        /// <summary>
        /// RichTextBox가 속한 TabPage에서 같은 탭의 PanelLine 찾기
        /// </summary>
        private Panel FindPanelForEditor(RichTextBox editor)
        {
            if (editor?.Parent is TabPage page)
            {
                foreach (Control ctl in page.Controls)
                {
                    if (ctl is Panel p && p.Dock == DockStyle.Left)
                        return p;
                }
            }
            return null;
        }
    }
}
