using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VirtualFileSystem.Abstractions
{
    public class VirtualFileSystemException : Exception
    {
        public VirtualFileSystemException()
        {
        }

        public VirtualFileSystemException(string? message) : base(message)
        {
        }

        public VirtualFileSystemException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
