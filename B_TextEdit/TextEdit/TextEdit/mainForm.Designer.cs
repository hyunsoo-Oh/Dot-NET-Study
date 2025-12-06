namespace TextEdit
{
    partial class mainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.EditMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.EncodingMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabNew = new System.Windows.Forms.TabPage();
            this.panelLine = new System.Windows.Forms.Panel();
            this.txtLine = new System.Windows.Forms.RichTextBox();
            this.새로만들기NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.열기OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.저장SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.다른이름으로저장AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.페이지설정UToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.인쇄PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.끝내기XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.잘라내기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.복사CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.환경설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.스타일설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.단축키설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBar.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuBar
            // 
            this.menuBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.EditMenu,
            this.SearchMenu,
            this.EncodingMenu,
            this.SettingMenu});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(800, 28);
            this.menuBar.TabIndex = 0;
            this.menuBar.Text = "menuStrip1";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.새로만들기NToolStripMenuItem,
            this.열기OToolStripMenuItem,
            this.저장SToolStripMenuItem,
            this.다른이름으로저장AToolStripMenuItem,
            this.toolStripSeparator1,
            this.페이지설정UToolStripMenuItem,
            this.인쇄PToolStripMenuItem,
            this.toolStripSeparator2,
            this.끝내기XToolStripMenuItem});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(70, 24);
            this.FileMenu.Text = "파일(F)";
            // 
            // EditMenu
            // 
            this.EditMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.잘라내기ToolStripMenuItem,
            this.복사CToolStripMenuItem});
            this.EditMenu.Name = "EditMenu";
            this.EditMenu.Size = new System.Drawing.Size(71, 24);
            this.EditMenu.Text = "편집(E)";
            // 
            // SearchMenu
            // 
            this.SearchMenu.Name = "SearchMenu";
            this.SearchMenu.Size = new System.Drawing.Size(71, 24);
            this.SearchMenu.Text = "찾기(S)";
            // 
            // EncodingMenu
            // 
            this.EncodingMenu.Name = "EncodingMenu";
            this.EncodingMenu.Size = new System.Drawing.Size(89, 24);
            this.EncodingMenu.Text = "인코딩(N)";
            // 
            // SettingMenu
            // 
            this.SettingMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.환경설정ToolStripMenuItem,
            this.스타일설정ToolStripMenuItem,
            this.단축키설정ToolStripMenuItem});
            this.SettingMenu.Name = "SettingMenu";
            this.SettingMenu.Size = new System.Drawing.Size(71, 24);
            this.SettingMenu.Text = "설정(T)";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtLine);
            this.tabPage1.Controls.Add(this.panelLine);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 393);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabNew);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 28);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 422);
            this.tabControl.TabIndex = 1;
            // 
            // tabNew
            // 
            this.tabNew.Location = new System.Drawing.Point(4, 25);
            this.tabNew.Name = "tabNew";
            this.tabNew.Size = new System.Drawing.Size(792, 391);
            this.tabNew.TabIndex = 1;
            this.tabNew.Text = "+";
            this.tabNew.UseVisualStyleBackColor = true;
            // 
            // panelLine
            // 
            this.panelLine.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLine.Location = new System.Drawing.Point(3, 3);
            this.panelLine.Name = "panelLine";
            this.panelLine.Size = new System.Drawing.Size(71, 387);
            this.panelLine.TabIndex = 1;
            // 
            // txtLine
            // 
            this.txtLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLine.Location = new System.Drawing.Point(74, 3);
            this.txtLine.Name = "txtLine";
            this.txtLine.Size = new System.Drawing.Size(715, 387);
            this.txtLine.TabIndex = 2;
            this.txtLine.Text = "";
            // 
            // 새로만들기NToolStripMenuItem
            // 
            this.새로만들기NToolStripMenuItem.Name = "새로만들기NToolStripMenuItem";
            this.새로만들기NToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.새로만들기NToolStripMenuItem.Text = "새로만들기(N)";
            // 
            // 열기OToolStripMenuItem
            // 
            this.열기OToolStripMenuItem.Name = "열기OToolStripMenuItem";
            this.열기OToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.열기OToolStripMenuItem.Text = "열기(O)";
            // 
            // 저장SToolStripMenuItem
            // 
            this.저장SToolStripMenuItem.Name = "저장SToolStripMenuItem";
            this.저장SToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.저장SToolStripMenuItem.Text = "저장(S)";
            // 
            // 다른이름으로저장AToolStripMenuItem
            // 
            this.다른이름으로저장AToolStripMenuItem.Name = "다른이름으로저장AToolStripMenuItem";
            this.다른이름으로저장AToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.다른이름으로저장AToolStripMenuItem.Text = "다른 이름으로 저장(A)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(239, 6);
            // 
            // 페이지설정UToolStripMenuItem
            // 
            this.페이지설정UToolStripMenuItem.Name = "페이지설정UToolStripMenuItem";
            this.페이지설정UToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.페이지설정UToolStripMenuItem.Text = "페이지 설정(U)";
            // 
            // 인쇄PToolStripMenuItem
            // 
            this.인쇄PToolStripMenuItem.Name = "인쇄PToolStripMenuItem";
            this.인쇄PToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.인쇄PToolStripMenuItem.Text = "인쇄(P)";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(239, 6);
            // 
            // 끝내기XToolStripMenuItem
            // 
            this.끝내기XToolStripMenuItem.Name = "끝내기XToolStripMenuItem";
            this.끝내기XToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.끝내기XToolStripMenuItem.Text = "끝내기(X)";
            // 
            // 잘라내기ToolStripMenuItem
            // 
            this.잘라내기ToolStripMenuItem.Name = "잘라내기ToolStripMenuItem";
            this.잘라내기ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.잘라내기ToolStripMenuItem.Text = "잘라내기";
            // 
            // 복사CToolStripMenuItem
            // 
            this.복사CToolStripMenuItem.Name = "복사CToolStripMenuItem";
            this.복사CToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.복사CToolStripMenuItem.Text = "복사(C)";
            // 
            // 환경설정ToolStripMenuItem
            // 
            this.환경설정ToolStripMenuItem.Name = "환경설정ToolStripMenuItem";
            this.환경설정ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.환경설정ToolStripMenuItem.Text = "환경설정";
            // 
            // 스타일설정ToolStripMenuItem
            // 
            this.스타일설정ToolStripMenuItem.Name = "스타일설정ToolStripMenuItem";
            this.스타일설정ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.스타일설정ToolStripMenuItem.Text = "스타일 설정";
            // 
            // 단축키설정ToolStripMenuItem
            // 
            this.단축키설정ToolStripMenuItem.Name = "단축키설정ToolStripMenuItem";
            this.단축키설정ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.단축키설정ToolStripMenuItem.Text = "단축키 설정";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuBar);
            this.MainMenuStrip = this.menuBar;
            this.Name = "mainForm";
            this.Text = "Form1";
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.ToolStripMenuItem EditMenu;
        private System.Windows.Forms.ToolStripMenuItem FileMenu;
        private System.Windows.Forms.ToolStripMenuItem SearchMenu;
        private System.Windows.Forms.ToolStripMenuItem EncodingMenu;
        private System.Windows.Forms.ToolStripMenuItem SettingMenu;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabNew;
        private System.Windows.Forms.Panel panelLine;
        private System.Windows.Forms.RichTextBox txtLine;
        private System.Windows.Forms.ToolStripMenuItem 새로만들기NToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 열기OToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 저장SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 다른이름으로저장AToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 페이지설정UToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 인쇄PToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 끝내기XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 잘라내기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 복사CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 환경설정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 스타일설정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 단축키설정ToolStripMenuItem;
    }
}

