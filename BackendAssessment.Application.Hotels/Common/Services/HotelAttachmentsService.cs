using AutoMapper;
using BackendAssessment.Application.Common.Storage.Contracts;
using BackendAssessment.Application.Hotels.Common.Contracts;
using BackendAssessment.Application.Storage.Services;
using Microsoft.Extensions.Logging;

namespace BackendAssessment.Application.Hotels.Common.Services
{
    public class HotelAttachmentsService<T> : BaseAttachmentsService<T>, IHotelAttachmentsService<T>
        where T : IBaseServiceStorageSettings
    {
        #region Constructor
        public HotelAttachmentsService(
            IHotelAttachmentsRepository attachmentsRepository,
            IBlobService<T> blobService,
            IMapper mapper,
            ILogger<HotelAttachmentsService<T>> logger)
            : base(attachmentsRepository, blobService, mapper, logger)
        {
        }
        #endregion
    }
}