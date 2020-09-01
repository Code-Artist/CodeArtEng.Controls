using System;
using System.IO;

namespace CodeArtEng.Controls
{
    /// <summary>
    /// File explorer item
    /// </summary>
    public sealed class FileExplorerItemInfo
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="isDirectory"></param>
        public FileExplorerItemInfo(string name, bool isDirectory)
        {
            FullName = Name = name;
            Attributes = FileAttributes.Normal;
            if (isDirectory) Attributes = FileAttributes.Directory;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fullName"></param>
        /// <param name="isDirectory"></param>
        public FileExplorerItemInfo(string name, string fullName, bool isDirectory)
        {
            Name = name;
            FullName = fullName;
            Attributes = FileAttributes.Normal;
            if (isDirectory) Attributes = FileAttributes.Directory;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="directory"></param>
        public FileExplorerItemInfo(DirectoryInfo directory) { Clone(directory); }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="file"></param>
        public FileExplorerItemInfo(FileInfo file) { Clone(file); Length = file.Length; }

        private void Clone(FileSystemInfo info)
        {
            Exists = info.Exists;
            FullName = info.FullName;
            Name = info.Name;
            Attributes |= info.Attributes;
            CreationTime = info.CreationTime;
            CreationTimeUtc = info.CreationTimeUtc;
            LastAccessTime = info.LastAccessTime;
            LastAccessTimeUtc = info.LastAccessTimeUtc;
            LastWriteTime = info.LastWriteTime;
            LastWriteTimeUtc = info.LastWriteTimeUtc;
            Length = 0;
        }

        /// <summary>
        /// Display name
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Item's full path.
        /// </summary>
        public string FullName { get; private set; }
        /// <summary>
        /// Items attributes.
        /// </summary>
        public FileAttributes Attributes { get; set; }
        /// <summary>
        /// True if item exists
        /// </summary>
        public bool Exists { get; private set; }
        /// <summary>
        /// Item size in length.
        /// </summary>
        public long Length { get; set; }
        /// <summary>
        /// Creation time
        /// </summary>
        public DateTime CreationTime { get; set; }
        /// <summary>
        /// Creation time in UTC format
        /// </summary>
        public DateTime CreationTimeUtc { get; set; }
        /// <summary>
        /// Last access time
        /// </summary>
        public DateTime LastAccessTime { get; set; }
        /// <summary>
        /// Last access time in UTC format
        /// </summary>
        public DateTime LastAccessTimeUtc { get; set; }
        /// <summary>
        /// Last modified time
        /// </summary>
        public DateTime LastWriteTime { get; set; }
        /// <summary>
        /// Last modified time in UTC format.
        /// </summary>
        public DateTime LastWriteTimeUtc { get; set; }
    }
}
