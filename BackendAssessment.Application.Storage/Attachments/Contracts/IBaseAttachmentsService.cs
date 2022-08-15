using BackendAssessment.Application.Common.Storage.Contracts;
using BackendAssessment.Application.Storage.Dtos;

namespace BackendAssessment.Application.Storage.Contracts
{
    public interface IBaseAttachmentsService<T>
        where T : IBaseServiceStorageSettings
    {
        Task<AttachmentContentDto> GetContentByIdAsync(Guid id);

        Task<BaseAttachmentDto> GetByIdAsync(Guid id);

        Task<BaseAttachmentDto> SaveAsync(AddAttachmentDto attachmentDto);

        Task DeleteAsync(Guid id);
    }
}