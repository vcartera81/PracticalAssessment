using System.Threading.Tasks;
using PracticalAssessment.DataAccessContract.Entities;

namespace PracticalAssessment.DataAccessContract
{
    public interface IPersistentOperationRepository<in TEntity> where TEntity : EntityBase
    {
        Task<int> Add(TEntity entity);

        Task Update(TEntity entity);

        Task Remove(int key);
    }
}
