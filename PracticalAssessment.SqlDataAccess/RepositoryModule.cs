﻿using Autofac;
using PracticalAssessment.DataAccessContract;
using PracticalAssessment.SqlDataAccess.Repositories;

namespace PracticalAssessment.SqlDataAccess
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<TransactionRepository>().As<ITransactionRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().InstancePerLifetimeScope();
            builder.RegisterType<RecipientRepository>().As<IRecipientRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CurrencyRepository>().As<ICurrencyRepository>().InstancePerLifetimeScope();
        }
    }
}
