using System.Threading.Tasks;
using PracticalAssessment.DataAccessContract.Entities;

namespace PracticalAssessment.DataAccessContract
{
    public interface IRecipientRepository : IReadOnlyOperationRepository<Recipient>, IPersistentOperationRepository<Recipient>
    {
        Task<bool> NameExists(string name);
    }
}
