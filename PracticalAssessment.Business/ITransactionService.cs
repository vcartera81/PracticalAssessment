using System.Collections.Generic;
using System.Threading.Tasks;
using PracticalAssessment.Business.DTO;

namespace PracticalAssessment.Business
{
    public interface ITransactionService
    {
        public Task<IEnumerable<TransactionDto>> GetAll();

        public Task<IEnumerable<GroupedTransactionDto>> GetAllGroupedByDate();
    }
}
