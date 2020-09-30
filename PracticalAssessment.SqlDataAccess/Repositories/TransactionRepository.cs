using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PracticalAssessment.DataAccessContract;
using PracticalAssessment.DataAccessContract.Entities;

namespace PracticalAssessment.SqlDataAccess.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly Context _context;

        public TransactionRepository(Context context) => _context = context;

        private IQueryable<Transaction> FullQuery() => _context
            .Transactions
            .Include(_ => _.Category)
            .Include(_ => _.Currency)
            .Include(_ => _.Recipient);

        public async Task<IEnumerable<Transaction>> ListAsync() => await FullQuery().ToListAsync();

        public async Task<IEnumerable<IGrouping<DateTime, Transaction>>> ListGroupedByDateAsync()
        {
            var all = await ListAsync();

            return all
                .OrderByDescending(_ => _.OccuredOn)
                .GroupBy(_ => _.OccuredOn);
        }
    }
}