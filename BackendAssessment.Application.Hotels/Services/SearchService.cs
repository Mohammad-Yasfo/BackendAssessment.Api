using AutoMapper;
using BackendAssessment.Application.Common;
using BackendAssessment.Application.Common.Contracts;
using BackendAssessment.Application.Common.Dtos;
using BackendAssessment.Application.Hotels.Contracts;
using BackendAssessment.Application.Hotels.Dtos;
using Microsoft.Extensions.Logging;

namespace BackendAssessment.Application.Hotels.Services
{
    public class SearchService : BaseService, ISearchService
    {
        #region Properties

        private readonly ISearchRepository repository;
        #endregion

        #region constructor

        public SearchService(
            ISearchRepository repository,
            IHotelsUnitOfWork unitOfWork,
            ILogger<SearchService> logger,
            IMapper mapper
            )
             : base(unitOfWork, logger, mapper)
        {
            this.repository = repository;
        }

        #endregion

        #region Methods

        public Task<PaginatedDto<HotelListingItemDto>> GetHotelsAsync(int pageIndex, int pageSize, string searchName, FilterDto filterDto)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion
    }
}