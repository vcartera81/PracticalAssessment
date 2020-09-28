namespace PracticalAssessment.DataAccessContract.Entities
{
    public class Recipient : EntityBase
    {
        private Recipient()
        {
            // EF ctor
        }

        public string Name { get; set; }
    }
}
