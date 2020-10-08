using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CodeArtEng.Controls
{
    /// <summary>
    /// File explorer control. Capable to explore local and remote path.
    /// </summary>
    public partial class FileExplorer : UserControl
    {
        private enum ImageIndexName
        {
            MyComputer = 0,
            HDD = 1,
            Folder = 2,
            FolderOpen = 3,
            File = 4,
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public FileExplorer()
        {
            InitializeComponent();
            FolderTreeView.Dock = DockStyle.Fill;
            FileListView.Dock = DockStyle.Fill;
            FileListView.Items.Clear();

            HideSystemFolder = true;
            _SplitterDistance = SplitterDistance;
        }

        #region [ Private Fields and Methods ]

        private TreeNode SelectedNode { get; set; }
        private IFileExplorer ExplorerHandler;
        private int _SplitterDistance;
        private void RefreshFileList()
        {
            ListViewItem ptrListItem;
            FileListView.Items.Clear();
            if (SelectedFolder == null) return;

            FileExplorerItemInfo[] folders = ExplorerHandler.GetDirectories(SelectedFolder);
            if (folders == null) return;
            foreach (FileExplorerItemInfo ptrItem in folders)
            {
                if (ptrItem.Attributes.HasFlag(FileAttributes.System) && HideSystemFolder) continue;
                ptrListItem = FileListView.Items.Add(ptrItem.Name);
                ptrListItem.Text = ptrItem.Name;
                ptrListItem.ImageIndex = (int)ImageIndexName.Folder;
            }

            if (!ShowFoldersOnly)
            {
                FileExplorerItemInfo[] files = ExplorerHandler.GetFiles(SelectedFolder);
                if (files == null) return;
                foreach (FileExplorerItemInfo ptrFile in files)
                {
                    if (ptrFile.Attributes.HasFlag(FileAttributes.System) && HideSystemFolder) continue;
                    ptrListItem = FileListView.Items.Add(ptrFile.Name);
                    ptrListItem.Text = ptrFile.Name;
                    ptrListItem.SubItems.Add(ptrFile.LastWriteTime.ToString());
                    ptrListItem.SubItems.Add((ptrFile.Length / 1024).ToString() + " KB");
                    ptrListItem.ImageIndex = (int)ImageIndexName.File;
                }
            }
            FileListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        private string[] _SelectedFiles;

        #endregion

        #region [ Public Property ]

        /// <summary>
        /// Hide all files.
        /// </summary>
        [DefaultValue(false)]
        [Description("Hide all files")]
        public bool ShowFoldersOnly { get; set; } = false;

        /// <summary>
        /// Allows multiple items to be selected.
        /// </summary>
        [DefaultValue(true)]
        [Description("Allows multiple items to be selected.")]
        public bool MultiSelect { get => FileListView.MultiSelect; set => FileListView.MultiSelect = value; }

        /// <summary>
        /// Return folder selected in folder tree view.
        /// </summary>
        [Browsable(false)]
        public string SelectedFolder { get; private set; }

        /// <summary>
        /// Show / hide system folder
        /// </summary>
        [Category("Explorer")]
        [DisplayName("Hide System Folder")]
        [Description("Show / hide system folders")]
        public bool HideSystemFolder { get; set; }

        /// <summary>
        /// Configure file window's view.
        /// </summary>
        [Category("Explorer")]
        [DisplayName("File View")]
        [Description("Configure file window's view.")]
        public View FileView
        {
            get { return FileListView.View; }
            set { FileListView.View = value; }
        }

        /// <summary>
        /// Determines pixel distance of the splitter from the left of top edge.
        /// </summary>
        [Category("Explorer")]
        [DisplayName("SplitterDistance")]
        [Description("Determines pixel distance of the splitter from the left of top edge.")]
        public int SplitterDistance
        {
            get { return splitContainer1.SplitterDistance; }
            set { _SplitterDistance = splitContainer1.SplitterDistance = value; }
        }

        #endregion

        #region [ Public Methods ]

        /// <summary>
        /// Attach control to local.
        /// </summary>
        public void AttachToMyComputer()
        {
            ExplorerHandler = new LocalFileExplorer();
            DriveInfo[] drives = DriveInfo.GetDrives();
            FolderTreeView.Nodes.Clear();

            TreeNode ptrNode = FolderTreeView.Nodes.Add("My Computer");
            ptrNode.ImageIndex = (int)ImageIndexName.MyComputer;
            ptrNode.SelectedImageIndex = (int)ImageIndexName.MyComputer;
            TreeNode childNode;
            foreach (DriveInfo ptrDrive in drives)
            {
                if ((ptrDrive.DriveType == DriveType.Fixed) ||
                    (ptrDrive.DriveType == DriveType.Removable))
                {
                    childNode = ptrNode.Nodes.Add(ptrDrive.Name);
                    childNode.Name = childNode.Text;
                    childNode.Tag = ptrDrive.Name;
                    childNode.ImageIndex = (int)ImageIndexName.HDD;
                    childNode.SelectedImageIndex = (int)ImageIndexName.HDD;
                    childNode.Nodes.Add(" ");
                }
            }
            ptrNode.Expand(); //Expand node to drive level.
            OnSourceChanged();
        }
        /// <summary>
        /// Attach control to object which implement IFileExplorer interface.
        /// </summary>
        /// <param name="source"></param>
        public void AttachSource(IFileExplorer source)
        {
            if (ExplorerHandler != null)
            {
                //Remove old Events
                ExplorerHandler.DeviceConnected -= ExplorerHandler_DeviceConnected;
                ExplorerHandler.DeviceDisconnected -= ExplorerHandler_DeviceDisconnected;
            }
            ExplorerHandler = source;
            ExplorerHandler.DeviceConnected += ExplorerHandler_DeviceConnected;
            ExplorerHandler.DeviceDisconnected += ExplorerHandler_DeviceDisconnected;

            RefreshFolderTreeView();
            OnSourceChanged();
        }

        private void ExplorerHandler_DeviceDisconnected(object sender, EventArgs e)
        {
            if (SuspendEvent) return;
            ClearTreeView();
        }

        private void ClearTreeView()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(ClearTreeView));
                return;
            }
            FolderTreeView.Nodes.Clear();
            FileListView.Clear();
        }

        private bool SuspendEvent = false;

        private void ExplorerHandler_DeviceConnected(object sender, EventArgs e)
        {
            if (SuspendEvent) return;
            RefreshFolderTreeView();
        }

        /// <summary>
        /// Refresh Folders in File Explorer
        /// </summary>
        public void RefreshFolderTreeView()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(RefreshFolderTreeView));
                return;
            }

            SuspendEvent = true;
            try
            {

                //Reconnect used by MediaDevice - Must run in Main Thread.
                if (!ExplorerHandler.IsConnected) ExplorerHandler.Reconnect();
                FolderTreeView.Nodes.Clear();
                FileListView.Clear();

                if (!string.IsNullOrEmpty(ExplorerHandler.Name))
                {
                    if (!ExplorerHandler.IsConnected) return;
                    TreeNode ptrNode = FolderTreeView.Nodes.Add(ExplorerHandler.Name);
                    ptrNode.Name = ptrNode.Text;
                    ptrNode.ImageIndex = (int)ImageIndexName.Folder;
                    ptrNode.Tag = ExplorerHandler.Root;
                    ptrNode.SelectedImageIndex = (int)ImageIndexName.Folder;
                    ptrNode.Nodes.Add(" ");
                }
            }
            finally { SuspendEvent = false; }
        }

        /// <summary>
        /// Unsubscribe control from current source
        /// </summary>
        public void DetachSource()
        {
            FolderTreeView.Nodes.Clear();
            FileListView.Clear();
            ExplorerHandler = null;
            SelectedFolder = string.Empty;
            _SelectedFiles = null;
        }
        /// <summary>
        /// Get list of selected file.
        /// </summary>
        /// <returns></returns>
        public string[] SelectedFiles() { return _SelectedFiles; }
        /// <summary>
        /// Refresh control.
        /// </summary>
        public override void Refresh()
        {
            if (ExplorerHandler == null) return;
            if (ExplorerHandler.IsConnected)
            {
                RefreshFileList();
                base.Refresh();
            }
        }

        /// <summary>
        /// Set and focus selected path.
        /// </summary>
        /// <param name="directory"></param>
        public void SetSelectedFolder(string directory)
        {
            SuspendLayout();
            try
            {
                if (!string.IsNullOrEmpty(ExplorerHandler.FolderPathPrefix))
                {
                    //Remove prefix folder path if matched
                    if (directory.StartsWith(ExplorerHandler.FolderPathPrefix, StringComparison.InvariantCultureIgnoreCase))
                    {
                        directory = directory.Substring(ExplorerHandler.FolderPathPrefix.Length);
                    }
                }

                string root = ExplorerHandler.GetSelectedFolderRoot(directory);
                string[] folders = directory.Replace(root, "").Split(new char[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries);
                TreeNode ptrNode = FolderTreeView.Nodes.Find(root, true)?.First();
                FolderTreeView.SelectedNode = ptrNode;
                ptrNode.Expand();
                foreach (string f in folders)
                {
                    ptrNode = ptrNode.Nodes.Find(f, false).First();
                    ptrNode.Expand();
                }
                FolderTreeView.SelectedNode = ptrNode;
                SelectedFolder = directory;
            }
            catch (Exception ex)
            {
                Trace.WriteLine("ERROR: Unable to set initial directory: " + directory + "\n" + ex.Message);
            }
        }

        #endregion

        #region [ Events ]

        private void HandleFileExplorerEvent(EventHandler<FileExplorerEventArgs> eventHandler, FileExplorerEventArgs args)
        {
            eventHandler?.Invoke(this, args);
        }
        private bool HandleKeyEvent(KeyEventHandler eventHandle, KeyEventArgs args)
        {
            KeyEventHandler handler = eventHandle;
            if (handler == null) return false;

            args.Handled = false;
            handler?.Invoke(this, args);
            return args.Handled;
        }

        /// <summary>
        /// Event raised when folder in folder tree view is selected
        /// </summary>
        public event EventHandler<FileExplorerEventArgs> FolderSelected;
        /// <summary>
        /// Event raised when file source had changed.
        /// </summary>
        public event EventHandler<FileExplorerEventArgs> SourceChanged;
        /// <summary>
        /// Event raised when user double clicked file with mouse
        /// </summary>
        public event EventHandler<FileExplorerEventArgs> FileDoubleClicked;
        /// <summary>
        /// Event raised when key is pressed.
        /// </summary>
        public new event KeyEventHandler KeyDown; //Hide base class event

        private void OnFolderSelected() { HandleFileExplorerEvent(FolderSelected, new FileExplorerEventArgs()); }
        private void OnSourceChanged() { HandleFileExplorerEvent(SourceChanged, new FileExplorerEventArgs()); }
        private void OnFileDoubleClicked() { HandleFileExplorerEvent(FileDoubleClicked, new FileExplorerEventArgs()); }
        private bool OnControlKeyDown(KeyEventArgs e) { return HandleKeyEvent(KeyDown, e); }

        #endregion

        #region [ (Internal) FolderTreeView Events ]

        private void FolderTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode ptrNode = e.Node;
            if (ptrNode.Tag == null) return;

            ptrNode.Nodes.Clear();
            try
            {
                FileExplorerItemInfo[] subFolders = ExplorerHandler.GetDirectories(ptrNode.Tag.ToString());
                TreeNode childNode;
                foreach (FileExplorerItemInfo ptrDir in subFolders)
                {
                    if (ptrDir.Attributes.HasFlag(FileAttributes.System) && HideSystemFolder) continue;
                    if (ptrDir.Attributes.HasFlag(FileAttributes.Directory))
                    {
                        childNode = ptrNode.Nodes.Add(ptrDir.Name);
                        childNode.Name = childNode.Text;
                        childNode.ImageIndex = (int)ImageIndexName.Folder; ;
                        childNode.SelectedImageIndex = (int)ImageIndexName.FolderOpen;
                        childNode.Tag = ptrDir.FullName;
                        childNode.Nodes.Add(" ");
                    }
                }
            }
            catch (Exception ex)
            {
                //Private events has no direct caller, don't rethrow exception.
                MessageBox.Show("Unable to access folder " + ptrNode.Tag.ToString() + "\n" + ex.Message,
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FolderTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectedNode = FolderTreeView.SelectedNode;
            try
            {
                _SelectedFiles = null;
                SelectedFolder = SelectedNode?.Tag?.ToString();
            }
            catch (NullReferenceException) { SelectedFolder = string.Empty; }
            TxtSelectedFolder.Text = ExplorerHandler.FolderPathPrefix + SelectedFolder; //Append prefix folder path
            OnFolderSelected();
            RefreshFileList();
        }
        private void FolderTreeView_KeyDown(object sender, KeyEventArgs e)
        {
            if (OnControlKeyDown(e) == true) return;
            if (e.KeyCode == Keys.F5)
            {
                TreeNode backup = SelectedNode;
                FolderTreeView.SelectedNode = FolderTreeView.SelectedNode.Parent;
                FolderTreeView.SelectedNode.Expand(); //Get subfolders
                TreeNodeCollection childNodes = FolderTreeView.SelectedNode.Nodes;
                try
                {
                    foreach (TreeNode ptrChild in childNodes)
                    {
                        if (string.Compare(ptrChild.Text, backup.Text) == 0)
                            FolderTreeView.SelectedNode = ptrChild;
                    }
                }
                catch { /* Do Nothing */ }
                finally { RefreshFileList(); }
            }
        }

        private void TxtSelectedFolder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                string inputPath = TxtSelectedFolder.Text;
                SetSelectedFolder(inputPath);
            }
        }

        #endregion

        #region [ (Internal) FileListView Events ]

        private void FileListView_DoubleClick(object sender, EventArgs e)
        {
            if (FileListView.SelectedItems.Count == 0) return;
            ListViewItem ptrItem = FileListView.SelectedItems[0];
            if (ptrItem.ImageIndex == (int)ImageIndexName.File)
            {
                OnFileDoubleClicked();
                return;
            }

            //Selected items not found. Expand to next level
            FolderTreeView.SelectedNode.Expand();
            if (FolderTreeView.SelectedNode.Nodes != null)
            {
                TreeNodeCollection subNodes = FolderTreeView.SelectedNode.Nodes;
                foreach (TreeNode ptrNode in subNodes)
                {
                    if (ptrNode.Text == ptrItem.Text)
                        FolderTreeView.SelectedNode = ptrNode;
                }
            }

        }
        private void FileListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (OnControlKeyDown(e) == true) return;
            if (e.KeyCode == Keys.F5)
            {
                //Refresh file list
                RefreshFileList();
            }
        }
        private void FileListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection items = FileListView.SelectedItems;
            _SelectedFiles = new string[items.Count];
            string separator = ExplorerHandler.PathSeparator.ToString();
            for (int x = 0; x < items.Count; x++)
            {
                _SelectedFiles[x] = SelectedFolder + (SelectedFolder.EndsWith(separator) ? "" : separator) + items[x].Text;
            }
        }

        #endregion

        #region [ (Internal) splitContainer1 Events ]

        private bool TrackSplitterMove;
        private void splitContainer1_SizeChanged(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = _SplitterDistance;
        }
        private void splitContainer1_MouseDown(object sender, MouseEventArgs e)
        {
            TrackSplitterMove = true;
        }
        private void splitContainer1_MouseUp(object sender, MouseEventArgs e)
        {
            TrackSplitterMove = false;
        }
        private void splitContainer1_SplitterMoving(object sender, SplitterCancelEventArgs e)
        {
            if (TrackSplitterMove)
            {
                _SplitterDistance = e.SplitX;
            }
        }

        #endregion

        #region [ (Internal) FileListView - Context Menu Events ]

        private void viewContextSmallIcon_Click(object sender, EventArgs e)
        {

        }
        private void viewToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            View viewType = FileListView.View;
            ToolStripItemCollection items = viewToolStripMenuItem.DropDownItems;
            foreach (ToolStripMenuItem ptrItem in items)
                ptrItem.Checked = false;

            switch (viewType)
            {
                case View.SmallIcon:
                    viewContextSmallIcon.Checked = true;
                    break;
                case View.LargeIcon:
                    viewContextLargeIcon.Checked = true;
                    break;
                case View.List:
                    viewContextList.Checked = true;
                    break;
                case View.Tile:
                    viewContextTile.Checked = true;
                    break;
                case View.Details:
                    viewContextDetail.Checked = true;
                    break;
                default: break;
            }
        }
        private void viewContext_Clicked(object sender, EventArgs e)
        {
            string caption = ((ToolStripMenuItem)sender).Text;
            if (caption == viewContextSmallIcon.Text) FileListView.View = View.SmallIcon;
            else if (caption == viewContextLargeIcon.Text) FileListView.View = View.LargeIcon;
            else if (caption == viewContextList.Text) FileListView.View = View.List;
            else if (caption == viewContextDetail.Text) FileListView.View = View.Details;
            else if (caption == viewContextTile.Text) FileListView.View = View.Tile;
        }

        #endregion

    }

    /// <summary>
    /// File explorer event arguments.
    /// </summary>
    public class FileExplorerEventArgs : EventArgs
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public FileExplorerEventArgs() : base() { }
    }
}
