using System.Collections.Generic;
using System.Threading.Tasks;
using PracticalAssessment.Business.Exception;

namespace PracticalAssessment.Business.Validation
{
    public abstract class ValidatorBase<TDto> : IValidator<TDto>
    {
        public abstract Task ValidateForAdding(TDto dto);

        public abstract Task ValidateForUpdate(TDto dto);

        public abstract Task ValidateForDeletion(int id);

        protected void ValidateValueNotNullOrWhitespace(string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new BusinessException($"Field {propertyName} can't be null or empty.");
        }

        protected void ValidateNotDefaultValue<TValue>(TValue value, string propertyName) where TValue : struct
        {
            if (EqualityComparer<TValue>.Default.Equals(value, default))
                throw new BusinessException($"Field {propertyName} can't have the default value of {value}.");
        }
    }
}
