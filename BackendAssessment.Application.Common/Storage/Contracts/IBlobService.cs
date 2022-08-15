using BackendAssessment.Domain.Storage.Models;
using Microsoft.AspNetCore.Http;

namespace BackendAssessment.Application.Common.Storage.Contracts
{
    public interface IBlobService<T>
        where T : IBaseServiceStorageSettings
    {
        Task<byte[]> GetAsync(Attachment attachment);
        Task AddAsync(Attachment attachment, byte[] content);
        Task UploadMultiFilesAsync(IEnumerable<AttachmentInfo> attachments);

        Task<IEnumerable<Uri>> ListAsync();
        Task UploadMultiFilesAsync(IFormFileCollection files);
        Task DeleteAsync(string key);
    }
}