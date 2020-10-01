using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PracticalAssessment.DataAccessContract;
using PracticalAssessment.DataAccessContract.Entities;

namespace PracticalAssessment.SqlDataAccess
{
    public abstract class RepositoryBase<TEntity> : IReadOnlyOperationRepository<TEntity>, IPersistentOperationRepository<TEntity> where TEntity : EntityBase
    {
        protected readonly Context Context;

        protected RepositoryBase(Context context) => Context = context;

        public async Task<IEnumerable<TEntity>> ListAsync() => await FullQuery.ToListAsync();

        protected abstract IQueryable<TEntity> FullQuery { get; }

        public async Task<int> Add(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
            await Context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task Update(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
            await Context.SaveChangesAsync();
        }

        public async Task Remove(int key)
        {
            var matchingEntity = await Context
                .Set<TEntity>()
                .FirstOrDefaultAsync(_ => _.Id == key);

            if (matchingEntity == null)
                throw new ArgumentException($"There's no entity with ID {key}.");

            Context.Set<TEntity>().Remove(matchingEntity);
            await Context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int key) => await Context
            .Set<TEntity>()
            .AsNoTracking()
            .FirstOrDefaultAsync(_ => _.Id == key) != null;
    }
}
