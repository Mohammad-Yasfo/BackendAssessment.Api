using BackendAssessment.Domain.Hotels;

namespace BackendAssessment.Application.Hotels.Contracts
{
    public interface ISearchRepository
    {
        Task<IEnumerable<Hotel>> GetAsync(int startCountingFrom, int numberOfItems, string searchName, string checkIn, string checkOut, HotelFilter filter);
    }
}