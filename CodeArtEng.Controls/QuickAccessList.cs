using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
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
        /// Defines the search filter for files. This property determines which file types
        /// are included in the search results.
        /// </summary>
        /// <remarks>
        /// By default, the file filter is set to "*.*", which means all file types are included.
        /// You can specify a different filter, such as "*.txt" for text files or "*.jpg" for image files.
        /// </remarks>
        [Category("Search Options"), Browsable(true), Description("Defines the search filter for files.")]
        [DefaultValue("*.*")]
        public string FileFilter { get; set; } = "*.*";

        /// <summary>
        /// Defines the search folder for child items. This property allows users to 
        /// specify multiple search paths, which can be edited at design time using a custom editor.
        /// </summary>
        /// <remarks>
        /// The search paths can be added, deleted, or modified using the interactive editor dialog.
        /// This provides a flexible way to manage multiple directories for searching child items.
        /// </remarks>
        [Category("Search Options"), Editor(typeof(SearchPathsEditor), typeof(UITypeEditor))]
        [Browsable(true), Description("Define search folder for child items.")]
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
