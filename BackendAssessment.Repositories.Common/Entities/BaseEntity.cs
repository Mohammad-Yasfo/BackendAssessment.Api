using BackendAssessment.Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAssessment.Repositories.Common.Entities
{
    public abstract class RelationEntity
    {
        public DateTime CreatedDateTime { get; set; }

        public Guid CreatedBy { get; set; }
    }

    public abstract class TransactionalEntity<T> : BaseEntity<T>
    {
        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }
    }

    public abstract class TransactionalEntity : BaseEntity<Guid>
    {
        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }
    }

    public abstract class BaseEntity<T>
    {
        public T Id { get; set; }
    }

    public abstract class BaseEntity : BaseEntity<Guid>
    {
    }

    public abstract class BaseNamedEntity<Tkey> : BaseEntity<Tkey>
    {
        [Required]
        [MaxLength(Constants.MediumTitleMaxLength)]
        public string Name { get; set; }
    }
}