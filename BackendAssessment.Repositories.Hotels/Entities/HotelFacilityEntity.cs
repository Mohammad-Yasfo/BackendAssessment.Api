using BackendAssessment.Repositories.Common.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendAssessment.Repositories.Hotels.Entities
{
    public class HotelFacilityEntity : RelationEntity
    {
        [Required]
        [ForeignKey("Hotel")]
        public Guid HotelId { get; set; }
        public virtual HotelEntity Hotel { get; set; }

        [Required]
        [ForeignKey("Facility")]
        public byte FacilityId { get; set; }
        public virtual FacilityEntity Facility { get; set; }
    }
}