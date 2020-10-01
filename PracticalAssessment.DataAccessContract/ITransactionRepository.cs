using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticalAssessment.DataAccessContract.Entities;

namespace PracticalAssessment.DataAccessContract
{
    public interface ITransactionRepository : IReadOnlyOperationRepository<Transaction>, IPersistentOperationRepository<Transaction>
    {
        Task<IEnumerable<IGrouping<DateTime, Transaction>>> ListGroupedByDateAsync();
    }
}