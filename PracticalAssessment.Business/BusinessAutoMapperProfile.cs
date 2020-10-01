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

            CreateMap<TransactionDto, Transaction>()
                .ForMember(_ => _.RecipientId, m => m.MapFrom(_ => _.Recipient.Id))
                .ForMember(_ => _.CategoryId, m => m.MapFrom(_ => _.Category.Id))
                .ForMember(_ => _.CurrencyId, m => m.MapFrom(_ => _.Currency.Id))
                .ForMember(_ => _.Currency, m => m.Ignore())
                .ForMember(_ => _.Category, m => m.Ignore())
                .ForMember(_ => _.Recipient, m => m.Ignore());
        }
    }
}
