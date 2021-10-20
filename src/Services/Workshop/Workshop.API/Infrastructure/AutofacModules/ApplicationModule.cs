using Autofac;
using MediatR;
using System.Reflection;
using Workshop.API.Application.Commands.BodyworkParameter;
using Workshop.API.Application.Commands.BrandParameter;
using Workshop.API.Application.Queries.BodyWorkType;
using Workshop.API.Application.Queries.Brand;
using Workshop.API.Application.Queries.TireType;
using Workshop.Damain.AggregatesModel.ParameterAggregate;
using Workshop.Infrastructure.Repositories;

namespace Workshop.API.Infrastructure.AutofacModules
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
            #region Brands Application

            builder.Register(c => new BrandQueries(QueriesConnectionString))
                .As<IBrandQueries>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BrandRepository>()
                .As<IBrandRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(CreateBrandCommandHandler)
                .GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(UpdateBrandCommandHandler)
                .GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(DeleteBrandCommandHandler)
                .GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            #endregion

            #region Bodywork Application

            builder.Register(c => new BodyWorkTypesQueries(QueriesConnectionString))
                .As<IBodyWorkTypeQueries>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BodyWorkTypeRepository>()
                .As<IBodyWorkTypeRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(CreateBodyWorkCommandHandler)
                .GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(DeleteBodyWorkCommandHandler)
                .GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(UpdateBodyWorkCommandHandler)
                .GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            #endregion

            #region TireType Application

            builder.Register(c => new TireTypeQueries(QueriesConnectionString))
                .As<ITireTypeQueries>()
                .InstancePerLifetimeScope();

            //builder.RegisterType<TireTypeRepository>()
            //    .As<ITireTypeRepository>()
            //    .InstancePerLifetimeScope();

            //builder.RegisterAssemblyTypes(typeof(CreateTireTypeCommandHandler)
            //    .GetTypeInfo().Assembly)
            //    .AsClosedTypesOf(typeof(IRequestHandler<,>));

            //builder.RegisterAssemblyTypes(typeof(DeleteTireTypeCommandHandler)
            //    .GetTypeInfo().Assembly)
            //    .AsClosedTypesOf(typeof(IRequestHandler<,>));

            //builder.RegisterAssemblyTypes(typeof(UpdateTireTypeCommandHandler)
            //    .GetTypeInfo().Assembly)
            //    .AsClosedTypesOf(typeof(IRequestHandler<,>));

            #endregion
        }
    }
}
