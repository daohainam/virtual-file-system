using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualFileSystem.Abstractions
{
    public interface IVDirectory: IVObject
    {
        IQueryable<IVDirectory> FindDirectories();
        IQueryable<IVFile> FindFiles();
    }
}
