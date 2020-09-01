namespace ToolStripMruListDemo
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
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMruList1 = new CodeArtEng.Controls.ToolStripMruList();
            this.quickAccessList1 = new CodeArtEng.Controls.QuickAccessList();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.addFileToolStripMenuItem,
            this.quickAccessList1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(382, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMruList1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // addFileToolStripMenuItem
            // 
            this.addFileToolStripMenuItem.Name = "addFileToolStripMenuItem";
            this.addFileToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.addFileToolStripMenuItem.Text = "Add File";
            this.addFileToolStripMenuItem.Click += new System.EventHandler(this.addFileToolStripMenuItem_Click);
            // 
            // toolStripMruList1
            // 
            this.toolStripMruList1.Enabled = false;
            this.toolStripMruList1.MaxPathLength = 40;
            this.toolStripMruList1.MruListSize = 5;
            this.toolStripMruList1.Name = "toolStripMruList1";
            this.toolStripMruList1.RecentFileList = new string[0];
            this.toolStripMruList1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMruList1.Text = "Recent File List";
            this.toolStripMruList1.RecentFileClicked += new System.EventHandler<CodeArtEng.Controls.RecentFileClickedEventArgs>(this.toolStripMruList1_RecentFileClicked);
            // 
            // quickAccessList1
            // 
            this.quickAccessList1.Name = "quickAccessList1";
            this.quickAccessList1.SearchPaths = ((System.Collections.Generic.List<string>)(resources.GetObject("quickAccessList1.SearchPaths")));
            this.quickAccessList1.Size = new System.Drawing.Size(108, 20);
            this.quickAccessList1.Text = "quickAccessList1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 231);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private CodeArtEng.Controls.ToolStripMruList toolStripMruList1;
        private System.Windows.Forms.ToolStripMenuItem addFileToolStripMenuItem;
        private CodeArtEng.Controls.QuickAccessList quickAccessList1;
    }
}

