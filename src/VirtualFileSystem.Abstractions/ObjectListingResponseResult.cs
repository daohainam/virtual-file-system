using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualFileSystem.Abstractions
{
    public interface IObjectListingResponseResult
    {
        public IEnumerable<IVDirectory> Directories { get; }
        public IEnumerable<IVFile> Files { get; }
    }
}
