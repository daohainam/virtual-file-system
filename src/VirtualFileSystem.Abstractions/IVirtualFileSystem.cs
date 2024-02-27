namespace VirtualFileSystem.Abstractions
{
    public interface IVirtualFileSystem
    {
        Task<IVDirectory> GetDirectoryAsync(string path, CancellationToken cancellationToken = default);
        Task<IVFile> GetFileAsync(string path, CancellationToken cancellationToken = default);
    }
}
