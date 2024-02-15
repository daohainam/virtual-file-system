using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualFileSystem.Abstractions;

namespace VirtualFileSystem.Local
{
    internal class LocalObjectListingResponse(DirectoryInfo directory, ObjectListingRequest request, IObjectListingResponseResult listingResponseResult, int nextIndex, LocalFileSystem localFileSystem) : ObjectListingResponse
    {
        public override ObjectListingRequest Request => request;

        public override IObjectListingResponseResult Result => listingResponseResult;

        public override async Task<ObjectListingResponse> Next()
        {
            string pattern = string.IsNullOrEmpty(request.Prefix) ? "*.*" : $"{request.Prefix}*.*";
            var directories = directory.GetDirectories(pattern, SearchOption.TopDirectoryOnly).Select(d => new LocalVDirectory(d, localFileSystem));
            var files = directory.GetFiles(pattern, SearchOption.TopDirectoryOnly).Take(request.MaxResults).Select(f => new LocalVFile(f));

            var response = new LocalObjectListingResponse(directory, request, new LocalObjectListingResponseResult(directories, files), nextIndex + files.Count(), localFileSystem);

            return await Task.FromResult(response);
        }
    }
}
