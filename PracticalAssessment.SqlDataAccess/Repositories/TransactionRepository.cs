using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PracticalAssessment.DataAccessContract;
using PracticalAssessment.DataAccessContract.Entities;

namespace PracticalAssessment.SqlDataAccess.Repositories
{
    public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
    {
        public TransactionRepository(Context context) : base(context)
        {
        }

        protected override IQueryable<Transaction> FullQuery => Context
            .Transactions
            .Include(_ => _.Category)
            .Include(_ => _.Currency)
            .Include(_ => _.Recipient);

        public async Task<IEnumerable<IGrouping<DateTime, Transaction>>> ListGroupedByDateAsync()
        {
            var all = await ListAsync();

            return all
                .OrderByDescending(_ => _.OccuredOn)
                .GroupBy(_ => _.OccuredOn.Date);
        }
    }
}