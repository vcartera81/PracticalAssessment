using System.Collections.Generic;
using PracticalAssessment.DataAccessContract.Entities;

namespace PracticalAssessment.Business
{
    internal static class Extensions
    {
        public static double GetBalance(this IEnumerable<Transaction> source)
        {
            var balance = 0.0;
            foreach (var transaction in source)
            {
                if (transaction.Category.Type == CategoryType.Income)
                    balance += transaction.Amount;
                else balance -= transaction.Amount;
            }

            return balance;
        }
    }
}
