using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualFileSystem.Abstractions;

namespace VirtualFileSystem.Local
{
    internal class LocalObjectListingResponseResult(IEnumerable<IVDirectory> directories, IEnumerable<IVFile> files) : IObjectListingResponseResult
    {
        public IEnumerable<IVDirectory> Directories => directories;

        public IEnumerable<IVFile> Files => files;
    }
}
