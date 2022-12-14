using BackendAssessment.Application.Common.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BackendAssessment.Repositories.Storage
{
    public class AttachmentsUnitOfWork : IAttachmentsUnitOfWork
    {
        protected DbContext Context { get; }

        private int NumberOfBlockers { get; set; } = 0;

        public AttachmentsUnitOfWork(AttachmentsDbContext context)
        {
            Context = context;
        }

        public int SaveChanges()
        {
            if (NumberOfBlockers == 0)
                return Context.SaveChanges();

            return 0;
        }

        public async Task<int> SaveChangesAsync()
        {
            if (NumberOfBlockers == 0)
                return await Context.SaveChangesAsync();

            return 0;
        }

        public void BlockSaveChanges()
        {
            NumberOfBlockers++;
        }
        public void UnBlockSaveChanges()
        {
            if (NumberOfBlockers > 0)
                NumberOfBlockers--;
        }
    }
}