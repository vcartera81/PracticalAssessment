using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> NameExists(string nameToCheck) =>
            await FullQuery.FirstOrDefaultAsync(_ => _.Name == nameToCheck) != null;
    }
}
