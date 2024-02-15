using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualFileSystem.Abstractions
{
    public class ObjectListingRequest
    {
        public string Prefix { get; set; } = string.Empty;
        public int MaxResults { get; set; } = 1000; // it depends on provider max results (fex: Azure = 5000, AWS = 1000...), if you request a value > provider specific MaxResults, you will get an error
    }
}
