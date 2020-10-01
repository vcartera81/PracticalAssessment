using System.Linq;
using PracticalAssessment.DataAccessContract;
using PracticalAssessment.DataAccessContract.Entities;

namespace PracticalAssessment.SqlDataAccess.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(Context context) : base(context)
        {
        }

        protected override IQueryable<Category> FullQuery => Context.Categories;
    }
}
