namespace BackendAssessment.Application.Common.Contracts
{
    public interface IUnitOfWork
    {
        void BlockSaveChanges();
        void UnBlockSaveChanges();
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}