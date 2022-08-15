using BackendAssessment.Application.Storage.Configuration;
using Microsoft.WindowsAzure.Storage.Blob;

namespace BackendAssessment.Infrastructure.AzureBlobStorage
{
    public interface IBlobConnectionFactory
    {
        Task<CloudBlobContainer> GetBlobContainer(BlobContainerSettings blobContainerSettings);
    }
}