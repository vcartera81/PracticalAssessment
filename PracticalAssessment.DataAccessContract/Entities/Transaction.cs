using System;

namespace PracticalAssessment.DataAccessContract.Entities
{
    public class Transaction : EntityBase
    {
        private Transaction()
        {
            // EF ctor
        }

        public DateTime OccuredOn { get; private set; }

        public string Title { get; private set; }

        public double Amount { get; private set; }

        public int CurrencyId { get; private set; }

        public Currency Currency { get; private set; }

        public int CategoryId { get; private set; }

        public Category Category { get; private set; }

        public int RecipientId { get; private set; }

        public Recipient Recipient { get; private set; }
    }
}
