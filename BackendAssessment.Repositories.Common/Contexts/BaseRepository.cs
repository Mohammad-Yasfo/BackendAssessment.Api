using AutoMapper;
using BackendAssessment.Repositories.Common.Contexts.Contracts;
using Microsoft.Extensions.Logging;

namespace BackendAssessment.Repositories.Common.Contexts
{
    public abstract class BaseRepository<TContext>
    {
        protected TContext Context { get; }

        public BaseRepository(TContext context)
        {
            Context = context;
        }
    }

    public abstract class BaseEntityRepository<TContext, TEntity>
        where TEntity : class
        where TContext : IBaseEntityContext<TEntity>
    {
        protected readonly ILogger Logger;
        protected readonly IMapper mapper;
        protected readonly TContext Context;

        public BaseEntityRepository(
            ILogger logger,
            IMapper mapper,
            TContext context)
        {
            this.Logger = logger;
            this.mapper = mapper;
            this.Context = context;
        }
    }
}