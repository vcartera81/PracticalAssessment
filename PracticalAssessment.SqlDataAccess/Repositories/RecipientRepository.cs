using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PracticalAssessment.DataAccessContract;
using PracticalAssessment.DataAccessContract.Entities;

namespace PracticalAssessment.SqlDataAccess.Repositories
{
    public class RecipientRepository : RepositoryBase<Recipient>, IRecipientRepository
    {
        public RecipientRepository(Context context) : base(context)
        {
        }

        protected override IQueryable<Recipient> FullQuery => Context.Recipients;

        public async Task<bool> NameExists(string nameToCheck) =>
            await FullQuery.FirstOrDefaultAsync(_ => _.Name == nameToCheck) != null;
    }
}
