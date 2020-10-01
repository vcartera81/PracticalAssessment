using System.Threading.Tasks;

namespace PracticalAssessment.Business.Validation
{
    public interface IValidator<in TDto>
    {
        Task ValidateForAdding(TDto dto);

        Task ValidateForUpdate(TDto dto);

        Task ValidateForDeletion(int id);
    }
}