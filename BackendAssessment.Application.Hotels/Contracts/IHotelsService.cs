using BackendAssessment.Application.Hotels.Dtos;

namespace BackendAssessment.Application.Hotels.Contracts
{
    public interface IHotelsService
    {
        Task<HotelListingItemDto> GetAsync(string hotelName);
        Task<HotelListingItemDto> GetProfileAsync(Guid hotelId);
    }
}