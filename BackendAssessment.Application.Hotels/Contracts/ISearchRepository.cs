using BackendAssessment.Domain.Hotels;

namespace BackendAssessment.Application.Hotels.Contracts
{
    public interface ISearchRepository
    {
        Task<IList<Hotel>> GetAsync(int startCountingFrom, int numberOfItems, string searchName, DateTime checkIn, DateTime checkOut, HotelFilter filter);
    }
}