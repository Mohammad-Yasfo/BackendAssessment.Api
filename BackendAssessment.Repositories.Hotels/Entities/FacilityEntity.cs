using BackendAssessment.Repositories.Common.Entities;

namespace BackendAssessment.Repositories.Hotels.Entities
{
    public class FacilityEntity : BaseNamedEntity<byte>
    {
        public bool IsPublished { get; set; }
    }
}