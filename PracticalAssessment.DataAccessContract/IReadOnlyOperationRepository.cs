using System.Collections.Generic;
using System.Threading.Tasks;
using PracticalAssessment.DataAccessContract.Entities;

namespace PracticalAssessment.DataAccessContract
{
    public interface IReadOnlyOperationRepository<TEntity> where TEntity : EntityBase
    {
        Task<IEnumerable<TEntity>> ListAsync();

        Task<bool> Exists(int key);
    }
}
