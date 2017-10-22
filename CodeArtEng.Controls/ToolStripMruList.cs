using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace CodeArtEng.Controls
{
    /// <summary>
    /// Toolstrip Most Recently Used (MRU) List
    /// </summary>
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    [DefaultEvent("RecentFileClicked")]
    public class ToolStripMruList : ToolStripMenuItem
    {
        private List<string> MRUList;

        /// <summary>
        /// Constructor
        /// </summary>
        public ToolStripMruList()
        {
            MRUList = new List<string>();

            //Default Settings
            MruListSize = 5;
            MaxPathLength = 40;
        }

        #region [ Properties ]

        /// <summary>
        /// Number of items in MRU List.
        /// </summary>
        [Browsable(true), Description("Number of items in MRU List.")]
        public int MruListSize { get; set; }

        /// <summary>
        /// File path display length.
        /// Long file path will be truncated. 
        /// Set to -1 to show full path.
        /// </summary>
        [Browsable(true),
        Description("File path display length." +
            "Long file path will be truncated. " +
            "Set to -1 to show full path.")]
        public int MaxPathLength { get; set; }

        #endregion

        /// <summary>
        /// Add recently used file to MRU list
        /// </summary>
        /// <param name="filePath"></param>
        public void AddRecentFileToMruList(string filePath)
        {
            int currentIndex = MRUList.IndexOf(filePath);
            if (currentIndex != -1) MRUList.RemoveAt(currentIndex);

            MRUList.Insert(0, filePath);
            while (MRUList.Count > MruListSize) MRUList.RemoveAt(MruListSize);
            UpdateMruList();
        }
        /// <summary>
        /// Get or set Recent file list items.
        /// </summary>
        public string[] RecentFileList
        {
            get { return MRUList.ToArray(); }
            set
            {
                MRUList.Clear();
                foreach (string ptrValue in value)
                {
                    if (string.IsNullOrEmpty(ptrValue)) continue;
                    MRUList.Add(ptrValue);
                }
                UpdateMruList();
            }
        }

        #region [ Private Functions ]

        private void UpdateMruList()
        {
            //Remove all previous items
            DropDownItems.Clear();

            //Load MRU List
            if (MRUList.Count() == 0) return;
            for (int x = 0; x < MRUList.Count(); x++)
            {
                string recentFile = GetRelativePath(MRUList[x]);
                ToolStripMenuItem newItem = new ToolStripMenuItem(
                    "&" + (x + 1).ToString() + " " + recentFile);
                newItem.Click += new EventHandler(MruItemClicked);
                newItem.Tag = "MRU-" + (x.ToString());
                if (recentFile.Length != MRUList[x].Length)
                    newItem.ToolTipText = MRUList[x];
                DropDownItems.Add(newItem);
            }

            //Add additional feature here
            if (DropDownItems.Count != 0)
            {
                //Clear History
                DropDownItems.Add(new ToolStripSeparator());
                ToolStripMenuItem clearRecentFile = new ToolStripMenuItem("Clear Recent File List");
                DropDownItems.Add(clearRecentFile);
                clearRecentFile.Click += new EventHandler(clearRecentFile_Click);

                //Remove Dead Files
                ToolStripMenuItem removeInvalidFiles = new ToolStripMenuItem("Remove Invalid Files");
                DropDownItems.Add(removeInvalidFiles);
                removeInvalidFiles.Click += new EventHandler(removeInvalidFiles_Click);
            }
        }

        private void removeInvalidFiles_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < MRUList.Count(); x++)
            {
                if (File.Exists(MRUList[x])) continue;
                MRUList.RemoveAt(x);
                x--;
            }
            UpdateMruList();
        }
        private void clearRecentFile_Click(object sender, EventArgs e)
        {
            MRUList.Clear();
            UpdateMruList();
        }

        private string GetRelativePath(string inputPath)
        {
            if (MaxPathLength == -1) return inputPath;
            if (inputPath.Length < MaxPathLength) return inputPath;

            List<string> result = new List<string>();
            string[] tItem = inputPath.Split('\\');
            if (tItem.Count() < 2) return inputPath;

            result.Add(tItem[0]);
            result.Add("...");
            result.Add(tItem.Last());

            //Minimum Requirement
            int totalLength = 0;
            foreach (string item in result) totalLength += item.Length;
            totalLength += result.Count - 1; //Including [\] between each item

            for (int x = tItem.Count() - 2; x > 0; x--)
            {
                if (totalLength + tItem[x].Length < MaxPathLength)
                {
                    result.Insert(2, tItem[x]);
                    totalLength += tItem[x].Length + 1; //Including [\] symbol
                }
                else break;
            }

            string resultString = string.Join("\\", result.ToArray());
            return resultString;
        }
        private void MruItemClicked(object sender, EventArgs e)
        {
            int MruIndex = Convert.ToInt16(((ToolStripMenuItem)sender).Tag.ToString().Split('-')[1]);
            string selectedFile = MRUList[MruIndex];
            OnRecentFileClicked(selectedFile);
            AddRecentFileToMruList(selectedFile);
        }

        #endregion

        #region [ Events ]

        /// <summary>
        /// Event raised when item in recent file list clicked.
        /// </summary>
        public event EventHandler<RecentFileClickedEventArgs> RecentFileClicked;
        private void OnRecentFileClicked(string path)
        {
            EventHandler<RecentFileClickedEventArgs> eventHandler = RecentFileClicked;
            if (eventHandler != null)
                eventHandler(this, new RecentFileClickedEventArgs(path));
        }

        #endregion
    }

    /// <summary>
    /// Recent File List Clicked Event Arguments
    /// </summary>
    public class RecentFileClickedEventArgs : EventArgs
    {
        /// <summary>
        /// Selected file path.
        /// </summary>
        public string FileName { get; private set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fileName">Selected file path.</param>
        public RecentFileClickedEventArgs(string fileName) { FileName = fileName; }
    }
}
