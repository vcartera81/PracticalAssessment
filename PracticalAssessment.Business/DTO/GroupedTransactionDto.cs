using System;
using System.Collections.Generic;

namespace PracticalAssessment.Business.DTO
{
    public class GroupedTransactionDto
    {
        public IEnumerable<TransactionDto> Transactions { get; set; }

        public DateTime Date { get; set; }

        public double Balance { get; set; }
    }
}
