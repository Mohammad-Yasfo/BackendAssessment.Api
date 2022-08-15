using BackendAssessment.Application.Common.Dtos;
using BackendAssessment.Application.Hotels.Dtos;

namespace BackendAssessment.Application.Hotels.Contracts
{
    public interface ISearchService
    {
        Task<PaginatedDto<HotelListingItemDto>> GetAsync(int pageIndex, int pageSize, string searchName, string checkIn, string checkOut, FilterDto filterDto);
    }
}