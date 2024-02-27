using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualFileSystem.Abstractions;

namespace VirtualFileSystem.S3
{
    internal class S3Directory : IVDirectory
    {
        public string Name => throw new NotImplementedException();

        public bool Exists => throw new NotImplementedException();

        public string FullName => throw new NotImplementedException();

        public Task<ObjectListingResponse> FindObjects(ObjectListingRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
