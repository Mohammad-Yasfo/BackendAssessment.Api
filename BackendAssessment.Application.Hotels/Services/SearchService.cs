using AutoMapper;
using BackendAssessment.Application.Common;
using BackendAssessment.Application.Common.Contracts;
using BackendAssessment.Application.Common.Dtos;
using BackendAssessment.Application.Common.Extensions;
using BackendAssessment.Application.Hotels.Contracts;
using BackendAssessment.Application.Hotels.Dtos;
using BackendAssessment.Domain.Hotels;
using Microsoft.AspNetCore.Http;
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
            IHttpContextAccessor httpContextAccessor,
            ISearchRepository repository,
            IHotelsUnitOfWork unitOfWork,
            ILogger<SearchService> logger,
            IMapper mapper
            )
             : base(httpContextAccessor, unitOfWork, logger, mapper)
        {
            this.repository = repository;
        }

        #endregion

        #region Methods

        public async Task<PaginatedDto<HotelListingItemDto>> GetAsync(int pageIndex, int pageSize, string searchName, string checkIn, string checkOut, FilterDto filterDto)
        {
            try
            {
                var startCountingFrom = (pageIndex - 1) * pageSize;

                var filter = mapper.Map<HotelFilter>(filterDto);
                var checkInDate = DateTime.Parse(checkIn);
                var checkOutDate = DateTime.Parse(checkOut);

                var result = await repository.GetAsync(startCountingFrom, pageSize + 1, searchName, checkInDate, checkOutDate, filter);

                return mapper.Map<IEnumerable<HotelListingItemDto>>(result)
                    .ToPagedList(pageIndex, pageSize, httpContext);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error when try to search about hotels.", ex);
            }
        }

        #endregion
    }
}