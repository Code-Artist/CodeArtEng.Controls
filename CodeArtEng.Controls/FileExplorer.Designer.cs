namespace CodeArtEng.Controls
{
    partial class FileExplorer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param caption="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileExplorer));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Test", 4);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Test", "Folder_16x16.png");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Test");
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.FolderTreeView = new System.Windows.Forms.TreeView();
            this.FolderIconList = new System.Windows.Forms.ImageList(this.components);
            this.FileListView = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDateModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewContextSmallIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.viewContextLargeIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.viewContextList = new System.Windows.Forms.ToolStripMenuItem();
            this.viewContextDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.viewContextTile = new System.Windows.Forms.ToolStripMenuItem();
            this.LargeImageList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.fileContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.FolderTreeView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.FileListView);
            this.splitContainer1.Size = new System.Drawing.Size(372, 376);
            this.splitContainer1.SplitterDistance = 183;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoving += new System.Windows.Forms.SplitterCancelEventHandler(this.splitContainer1_SplitterMoving);
            this.splitContainer1.SizeChanged += new System.EventHandler(this.splitContainer1_SizeChanged);
            this.splitContainer1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.splitContainer1_MouseDown);
            this.splitContainer1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.splitContainer1_MouseUp);
            // 
            // FolderTreeView
            // 
            this.FolderTreeView.ImageIndex = 0;
            this.FolderTreeView.ImageList = this.FolderIconList;
            this.FolderTreeView.Location = new System.Drawing.Point(16, 15);
            this.FolderTreeView.Name = "FolderTreeView";
            this.FolderTreeView.SelectedImageIndex = 0;
            this.FolderTreeView.Size = new System.Drawing.Size(144, 345);
            this.FolderTreeView.TabIndex = 0;
            this.FolderTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.FolderTreeView_BeforeExpand);
            this.FolderTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.FolderTreeView_AfterSelect);
            this.FolderTreeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FolderTreeView_KeyDown);
            // 
            // FolderIconList
            // 
            this.FolderIconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("FolderIconList.ImageStream")));
            this.FolderIconList.TransparentColor = System.Drawing.Color.Transparent;
            this.FolderIconList.Images.SetKeyName(0, "Computer.png");
            this.FolderIconList.Images.SetKeyName(1, "Hard_Drive.png");
            this.FolderIconList.Images.SetKeyName(2, "folderopen.ico");
            this.FolderIconList.Images.SetKeyName(3, "folderopen.ico");
            this.FolderIconList.Images.SetKeyName(4, "document.ico");
            // 
            // FileListView
            // 
            this.FileListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colDateModified,
            this.colSize});
            this.FileListView.ContextMenuStrip = this.fileContextMenu;
            this.FileListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.FileListView.LargeImageList = this.LargeImageList;
            this.FileListView.Location = new System.Drawing.Point(12, 15);
            this.FileListView.Name = "FileListView";
            this.FileListView.Size = new System.Drawing.Size(157, 344);
            this.FileListView.SmallImageList = this.FolderIconList;
            this.FileListView.TabIndex = 0;
            this.FileListView.UseCompatibleStateImageBehavior = false;
            this.FileListView.SelectedIndexChanged += new System.EventHandler(this.FileListView_SelectedIndexChanged);
            this.FileListView.DoubleClick += new System.EventHandler(this.FileListView_DoubleClick);
            this.FileListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FileListView_KeyDown);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            // 
            // colDateModified
            // 
            this.colDateModified.Text = "Date Modified";
            // 
            // colSize
            // 
            this.colSize.Text = "Size";
            // 
            // fileContextMenu
            // 
            this.fileContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem});
            this.fileContextMenu.Name = "fileContextMenu";
            this.fileContextMenu.Size = new System.Drawing.Size(100, 26);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewContextSmallIcon,
            this.viewContextLargeIcon,
            this.viewContextList,
            this.viewContextDetail,
            this.viewContextTile});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.viewToolStripMenuItem.Text = "&View";
            this.viewToolStripMenuItem.DropDownOpening += new System.EventHandler(this.viewToolStripMenuItem_DropDownOpening);
            // 
            // viewContextSmallIcon
            // 
            this.viewContextSmallIcon.Name = "viewContextSmallIcon";
            this.viewContextSmallIcon.Size = new System.Drawing.Size(152, 22);
            this.viewContextSmallIcon.Text = "Small Icon";
            this.viewContextSmallIcon.Click += new System.EventHandler(this.viewContext_Clicked);
            // 
            // viewContextLargeIcon
            // 
            this.viewContextLargeIcon.Name = "viewContextLargeIcon";
            this.viewContextLargeIcon.Size = new System.Drawing.Size(152, 22);
            this.viewContextLargeIcon.Text = "Large Icon";
            this.viewContextLargeIcon.Click += new System.EventHandler(this.viewContext_Clicked);
            // 
            // viewContextList
            // 
            this.viewContextList.Name = "viewContextList";
            this.viewContextList.Size = new System.Drawing.Size(152, 22);
            this.viewContextList.Text = "List";
            this.viewContextList.Click += new System.EventHandler(this.viewContext_Clicked);
            // 
            // viewContextDetail
            // 
            this.viewContextDetail.Name = "viewContextDetail";
            this.viewContextDetail.Size = new System.Drawing.Size(152, 22);
            this.viewContextDetail.Text = "Details";
            this.viewContextDetail.Click += new System.EventHandler(this.viewContext_Clicked);
            // 
            // viewContextTile
            // 
            this.viewContextTile.Name = "viewContextTile";
            this.viewContextTile.Size = new System.Drawing.Size(152, 22);
            this.viewContextTile.Text = "Tile";
            this.viewContextTile.Click += new System.EventHandler(this.viewContext_Clicked);
            // 
            // LargeImageList
            // 
            this.LargeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("LargeImageList.ImageStream")));
            this.LargeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.LargeImageList.Images.SetKeyName(0, "Computer.png");
            this.LargeImageList.Images.SetKeyName(1, "Hard_Drive.png");
            this.LargeImageList.Images.SetKeyName(2, "FolderOpen_48x48_72.png");
            this.LargeImageList.Images.SetKeyName(3, "FolderOpen_48x48_72.png");
            this.LargeImageList.Images.SetKeyName(4, "Generic_Document.png");
            // 
            // FileExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "FileExplorer";
            this.Size = new System.Drawing.Size(372, 376);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.fileContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView FolderTreeView;
        private System.Windows.Forms.ImageList FolderIconList;
        private System.Windows.Forms.ListView FileListView;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colDateModified;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.Windows.Forms.ContextMenuStrip fileContextMenu;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewContextSmallIcon;
        private System.Windows.Forms.ToolStripMenuItem viewContextLargeIcon;
        private System.Windows.Forms.ToolStripMenuItem viewContextList;
        private System.Windows.Forms.ToolStripMenuItem viewContextDetail;
        private System.Windows.Forms.ToolStripMenuItem viewContextTile;
        private System.Windows.Forms.ImageList LargeImageList;
    }
}
