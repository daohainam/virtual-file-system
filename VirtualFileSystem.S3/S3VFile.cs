using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualFileSystem.Abstractions;

namespace VirtualFileSystem.S3
{
    internal class S3VFile : IVFile, IDisposable
    {
        private bool disposedValue;

        private readonly string path;
        private readonly string fileName;
        private readonly bool exists;
        private readonly long length;
        private readonly DateTime lastModified;

        public S3VFile(string path, string fileName, bool exists, long contentLength, DateTime lastModified)
        {
            this.path = path;
            this.fileName = fileName;
            this.exists = exists;
            this.length = contentLength;
            this.lastModified = lastModified;
        }

        public long Length => length;

        public string Name => fileName;

        public bool Exists => exists;

        public string FullName => path;

        public DateTime LastModified => lastModified;

        public Stream OpenRead()
        {
            throw new NotImplementedException();
        }

        public Stream OpenWrite()
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~S3VFile()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
