namespace PracticalAssessment.Business.DTO
{
    public class CategoryDto
    {
        public int Id { get; set; }

        public CategoryType Type { get; private set; }

        public string Name { get; private set; }
    }
}
