using System.Collections.Generic;
using System.Threading.Tasks;
using PracticalAssessment.Business.DTO;

namespace PracticalAssessment.Business
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionDto>> GetAll();

        Task<IEnumerable<GroupedTransactionDto>> GetAllGroupedByDate();

        Task<int> Add(TransactionDto newTransaction);

        Task Update(TransactionDto updatedTransaction);

        Task Delete(int transactionId);
    }
}
