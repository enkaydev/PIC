namespace PIC_Simulator
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
			this.label1 = new System.Windows.Forms.Label();
			this.box_CodeView = new System.Windows.Forms.RichTextBox();
			this.lbl_path = new System.Windows.Forms.Label();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.cmd_Start = new System.Windows.Forms.Button();
			this.cmd_next = new System.Windows.Forms.Button();
			this.cmd_reset = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.cmdOpenFile = new System.Windows.Forms.ToolStripMenuItem();
			this.programmÖffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cmdOpenDoc = new System.Windows.Forms.ToolStripMenuItem();
			this.label4 = new System.Windows.Forms.Label();
			this.lvMemory = new System.Windows.Forms.ListView();
			this.Index = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.cmd_Stop = new System.Windows.Forms.Button();
			this.insertTime = new System.Windows.Forms.TextBox();
			this.lvSpecial = new System.Windows.Forms.ListView();
			this.c1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.c2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lbStack = new System.Windows.Forms.ListBox();
			this.btn_RA_Tris_7 = new System.Windows.Forms.Button();
			this.btn_RA_Tris_6 = new System.Windows.Forms.Button();
			this.btn_RA_Tris_5 = new System.Windows.Forms.Button();
			this.btn_RA_Tris_4 = new System.Windows.Forms.Button();
			this.btn_RA_Tris_3 = new System.Windows.Forms.Button();
			this.btn_RA_Tris_2 = new System.Windows.Forms.Button();
			this.btn_RA_Tris_1 = new System.Windows.Forms.Button();
			this.btn_RA_1 = new System.Windows.Forms.Button();
			this.btn_RA_2 = new System.Windows.Forms.Button();
			this.btn_RA_3 = new System.Windows.Forms.Button();
			this.btn_RA_4 = new System.Windows.Forms.Button();
			this.btn_RA_5 = new System.Windows.Forms.Button();
			this.btn_RA_6 = new System.Windows.Forms.Button();
			this.btn_RA_7 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.btn_RB_1 = new System.Windows.Forms.Button();
			this.btn_RB_2 = new System.Windows.Forms.Button();
			this.btn_RB_3 = new System.Windows.Forms.Button();
			this.btn_RB_4 = new System.Windows.Forms.Button();
			this.btn_RB_5 = new System.Windows.Forms.Button();
			this.btn_RB_6 = new System.Windows.Forms.Button();
			this.btn_RB_7 = new System.Windows.Forms.Button();
			this.btn_RB_Tris_1 = new System.Windows.Forms.Button();
			this.btn_RB_Tris_2 = new System.Windows.Forms.Button();
			this.btn_RB_Tris_3 = new System.Windows.Forms.Button();
			this.btn_RB_Tris_4 = new System.Windows.Forms.Button();
			this.btn_RB_Tris_5 = new System.Windows.Forms.Button();
			this.btn_RB_Tris_6 = new System.Windows.Forms.Button();
			this.btn_RB_Tris_7 = new System.Windows.Forms.Button();
			this.btn_RB_0 = new System.Windows.Forms.Button();
			this.btn_RB_Tris_0 = new System.Windows.Forms.Button();
			this.btn_RA_0 = new System.Windows.Forms.Button();
			this.btn_RA_Tris_0 = new System.Windows.Forms.Button();
			this.edRS232Log = new System.Windows.Forms.TextBox();
			this.cbxComPorts = new System.Windows.Forms.ComboBox();
			this.btnRSConnect = new System.Windows.Forms.Button();
			this.btnRSDisconnect = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.edClockAddr = new System.Windows.Forms.TextBox();
			this.edClockBit = new System.Windows.Forms.TextBox();
			this.btnClockStart = new System.Windows.Forms.Button();
			this.edCLockFreq = new System.Windows.Forms.TextBox();
			this.WakeUpButton = new System.Windows.Forms.Button();
			this.btnWD1 = new System.Windows.Forms.Button();
			this.btnWD0 = new System.Windows.Forms.Button();
			this.tbWD = new System.Windows.Forms.TextBox();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.SystemColors.Control;
			this.label1.Location = new System.Drawing.Point(29, 78);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(0, 13);
			this.label1.TabIndex = 1;
			// 
			// box_CodeView
			// 
			this.box_CodeView.Location = new System.Drawing.Point(8, 77);
			this.box_CodeView.Margin = new System.Windows.Forms.Padding(2);
			this.box_CodeView.Name = "box_CodeView";
			this.box_CodeView.ReadOnly = true;
			this.box_CodeView.Size = new System.Drawing.Size(626, 600);
			this.box_CodeView.TabIndex = 3;
			this.box_CodeView.Text = "";
			this.box_CodeView.WordWrap = false;
			this.box_CodeView.DoubleClick += new System.EventHandler(this.box_CodeView_DoubleClick);
			// 
			// lbl_path
			// 
			this.lbl_path.AutoSize = true;
			this.lbl_path.Location = new System.Drawing.Point(87, 469);
			this.lbl_path.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbl_path.Name = "lbl_path";
			this.lbl_path.Size = new System.Drawing.Size(0, 13);
			this.lbl_path.TabIndex = 4;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// cmd_Start
			// 
			this.cmd_Start.Location = new System.Drawing.Point(11, 29);
			this.cmd_Start.Margin = new System.Windows.Forms.Padding(2);
			this.cmd_Start.Name = "cmd_Start";
			this.cmd_Start.Size = new System.Drawing.Size(50, 23);
			this.cmd_Start.TabIndex = 5;
			this.cmd_Start.Text = "Start";
			this.cmd_Start.UseVisualStyleBackColor = true;
			this.cmd_Start.Click += new System.EventHandler(this.cmd_Start_Click);
			// 
			// cmd_next
			// 
			this.cmd_next.Location = new System.Drawing.Point(126, 31);
			this.cmd_next.Margin = new System.Windows.Forms.Padding(2);
			this.cmd_next.Name = "cmd_next";
			this.cmd_next.Size = new System.Drawing.Size(50, 21);
			this.cmd_next.TabIndex = 6;
			this.cmd_next.Text = "Schritt";
			this.cmd_next.UseVisualStyleBackColor = true;
			this.cmd_next.Click += new System.EventHandler(this.cmd_next_Click);
			// 
			// cmd_reset
			// 
			this.cmd_reset.Location = new System.Drawing.Point(190, 31);
			this.cmd_reset.Margin = new System.Windows.Forms.Padding(2);
			this.cmd_reset.Name = "cmd_reset";
			this.cmd_reset.Size = new System.Drawing.Size(50, 21);
			this.cmd_reset.TabIndex = 7;
			this.cmd_reset.Text = "Reset";
			this.cmd_reset.UseVisualStyleBackColor = true;
			this.cmd_reset.Click += new System.EventHandler(this.cmd_reset_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdOpenFile,
            this.hilfeToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
			this.menuStrip1.Size = new System.Drawing.Size(1298, 24);
			this.menuStrip1.TabIndex = 9;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// cmdOpenFile
			// 
			this.cmdOpenFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programmÖffnenToolStripMenuItem,
            this.beendenToolStripMenuItem});
			this.cmdOpenFile.Name = "cmdOpenFile";
			this.cmdOpenFile.Size = new System.Drawing.Size(46, 20);
			this.cmdOpenFile.Text = "Datei";
			// 
			// programmÖffnenToolStripMenuItem
			// 
			this.programmÖffnenToolStripMenuItem.Name = "programmÖffnenToolStripMenuItem";
			this.programmÖffnenToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.programmÖffnenToolStripMenuItem.Text = "Programm öffnen";
			this.programmÖffnenToolStripMenuItem.Click += new System.EventHandler(this.programmÖffnenToolStripMenuItem_Click);
			// 
			// beendenToolStripMenuItem
			// 
			this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
			this.beendenToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.beendenToolStripMenuItem.Text = "Beenden";
			this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
			// 
			// hilfeToolStripMenuItem
			// 
			this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdOpenDoc});
			this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
			this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.hilfeToolStripMenuItem.Text = "Hilfe";
			// 
			// cmdOpenDoc
			// 
			this.cmdOpenDoc.Name = "cmdOpenDoc";
			this.cmdOpenDoc.Size = new System.Drawing.Size(195, 22);
			this.cmdOpenDoc.Text = "Dokumentation öffnen";
			this.cmdOpenDoc.Click += new System.EventHandler(this.cmdOpenDoc_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(778, 29);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(95, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "Quarzfrequenz in s";
			// 
			// lvMemory
			// 
			this.lvMemory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Index,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16});
			this.lvMemory.Location = new System.Drawing.Point(711, 78);
			this.lvMemory.Margin = new System.Windows.Forms.Padding(2);
			this.lvMemory.Name = "lvMemory";
			this.lvMemory.Size = new System.Drawing.Size(576, 354);
			this.lvMemory.TabIndex = 14;
			this.lvMemory.UseCompatibleStateImageBehavior = false;
			this.lvMemory.View = System.Windows.Forms.View.Details;
			// 
			// Index
			// 
			this.Index.Text = " ";
			this.Index.Width = 48;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "0";
			this.columnHeader1.Width = 32;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "1";
			this.columnHeader2.Width = 32;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "2";
			this.columnHeader3.Width = 32;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "3";
			this.columnHeader4.Width = 32;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "4";
			this.columnHeader5.Width = 32;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "5";
			this.columnHeader6.Width = 32;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "6";
			this.columnHeader7.Width = 32;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "7";
			this.columnHeader8.Width = 32;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "8";
			this.columnHeader9.Width = 32;
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "9";
			this.columnHeader10.Width = 32;
			// 
			// columnHeader11
			// 
			this.columnHeader11.Text = "A";
			this.columnHeader11.Width = 32;
			// 
			// columnHeader12
			// 
			this.columnHeader12.Text = "B";
			this.columnHeader12.Width = 32;
			// 
			// columnHeader13
			// 
			this.columnHeader13.Text = "C";
			this.columnHeader13.Width = 32;
			// 
			// columnHeader14
			// 
			this.columnHeader14.Text = "D";
			this.columnHeader14.Width = 32;
			// 
			// columnHeader15
			// 
			this.columnHeader15.Text = "E";
			this.columnHeader15.Width = 32;
			// 
			// columnHeader16
			// 
			this.columnHeader16.Text = "F";
			this.columnHeader16.Width = 32;
			// 
			// cmd_Stop
			// 
			this.cmd_Stop.Location = new System.Drawing.Point(64, 30);
			this.cmd_Stop.Margin = new System.Windows.Forms.Padding(2);
			this.cmd_Stop.Name = "cmd_Stop";
			this.cmd_Stop.Size = new System.Drawing.Size(50, 22);
			this.cmd_Stop.TabIndex = 15;
			this.cmd_Stop.Text = "Stop";
			this.cmd_Stop.UseVisualStyleBackColor = true;
			this.cmd_Stop.Click += new System.EventHandler(this.cmd_Stop_Click);
			// 
			// insertTime
			// 
			this.insertTime.Location = new System.Drawing.Point(894, 31);
			this.insertTime.Margin = new System.Windows.Forms.Padding(2);
			this.insertTime.Name = "insertTime";
			this.insertTime.Size = new System.Drawing.Size(47, 20);
			this.insertTime.TabIndex = 17;
			this.insertTime.Text = "500";
			// 
			// lvSpecial
			// 
			this.lvSpecial.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.c1,
            this.c2});
			this.lvSpecial.Location = new System.Drawing.Point(640, 438);
			this.lvSpecial.Margin = new System.Windows.Forms.Padding(2);
			this.lvSpecial.Name = "lvSpecial";
			this.lvSpecial.Size = new System.Drawing.Size(269, 239);
			this.lvSpecial.TabIndex = 18;
			this.lvSpecial.UseCompatibleStateImageBehavior = false;
			this.lvSpecial.View = System.Windows.Forms.View.Details;
			// 
			// c1
			// 
			this.c1.Text = "Name";
			this.c1.Width = 128;
			// 
			// c2
			// 
			this.c2.Text = "Wert";
			this.c2.Width = 128;
			// 
			// lbStack
			// 
			this.lbStack.FormattingEnabled = true;
			this.lbStack.Location = new System.Drawing.Point(640, 78);
			this.lbStack.Name = "lbStack";
			this.lbStack.Size = new System.Drawing.Size(66, 355);
			this.lbStack.TabIndex = 19;
			// 
			// btn_RA_Tris_7
			// 
			this.btn_RA_Tris_7.Location = new System.Drawing.Point(913, 459);
			this.btn_RA_Tris_7.Name = "btn_RA_Tris_7";
			this.btn_RA_Tris_7.Size = new System.Drawing.Size(21, 23);
			this.btn_RA_Tris_7.TabIndex = 20;
			this.btn_RA_Tris_7.Text = "i";
			this.btn_RA_Tris_7.UseVisualStyleBackColor = true;
			this.btn_RA_Tris_7.Click += new System.EventHandler(this.btn_RA_Tris_7_Click);
			// 
			// btn_RA_Tris_6
			// 
			this.btn_RA_Tris_6.Location = new System.Drawing.Point(940, 459);
			this.btn_RA_Tris_6.Name = "btn_RA_Tris_6";
			this.btn_RA_Tris_6.Size = new System.Drawing.Size(21, 23);
			this.btn_RA_Tris_6.TabIndex = 21;
			this.btn_RA_Tris_6.Text = "i";
			this.btn_RA_Tris_6.UseVisualStyleBackColor = true;
			this.btn_RA_Tris_6.Click += new System.EventHandler(this.btn_RA_Tris_6_Click);
			// 
			// btn_RA_Tris_5
			// 
			this.btn_RA_Tris_5.Location = new System.Drawing.Point(967, 459);
			this.btn_RA_Tris_5.Name = "btn_RA_Tris_5";
			this.btn_RA_Tris_5.Size = new System.Drawing.Size(21, 23);
			this.btn_RA_Tris_5.TabIndex = 22;
			this.btn_RA_Tris_5.Text = "i";
			this.btn_RA_Tris_5.UseVisualStyleBackColor = true;
			this.btn_RA_Tris_5.Click += new System.EventHandler(this.btn_RA_Tris_5_Click);
			// 
			// btn_RA_Tris_4
			// 
			this.btn_RA_Tris_4.Location = new System.Drawing.Point(994, 459);
			this.btn_RA_Tris_4.Name = "btn_RA_Tris_4";
			this.btn_RA_Tris_4.Size = new System.Drawing.Size(21, 23);
			this.btn_RA_Tris_4.TabIndex = 23;
			this.btn_RA_Tris_4.Text = "i";
			this.btn_RA_Tris_4.UseVisualStyleBackColor = true;
			this.btn_RA_Tris_4.Click += new System.EventHandler(this.btn_RA_Tris_4_Click);
			// 
			// btn_RA_Tris_3
			// 
			this.btn_RA_Tris_3.Location = new System.Drawing.Point(1021, 459);
			this.btn_RA_Tris_3.Name = "btn_RA_Tris_3";
			this.btn_RA_Tris_3.Size = new System.Drawing.Size(21, 23);
			this.btn_RA_Tris_3.TabIndex = 24;
			this.btn_RA_Tris_3.Text = "i";
			this.btn_RA_Tris_3.UseVisualStyleBackColor = true;
			this.btn_RA_Tris_3.Click += new System.EventHandler(this.btn_RA_Tris_3_Click);
			// 
			// btn_RA_Tris_2
			// 
			this.btn_RA_Tris_2.Location = new System.Drawing.Point(1048, 459);
			this.btn_RA_Tris_2.Name = "btn_RA_Tris_2";
			this.btn_RA_Tris_2.Size = new System.Drawing.Size(21, 23);
			this.btn_RA_Tris_2.TabIndex = 25;
			this.btn_RA_Tris_2.Text = "i";
			this.btn_RA_Tris_2.UseVisualStyleBackColor = true;
			this.btn_RA_Tris_2.Click += new System.EventHandler(this.btn_RA_Tris_2_Click);
			// 
			// btn_RA_Tris_1
			// 
			this.btn_RA_Tris_1.Location = new System.Drawing.Point(1075, 459);
			this.btn_RA_Tris_1.Name = "btn_RA_Tris_1";
			this.btn_RA_Tris_1.Size = new System.Drawing.Size(21, 23);
			this.btn_RA_Tris_1.TabIndex = 26;
			this.btn_RA_Tris_1.Text = "i";
			this.btn_RA_Tris_1.UseVisualStyleBackColor = true;
			this.btn_RA_Tris_1.Click += new System.EventHandler(this.btn_RA_Tris_1_Click);
			// 
			// btn_RA_1
			// 
			this.btn_RA_1.Location = new System.Drawing.Point(1075, 488);
			this.btn_RA_1.Name = "btn_RA_1";
			this.btn_RA_1.Size = new System.Drawing.Size(21, 23);
			this.btn_RA_1.TabIndex = 33;
			this.btn_RA_1.Text = "0";
			this.btn_RA_1.UseVisualStyleBackColor = true;
			this.btn_RA_1.Click += new System.EventHandler(this.btn_RA_1_Click);
			// 
			// btn_RA_2
			// 
			this.btn_RA_2.Location = new System.Drawing.Point(1048, 488);
			this.btn_RA_2.Name = "btn_RA_2";
			this.btn_RA_2.Size = new System.Drawing.Size(21, 23);
			this.btn_RA_2.TabIndex = 32;
			this.btn_RA_2.Text = "0";
			this.btn_RA_2.UseVisualStyleBackColor = true;
			this.btn_RA_2.Click += new System.EventHandler(this.btn_RA_2_Click);
			// 
			// btn_RA_3
			// 
			this.btn_RA_3.Location = new System.Drawing.Point(1021, 488);
			this.btn_RA_3.Name = "btn_RA_3";
			this.btn_RA_3.Size = new System.Drawing.Size(21, 23);
			this.btn_RA_3.TabIndex = 31;
			this.btn_RA_3.Text = "0";
			this.btn_RA_3.UseVisualStyleBackColor = true;
			this.btn_RA_3.Click += new System.EventHandler(this.btn_RA_3_Click);
			// 
			// btn_RA_4
			// 
			this.btn_RA_4.Location = new System.Drawing.Point(994, 488);
			this.btn_RA_4.Name = "btn_RA_4";
			this.btn_RA_4.Size = new System.Drawing.Size(21, 23);
			this.btn_RA_4.TabIndex = 30;
			this.btn_RA_4.Text = "0";
			this.btn_RA_4.UseVisualStyleBackColor = true;
			this.btn_RA_4.Click += new System.EventHandler(this.btn_RA_4_Click);
			// 
			// btn_RA_5
			// 
			this.btn_RA_5.Location = new System.Drawing.Point(967, 488);
			this.btn_RA_5.Name = "btn_RA_5";
			this.btn_RA_5.Size = new System.Drawing.Size(21, 23);
			this.btn_RA_5.TabIndex = 29;
			this.btn_RA_5.Text = "0";
			this.btn_RA_5.UseVisualStyleBackColor = true;
			this.btn_RA_5.Click += new System.EventHandler(this.btn_RA_5_Click);
			// 
			// btn_RA_6
			// 
			this.btn_RA_6.Location = new System.Drawing.Point(940, 488);
			this.btn_RA_6.Name = "btn_RA_6";
			this.btn_RA_6.Size = new System.Drawing.Size(21, 23);
			this.btn_RA_6.TabIndex = 28;
			this.btn_RA_6.Text = "0";
			this.btn_RA_6.UseVisualStyleBackColor = true;
			this.btn_RA_6.Click += new System.EventHandler(this.btn_RA_6_Click);
			// 
			// btn_RA_7
			// 
			this.btn_RA_7.Location = new System.Drawing.Point(913, 488);
			this.btn_RA_7.Name = "btn_RA_7";
			this.btn_RA_7.Size = new System.Drawing.Size(21, 23);
			this.btn_RA_7.TabIndex = 27;
			this.btn_RA_7.Text = "0";
			this.btn_RA_7.UseVisualStyleBackColor = true;
			this.btn_RA_7.Click += new System.EventHandler(this.btn_RA_7_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(915, 438);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(22, 13);
			this.label2.TabIndex = 34;
			this.label2.Text = "RA";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(915, 524);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(22, 13);
			this.label5.TabIndex = 49;
			this.label5.Text = "RB";
			// 
			// btn_RB_1
			// 
			this.btn_RB_1.Location = new System.Drawing.Point(1075, 574);
			this.btn_RB_1.Name = "btn_RB_1";
			this.btn_RB_1.Size = new System.Drawing.Size(21, 23);
			this.btn_RB_1.TabIndex = 48;
			this.btn_RB_1.Text = "0";
			this.btn_RB_1.UseVisualStyleBackColor = true;
			this.btn_RB_1.Click += new System.EventHandler(this.btn_RB_1_Click);
			// 
			// btn_RB_2
			// 
			this.btn_RB_2.Location = new System.Drawing.Point(1048, 574);
			this.btn_RB_2.Name = "btn_RB_2";
			this.btn_RB_2.Size = new System.Drawing.Size(21, 23);
			this.btn_RB_2.TabIndex = 47;
			this.btn_RB_2.Text = "0";
			this.btn_RB_2.UseVisualStyleBackColor = true;
			this.btn_RB_2.Click += new System.EventHandler(this.btn_RB_2_Click);
			// 
			// btn_RB_3
			// 
			this.btn_RB_3.Location = new System.Drawing.Point(1021, 574);
			this.btn_RB_3.Name = "btn_RB_3";
			this.btn_RB_3.Size = new System.Drawing.Size(21, 23);
			this.btn_RB_3.TabIndex = 46;
			this.btn_RB_3.Text = "0";
			this.btn_RB_3.UseVisualStyleBackColor = true;
			this.btn_RB_3.Click += new System.EventHandler(this.btn_RB_3_Click);
			// 
			// btn_RB_4
			// 
			this.btn_RB_4.Location = new System.Drawing.Point(994, 574);
			this.btn_RB_4.Name = "btn_RB_4";
			this.btn_RB_4.Size = new System.Drawing.Size(21, 23);
			this.btn_RB_4.TabIndex = 45;
			this.btn_RB_4.Text = "0";
			this.btn_RB_4.UseVisualStyleBackColor = true;
			this.btn_RB_4.Click += new System.EventHandler(this.btn_RB_4_Click);
			// 
			// btn_RB_5
			// 
			this.btn_RB_5.Location = new System.Drawing.Point(967, 574);
			this.btn_RB_5.Name = "btn_RB_5";
			this.btn_RB_5.Size = new System.Drawing.Size(21, 23);
			this.btn_RB_5.TabIndex = 44;
			this.btn_RB_5.Text = "0";
			this.btn_RB_5.UseVisualStyleBackColor = true;
			this.btn_RB_5.Click += new System.EventHandler(this.btn_RB_5_Click);
			// 
			// btn_RB_6
			// 
			this.btn_RB_6.Location = new System.Drawing.Point(940, 574);
			this.btn_RB_6.Name = "btn_RB_6";
			this.btn_RB_6.Size = new System.Drawing.Size(21, 23);
			this.btn_RB_6.TabIndex = 43;
			this.btn_RB_6.Text = "0";
			this.btn_RB_6.UseVisualStyleBackColor = true;
			this.btn_RB_6.Click += new System.EventHandler(this.btn_RB_6_Click);
			// 
			// btn_RB_7
			// 
			this.btn_RB_7.Location = new System.Drawing.Point(913, 574);
			this.btn_RB_7.Name = "btn_RB_7";
			this.btn_RB_7.Size = new System.Drawing.Size(21, 23);
			this.btn_RB_7.TabIndex = 42;
			this.btn_RB_7.Text = "0";
			this.btn_RB_7.UseVisualStyleBackColor = true;
			this.btn_RB_7.Click += new System.EventHandler(this.btn_RB_7_Click);
			// 
			// btn_RB_Tris_1
			// 
			this.btn_RB_Tris_1.Location = new System.Drawing.Point(1075, 545);
			this.btn_RB_Tris_1.Name = "btn_RB_Tris_1";
			this.btn_RB_Tris_1.Size = new System.Drawing.Size(21, 23);
			this.btn_RB_Tris_1.TabIndex = 41;
			this.btn_RB_Tris_1.Text = "i";
			this.btn_RB_Tris_1.UseVisualStyleBackColor = true;
			this.btn_RB_Tris_1.Click += new System.EventHandler(this.btn_RB_Tris_1_Click);
			// 
			// btn_RB_Tris_2
			// 
			this.btn_RB_Tris_2.Location = new System.Drawing.Point(1048, 545);
			this.btn_RB_Tris_2.Name = "btn_RB_Tris_2";
			this.btn_RB_Tris_2.Size = new System.Drawing.Size(21, 23);
			this.btn_RB_Tris_2.TabIndex = 40;
			this.btn_RB_Tris_2.Text = "i";
			this.btn_RB_Tris_2.UseVisualStyleBackColor = true;
			this.btn_RB_Tris_2.Click += new System.EventHandler(this.btn_RB_Tris_2_Click);
			// 
			// btn_RB_Tris_3
			// 
			this.btn_RB_Tris_3.Location = new System.Drawing.Point(1021, 545);
			this.btn_RB_Tris_3.Name = "btn_RB_Tris_3";
			this.btn_RB_Tris_3.Size = new System.Drawing.Size(21, 23);
			this.btn_RB_Tris_3.TabIndex = 39;
			this.btn_RB_Tris_3.Text = "i";
			this.btn_RB_Tris_3.UseVisualStyleBackColor = true;
			this.btn_RB_Tris_3.Click += new System.EventHandler(this.btn_RB_Tris_3_Click);
			// 
			// btn_RB_Tris_4
			// 
			this.btn_RB_Tris_4.Location = new System.Drawing.Point(994, 545);
			this.btn_RB_Tris_4.Name = "btn_RB_Tris_4";
			this.btn_RB_Tris_4.Size = new System.Drawing.Size(21, 23);
			this.btn_RB_Tris_4.TabIndex = 38;
			this.btn_RB_Tris_4.Text = "i";
			this.btn_RB_Tris_4.UseVisualStyleBackColor = true;
			this.btn_RB_Tris_4.Click += new System.EventHandler(this.btn_RB_Tris_4_Click);
			// 
			// btn_RB_Tris_5
			// 
			this.btn_RB_Tris_5.Location = new System.Drawing.Point(967, 545);
			this.btn_RB_Tris_5.Name = "btn_RB_Tris_5";
			this.btn_RB_Tris_5.Size = new System.Drawing.Size(21, 23);
			this.btn_RB_Tris_5.TabIndex = 37;
			this.btn_RB_Tris_5.Text = "i";
			this.btn_RB_Tris_5.UseVisualStyleBackColor = true;
			this.btn_RB_Tris_5.Click += new System.EventHandler(this.btn_RB_Tris_5_Click);
			// 
			// btn_RB_Tris_6
			// 
			this.btn_RB_Tris_6.Location = new System.Drawing.Point(940, 545);
			this.btn_RB_Tris_6.Name = "btn_RB_Tris_6";
			this.btn_RB_Tris_6.Size = new System.Drawing.Size(21, 23);
			this.btn_RB_Tris_6.TabIndex = 36;
			this.btn_RB_Tris_6.Text = "i";
			this.btn_RB_Tris_6.UseVisualStyleBackColor = true;
			this.btn_RB_Tris_6.Click += new System.EventHandler(this.btn_RB_Tris_6_Click);
			// 
			// btn_RB_Tris_7
			// 
			this.btn_RB_Tris_7.Location = new System.Drawing.Point(913, 545);
			this.btn_RB_Tris_7.Name = "btn_RB_Tris_7";
			this.btn_RB_Tris_7.Size = new System.Drawing.Size(21, 23);
			this.btn_RB_Tris_7.TabIndex = 35;
			this.btn_RB_Tris_7.Text = "i";
			this.btn_RB_Tris_7.UseVisualStyleBackColor = true;
			this.btn_RB_Tris_7.Click += new System.EventHandler(this.btn_RB_Tris_7_Click);
			// 
			// btn_RB_0
			// 
			this.btn_RB_0.Location = new System.Drawing.Point(1102, 574);
			this.btn_RB_0.Name = "btn_RB_0";
			this.btn_RB_0.Size = new System.Drawing.Size(21, 23);
			this.btn_RB_0.TabIndex = 53;
			this.btn_RB_0.Text = "0";
			this.btn_RB_0.UseVisualStyleBackColor = true;
			this.btn_RB_0.Click += new System.EventHandler(this.btn_RB_0_Click);
			// 
			// btn_RB_Tris_0
			// 
			this.btn_RB_Tris_0.Location = new System.Drawing.Point(1102, 545);
			this.btn_RB_Tris_0.Name = "btn_RB_Tris_0";
			this.btn_RB_Tris_0.Size = new System.Drawing.Size(21, 23);
			this.btn_RB_Tris_0.TabIndex = 52;
			this.btn_RB_Tris_0.Text = "i";
			this.btn_RB_Tris_0.UseVisualStyleBackColor = true;
			this.btn_RB_Tris_0.Click += new System.EventHandler(this.btn_RB_Tris_0_Click);
			// 
			// btn_RA_0
			// 
			this.btn_RA_0.Location = new System.Drawing.Point(1102, 488);
			this.btn_RA_0.Name = "btn_RA_0";
			this.btn_RA_0.Size = new System.Drawing.Size(21, 23);
			this.btn_RA_0.TabIndex = 51;
			this.btn_RA_0.Text = "0";
			this.btn_RA_0.UseVisualStyleBackColor = true;
			this.btn_RA_0.Click += new System.EventHandler(this.btn_RA_0_Click);
			// 
			// btn_RA_Tris_0
			// 
			this.btn_RA_Tris_0.Location = new System.Drawing.Point(1102, 459);
			this.btn_RA_Tris_0.Name = "btn_RA_Tris_0";
			this.btn_RA_Tris_0.Size = new System.Drawing.Size(21, 23);
			this.btn_RA_Tris_0.TabIndex = 50;
			this.btn_RA_Tris_0.Text = "i";
			this.btn_RA_Tris_0.UseVisualStyleBackColor = true;
			this.btn_RA_Tris_0.Click += new System.EventHandler(this.btn_RA_Tris_0_Click);
			// 
			// edRS232Log
			// 
			this.edRS232Log.Location = new System.Drawing.Point(1129, 494);
			this.edRS232Log.Multiline = true;
			this.edRS232Log.Name = "edRS232Log";
			this.edRS232Log.Size = new System.Drawing.Size(157, 183);
			this.edRS232Log.TabIndex = 54;
			// 
			// cbxComPorts
			// 
			this.cbxComPorts.FormattingEnabled = true;
			this.cbxComPorts.Location = new System.Drawing.Point(1129, 438);
			this.cbxComPorts.Name = "cbxComPorts";
			this.cbxComPorts.Size = new System.Drawing.Size(157, 21);
			this.cbxComPorts.TabIndex = 55;
			// 
			// btnRSConnect
			// 
			this.btnRSConnect.Location = new System.Drawing.Point(1129, 465);
			this.btnRSConnect.Name = "btnRSConnect";
			this.btnRSConnect.Size = new System.Drawing.Size(75, 23);
			this.btnRSConnect.TabIndex = 56;
			this.btnRSConnect.Text = "Connect";
			this.btnRSConnect.UseVisualStyleBackColor = true;
			this.btnRSConnect.Click += new System.EventHandler(this.btnRSConnect_Click);
			// 
			// btnRSDisconnect
			// 
			this.btnRSDisconnect.Location = new System.Drawing.Point(1212, 464);
			this.btnRSDisconnect.Name = "btnRSDisconnect";
			this.btnRSDisconnect.Size = new System.Drawing.Size(75, 23);
			this.btnRSDisconnect.TabIndex = 57;
			this.btnRSDisconnect.Text = "Disconnect";
			this.btnRSDisconnect.UseVisualStyleBackColor = true;
			this.btnRSDisconnect.Click += new System.EventHandler(this.btnRSDisconnect_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(915, 610);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 13);
			this.label6.TabIndex = 58;
			this.label6.Text = "Taktgeber";
			// 
			// edClockAddr
			// 
			this.edClockAddr.Location = new System.Drawing.Point(918, 626);
			this.edClockAddr.Name = "edClockAddr";
			this.edClockAddr.Size = new System.Drawing.Size(64, 20);
			this.edClockAddr.TabIndex = 59;
			this.edClockAddr.Text = "0x20";
			// 
			// edClockBit
			// 
			this.edClockBit.Location = new System.Drawing.Point(994, 626);
			this.edClockBit.Name = "edClockBit";
			this.edClockBit.Size = new System.Drawing.Size(64, 20);
			this.edClockBit.TabIndex = 60;
			this.edClockBit.Text = "3";
			// 
			// btnClockStart
			// 
			this.btnClockStart.Location = new System.Drawing.Point(1064, 626);
			this.btnClockStart.Name = "btnClockStart";
			this.btnClockStart.Size = new System.Drawing.Size(49, 23);
			this.btnClockStart.TabIndex = 61;
			this.btnClockStart.Text = "Start";
			this.btnClockStart.UseVisualStyleBackColor = true;
			this.btnClockStart.Click += new System.EventHandler(this.btnClockStart_Click);
			// 
			// edCLockFreq
			// 
			this.edCLockFreq.Location = new System.Drawing.Point(918, 652);
			this.edCLockFreq.Name = "edCLockFreq";
			this.edCLockFreq.Size = new System.Drawing.Size(140, 20);
			this.edCLockFreq.TabIndex = 62;
			this.edCLockFreq.Text = "1500";
			// 
			// WakeUpButton
			// 
			this.WakeUpButton.Location = new System.Drawing.Point(254, 31);
			this.WakeUpButton.Name = "WakeUpButton";
			this.WakeUpButton.Size = new System.Drawing.Size(63, 21);
			this.WakeUpButton.TabIndex = 63;
			this.WakeUpButton.Text = "Wake Up";
			this.WakeUpButton.UseVisualStyleBackColor = true;
			this.WakeUpButton.Click += new System.EventHandler(this.button1_Click);
			// 
			// btnWD1
			// 
			this.btnWD1.Location = new System.Drawing.Point(341, 18);
			this.btnWD1.Name = "btnWD1";
			this.btnWD1.Size = new System.Drawing.Size(126, 23);
			this.btnWD1.TabIndex = 64;
			this.btnWD1.Text = "Watchdog An";
			this.btnWD1.UseVisualStyleBackColor = true;
			this.btnWD1.Click += new System.EventHandler(this.button1_Click_1);
			// 
			// btnWD0
			// 
			this.btnWD0.Location = new System.Drawing.Point(341, 48);
			this.btnWD0.Name = "btnWD0";
			this.btnWD0.Size = new System.Drawing.Size(126, 23);
			this.btnWD0.TabIndex = 65;
			this.btnWD0.Text = "Watchdog Aus";
			this.btnWD0.UseVisualStyleBackColor = true;
			this.btnWD0.Click += new System.EventHandler(this.button2_Click);
			// 
			// tbWD
			// 
			this.tbWD.Location = new System.Drawing.Point(474, 18);
			this.tbWD.Name = "tbWD";
			this.tbWD.Size = new System.Drawing.Size(58, 20);
			this.tbWD.TabIndex = 66;
			this.tbWD.Text = "18.0";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1298, 692);
			this.Controls.Add(this.tbWD);
			this.Controls.Add(this.btnWD0);
			this.Controls.Add(this.btnWD1);
			this.Controls.Add(this.WakeUpButton);
			this.Controls.Add(this.edCLockFreq);
			this.Controls.Add(this.btnClockStart);
			this.Controls.Add(this.edClockBit);
			this.Controls.Add(this.edClockAddr);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.btnRSDisconnect);
			this.Controls.Add(this.btnRSConnect);
			this.Controls.Add(this.cbxComPorts);
			this.Controls.Add(this.edRS232Log);
			this.Controls.Add(this.btn_RB_0);
			this.Controls.Add(this.btn_RB_Tris_0);
			this.Controls.Add(this.btn_RA_0);
			this.Controls.Add(this.btn_RA_Tris_0);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.btn_RB_1);
			this.Controls.Add(this.btn_RB_2);
			this.Controls.Add(this.btn_RB_3);
			this.Controls.Add(this.btn_RB_4);
			this.Controls.Add(this.btn_RB_5);
			this.Controls.Add(this.btn_RB_6);
			this.Controls.Add(this.btn_RB_7);
			this.Controls.Add(this.btn_RB_Tris_1);
			this.Controls.Add(this.btn_RB_Tris_2);
			this.Controls.Add(this.btn_RB_Tris_3);
			this.Controls.Add(this.btn_RB_Tris_4);
			this.Controls.Add(this.btn_RB_Tris_5);
			this.Controls.Add(this.btn_RB_Tris_6);
			this.Controls.Add(this.btn_RB_Tris_7);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btn_RA_1);
			this.Controls.Add(this.btn_RA_2);
			this.Controls.Add(this.btn_RA_3);
			this.Controls.Add(this.btn_RA_4);
			this.Controls.Add(this.btn_RA_5);
			this.Controls.Add(this.btn_RA_6);
			this.Controls.Add(this.btn_RA_7);
			this.Controls.Add(this.btn_RA_Tris_1);
			this.Controls.Add(this.btn_RA_Tris_2);
			this.Controls.Add(this.btn_RA_Tris_3);
			this.Controls.Add(this.btn_RA_Tris_4);
			this.Controls.Add(this.btn_RA_Tris_5);
			this.Controls.Add(this.btn_RA_Tris_6);
			this.Controls.Add(this.btn_RA_Tris_7);
			this.Controls.Add(this.lbStack);
			this.Controls.Add(this.lvSpecial);
			this.Controls.Add(this.insertTime);
			this.Controls.Add(this.cmd_Stop);
			this.Controls.Add(this.lvMemory);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.cmd_reset);
			this.Controls.Add(this.cmd_next);
			this.Controls.Add(this.cmd_Start);
			this.Controls.Add(this.lbl_path);
			this.Controls.Add(this.box_CodeView);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "PIC Simulator";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox box_CodeView;
        private System.Windows.Forms.Label lbl_path;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button cmd_Start;
        private System.Windows.Forms.Button cmd_next;
        private System.Windows.Forms.Button cmd_reset;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cmdOpenFile;
        private System.Windows.Forms.ToolStripMenuItem programmÖffnenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmdOpenDoc;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lvMemory;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.Button cmd_Stop;
        private System.Windows.Forms.TextBox insertTime;
		private System.Windows.Forms.ListView lvSpecial;
		private System.Windows.Forms.ColumnHeader c1;
		private System.Windows.Forms.ColumnHeader c2;
		private System.Windows.Forms.ListBox lbStack;
		private System.Windows.Forms.ColumnHeader Index;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		private System.Windows.Forms.ColumnHeader columnHeader13;
		private System.Windows.Forms.ColumnHeader columnHeader14;
		private System.Windows.Forms.ColumnHeader columnHeader15;
		private System.Windows.Forms.ColumnHeader columnHeader16;
		private System.Windows.Forms.Button btn_RA_Tris_7;
		private System.Windows.Forms.Button btn_RA_Tris_6;
		private System.Windows.Forms.Button btn_RA_Tris_5;
		private System.Windows.Forms.Button btn_RA_Tris_4;
		private System.Windows.Forms.Button btn_RA_Tris_3;
		private System.Windows.Forms.Button btn_RA_Tris_2;
		private System.Windows.Forms.Button btn_RA_Tris_1;
		private System.Windows.Forms.Button btn_RA_1;
		private System.Windows.Forms.Button btn_RA_2;
		private System.Windows.Forms.Button btn_RA_3;
		private System.Windows.Forms.Button btn_RA_4;
		private System.Windows.Forms.Button btn_RA_5;
		private System.Windows.Forms.Button btn_RA_6;
		private System.Windows.Forms.Button btn_RA_7;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btn_RB_1;
		private System.Windows.Forms.Button btn_RB_2;
		private System.Windows.Forms.Button btn_RB_3;
		private System.Windows.Forms.Button btn_RB_4;
		private System.Windows.Forms.Button btn_RB_5;
		private System.Windows.Forms.Button btn_RB_6;
		private System.Windows.Forms.Button btn_RB_7;
		private System.Windows.Forms.Button btn_RB_Tris_1;
		private System.Windows.Forms.Button btn_RB_Tris_2;
		private System.Windows.Forms.Button btn_RB_Tris_3;
		private System.Windows.Forms.Button btn_RB_Tris_4;
		private System.Windows.Forms.Button btn_RB_Tris_5;
		private System.Windows.Forms.Button btn_RB_Tris_6;
		private System.Windows.Forms.Button btn_RB_Tris_7;
		private System.Windows.Forms.Button btn_RB_0;
		private System.Windows.Forms.Button btn_RB_Tris_0;
		private System.Windows.Forms.Button btn_RA_0;
		private System.Windows.Forms.Button btn_RA_Tris_0;
		private System.Windows.Forms.TextBox edRS232Log;
		private System.Windows.Forms.ComboBox cbxComPorts;
		private System.Windows.Forms.Button btnRSConnect;
		private System.Windows.Forms.Button btnRSDisconnect;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox edClockAddr;
		private System.Windows.Forms.TextBox edClockBit;
		private System.Windows.Forms.Button btnClockStart;
		private System.Windows.Forms.TextBox edCLockFreq;
        private System.Windows.Forms.Button WakeUpButton;
		private System.Windows.Forms.Button btnWD1;
		private System.Windows.Forms.Button btnWD0;
		private System.Windows.Forms.TextBox tbWD;
	}
}

