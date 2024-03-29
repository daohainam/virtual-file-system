﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualFileSystem.Abstractions;

namespace VirtualFileSystem.Local
{
    internal class LocalVDirectory(DirectoryInfo directory, LocalFileSystem localFileSystem) : IVDirectory
    {
        private readonly DirectoryInfo directory = directory ?? throw new ArgumentNullException(nameof(directory));
        private readonly LocalFileSystem localFileSystem = localFileSystem ?? throw new ArgumentNullException(nameof(localFileSystem));

        public string Name => directory.Name;

        public bool Exists => directory.Exists;

        public string FullName => directory.FullName;

        public async Task<ObjectListingResponse> FindObjects(ObjectListingRequest request)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));
            ArgumentOutOfRangeException.ThrowIfLessThan(request.MaxResults, 1, "request.MaxResults");

            string pattern = string.IsNullOrEmpty(request.Prefix) ? "*.*" : $"{request.Prefix}*.*";
            var directories = directory.GetDirectories(pattern, SearchOption.TopDirectoryOnly).Select(d => new LocalVDirectory(d, localFileSystem));
            var files = directory.GetFiles(pattern, SearchOption.TopDirectoryOnly).Take(request.MaxResults).Select(f => new LocalVFile(f, localFileSystem));

            var response = new LocalObjectListingResponse(directory, request, new LocalObjectListingResponseResult(directories, files), files.Count(), localFileSystem);

            return await Task.FromResult(response);
        }
    }
}
