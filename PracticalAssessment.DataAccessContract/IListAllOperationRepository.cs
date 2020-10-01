using System.Collections.Generic;
using System.Threading.Tasks;
using PracticalAssessment.DataAccessContract.Entities;

namespace PracticalAssessment.DataAccessContract
{
    public interface IListAllOperationRepository<TEntity> where TEntity : EntityBase
    {
        public Task<IEnumerable<TEntity>> ListAsync();
    }
}
