using BackendAssessment.Repositories.Common.Entities;
using System.ComponentModel.DataAnnotations;

namespace BackendAssessment.Repositories.Hotels.Entities
{
    public class HotelEntity : BaseEntity
    {
        public byte CurrencyId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        [Required]
        [Range(0, 100)]
        public decimal RatingValue { get; set; }

        [Range(0.01, 99999.99)]
        public decimal MinimumValue { get; set; }

        [Range(0.01, 99999.99)]
        public decimal MaximumValue { get; set; }

        public Guid? FeaturedImageId { get; set; }

        public virtual ICollection<HotelFacilityEntity> HotelFacilities { get; set; }
    }
}