using System.Linq;
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
    }
}
