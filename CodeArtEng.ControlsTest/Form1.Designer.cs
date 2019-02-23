namespace CodeArtEng.ControlsTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param caption="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMruList1 = new CodeArtEng.Controls.ToolStripMruList();
            this.addRecentFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.labeledTextBox3 = new CodeArtEng.Controls.LabeledTextBox();
            this.labeledTextBox2 = new CodeArtEng.Controls.LabeledTextBox();
            this.labeledTextBox1 = new CodeArtEng.Controls.LabeledTextBox();
            this.lbTextBox3 = new CodeArtEng.Controls.LabeledTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.hintedTextBox1 = new CodeArtEng.Controls.HintedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.multiLineButton4 = new CodeArtEng.Controls.MultiLineButton();
            this.multiLineButton3 = new CodeArtEng.Controls.MultiLineButton();
            this.multiLineButton2 = new CodeArtEng.Controls.MultiLineButton();
            this.multiLineButton1 = new CodeArtEng.Controls.MultiLineButton();
            this.statusLabel3 = new CodeArtEng.Controls.StatusLabel();
            this.statusLabel2 = new CodeArtEng.Controls.StatusLabel();
            this.statusLabel1 = new CodeArtEng.Controls.StatusLabel();
            this.folderBrowsePanel1 = new CodeArtEng.Controls.FolderBrowsePanel();
            this.openFilePanel1 = new CodeArtEng.Controls.OpenFilePanel();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.fileExplorer1 = new CodeArtEng.Controls.FileExplorer();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btCmdMacroEditor = new System.Windows.Forms.Button();
            this.btCmdLineDialog1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hintedTextBox1)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.addRecentFileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(969, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMruList1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(159, 6);
            // 
            // toolStripMruList1
            // 
            this.toolStripMruList1.Enabled = false;
            this.toolStripMruList1.MaxPathLength = 40;
            this.toolStripMruList1.MruListSize = 5;
            this.toolStripMruList1.Name = "toolStripMruList1";
            this.toolStripMruList1.RecentFileList = new string[0];
            this.toolStripMruList1.Size = new System.Drawing.Size(162, 26);
            this.toolStripMruList1.Text = "Recent Files";
            this.toolStripMruList1.RecentFileClicked += new System.EventHandler<CodeArtEng.Controls.RecentFileClickedEventArgs>(this.toolStripMruList1_RecentFileClicked);
            // 
            // addRecentFileToolStripMenuItem
            // 
            this.addRecentFileToolStripMenuItem.Name = "addRecentFileToolStripMenuItem";
            this.addRecentFileToolStripMenuItem.Size = new System.Drawing.Size(125, 24);
            this.addRecentFileToolStripMenuItem.Text = "Add Recent File";
            this.addRecentFileToolStripMenuItem.Click += new System.EventHandler(this.addRecentFileToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(969, 472);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.labeledTextBox3);
            this.tabPage2.Controls.Add(this.labeledTextBox2);
            this.tabPage2.Controls.Add(this.labeledTextBox1);
            this.tabPage2.Controls.Add(this.lbTextBox3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.hintedTextBox1);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.multiLineButton4);
            this.tabPage2.Controls.Add(this.multiLineButton3);
            this.tabPage2.Controls.Add(this.multiLineButton2);
            this.tabPage2.Controls.Add(this.multiLineButton1);
            this.tabPage2.Controls.Add(this.statusLabel3);
            this.tabPage2.Controls.Add(this.statusLabel2);
            this.tabPage2.Controls.Add(this.statusLabel1);
            this.tabPage2.Controls.Add(this.folderBrowsePanel1);
            this.tabPage2.Controls.Add(this.openFilePanel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(961, 443);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Panels";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // labeledTextBox3
            // 
            this.labeledTextBox3.DropDownListItems = new string[0];
            this.labeledTextBox3.Hint = null;
            this.labeledTextBox3.IsDropDownList = true;
            this.labeledTextBox3.LabelAutoSize = false;
            this.labeledTextBox3.LabelText = "label";
            this.labeledTextBox3.LabelTextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.labeledTextBox3.LabelWidth = 120;
            this.labeledTextBox3.Location = new System.Drawing.Point(469, 219);
            this.labeledTextBox3.Margin = new System.Windows.Forms.Padding(5);
            this.labeledTextBox3.MinimumSize = new System.Drawing.Size(0, 28);
            this.labeledTextBox3.Name = "labeledTextBox3";
            this.labeledTextBox3.ReadOnly = false;
            this.labeledTextBox3.Size = new System.Drawing.Size(428, 28);
            this.labeledTextBox3.TabIndex = 24;
            this.labeledTextBox3.Text = "labeledTextBox3";
            // 
            // labeledTextBox2
            // 
            this.labeledTextBox2.DropDownListItems = new string[0];
            this.labeledTextBox2.Hint = null;
            this.labeledTextBox2.LabelAutoSize = true;
            this.labeledTextBox2.LabelText = "label";
            this.labeledTextBox2.LabelTextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.labeledTextBox2.LabelWidth = 41;
            this.labeledTextBox2.Location = new System.Drawing.Point(469, 255);
            this.labeledTextBox2.Margin = new System.Windows.Forms.Padding(5);
            this.labeledTextBox2.MinimumSize = new System.Drawing.Size(0, 28);
            this.labeledTextBox2.Name = "labeledTextBox2";
            this.labeledTextBox2.ReadOnly = false;
            this.labeledTextBox2.ShowCheckBox = true;
            this.labeledTextBox2.Size = new System.Drawing.Size(428, 28);
            this.labeledTextBox2.TabIndex = 23;
            this.labeledTextBox2.Text = "labeledTextBox2";
            this.labeledTextBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.labeledTextBox2_KeyDown);
            // 
            // labeledTextBox1
            // 
            this.labeledTextBox1.DropDownListItems = new string[0];
            this.labeledTextBox1.Hint = null;
            this.labeledTextBox1.IsDropDownList = true;
            this.labeledTextBox1.LabelAutoSize = true;
            this.labeledTextBox1.LabelText = "label";
            this.labeledTextBox1.LabelTextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.labeledTextBox1.LabelWidth = 41;
            this.labeledTextBox1.Location = new System.Drawing.Point(431, 304);
            this.labeledTextBox1.Margin = new System.Windows.Forms.Padding(5);
            this.labeledTextBox1.MinimumSize = new System.Drawing.Size(0, 28);
            this.labeledTextBox1.Name = "labeledTextBox1";
            this.labeledTextBox1.ReadOnly = false;
            this.labeledTextBox1.Size = new System.Drawing.Size(500, 28);
            this.labeledTextBox1.TabIndex = 22;
            this.labeledTextBox1.Text = "labeledTextBox3";
            // 
            // lbTextBox3
            // 
            this.lbTextBox3.DropDownListItems = new string[0];
            this.lbTextBox3.Hint = "TIPS - Testing";
            this.lbTextBox3.LabelAutoSize = true;
            this.lbTextBox3.LabelText = "label";
            this.lbTextBox3.LabelTextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbTextBox3.LabelWidth = 41;
            this.lbTextBox3.Location = new System.Drawing.Point(431, 337);
            this.lbTextBox3.Margin = new System.Windows.Forms.Padding(5);
            this.lbTextBox3.MinimumSize = new System.Drawing.Size(0, 28);
            this.lbTextBox3.Name = "lbTextBox3";
            this.lbTextBox3.ReadOnly = false;
            this.lbTextBox3.Size = new System.Drawing.Size(500, 28);
            this.lbTextBox3.TabIndex = 21;
            this.lbTextBox3.Text = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(523, 382);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "label2";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(441, 379);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(171, 314);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "label1";
            // 
            // hintedTextBox1
            // 
            this.hintedTextBox1.Hint = "This is hint";
            this.hintedTextBox1.Location = new System.Drawing.Point(63, 276);
            this.hintedTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.hintedTextBox1.Name = "hintedTextBox1";
            this.hintedTextBox1.Size = new System.Drawing.Size(252, 22);
            this.hintedTextBox1.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(63, 308);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // multiLineButton4
            // 
            this.multiLineButton4.ButtonStyle = CodeArtEng.Controls.MultiLineButtonStyle.Square;
            this.multiLineButton4.Image = global::CodeArtEng.ControlsTest.Properties.Resources.CAELogoSmall;
            this.multiLineButton4.ImageMargin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.multiLineButton4.Location = new System.Drawing.Point(499, 22);
            this.multiLineButton4.MainTitleFont = new System.Drawing.Font("Arial", 8.25F);
            this.multiLineButton4.Margin = new System.Windows.Forms.Padding(4);
            this.multiLineButton4.Name = "multiLineButton4";
            this.multiLineButton4.Size = new System.Drawing.Size(171, 58);
            this.multiLineButton4.SubTitleFont = new System.Drawing.Font("Verdana", 6.75F);
            this.multiLineButton4.TabIndex = 4;
            // 
            // multiLineButton3
            // 
            this.multiLineButton3.Image = global::CodeArtEng.ControlsTest.Properties.Resources.CAELogoSmall;
            this.multiLineButton3.ImageMargin = new System.Windows.Forms.Padding(3);
            this.multiLineButton3.Location = new System.Drawing.Point(677, 22);
            this.multiLineButton3.MainTitleFont = new System.Drawing.Font("Arial", 8.25F);
            this.multiLineButton3.Margin = new System.Windows.Forms.Padding(4);
            this.multiLineButton3.Name = "multiLineButton3";
            this.multiLineButton3.Size = new System.Drawing.Size(229, 36);
            this.multiLineButton3.SubTitleFont = new System.Drawing.Font("Verdana", 6.75F);
            this.multiLineButton3.SubtitleVisible = false;
            this.multiLineButton3.TabIndex = 6;
            // 
            // multiLineButton2
            // 
            this.multiLineButton2.Image = global::CodeArtEng.ControlsTest.Properties.Resources.Logo1;
            this.multiLineButton2.ImageMargin = new System.Windows.Forms.Padding(3);
            this.multiLineButton2.Location = new System.Drawing.Point(499, 87);
            this.multiLineButton2.MainTitleFont = new System.Drawing.Font("Arial", 8.25F);
            this.multiLineButton2.Margin = new System.Windows.Forms.Padding(4);
            this.multiLineButton2.Name = "multiLineButton2";
            this.multiLineButton2.Size = new System.Drawing.Size(171, 70);
            this.multiLineButton2.SubTitleFont = new System.Drawing.Font("Verdana", 6.75F);
            this.multiLineButton2.TabIndex = 5;
            this.multiLineButton2.Click += new System.EventHandler(this.multiLineButton2_Click);
            // 
            // multiLineButton1
            // 
            this.multiLineButton1.ButtonStyle = CodeArtEng.Controls.MultiLineButtonStyle.Square;
            this.multiLineButton1.Image = global::CodeArtEng.ControlsTest.Properties.Resources.Logo1;
            this.multiLineButton1.ImageMargin = new System.Windows.Forms.Padding(3);
            this.multiLineButton1.Location = new System.Drawing.Point(677, 73);
            this.multiLineButton1.MainTitleFont = new System.Drawing.Font("Arial", 8.25F);
            this.multiLineButton1.Margin = new System.Windows.Forms.Padding(4);
            this.multiLineButton1.Name = "multiLineButton1";
            this.multiLineButton1.Size = new System.Drawing.Size(241, 85);
            this.multiLineButton1.SubTitleFont = new System.Drawing.Font("Verdana", 6.75F);
            this.multiLineButton1.TabIndex = 7;
            // 
            // statusLabel3
            // 
            this.statusLabel3.Location = new System.Drawing.Point(63, 192);
            this.statusLabel3.Margin = new System.Windows.Forms.Padding(5);
            this.statusLabel3.MaximumSize = new System.Drawing.Size(1332, 20);
            this.statusLabel3.MinimumSize = new System.Drawing.Size(0, 20);
            this.statusLabel3.Name = "statusLabel3";
            this.statusLabel3.Size = new System.Drawing.Size(200, 20);
            this.statusLabel3.State = CodeArtEng.Controls.StatusLabelState.Red;
            this.statusLabel3.TabIndex = 10;
            this.statusLabel3.Text = "statusLabel3";
            // 
            // statusLabel2
            // 
            this.statusLabel2.Location = new System.Drawing.Point(63, 165);
            this.statusLabel2.Margin = new System.Windows.Forms.Padding(5);
            this.statusLabel2.MaximumSize = new System.Drawing.Size(1332, 20);
            this.statusLabel2.MinimumSize = new System.Drawing.Size(0, 20);
            this.statusLabel2.Name = "statusLabel2";
            this.statusLabel2.Size = new System.Drawing.Size(200, 20);
            this.statusLabel2.State = CodeArtEng.Controls.StatusLabelState.Yellow;
            this.statusLabel2.TabIndex = 9;
            this.statusLabel2.Text = "statusLabel2";
            // 
            // statusLabel1
            // 
            this.statusLabel1.Location = new System.Drawing.Point(63, 138);
            this.statusLabel1.Margin = new System.Windows.Forms.Padding(5);
            this.statusLabel1.MaximumSize = new System.Drawing.Size(1332, 20);
            this.statusLabel1.MinimumSize = new System.Drawing.Size(0, 20);
            this.statusLabel1.Name = "statusLabel1";
            this.statusLabel1.Size = new System.Drawing.Size(200, 20);
            this.statusLabel1.State = CodeArtEng.Controls.StatusLabelState.Green;
            this.statusLabel1.TabIndex = 8;
            this.statusLabel1.Text = "statusLabel1";
            // 
            // folderBrowsePanel1
            // 
            this.folderBrowsePanel1.LabelAutoSize = false;
            this.folderBrowsePanel1.LabelWidth = 80;
            this.folderBrowsePanel1.Location = new System.Drawing.Point(48, 63);
            this.folderBrowsePanel1.Margin = new System.Windows.Forms.Padding(5);
            this.folderBrowsePanel1.Name = "folderBrowsePanel1";
            this.folderBrowsePanel1.SelectedPath = "";
            this.folderBrowsePanel1.Size = new System.Drawing.Size(428, 27);
            this.folderBrowsePanel1.TabIndex = 3;
            this.folderBrowsePanel1.Text = "";
            // 
            // openFilePanel1
            // 
            this.openFilePanel1.FileFilter = "All Files|*.*";
            this.openFilePanel1.LabelAutoSize = false;
            this.openFilePanel1.LabelWidth = 80;
            this.openFilePanel1.Location = new System.Drawing.Point(48, 28);
            this.openFilePanel1.Margin = new System.Windows.Forms.Padding(5);
            this.openFilePanel1.Name = "openFilePanel1";
            this.openFilePanel1.SelectedFile = "";
            this.openFilePanel1.Size = new System.Drawing.Size(428, 27);
            this.openFilePanel1.TabIndex = 2;
            this.openFilePanel1.Text = "File Open";
            this.openFilePanel1.TextChanged += new System.EventHandler(this.openFilePanel1_TextChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.fileExplorer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(961, 443);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "File Explorer";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // fileExplorer1
            // 
            this.fileExplorer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileExplorer1.FileView = System.Windows.Forms.View.LargeIcon;
            this.fileExplorer1.HideSystemFolder = true;
            this.fileExplorer1.Location = new System.Drawing.Point(4, 4);
            this.fileExplorer1.Margin = new System.Windows.Forms.Padding(5);
            this.fileExplorer1.Name = "fileExplorer1";
            this.fileExplorer1.Size = new System.Drawing.Size(953, 435);
            this.fileExplorer1.SplitterDistance = 150;
            this.fileExplorer1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.propertyGrid1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(961, 443);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "TimePickerEditor";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.propertyGrid1.LineColor = System.Drawing.SystemColors.ControlDark;
            this.propertyGrid1.Location = new System.Drawing.Point(28, 21);
            this.propertyGrid1.Margin = new System.Windows.Forms.Padding(4);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(375, 386);
            this.propertyGrid1.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btCmdMacroEditor);
            this.tabPage4.Controls.Add(this.btCmdLineDialog1);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage4.Size = new System.Drawing.Size(961, 443);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Command Line";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btCmdMacroEditor
            // 
            this.btCmdMacroEditor.Location = new System.Drawing.Point(11, 59);
            this.btCmdMacroEditor.Margin = new System.Windows.Forms.Padding(4);
            this.btCmdMacroEditor.Name = "btCmdMacroEditor";
            this.btCmdMacroEditor.Size = new System.Drawing.Size(280, 44);
            this.btCmdMacroEditor.TabIndex = 1;
            this.btCmdMacroEditor.Text = "Command Macro Editor";
            this.btCmdMacroEditor.UseVisualStyleBackColor = true;
            this.btCmdMacroEditor.Click += new System.EventHandler(this.btCmdMacroEditor_Click);
            // 
            // btCmdLineDialog1
            // 
            this.btCmdLineDialog1.Location = new System.Drawing.Point(11, 7);
            this.btCmdLineDialog1.Margin = new System.Windows.Forms.Padding(4);
            this.btCmdLineDialog1.Name = "btCmdLineDialog1";
            this.btCmdLineDialog1.Size = new System.Drawing.Size(280, 44);
            this.btCmdLineDialog1.TabIndex = 0;
            this.btCmdLineDialog1.Text = "Command Line Helper";
            this.btCmdLineDialog1.UseVisualStyleBackColor = true;
            this.btCmdLineDialog1.Click += new System.EventHandler(this.btCmdLineDialog1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 500);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hintedTextBox1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.FileExplorer fileExplorer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Controls.ToolStripMruList toolStripMruList1;
        private System.Windows.Forms.ToolStripMenuItem addRecentFileToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Controls.OpenFilePanel openFilePanel1;
        private Controls.FolderBrowsePanel folderBrowsePanel1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private Controls.StatusLabel statusLabel1;
        private Controls.StatusLabel statusLabel3;
        private Controls.StatusLabel statusLabel2;
        private Controls.MultiLineButton multiLineButton1;
        private Controls.MultiLineButton multiLineButton2;
        private Controls.MultiLineButton multiLineButton3;
        private Controls.MultiLineButton multiLineButton4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage4;
        private Controls.HintedTextBox hintedTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btCmdLineDialog1;
        private System.Windows.Forms.Button btCmdMacroEditor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private Controls.LabeledTextBox labeledTextBox1;
        private Controls.LabeledTextBox lbTextBox3;
        private Controls.LabeledTextBox labeledTextBox3;
        private Controls.LabeledTextBox labeledTextBox2;
    }
}

