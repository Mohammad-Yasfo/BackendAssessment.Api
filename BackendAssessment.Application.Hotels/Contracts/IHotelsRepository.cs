using BackendAssessment.Domain.Hotels;

namespace BackendAssessment.Application.Hotels.Contracts
{
    public interface IHotelsRepository
    {
        Task<IList<Hotel>> GetByNameAsync(string hotelName);
        Task<Hotel> GetProfileAsync(Guid hotelId);
    }
}