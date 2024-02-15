using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualFileSystem.Abstractions;

namespace VirtualFileSystem.Local
{
    public class LocalVFile(FileInfo file, LocalFileSystem localFileSystem) : IVFile
    {
        public bool IsReadOnly => file.IsReadOnly;

        public string Name => file.Name;

        public long Length => file.Length;

        public Stream OpenRead()
        {
            return file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
        }
        public Stream OpenWrite()
        {
            return file.Open(FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
        }
    }
}
