using System.Collections.Generic;
using System.Threading.Tasks;
using PracticalAssessment.DataAccessContract.Entities;

namespace PracticalAssessment.DataAccessContract
{
    public interface ITransactionRepository
    {
        public Task<IEnumerable<Transaction>> ListAsync();
    }
}