using BackendAssessment.Application.Hotels.Dtos;

namespace BackendAssessment.Application.Hotels.Contracts
{
    public interface IHotelsService
    {
        Task<IList<HotelDto>> GetAsync(string hotelName);
        Task<HotelListingItemDto> GetProfileAsync(Guid hotelId);
    }
}