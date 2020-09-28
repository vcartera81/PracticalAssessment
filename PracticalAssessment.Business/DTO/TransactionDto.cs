using System;

namespace PracticalAssessment.Business.DTO
{
    public class TransactionDto
    {
        public int Id { get; set; }

        public DateTime OccuredOn { get; set; }

        public string Title { get; set; }

        public double Amount { get; set; }

        public CurrencyDto Currency { get; set; }

        public CategoryDto Category { get; set; }

        public RecipientDto Recipient { get; set; }
    }
}
