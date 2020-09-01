using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CodeArtEng.Controls
{
    internal class LocalFileExplorer : IFileExplorer
    {
        FileExplorerType IFileExplorer.HostType { get { return FileExplorerType.Local; } }
        string IFileExplorer.Name { get { return string.Empty; } }
        string IFileExplorer.Root { get { return string.Empty; } }

        FileExplorerItemInfo[] IFileExplorer.GetDirectories(string path)
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                DirectoryInfo[] dirList = dirInfo.GetDirectories();
                FileExplorerItemInfo[] items = new FileExplorerItemInfo[dirList.Count()];
                for (int x = 0; x < dirList.Count(); x++)
                    items[x] = new FileExplorerItemInfo(dirList[x]);
                return items;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "File Explorer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        FileExplorerItemInfo[] IFileExplorer.GetFiles(string path)
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                FileInfo[] files = dirInfo.GetFiles();
                FileExplorerItemInfo[] items = new FileExplorerItemInfo[files.Count()];
                for (int x = 0; x < files.Count(); x++)
                    items[x] = new FileExplorerItemInfo(files[x]);
                return items;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "File Explorer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        char IFileExplorer.PathSeparator { get { return '\\'; } }
        bool IFileExplorer.IsConnected { get { return true; } }

        string IFileExplorer.FolderPathPrefix { get => ""; }

        #region [ Connection Status Changed Handling ]

        /// <summary>
        /// Not used for Local File Explorer
        /// </summary>
        event EventHandler IFileExplorer.ConnectionStatusChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        void IFileExplorer.Reconnect()
        {
            throw new NotImplementedException();
        }

        #endregion

        string IFileExplorer.GetSelectedFolderRoot(string inputPath)
        {
            return Path.GetPathRoot(Path.GetFullPath(inputPath));
        }

    }
}
