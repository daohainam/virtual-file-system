using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualFileSystem.Abstractions
{
    public abstract class ObjectListingResponse
    {
        public abstract ObjectListingRequest Request { get; }
        public abstract Task<ObjectListingResponse> Next();
        public abstract IObjectListingResponseResult Result { get; }
    }
}
