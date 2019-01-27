namespace CodeArtEng.Controls
{
    partial class CommandMacroEditor
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
            this.TxtCommand = new System.Windows.Forms.TextBox();
            this.MacroGridView = new System.Windows.Forms.DataGridView();
            this.ColMacro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btCancel = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.btInsert = new System.Windows.Forms.Button();
            this.btAddFolder = new System.Windows.Forms.Button();
            this.btAddFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.MacroGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtCommand
            // 
            this.TxtCommand.Location = new System.Drawing.Point(11, 10);
            this.TxtCommand.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtCommand.Multiline = true;
            this.TxtCommand.Name = "TxtCommand";
            this.TxtCommand.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtCommand.Size = new System.Drawing.Size(708, 157);
            this.TxtCommand.TabIndex = 0;
            // 
            // MacroGridView
            // 
            this.MacroGridView.AllowUserToAddRows = false;
            this.MacroGridView.AllowUserToDeleteRows = false;
            this.MacroGridView.AllowUserToResizeRows = false;
            this.MacroGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MacroGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MacroGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColMacro,
            this.ColValue});
            this.MacroGridView.Location = new System.Drawing.Point(11, 175);
            this.MacroGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MacroGridView.Name = "MacroGridView";
            this.MacroGridView.ReadOnly = true;
            this.MacroGridView.RowHeadersVisible = false;
            this.MacroGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MacroGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MacroGridView.Size = new System.Drawing.Size(709, 286);
            this.MacroGridView.TabIndex = 1;
            this.MacroGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MacroGridView_CellDoubleClick);
            this.MacroGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MacroGridView_KeyDown);
            // 
            // ColMacro
            // 
            this.ColMacro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColMacro.HeaderText = "Macro";
            this.ColMacro.Name = "ColMacro";
            this.ColMacro.ReadOnly = true;
            this.ColMacro.Width = 76;
            // 
            // ColValue
            // 
            this.ColValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColValue.HeaderText = "Value";
            this.ColValue.Name = "ColValue";
            this.ColValue.ReadOnly = true;
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(620, 468);
            this.btCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(100, 28);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // btOK
            // 
            this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOK.Location = new System.Drawing.Point(512, 468);
            this.btOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(100, 28);
            this.btOK.TabIndex = 3;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btInsert
            // 
            this.btInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btInsert.Location = new System.Drawing.Point(11, 468);
            this.btInsert.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btInsert.Name = "btInsert";
            this.btInsert.Size = new System.Drawing.Size(100, 28);
            this.btInsert.TabIndex = 4;
            this.btInsert.Text = "Insert";
            this.btInsert.UseVisualStyleBackColor = true;
            this.btInsert.Click += new System.EventHandler(this.btInsert_Click);
            // 
            // btAddFolder
            // 
            this.btAddFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btAddFolder.Location = new System.Drawing.Point(119, 468);
            this.btAddFolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btAddFolder.Name = "btAddFolder";
            this.btAddFolder.Size = new System.Drawing.Size(100, 28);
            this.btAddFolder.TabIndex = 5;
            this.btAddFolder.Text = "Add Folder";
            this.btAddFolder.UseVisualStyleBackColor = true;
            this.btAddFolder.Click += new System.EventHandler(this.btAddFolder_Click);
            // 
            // btAddFile
            // 
            this.btAddFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btAddFile.Location = new System.Drawing.Point(227, 468);
            this.btAddFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btAddFile.Name = "btAddFile";
            this.btAddFile.Size = new System.Drawing.Size(100, 28);
            this.btAddFile.TabIndex = 6;
            this.btAddFile.Text = "Add File";
            this.btAddFile.UseVisualStyleBackColor = true;
            this.btAddFile.Click += new System.EventHandler(this.btAddFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Title = "Select File...";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Select Folder";
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // CommandMacroEditor
            // 
            this.AcceptButton = this.btOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(731, 506);
            this.Controls.Add(this.btAddFile);
            this.Controls.Add(this.btAddFolder);
            this.Controls.Add(this.btInsert);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.MacroGridView);
            this.Controls.Add(this.TxtCommand);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CommandMacroEditor";
            this.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Text = "CommandMacroEditor";
            ((System.ComponentModel.ISupportInitialize)(this.MacroGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtCommand;
        private System.Windows.Forms.DataGridView MacroGridView;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMacro;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColValue;
        private System.Windows.Forms.Button btInsert;
        private System.Windows.Forms.Button btAddFolder;
        private System.Windows.Forms.Button btAddFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}