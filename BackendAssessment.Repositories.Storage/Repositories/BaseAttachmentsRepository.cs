using AutoMapper;
using BackendAssessment.Repositories.Common.Contexts;

namespace BackendAssessment.Repositories.Storage.Repositories
{
    public class BaseAttachmentsRepository : BaseRepository<AttachmentsDbContext>
    {
        #region Properties

        protected IMapper mapper;

        #endregion

        #region Constructor

        public BaseAttachmentsRepository(AttachmentsDbContext context, IMapper mapper) : base(context)
        {
            this.mapper = mapper;
        }

        #endregion
    }
}