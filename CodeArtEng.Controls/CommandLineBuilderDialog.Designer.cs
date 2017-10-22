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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbDescription = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btCreateShortcut);
            this.panel1.Controls.Add(this.btCreateBatchFile);
            this.panel1.Controls.Add(this.btCopyToClipboard);
            this.panel1.Controls.Add(this.btClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(2, 383);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(521, 33);
            this.panel1.TabIndex = 0;
            // 
            // btCreateShortcut
            // 
            this.btCreateShortcut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCreateShortcut.Location = new System.Drawing.Point(191, 3);
            this.btCreateShortcut.Name = "btCreateShortcut";
            this.btCreateShortcut.Size = new System.Drawing.Size(120, 23);
            this.btCreateShortcut.TabIndex = 1;
            this.btCreateShortcut.Text = "Create Shortcut";
            this.btCreateShortcut.UseVisualStyleBackColor = true;
            this.btCreateShortcut.Click += new System.EventHandler(this.btCreateShortcut_Click);
            // 
            // btCreateBatchFile
            // 
            this.btCreateBatchFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCreateBatchFile.Location = new System.Drawing.Point(65, 3);
            this.btCreateBatchFile.Name = "btCreateBatchFile";
            this.btCreateBatchFile.Size = new System.Drawing.Size(120, 23);
            this.btCreateBatchFile.TabIndex = 2;
            this.btCreateBatchFile.Text = "Create Batch File";
            this.btCreateBatchFile.UseVisualStyleBackColor = true;
            this.btCreateBatchFile.Click += new System.EventHandler(this.btCreateBatchFile_Click);
            // 
            // btCopyToClipboard
            // 
            this.btCopyToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCopyToClipboard.Location = new System.Drawing.Point(317, 3);
            this.btCopyToClipboard.Name = "btCopyToClipboard";
            this.btCopyToClipboard.Size = new System.Drawing.Size(120, 23);
            this.btCopyToClipboard.TabIndex = 1;
            this.btCopyToClipboard.Text = "Copy to Clipboard";
            this.btCopyToClipboard.UseVisualStyleBackColor = true;
            this.btCopyToClipboard.Click += new System.EventHandler(this.btCopyToClipboard_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btClose.Location = new System.Drawing.Point(443, 3);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 0;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCommandOutput);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(521, 127);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Command Line Output";
            // 
            // txtCommandOutput
            // 
            this.txtCommandOutput.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtCommandOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCommandOutput.Location = new System.Drawing.Point(3, 16);
            this.txtCommandOutput.Multiline = true;
            this.txtCommandOutput.Name = "txtCommandOutput";
            this.txtCommandOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCommandOutput.Size = new System.Drawing.Size(515, 108);
            this.txtCommandOutput.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.optionsPanel);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(2, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(521, 254);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // optionsPanel
            // 
            this.optionsPanel.AutoScroll = true;
            this.optionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.optionsPanel.Location = new System.Drawing.Point(3, 48);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(515, 203);
            this.optionsPanel.TabIndex = 0;
            this.optionsPanel.WrapContents = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbDescription);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(515, 32);
            this.panel2.TabIndex = 0;
            // 
            // lbDescription
            // 
            this.lbDescription.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lbDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDescription.Location = new System.Drawing.Point(5, 5);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(505, 22);
            this.lbDescription.TabIndex = 0;
            this.lbDescription.Text = "label1";
            this.lbDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CommandLineBuilderDialog
            // 
            this.AcceptButton = this.btClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 418);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "CommandLineBuilderDialog";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Text = "Command Line Builder";
            this.Shown += new System.EventHandler(this.CommandLineBuilderDialog_Shown);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbDescription;
    }
}