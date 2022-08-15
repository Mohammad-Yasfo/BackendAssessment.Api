using AutoMapper;
using BackendAssessment.Application.Common.Contracts;
using Microsoft.Extensions.Logging;

namespace BackendAssessment.Application.Common
{
    public class BaseService
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IHotelsUnitOfWork liveMessagingUnitOfWork;
        protected readonly ILogger<BaseService> logger;
        protected readonly IMapper mapper;

        #region Constructors
        public BaseService(
            IUnitOfWork unitOfWork,
            ILogger<BaseService> logger,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }

        public BaseService(
            IHotelsUnitOfWork liveMessagingUnitOfWork,
            ILogger<BaseService> logger,
            IMapper mapper)
        {
            this.liveMessagingUnitOfWork = liveMessagingUnitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }
        #endregion

    }
}