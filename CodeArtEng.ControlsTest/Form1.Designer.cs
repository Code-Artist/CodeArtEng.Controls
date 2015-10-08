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
            this.folderBrowsePanel1 = new CodeArtEng.Controls.FolderBrowsePanel();
            this.openFilePanel1 = new CodeArtEng.Controls.OpenFilePanel();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.fileExplorer1 = new CodeArtEng.Controls.FileExplorer();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.addRecentFileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(532, 24);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // toolStripMruList1
            // 
            this.toolStripMruList1.MaxPathLength = 40;
            this.toolStripMruList1.MruListSize = 5;
            this.toolStripMruList1.Name = "toolStripMruList1";
            this.toolStripMruList1.RecentFileList = new string[0];
            this.toolStripMruList1.Size = new System.Drawing.Size(136, 22);
            this.toolStripMruList1.Text = "Recent Files";
            this.toolStripMruList1.RecentFileClicked += new System.EventHandler<CodeArtEng.Controls.RecentFileClickedEventArgs>(this.toolStripMruList1_RecentFileClicked);
            // 
            // addRecentFileToolStripMenuItem
            // 
            this.addRecentFileToolStripMenuItem.Name = "addRecentFileToolStripMenuItem";
            this.addRecentFileToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.addRecentFileToolStripMenuItem.Text = "Add Recent File";
            this.addRecentFileToolStripMenuItem.Click += new System.EventHandler(this.addRecentFileToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(532, 379);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.folderBrowsePanel1);
            this.tabPage2.Controls.Add(this.openFilePanel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(524, 353);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Panels";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // folderBrowsePanel1
            // 
            this.folderBrowsePanel1.Location = new System.Drawing.Point(36, 51);
            this.folderBrowsePanel1.Name = "folderBrowsePanel1";
            this.folderBrowsePanel1.Padding = new System.Windows.Forms.Padding(5, 1, 5, 1);
            this.folderBrowsePanel1.SelectedPath = "";
            this.folderBrowsePanel1.Size = new System.Drawing.Size(321, 22);
            this.folderBrowsePanel1.TabIndex = 1;
            this.folderBrowsePanel1.Text = "Folder Browse";
            // 
            // openFilePanel1
            // 
            this.openFilePanel1.FileFilter = "All Files|*.*";
            this.openFilePanel1.Location = new System.Drawing.Point(59, 23);
            this.openFilePanel1.Name = "openFilePanel1";
            this.openFilePanel1.Padding = new System.Windows.Forms.Padding(5, 1, 5, 1);
            this.openFilePanel1.SelectedFile = "";
            this.openFilePanel1.Size = new System.Drawing.Size(298, 22);
            this.openFilePanel1.TabIndex = 0;
            this.openFilePanel1.Text = "File Open";
            this.openFilePanel1.TextChanged += new System.EventHandler(this.openFilePanel1_TextChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.fileExplorer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(524, 353);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "File Explorer";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // fileExplorer1
            // 
            this.fileExplorer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileExplorer1.FileView = System.Windows.Forms.View.LargeIcon;
            this.fileExplorer1.HideSystemFolder = true;
            this.fileExplorer1.Location = new System.Drawing.Point(3, 3);
            this.fileExplorer1.Name = "fileExplorer1";
            this.fileExplorer1.Size = new System.Drawing.Size(518, 347);
            this.fileExplorer1.SplitterDistance = 150;
            this.fileExplorer1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.propertyGrid1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(524, 353);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "TimePickerEditor";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.propertyGrid1.Location = new System.Drawing.Point(21, 17);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(281, 314);
            this.propertyGrid1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 403);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
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
    }
}

