using PracticalAssessment.DataAccessContract.Entities;

namespace PracticalAssessment.DataAccessContract
{
    public interface ICurrencyRepository : IReadOnlyOperationRepository<Currency>
    {
    }
}