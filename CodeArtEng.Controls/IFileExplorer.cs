using System;

[assembly: CLSCompliant(true)]
namespace CodeArtEng.Controls
{

    /// <summary>
    /// File explorer type. (No longer used).
    /// </summary>
    public enum FileExplorerType
    {
        /// <summary>
        /// Local drive
        /// </summary>
        Local,
        /// <summary>
        /// Ftp Server
        /// </summary>
        Ftp,
    }

    /// <summary>
    /// File explorer interface.
    /// </summary>
    public interface IFileExplorer
    {
        /// <summary>
        /// Connection status changed event.
        /// </summary>
        event EventHandler ConnectionStatusChanged;
        /// <summary>
        /// Reconnect Device using current configuration.
        /// </summary>
        /// <remarks>This method must be implemented if derived class implement <see cref="ConnectionStatusChanged"/> event.</remarks>
        void Reconnect();

        /// <summary>
        /// Return root directory of given path
        /// </summary>
        /// <param name="inputPath"></param>
        /// <returns></returns>
        string GetSelectedFolderRoot(string inputPath);

        /// <summary>
        /// Instance name
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Root path / server name.
        /// </summary>
        string Root { get; }
        /// <summary>
        /// Get subdirectoy list from selected path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        FileExplorerItemInfo[] GetDirectories(string path);
        /// <summary>
        /// Get file list from selected path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        FileExplorerItemInfo[] GetFiles(string path);
        /// <summary>
        /// Get host type. <see cref="FileExplorerType"/>
        /// </summary>
        [Obsolete("Internal parameter, no longer used.")]
        FileExplorerType HostType { get; }
        /// <summary>
        /// Get path separator.
        /// </summary>
        char PathSeparator { get; }
        /// <summary>
        /// Check if  source still connected.
        /// </summary>
        bool IsConnected { get; }
        /// <summary>
        /// Prefix string on File Explorer Folder Path textbox
        /// </summary>
        string FolderPathPrefix { get; }
    }
}
