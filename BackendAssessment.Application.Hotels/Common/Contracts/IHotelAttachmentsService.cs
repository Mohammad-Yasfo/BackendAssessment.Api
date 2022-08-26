using BackendAssessment.Application.Common.Storage.Contracts;
using BackendAssessment.Application.Storage.Contracts;

namespace BackendAssessment.Application.Hotels.Common.Contracts
{
    public interface IHotelAttachmentsService<T> : IBaseAttachmentsService<T>
        where T : IBaseServiceStorageSettings
    {
    }
}