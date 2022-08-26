using BackendAssessment.Application.Hotels.Dtos;

namespace BackendAssessment.Application.Hotels.Common.Contracts
{
    public interface IHotelReferencesService
    {
        Task<HotelFacilitiesDto> GetAllAsync();
        Task<HotelFacilitiesDto> GetAllAsync(Guid hotelId);
    }
}