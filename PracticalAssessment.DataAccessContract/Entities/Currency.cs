namespace PracticalAssessment.DataAccessContract.Entities
{
    public class Currency : EntityBase
    {
        private Currency()
        {
            // EF ctor
        }

        public string Name { get; private set; }

        public string Code { get; private set; }

        public string Symbol { get; private set; }
    }
}
