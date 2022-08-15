using BackendAssessment.Domain.Storage.Models;

namespace BackendAssessment.Application.Storage.Contracts
{
    public interface IAttachmentsRepository
    {
        Task<Attachment> GetByIdAsync(Guid id);

        Task<Attachment> AddAsync(Attachment attachment);

        Task RemoveAsync(Guid id);
    }
}