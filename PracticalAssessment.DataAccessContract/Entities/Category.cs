namespace PracticalAssessment.DataAccessContract.Entities
{
    public class Category : EntityBase
    {
        private Category()
        {
            // EF ctor
        }

        public CategoryType Type { get; private set; }

        public string Name { get; private set; }
    }
}
