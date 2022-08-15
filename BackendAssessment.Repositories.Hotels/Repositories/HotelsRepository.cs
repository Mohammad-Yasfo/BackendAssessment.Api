using AutoMapper;
using BackendAssessment.Application.Hotels.Contracts;
using BackendAssessment.Domain.Hotels;
using BackendAssessment.Repositories.Common.Contexts;
using BackendAssessment.Repositories.Hotels.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BackendAssessment.Repositories.Hotels.Repositories
{
    public class HotelsRepository : BaseRepository<HotelsDbContext>, IHotelsRepository
    {
        #region Properties

        private readonly ILogger<HotelsRepository> logger;
        private readonly IMapper mapper;

        #endregion

        #region Constructor

        public HotelsRepository(
            HotelsDbContext context,
            ILogger<HotelsRepository> logger,
            IMapper mapper) : base(context)
        {
            this.logger = logger;
            this.mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<IList<Hotel>> GetByNameAsync(string hotelName)
        {
            var hotels = await Context.Hotels
                .Include(h => h.HotelFacilities)
                .Where(h => h.Name.ToLower().Contains(hotelName.Trim().ToLower()))
                .ToListAsync();

            return mapper.Map<IList<Hotel>>(hotels);
        }

        public async Task<Hotel> GetProfileAsync(Guid hotelId)
        {
            var hotel = await Context.Hotels
                .Include(h => h.HotelFacilities)
                .FirstOrDefaultAsync(h => h.Id == hotelId);

            return mapper.Map<Hotel>(hotel);
        }

        public async Task AddAsync(Hotel hotel)
        {
            var hotelEntity = mapper.Map<HotelEntity>(hotel);

            await Context.Hotels.AddAsync(hotelEntity);
        }

        public async Task UpdateAsync(Hotel hotel)
        {
            var newHotelEntity = mapper.Map<HotelEntity>(hotel);

            var oldHotelEntity = await Context.Hotels
                .FirstAsync(h => h.Id == hotel.Id);

            Context.Entry(oldHotelEntity).State = EntityState.Detached;
            Context.Entry(newHotelEntity).State = EntityState.Modified;
        }

        public async Task RemoveAsync(Guid hotelId)
        {
            var hotelEntity = await Context.Hotels
                .Include(h => h.HotelFacilities)
                .FirstAsync(h => h.Id == hotelId);

            Context.Hotels.Remove(hotelEntity);
        }

        #endregion
    }
}