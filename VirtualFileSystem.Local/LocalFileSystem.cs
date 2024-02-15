using VirtualFileSystem.Abstractions;

namespace VirtualFileSystem.Local
{
    public class LocalFileSystem : IVirtualFileSystem
    {
        public IVDirectory GetDirectory()
        {
            throw new NotImplementedException();
        }
    }
}
