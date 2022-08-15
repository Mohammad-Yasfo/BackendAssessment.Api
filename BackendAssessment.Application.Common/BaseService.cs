using AutoMapper;
using BackendAssessment.Application.Common.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace BackendAssessment.Application.Common
{
    public class BaseService
    {
        protected readonly IHttpContextAccessor httpContext;
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IHotelsUnitOfWork hotelsUnitOfWork;
        protected readonly ILiveMessagingUnitOfWork liveMessagingUnitOfWork;
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
            ILiveMessagingUnitOfWork liveMessagingUnitOfWork,
            ILogger<BaseService> logger,
            IMapper mapper)
        {
            this.liveMessagingUnitOfWork = liveMessagingUnitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }

        public BaseService(
            IHttpContextAccessor httpContext,
            IHotelsUnitOfWork hotelsUnitOfWork,
            ILogger<BaseService> logger,
            IMapper mapper)
        {
            this.httpContext = httpContext;
            this.hotelsUnitOfWork = hotelsUnitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }
        #endregion
    }
}