using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PracticalAssessment.DataAccessContract.Entities;

namespace PracticalAssessment.SqlDataAccess
{
    public abstract class RepositoryBase<TEntity> where TEntity : EntityBase
    {
        protected readonly Context Context;

        protected RepositoryBase(Context context) => Context = context;

        public async Task<IEnumerable<TEntity>> ListAsync() => await FullQuery.ToListAsync();

        protected abstract IQueryable<TEntity> FullQuery { get; }
    }
}
