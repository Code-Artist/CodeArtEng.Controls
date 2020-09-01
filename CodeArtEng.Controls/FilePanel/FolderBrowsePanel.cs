using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace CodeArtEng.Controls
{
    /// <summary>
    /// Panel which associated with <see cref="TextBox"/> and <see cref="FolderBrowserDialog"/> for path selection.
    /// </summary>
    [ToolboxItem(true)]
    public class FolderBrowsePanel : FilePanelBase
    {
        private FolderBrowserDialog folderBrowserDialog1;

        /// <summary>
        /// New folder browse dialog implemented using WindowsAPICodePack-Shell. 
        /// Set LegacyMode flag to use original Window's built in folder browse dialog.
        /// </summary>
        [Description("When set, use Windows built in folder brose dialog.")]
        [DefaultValue(false)]
        public bool LegacyMode { get; set; } = false;

        /// <summary>
        /// Constructor
        /// </summary>
        public FolderBrowsePanel() : base() { InitializeComponent(); }

        private void InitializeComponent()
        {
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // btBrowse
            // 
            this.btBrowse.Click += new System.EventHandler(this.btBrowse_Click);
            // 
            // textbox
            // 
            this.textbox.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            // 
            // FolderBrowsePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "FolderBrowsePanel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        internal override bool ValidateDropData(string filePath)
        {
            FileAttributes attr = File.GetAttributes(filePath);
            if (attr.HasFlag(FileAttributes.Directory)) return true;
            else return false;
        }

        private void btBrowse_Click(object sender, EventArgs e)
        {
            if (!LegacyMode)
            {
                using (CommonOpenFileDialog dialog = new CommonOpenFileDialog())
                {
                    dialog.IsFolderPicker = true;
                    dialog.InitialDirectory = SelectedPath;
                    if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                    {
                        SelectedPath = dialog.FileName;
                    }
                }
            }
            else
            {
                try { folderBrowserDialog1.SelectedPath = SelectedPath; }
                catch { SelectedPath = string.Empty; }
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    SelectedPath = folderBrowserDialog1.SelectedPath;
                }
            }
        }

        /// <summary>
        /// Get or set selected directory
        /// </summary>
        [Category("Folder Panel")]
        public string SelectedPath
        {
            get { return textbox.Text; }
            set { textbox.Text = value; }
        }
    }
}
