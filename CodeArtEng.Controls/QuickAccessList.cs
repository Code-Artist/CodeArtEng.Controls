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
    /// Quick Access List
    /// </summary>
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    [DefaultEvent("ItemClicked")]
    public class QuickAccessList : ToolStripMenuItem
    {
        #region [ Properties ]

        /// <summary>
        /// Define search filter for files.
        /// </summary>
        [Browsable(true), Description("Define search filter for files.")]
        [DefaultValue("*.*")]
        public string FileFilter { get; set; } = "*.*";

        /// <summary>
        /// Define search folder for child items.
        /// </summary>
        [Browsable(false)]
        //ToDo: Create editor?
        public List<string> SearchPaths { get; set; } = new List<string>();

        #endregion

        private readonly Stack<ToolStripMenuItem> ParentsStacks = new Stack<ToolStripMenuItem>();

        /// <summary>
        /// Rebuild list
        /// </summary>
        public void UpdateList()
        {
            DropDownItems.Clear();

            ToolStripMenuItem ptrItem = this;
            ToolStripMenuItem newItem;
            foreach (string p in SearchPaths)
            {
                try
                {
                    string fullPath = Path.GetFullPath(p);
                    FileAttributes attr = File.GetAttributes(fullPath);
                    if (IsDirectory(attr))
                    {
                        newItem = new ToolStripMenuItem(fullPath.Split('\\').Last());
                        ptrItem.DropDownItems.Add(newItem);
                        ParentsStacks.Push(ptrItem);
                        ptrItem = newItem;
                        ptrItem.DropDownItemClicked += PtrItem_DropDownItemClicked;

                        string[] files = Directory.GetFiles(fullPath, FileFilter);
                        foreach (string f in files)
                        {
                            newItem = new ToolStripMenuItem(Path.GetFileName(f));
                            newItem.Tag = Path.GetFullPath(f);
                            ptrItem.DropDownItems.Add(newItem);
                        }
                        ptrItem = ParentsStacks.Pop();
                    }
                }
                catch (FileNotFoundException) { continue; }
                catch (DirectoryNotFoundException) { continue; }
            }
        }

        private void PtrItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            OnItemClicked(e.ClickedItem);
        }

        private bool IsDirectory(FileAttributes attributes)
        {
            return (attributes & FileAttributes.Directory) > 0;
        }


        #region [ Events ]
        /// <summary>
        /// Event raised when item clicked
        /// </summary>
        public event EventHandler<ToolStripItemClickedEventArgs> ItemClicked;

        private void OnItemClicked(ToolStripItem sender)
        {
            ItemClicked?.Invoke(this, new ToolStripItemClickedEventArgs(sender));
        }
        #endregion  
    }
}
