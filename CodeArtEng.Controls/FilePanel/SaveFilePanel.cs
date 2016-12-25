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
    /// Panel which associate with <see cref="TextBox"/> and <see cref="SaveFileDialog"/> for file selection.
    /// </summary>
    [ToolboxItem(true)]
    public class SaveFilePanel : FilePanelBase
    {
        private System.Windows.Forms.SaveFileDialog saveFileDialog;

        /// <summary>
        /// Constructor
        /// </summary>
        public SaveFilePanel() : base() { InitializeComponent(); }

        private void InitializeComponent()
        {
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // btBrowse
            // 
            this.btBrowse.Click += new System.EventHandler(this.btBrowse_Click);
            // 
            // openFileDialog1
            // 
            this.saveFileDialog.FileName = "saveFileDialog";
            this.saveFileDialog.SupportMultiDottedExtensions = true;
            // 
            // SaveFilePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "SaveFilePanel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        internal override bool ValidateDropData(string filePath)
        {
            FileAttributes attr = File.GetAttributes(filePath);
            if (attr.HasFlag(FileAttributes.Directory)) return false;
            else return true;
        }

        private void btBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog.InitialDirectory = Path.GetDirectoryName(SelectedFile);
                saveFileDialog.FileName = Path.GetFileName(SelectedFile);
            }
            catch
            {
                saveFileDialog.InitialDirectory = string.Empty;
                saveFileDialog.FileName = string.Empty;
            }
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SelectedFile = saveFileDialog.FileName;
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
            get { return saveFileDialog.Filter; }
            set { saveFileDialog.Filter = value; }
        }

        /// <summary>
        /// Verify selected path in open file dialog.
        /// </summary>
        [Category("File Panel")]
        [DefaultValue(true)]
        public bool VerifyPath
        {
            get { return saveFileDialog.CheckPathExists; }
            set { saveFileDialog.CheckPathExists = value; }
        }

        /// <summary>
        /// Verify selected file in open file dialog.
        /// </summary>
        [Category("File Panel")]
        [DefaultValue(true)]
        public bool VerifyFileName
        {
            get { return saveFileDialog.CheckFileExists; }
            set { saveFileDialog.CheckFileExists = value; }
        }
    }
}
