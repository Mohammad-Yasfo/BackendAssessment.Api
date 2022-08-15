using AutoMapper;
using BackendAssessment.Application.Common;
using BackendAssessment.Application.Common.Contracts;
using BackendAssessment.Application.Hotels.Contracts;
using BackendAssessment.Application.Hotels.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace BackendAssessment.Application.Hotels.Services
{
    public class HotelsService : BaseService, IHotelsService
    {
        #region Properties

        private readonly IHotelsRepository repository;

        #endregion

        #region constructor

        public HotelsService(
            IHttpContextAccessor httpContextAccessor,
            IHotelsRepository repository,
            IHotelsUnitOfWork unitOfWork,
            ILogger<HotelsService> logger,
            IMapper mapper
            )
             : base(httpContextAccessor, unitOfWork, logger, mapper)
        {
            this.repository = repository;
        }

        #endregion

        #region Methods

        public async Task<IList<HotelDto>> GetAsync(string hotelName)
        {
            try
            {
                var hotels = await repository.GetByNameAsync(hotelName);

                return mapper.Map<IList<HotelDto>>(hotels);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error when try to get hotels by name.", ex);
            }
        }

        public async Task<HotelListingItemDto> GetProfileAsync(Guid hotelId)
        {
            try
            {
                var hotel = await repository.GetProfileAsync(hotelId);

                return mapper.Map<HotelListingItemDto>(hotel);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error when try to get hotel by Id, hotelId: {hotelId}", ex);
            }
        }

        #endregion
    }
}