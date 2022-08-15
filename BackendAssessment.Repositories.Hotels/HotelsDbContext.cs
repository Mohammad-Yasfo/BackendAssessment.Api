using BackendAssessment.Repositories.Common.Contexts;
using BackendAssessment.Repositories.Hotels.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendAssessment.Repositories.Hotels
{
    public class HotelsDbContext : BaseContext
    {
        #region Properties
        private const string commonSchema = "cmn";
        private const string configSchema = "cfg";
        #endregion

        #region Constructor
        public HotelsDbContext(DbContextOptions<HotelsDbContext> options) : base(options)
        {
        }
        #endregion

        #region DbSets
        public DbSet<HotelEntity> Hotels { get; set; }
        public DbSet<HotelFacilityEntity> HotelFacilities { get; set; }
        public DbSet<FacilityEntity> Facilities { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<HotelEntity>(e =>
            {
                e.ToTable("Hotels", configSchema);
                e.Property(h => h.RatingValue).HasColumnType("decimal").HasPrecision(4, 2);
                e.Property(p => p.MinimumValue).HasColumnType("decimal").HasPrecision(7, 2);
                e.Property(p => p.MaximumValue).HasColumnType("decimal").HasPrecision(7, 2);
            });

            builder.Entity<HotelFacilityEntity>(e =>
            {
                e.ToTable("HotelFacilities", configSchema)
                .HasKey(f => new { f.HotelId, f.FacilityId });
            });

            builder.Entity<FacilityEntity>(e =>
            {
                e.ToTable("Facilities", commonSchema);

                e.Property(p => p.Name).IsUnicode(false);
                e.Property(p => p.IsPublished).HasDefaultValue(false);
            });
        }
    }
}