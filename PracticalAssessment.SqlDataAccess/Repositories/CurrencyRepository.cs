using System.Linq;
using PracticalAssessment.DataAccessContract;
using PracticalAssessment.DataAccessContract.Entities;

namespace PracticalAssessment.SqlDataAccess.Repositories
{
    public class CurrencyRepository : RepositoryBase<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(Context context) : base(context)
        {
        }

        protected override IQueryable<Currency> FullQuery => Context.Currencies;
    }
}
