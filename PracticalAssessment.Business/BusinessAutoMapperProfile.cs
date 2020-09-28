using AutoMapper;
using PracticalAssessment.Business.DTO;
using PracticalAssessment.DataAccessContract.Entities;

namespace PracticalAssessment.Business
{
    // ReSharper disable once UnusedMember.Global
    public class BusinessAutoMapperProfile : Profile
    {
        public BusinessAutoMapperProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Currency, CurrencyDto>();
            CreateMap<Recipient, RecipientDto>();
            CreateMap<Transaction, TransactionDto>();
        }
    }
}
