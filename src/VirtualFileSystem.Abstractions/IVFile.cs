using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualFileSystem.Abstractions
{
    public interface IVFile: IVObject
    {
        Stream OpenRead();
        Stream OpenWrite();
        long Length { get; }
        DateTime LastModified { get; }
    }
}
