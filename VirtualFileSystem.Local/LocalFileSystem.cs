using VirtualFileSystem.Abstractions;

namespace VirtualFileSystem.Local
{
    public class LocalFileSystem : IVirtualFileSystem
    {
        public async Task<IVDirectory> GetDirectoryAsync(string path, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(path, nameof(path));

            if (OperatingSystem.IsWindows()) // we always use / in path, so we need to convert to OS-specific path separator
            {
                path = path.Replace('/', Path.DirectorySeparatorChar);
            }

            try
            {
                var localDirectory = new LocalVDirectory(new DirectoryInfo(path), this);

                return await Task.FromResult(localDirectory);
            } catch (Exception ex)
            {
                throw new VirtualFileSystemException("Error getting directory", ex);
            }
        }

        public async Task<IVFile> GetFileAsync(string path, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(path, nameof(path));

            if (OperatingSystem.IsWindows()) // we always use / in path, so we need to convert to OS-specific path separator
            {
                path = path.Replace('/', Path.DirectorySeparatorChar);
            }

            try
            {
                var localFile = new LocalVFile(new FileInfo(path), this);

                return await Task.FromResult(localFile);
            }
            catch (Exception ex)
            {
                throw new VirtualFileSystemException("Error getting file", ex);
            }
        }
    }
}
