using BackendAssessment.Application.Common.Storage.Contracts;
using BackendAssessment.Application.Storage.Configuration;
using BackendAssessment.Domain.Storage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage.Blob;

namespace BackendAssessment.Infrastructure.AzureBlobStorage
{
    public class AzureBlobService<T> : IBlobService<T>
        where T : IBaseServiceStorageSettings, new()
    {
        private readonly IBlobConnectionFactory azureBlobConnectionFactory;
        private readonly BlobSettings blobSettings;
        private readonly T serviceSettings;
        private readonly BlobContainerSettings container;

        public AzureBlobService(
                IBlobConnectionFactory azureBlobConnectionFactory,
                BlobSettings blobSetting)
        {
            this.azureBlobConnectionFactory = azureBlobConnectionFactory;
            this.blobSettings = blobSetting;
            this.serviceSettings = new T();

            if (!blobSetting.Containers.Any(c => c.Name == serviceSettings.ContainerName))
            {
                throw new InvalidOperationException($"Cannot find required container {serviceSettings.ContainerName}");
            }
            else
            {
                container = blobSettings.Containers
                    .First(c => c.Name == serviceSettings.ContainerName);
            }
        }

        /// <summary> 
		/// byte[] GetAsync(): Get a file from a container
		/// </summary> 
		public async Task<byte[]> GetAsync(Attachment attachment)
        {
            byte[] fileContent;
            var blobContainer = await azureBlobConnectionFactory.GetBlobContainer(container);
            // get the BlockReference from the Container reference
            CloudBlockBlob blockBlob = blobContainer.GetBlockBlobReference(attachment.CloudKey);

            if (await blockBlob.ExistsAsync())
            {
                // read data as string and return
                using (var ms = new MemoryStream())
                {
                    await blockBlob.DownloadToStreamAsync(ms);
                    fileContent = ms.ToArray();
                    return fileContent;
                }
            }
            else
            {
                throw new Exception();
            }
        }

        /// <summary> 
        /// AddAsync(Attachment attachment, byte[] content): Upload file to a container  
        /// </summary> 
        public async Task AddAsync(Attachment attachment, byte[] content)
        {
            var blobContainer = await azureBlobConnectionFactory.GetBlobContainer(container);

            var key = GetUniqueRandomBlobName(attachment.Name);
            var blob = blobContainer.GetBlockBlobReference(key);

            var stream = new MemoryStream(content)
            {
                Position = 0
            };
            using (stream)
            {
                await blob.UploadFromStreamAsync(stream);
            }
            attachment.Id = Guid.NewGuid();
            attachment.CloudKey = key;
        }

        /// <summary> 
        /// UploadAsync(IEnumerable<AttachmentInfo> attachments): Upload files to a container  
        /// </summary> 
        public async Task UploadMultiFilesAsync(IEnumerable<AttachmentInfo> attachments)
        {
            var blobContainer = await azureBlobConnectionFactory.GetBlobContainer(container);

            foreach (var file in attachments)
            {
                var key = GetUniqueRandomBlobName(file.Name);
                var blob = blobContainer.GetBlockBlobReference(key);

                var stream = new MemoryStream(file.Content)
                {
                    Position = 0
                };
                using (stream)
                {
                    await blob.UploadFromStreamAsync(stream);
                }
                file.CloudKey = key;
            }
        }

        /// <summary> 
		/// IEnumerable<Uri> ListAsync(): Get all files in a container
		/// </summary> 
        public async Task<IEnumerable<Uri>> ListAsync()
        {
            var blobContainer = await azureBlobConnectionFactory.GetBlobContainer(container);
            var allBlobs = new List<Uri>();
            BlobContinuationToken blobContinuationToken = null;

            do
            {
                var response = await blobContainer.ListBlobsSegmentedAsync(blobContinuationToken);
                foreach (IListBlobItem blob in response.Results)
                {
                    if (blob.GetType() == typeof(CloudBlockBlob))
                        allBlobs.Add(blob.Uri);
                }
                blobContinuationToken = response.ContinuationToken;
            } while (blobContinuationToken != null);

            return allBlobs;
        }

        /// <summary> 
        /// UploadAsync(IFormFileCollection files): Upload files to a container  
        /// </summary> 
        public async Task UploadMultiFilesAsync(IFormFileCollection files)
        {
            var blobContainer = await azureBlobConnectionFactory.GetBlobContainer(container);

            for (int i = 0; i < files.Count; i++)
            {
                var blob = blobContainer.GetBlockBlobReference(GetUniqueRandomBlobName(files[i].FileName));
                using var stream = files[i].OpenReadStream();
                await blob.UploadFromStreamAsync(stream);
            }
        }

        /// <summary> 
        /// DeleteAsync(string fileUrl): Detete file form container by unique uri.
        /// </summary>
        public async Task DeleteAsync(string fileKey)
        {
            var blobContainer = await azureBlobConnectionFactory.GetBlobContainer(container);

            string filename = fileKey;

            var blob = blobContainer.GetBlockBlobReference(filename);
            await blob.DeleteIfExistsAsync();
        }

        /// <summary> 
        /// string GetUniqueRandomBlobName(string filename): Generates a unique random file name to be uploaded  
        /// </summary> 
        private string GetUniqueRandomBlobName(string filename)
        {
            Guid fileId = Guid.NewGuid();
            string ext = Path.GetExtension(filename);
            //return string.Format("{0:10}_{1}{2}", DateTime.Now.Ticks, Guid.NewGuid(), ext);
            return string.Format("{0}{1}", fileId, ext);
        }
    }
}