using BackendAssessment.Application.Storage.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace BackendAssessment.Infrastructure.AzureBlobStorage
{
    public class AzureBlobConnectionFactory : IBlobConnectionFactory
    {
        // The configuration for Azure Blob Storage
        //private readonly IConfiguration configuration;
        private CloudBlobClient blobClient;
        private CloudBlobContainer blobContainer;

        //public AzureBlobConnectionFactory(IConfiguration configuration)
        //{
        //    this.configuration = configuration;
        //}
        public AzureBlobConnectionFactory()
        {
        }

        public async Task<CloudBlobContainer> GetBlobContainer(BlobContainerSettings blobContainerSettings)
        {
            if (blobContainer != null)
                return blobContainer;

            var containerName = blobContainerSettings.Name;
            if (string.IsNullOrWhiteSpace(containerName))
            {
                throw new ArgumentException();
            }

            var blobClient = GetClient(blobContainerSettings);

            blobContainer = blobClient.GetContainerReference(containerName);
            if (await blobContainer.CreateIfNotExistsAsync())
            {
                await blobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            }
            return blobContainer;
        }

        private CloudBlobClient GetClient(BlobContainerSettings blobContainerSettings)
        {
            if (blobClient != null)
                return blobClient;

            var storageConnectionString = blobContainerSettings.ConnectionString;

            if (string.IsNullOrWhiteSpace(storageConnectionString))
            {
                throw new ArgumentException();
            }

            if (!CloudStorageAccount.TryParse(storageConnectionString, out CloudStorageAccount storageAccount))
            {
                throw new Exception();
            }

            blobClient = storageAccount.CreateCloudBlobClient();
            return blobClient;
        }
    }
}