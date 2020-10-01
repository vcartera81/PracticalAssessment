using Autofac;
using PracticalAssessment.Business.DTO;
using PracticalAssessment.Business.Services;
using PracticalAssessment.Business.Validation;

namespace PracticalAssessment.Business
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            // services
            builder.RegisterType<TransactionService>().As<ITransactionService>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<RecipientService>().As<IRecipientService>().InstancePerLifetimeScope();
            builder.RegisterType<CurrencyService>().As<ICurrencyService>().InstancePerLifetimeScope();

            // validators
            builder.RegisterType<TransactionValidator>().As<IValidator<TransactionDto>>();
        }
    }
}
