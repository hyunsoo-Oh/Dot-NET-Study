using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace TextEdit
{
    public partial class mainForm : Form
    {
        TextEditClass txtEdit;
        public mainForm()
        {
            InitializeComponent();

            this.Text = "C# TextEdit";

            txtEdit = new TextEditClass(tabControl);
            MovePlusTabToRightEnd();
            txtEdit.CreateEmptyPage();
            tabControl.SelectedIndexChanged += tabControl_SelectedIndexChanged;
        }

        private void 새로만들기NToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 열기OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 파일 선택 다이얼로그 생성
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            // 다이얼로그 결과 확인
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // txt 파일인지 검사
                if (Path.GetExtension(filePath).ToLower() == ".txt")
                {
                    // TextEditClass를 통해 파일 기반 새 탭 생성
                    txtEdit.CreatePageFromFile(filePath);
                }
                else
                {
                    MessageBox.Show("텍스트 파일만 열 수 있습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void 저장SToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 다른이름으로저장AToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 페이지설정UToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 인쇄PToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 끝내기XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Text가 "+" 인 탭을 찾아 항상 맨 마지막으로 이동
        /// (디자이너에서 위치가 어디든 상관없이 정리)
        /// </summary>
        private void MovePlusTabToRightEnd()
        {
            TabPage plusTab = null;

            foreach (TabPage page in tabControl.TabPages)
            {
                if (page.Text == "+")
                {
                    plusTab = page;
                    break;
                }
            }

            if (plusTab != null)
            {
                tabControl.TabPages.Remove(plusTab);
                tabControl.TabPages.Add(plusTab);   // 맨 뒤에 다시 추가
            }
        }

        /// <summary>
        /// 사용자가 탭을 클릭해서 선택이 바뀔 때 호출
        /// - 만약 선택된 탭이 "+" 탭이면 새 New Page 생성
        /// </summary>
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == null)
                return;

            if (tabControl.SelectedTab.Text == "+")
            {
                // + 탭 클릭됨 → 새 페이지 생성
                txtEdit.CreateEmptyPage();
            }
        }
    }
}

