using BackendAssessment.Repositories.Common.Entities;
using System.ComponentModel.DataAnnotations;

namespace BackendAssessment.Repositories.Storage.Entities
{
    public class BaseAttachmentEntity : BaseEntity
    {
        [Required]
        [MinLength(1), MaxLength(100)]
        public string CloudKey { get; set; }

        [Required]
        public int Size { get; set; }

        [Required]
        [MinLength(1), MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string ContentType { get; set; }
    }
}