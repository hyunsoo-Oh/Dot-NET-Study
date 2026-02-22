namespace B_FileIO
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl_FileManage = new System.Windows.Forms.TabControl();
            this.tabPage_FileIO = new System.Windows.Forms.TabPage();
            this.tabPage_Serial = new System.Windows.Forms.TabPage();
            this.panel_Top = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer_FileIO = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button_New = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Load = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.splitContainer_Serial = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.menuStrip1.SuspendLayout();
            this.tabControl_FileManage.SuspendLayout();
            this.tabPage_FileIO.SuspendLayout();
            this.tabPage_Serial.SuspendLayout();
            this.panel_Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_FileIO)).BeginInit();
            this.splitContainer_FileIO.Panel1.SuspendLayout();
            this.splitContainer_FileIO.Panel2.SuspendLayout();
            this.splitContainer_FileIO.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Serial)).BeginInit();
            this.splitContainer_Serial.Panel1.SuspendLayout();
            this.splitContainer_Serial.Panel2.SuspendLayout();
            this.splitContainer_Serial.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(878, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(55, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // tabControl_FileManage
            // 
            this.tabControl_FileManage.Controls.Add(this.tabPage_FileIO);
            this.tabControl_FileManage.Controls.Add(this.tabPage_Serial);
            this.tabControl_FileManage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_FileManage.Location = new System.Drawing.Point(0, 33);
            this.tabControl_FileManage.Name = "tabControl_FileManage";
            this.tabControl_FileManage.SelectedIndex = 0;
            this.tabControl_FileManage.Size = new System.Drawing.Size(878, 511);
            this.tabControl_FileManage.TabIndex = 1;
            // 
            // tabPage_FileIO
            // 
            this.tabPage_FileIO.Controls.Add(this.splitContainer_FileIO);
            this.tabPage_FileIO.Controls.Add(this.panel_Top);
            this.tabPage_FileIO.Location = new System.Drawing.Point(4, 28);
            this.tabPage_FileIO.Name = "tabPage_FileIO";
            this.tabPage_FileIO.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_FileIO.Size = new System.Drawing.Size(870, 479);
            this.tabPage_FileIO.TabIndex = 0;
            this.tabPage_FileIO.Text = "FileIO";
            this.tabPage_FileIO.UseVisualStyleBackColor = true;
            // 
            // tabPage_Serial
            // 
            this.tabPage_Serial.Controls.Add(this.splitContainer_Serial);
            this.tabPage_Serial.Controls.Add(this.panel1);
            this.tabPage_Serial.Location = new System.Drawing.Point(4, 28);
            this.tabPage_Serial.Name = "tabPage_Serial";
            this.tabPage_Serial.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Serial.Size = new System.Drawing.Size(870, 479);
            this.tabPage_Serial.TabIndex = 1;
            this.tabPage_Serial.Text = "Serialization";
            this.tabPage_Serial.UseVisualStyleBackColor = true;
            // 
            // panel_Top
            // 
            this.panel_Top.Controls.Add(this.button_Load);
            this.panel_Top.Controls.Add(this.button_Save);
            this.panel_Top.Controls.Add(this.button_New);
            this.panel_Top.Controls.Add(this.button1);
            this.panel_Top.Controls.Add(this.textBox1);
            this.panel_Top.Controls.Add(this.label1);
            this.panel_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Top.Location = new System.Drawing.Point(3, 3);
            this.panel_Top.Name = "panel_Top";
            this.panel_Top.Size = new System.Drawing.Size(864, 76);
            this.panel_Top.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Location = new System.Drawing.Point(0, 522);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(878, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer_FileIO
            // 
            this.splitContainer_FileIO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_FileIO.Location = new System.Drawing.Point(3, 79);
            this.splitContainer_FileIO.Name = "splitContainer_FileIO";
            // 
            // splitContainer_FileIO.Panel1
            // 
            this.splitContainer_FileIO.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer_FileIO.Panel2
            // 
            this.splitContainer_FileIO.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer_FileIO.Size = new System.Drawing.Size(864, 397);
            this.splitContainer_FileIO.SplitterDistance = 430;
            this.splitContainer_FileIO.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 397);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Editor";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(430, 397);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Preview(Loaded)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(15, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Path:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox1.Location = new System.Drawing.Point(112, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(290, 33);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(413, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Browse...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button_New
            // 
            this.button_New.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_New.Location = new System.Drawing.Point(548, 22);
            this.button_New.Name = "button_New";
            this.button_New.Size = new System.Drawing.Size(90, 35);
            this.button_New.TabIndex = 3;
            this.button_New.Text = "New";
            this.button_New.UseVisualStyleBackColor = true;
            // 
            // button_Save
            // 
            this.button_Save.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_Save.Location = new System.Drawing.Point(654, 22);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(90, 35);
            this.button_Save.TabIndex = 4;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            // 
            // button_Load
            // 
            this.button_Load.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_Load.Location = new System.Drawing.Point(760, 22);
            this.button_Load.Name = "button_Load";
            this.button_Load.Size = new System.Drawing.Size(90, 35);
            this.button_Load.TabIndex = 5;
            this.button_Load.Text = "Load";
            this.button_Load.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Location = new System.Drawing.Point(3, 24);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(424, 370);
            this.textBox2.TabIndex = 0;
            // 
            // textBox3
            // 
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox3.Location = new System.Drawing.Point(3, 24);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox3.Size = new System.Drawing.Size(424, 370);
            this.textBox3.TabIndex = 1;
            // 
            // splitContainer_Serial
            // 
            this.splitContainer_Serial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Serial.Location = new System.Drawing.Point(3, 79);
            this.splitContainer_Serial.Name = "splitContainer_Serial";
            // 
            // splitContainer_Serial.Panel1
            // 
            this.splitContainer_Serial.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer_Serial.Panel2
            // 
            this.splitContainer_Serial.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer_Serial.Size = new System.Drawing.Size(864, 397);
            this.splitContainer_Serial.SplitterDistance = 429;
            this.splitContainer_Serial.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox5);
            this.groupBox3.Controls.Add(this.textBox4);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(429, 397);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Profile Input";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.propertyGrid1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(431, 397);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Object View";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.textBox6);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(864, 76);
            this.panel1.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.Location = new System.Drawing.Point(760, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 35);
            this.button2.TabIndex = 5;
            this.button2.Text = "Load";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button3.Location = new System.Drawing.Point(654, 22);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 35);
            this.button3.TabIndex = 4;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button4.Location = new System.Drawing.Point(548, 22);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(90, 35);
            this.button4.TabIndex = 3;
            this.button4.Text = "New";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button5.Location = new System.Drawing.Point(413, 22);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(120, 35);
            this.button5.TabIndex = 2;
            this.button5.Text = "Browse...";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox6.Location = new System.Drawing.Point(112, 22);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(290, 33);
            this.textBox6.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(15, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "File Path:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(15, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "File Path:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(15, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 22);
            this.label4.TabIndex = 7;
            this.label4.Text = "File Path:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(15, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 22);
            this.label5.TabIndex = 8;
            this.label5.Text = "Version:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(19, 196);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(157, 22);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Enable Logging";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox4.Location = new System.Drawing.Point(117, 48);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(290, 33);
            this.textBox4.TabIndex = 6;
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox5.Location = new System.Drawing.Point(117, 97);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(290, 33);
            this.textBox5.TabIndex = 10;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(3, 24);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(425, 370);
            this.propertyGrid1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 544);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl_FileManage);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl_FileManage.ResumeLayout(false);
            this.tabPage_FileIO.ResumeLayout(false);
            this.tabPage_Serial.ResumeLayout(false);
            this.panel_Top.ResumeLayout(false);
            this.panel_Top.PerformLayout();
            this.splitContainer_FileIO.Panel1.ResumeLayout(false);
            this.splitContainer_FileIO.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_FileIO)).EndInit();
            this.splitContainer_FileIO.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.splitContainer_Serial.Panel1.ResumeLayout(false);
            this.splitContainer_Serial.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Serial)).EndInit();
            this.splitContainer_Serial.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TabControl tabControl_FileManage;
        private System.Windows.Forms.TabPage tabPage_FileIO;
        private System.Windows.Forms.TabPage tabPage_Serial;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel_Top;
        private System.Windows.Forms.SplitContainer splitContainer_FileIO;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_Load;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_New;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.SplitContainer splitContainer_Serial;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}

