using Autofac;
using Customer.Api.Application.Commands.Banking;
using Customer.Api.Application.Queries.Banking;
using Customer.API.Application.Commands.Customer;
using Customer.API.Application.Queries.Customer;
using Customer.Domain.AggregatesModel.BankingAggregate;
using Customer.Domain.AggregatesModel.CustomerAggregate;
using Customer.Infrastructure.Repositories;
using MediatR;
using System.Reflection;

namespace Customer.API.Infrastructure.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {
        public string QueriesConnectionString { get; }

        public ApplicationModule(string qconstr)
        {
            QueriesConnectionString = qconstr;
        }

        protected override void Load(ContainerBuilder builder)
        {
            // Customer
            builder.Register(c => new CustomerQueries(QueriesConnectionString))
                .As<ICustomerQueries>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CustomerRepository>()
                .As<ICustomerRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(CreateCustomerCommandHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(UpdateCustomerCommandHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            // Banking
            builder.Register(c => new BankingQueries(QueriesConnectionString))
                .As<IBankingQueries>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BankingRepository>()
                .As<IBankingRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(CreateBankCommandHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));
        }
    }
}
