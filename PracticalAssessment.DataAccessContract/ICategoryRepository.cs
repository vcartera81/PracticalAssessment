using System.Threading.Tasks;
using PracticalAssessment.DataAccessContract.Entities;

namespace PracticalAssessment.DataAccessContract
{
    public interface ICategoryRepository : IReadOnlyOperationRepository<Category>, IPersistentOperationRepository<Category>
    {
        Task<bool> NameExists(string nameToCheck);
    }
}
