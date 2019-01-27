namespace CodeArtEng.Controls
{
    partial class CommandLineBuilderDialog
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btCreateShortcut = new System.Windows.Forms.Button();
            this.btCreateBatchFile = new System.Windows.Forms.Button();
            this.btCopyToClipboard = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCommandOutput = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.optionsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btCreateShortcut);
            this.panel1.Controls.Add(this.btCreateBatchFile);
            this.panel1.Controls.Add(this.btCopyToClipboard);
            this.panel1.Controls.Add(this.btClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 471);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(694, 41);
            this.panel1.TabIndex = 0;
            // 
            // btCreateShortcut
            // 
            this.btCreateShortcut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCreateShortcut.Location = new System.Drawing.Point(254, 4);
            this.btCreateShortcut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btCreateShortcut.Name = "btCreateShortcut";
            this.btCreateShortcut.Size = new System.Drawing.Size(160, 28);
            this.btCreateShortcut.TabIndex = 1;
            this.btCreateShortcut.Text = "Create Shortcut";
            this.btCreateShortcut.UseVisualStyleBackColor = true;
            this.btCreateShortcut.Click += new System.EventHandler(this.btCreateShortcut_Click);
            // 
            // btCreateBatchFile
            // 
            this.btCreateBatchFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCreateBatchFile.Location = new System.Drawing.Point(86, 4);
            this.btCreateBatchFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btCreateBatchFile.Name = "btCreateBatchFile";
            this.btCreateBatchFile.Size = new System.Drawing.Size(160, 28);
            this.btCreateBatchFile.TabIndex = 2;
            this.btCreateBatchFile.Text = "Create Batch File";
            this.btCreateBatchFile.UseVisualStyleBackColor = true;
            this.btCreateBatchFile.Click += new System.EventHandler(this.btCreateBatchFile_Click);
            // 
            // btCopyToClipboard
            // 
            this.btCopyToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCopyToClipboard.Location = new System.Drawing.Point(422, 4);
            this.btCopyToClipboard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btCopyToClipboard.Name = "btCopyToClipboard";
            this.btCopyToClipboard.Size = new System.Drawing.Size(160, 28);
            this.btCopyToClipboard.TabIndex = 1;
            this.btCopyToClipboard.Text = "Copy to Clipboard";
            this.btCopyToClipboard.UseVisualStyleBackColor = true;
            this.btCopyToClipboard.Click += new System.EventHandler(this.btCopyToClipboard_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btClose.Location = new System.Drawing.Point(590, 4);
            this.btClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(100, 28);
            this.btClose.TabIndex = 0;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCommandOutput);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(694, 156);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Command Line Output";
            // 
            // txtCommandOutput
            // 
            this.txtCommandOutput.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtCommandOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCommandOutput.Location = new System.Drawing.Point(4, 19);
            this.txtCommandOutput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCommandOutput.Multiline = true;
            this.txtCommandOutput.Name = "txtCommandOutput";
            this.txtCommandOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCommandOutput.Size = new System.Drawing.Size(686, 133);
            this.txtCommandOutput.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.optionsPanel);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 158);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(694, 313);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // optionsPanel
            // 
            this.optionsPanel.AutoScroll = true;
            this.optionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.optionsPanel.Location = new System.Drawing.Point(4, 19);
            this.optionsPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(686, 290);
            this.optionsPanel.TabIndex = 0;
            this.optionsPanel.WrapContents = false;
            // 
            // CommandLineBuilderDialog
            // 
            this.AcceptButton = this.btClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 514);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CommandLineBuilderDialog";
            this.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Text = "Command Line Builder";
            this.Shown += new System.EventHandler(this.CommandLineBuilderDialog_Shown);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btCreateShortcut;
        private System.Windows.Forms.Button btCreateBatchFile;
        private System.Windows.Forms.Button btCopyToClipboard;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCommandOutput;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel optionsPanel;
    }
}