using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

#if NET472
using WK.Libraries.BetterFolderBrowserNS;
#endif

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
        /// Occurs when <see cref="SelectedPath"/> property changed.
        /// </summary>
        public event EventHandler SelectedPathChanged;

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
        public FolderBrowsePanel() : base() { InitializeComponent();
            ValueChangedCallback = TextboxValueChangedCallback;
        }

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
#if NET472
            if (!LegacyMode)
            {
                try
                {
                    using (BetterFolderBrowser dialog = new BetterFolderBrowser())
                    {
                        dialog.Title = "Select Folders...";
                        dialog.RootFolder = SelectedPath;
                        dialog.Multiselect = false;

                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            SelectedPath = dialog.SelectedFolder;
                        }
                    }
                }
                catch (NullReferenceException)
                {
                    BrowseFolder_FolderBrowseDialog();
                }
            }
            else BrowseFolder_FolderBrowseDialog();
#else
            BrowseFolder_FolderBrowseDialog();
#endif
        }

        private void BrowseFolder_FolderBrowseDialog()
        {
            try { folderBrowserDialog1.SelectedPath = SelectedPath; }
            catch { SelectedPath = string.Empty; }
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                SelectedPath = folderBrowserDialog1.SelectedPath;
            }
        }

        private void TextboxValueChangedCallback()
        {
            SelectedPathChanged?.Invoke(this, null);
        }

        /// <summary>
        /// Get or set selected directory
        /// </summary>
        [Category("Folder Panel")]
        public string SelectedPath
        {
            get { return textbox.Text; }
            set
            {
                textbox.Text = value;
                SelectedPathChanged?.Invoke(this, null);
            }
        }
    }
}
