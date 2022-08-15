using BackendAssessment.Repositories.Common.Contexts;
using BackendAssessment.Repositories.Storage.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendAssessment.Repositories.Storage
{
    public class AttachmentsDbContext : BaseContext
    {
        #region Properties
        private const string commonSchema = "cmn";
        #endregion

        #region Constructor
        public AttachmentsDbContext(DbContextOptions<AttachmentsDbContext> options) : base(options)
        {
        }
        #endregion

        #region DbSets
        public DbSet<BaseAttachmentEntity> Attachments { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<BaseAttachmentEntity>(e =>
            {
                e.ToTable("Attachments", commonSchema);
            });
        }
    }
}