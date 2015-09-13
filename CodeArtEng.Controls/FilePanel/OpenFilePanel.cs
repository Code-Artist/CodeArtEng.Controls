using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace CodeArtEng.Controls
{
    /// <summary>
    /// Panel which associate with <see cref="TextBox"/> and <see cref="OpenFileDialog"/> for file selection.
    /// </summary>
    [ToolboxItem(true)]
    public class OpenFilePanel : FilePanelBase
    {
        private System.Windows.Forms.OpenFileDialog openFileDialog1;

        /// <summary>
        /// Constructor
        /// </summary>
        public OpenFilePanel() : base() { InitializeComponent(); }

        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btBrowse
            // 
            this.btBrowse.Click += new System.EventHandler(this.btBrowse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.SupportMultiDottedExtensions = true;
            // 
            // OpenFilePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "OpenFilePanel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public override bool ValidateDropData(string filePath)
        {
            FileAttributes attr = File.GetAttributes(filePath);
            if (attr.HasFlag(FileAttributes.Directory)) return false;
            else return true;
        }

        private void btBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.InitialDirectory = Path.GetDirectoryName(SelectedFile);
                openFileDialog1.FileName = Path.GetFileName(SelectedFile);
            }
            catch
            {
                openFileDialog1.InitialDirectory = string.Empty;
                openFileDialog1.FileName = string.Empty;
            }
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SelectedFile = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Get or set file name for selected file.
        /// </summary>
        [Category("File Panel")]
        public string SelectedFile
        {
            get { return textbox.Text; }
            set { textbox.Text = value; }
        }

        /// <summary>
        /// Get or set filter for file selection dialog
        /// </summary>
        [Category("File Panel")]
        public string FileFilter
        {
            get { return openFileDialog1.Filter; }
            set { openFileDialog1.Filter = value; }
        }

        /// <summary>
        /// Verify selected path in open file dialog.
        /// </summary>
        [Category("File Panel")]
        [DefaultValue(true)]
        public bool VerifyPath
        {
            get { return openFileDialog1.CheckPathExists; }
            set { openFileDialog1.CheckPathExists = value; }
        }

        /// <summary>
        /// Verify selected file in open file dialog.
        /// </summary>
        [Category("File Panel")]
        [DefaultValue(true)]
        public bool VerifyFileName
        {
            get { return openFileDialog1.CheckFileExists; }
            set { openFileDialog1.CheckFileExists = value; }
        }
    }
}
