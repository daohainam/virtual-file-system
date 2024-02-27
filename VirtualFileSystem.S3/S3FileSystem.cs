using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using VirtualFileSystem.Abstractions;
using VirtualFileSystem.S3.Helpers;

namespace VirtualFileSystem.S3
{
    public class S3FileSystem(AmazonS3Client client, string bucket) : IVirtualFileSystem
    {
        private readonly string bucket = bucket ?? throw new ArgumentNullException(nameof(bucket));
        private readonly AmazonS3Client client = client ?? throw new ArgumentNullException(nameof(client));

        public S3FileSystem(string accessKey, string secret, string region, string bucket) : this(new AmazonS3Client(accessKey, secret, RegionEndpoint.GetBySystemName(region)), bucket)
        {
        }

        public async Task<IVDirectory> GetDirectoryAsync(string path, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IVFile> GetFileAsync(string path, CancellationToken cancellationToken = default)
        {
            try
            {
                var request = new GetObjectMetadataRequest() { 
                    BucketName = bucket,
                    Key = path
                };

                var fileName = S3PathHelper.GetFileName(path);

                var metadata = await client.GetObjectMetadataAsync(request, cancellationToken);

                if (metadata != null)
                {
                    return new S3VFile(path, fileName, true, metadata.ContentLength, metadata.LastModified);
                }
                else
                {
                    return new S3VFile(path, fileName, false, 0, DateTime.MinValue);
                }

            } catch { 
                throw;
            }
        }
    }
}
