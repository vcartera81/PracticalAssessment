using Autofac;
using PracticalAssessment.Business.Services;

namespace PracticalAssessment.Business
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<TransactionService>().As<ITransactionService>().InstancePerLifetimeScope();
        }
    }
}
