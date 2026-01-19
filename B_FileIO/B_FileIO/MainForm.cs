using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B_FileIO
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            CenterSplit(splitContainer_FileIO);
            CenterSplit(splitContainer_Serial);
        }

        // SplitContainerControl 중앙 분리
        private void CenterSplit(SplitContainer sc)
        {
            if (sc.Orientation == Orientation.Vertical)
                sc.SplitterDistance = (sc.ClientSize.Width - sc.SplitterWidth) / 2;
            else
                sc.SplitterDistance = (sc.ClientSize.Height - sc.SplitterWidth) / 2;
        }
    }
}
