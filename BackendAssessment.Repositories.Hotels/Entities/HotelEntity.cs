using BackendAssessment.Repositories.Common.Entities;

namespace BackendAssessment.Repositories.Hotels.Entities
{
    public class HotelEntity : BaseEntity
    {
        public byte CurrencyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public decimal RatingValue { get; set; }
        public int MinimumValue { get; set; }
        public int MaximumValue { get; set; }
        public Guid? FeaturedImageId { get; set; }

        public virtual ICollection<HotelFacilityEntity> HotelFacilities { get; set; }
    }
}