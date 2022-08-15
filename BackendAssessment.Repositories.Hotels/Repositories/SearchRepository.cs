using AutoMapper;
using BackendAssessment.Application.Hotels.Contracts;
using BackendAssessment.Domain.Hotels;
using BackendAssessment.Repositories.Common.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BackendAssessment.Repositories.Hotels.Repositories
{
    public class SearchRepository : BaseRepository<HotelsDbContext>, ISearchRepository
    {
        #region Properties

        private readonly ILogger<SearchRepository> logger;
        private readonly IMapper mapper;

        #endregion

        #region Constructor

        public SearchRepository(
            HotelsDbContext context,
            ILogger<SearchRepository> logger,
            IMapper mapper) : base(context)
        {
            this.logger = logger;
            this.mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<IList<Hotel>> GetAsync(int startCountingFrom, int numberOfItems, string searchName, DateTime checkIn, DateTime checkOut, HotelFilter filter)
        {
            var query = Context.Hotels
                .Include(h => h.HotelFacilities)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchName))
            {
                query = query.Where(h => h.Name.ToLower().Contains(searchName.Trim().ToLower()));
            }

            if (filter != null)
            {
                if (filter.Radius.HasValue)
                    query = query.Where(h => h.RatingValue >= filter.Radius);

                if (filter.Budget.HasValue)
                    query = query.Where(h => h.MinimumValue >= filter.Budget && h.MaximumValue <= filter.Budget);

                if (filter.Facilities != null && filter.Facilities.Count > 0)
                    query = query.Where(h => h.HotelFacilities.Any(f => filter.Facilities.Any(ff => ff == f.FacilityId)));
            }

            var hotelEntities = query.OrderBy(v => v.Name)
                .Skip(startCountingFrom)
                .Take(numberOfItems)
                .ToListAsync();

            return mapper.Map<IList<Hotel>>(hotelEntities);
        }

        #endregion
    }
}