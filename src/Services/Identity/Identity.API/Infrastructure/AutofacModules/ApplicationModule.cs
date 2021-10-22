using Autofac;
using Identity.API.Application.Commands.Role;
using Identity.API.Application.Commands.User;
using MediatR;
using System.Reflection;

namespace Identity.API.Infrastructure.AutofacModules
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
            #region AspNetUser

            //builder.Register(c => new AspNetApplicationQueries(QueriesConnectionString))
            //    .As<IAspNetApplicationQueries>()
            //    .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(CreatetUserCommand)
                .GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(LoginUserCommand)
                .GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            #endregion

            #region AspNetRole

            //builder.Register(c => new AspNetApplicationQueries(QueriesConnectionString))
            //    .As<IAspNetApplicationQueries>()
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<AspNetUserRepository>()
            //    .As<IAspNetUserRepository>()
            //    .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(CreateRoleCommand)
                .GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            //builder.RegisterAssemblyTypes(typeof(DeleteAspNetRoleCommandHandler)
            //    .GetTypeInfo().Assembly)
            //    .AsClosedTypesOf(typeof(IRequestHandler<,>));

            //builder.RegisterAssemblyTypes(typeof(UpdateAspNetRoleCommandHandler)
            //    .GetTypeInfo().Assembly)
            //    .AsClosedTypesOf(typeof(IRequestHandler<,>));
            #endregion
        }
    }
}
