using Autofac;
using FluentValidation;
using Identity.API.Application.Behaviors;
using Identity.API.Application.Commands.AspnetRole;
using Identity.API.Application.Commands.AspnetUser;
using Identity.API.Application.Validations;
using MediatR;
using System.Reflection;

namespace Identity.API.Infrastructure.AutofacModules
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            // Register all the Command classes (they implement IRequestHandler) in assembly holding the Commands

            #region AspNetUser Commands CRUD

            builder.RegisterAssemblyTypes(typeof(CreateAspNetUserCommand)
                .GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            //builder.RegisterAssemblyTypes(typeof(DeleteAspNetUserCommand)
            //    .GetTypeInfo().Assembly)
            //    .AsClosedTypesOf(typeof(IRequestHandler<,>));

            //builder.RegisterAssemblyTypes(typeof(UpdateAspNetUserCommand)
            //    .GetTypeInfo().Assembly)
            //    .AsClosedTypesOf(typeof(IRequestHandler<,>));

            #endregion

            #region AspNetRole Commands CRUD

            builder.RegisterAssemblyTypes(typeof(CreateAspNetRoleCommand)
                .GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            //builder.RegisterAssemblyTypes(typeof(DeleteAspNetRoleCommand)
            //    .GetTypeInfo().Assembly)
            //    .AsClosedTypesOf(typeof(IRequestHandler<,>));

            //builder.RegisterAssemblyTypes(typeof(UpdateAspNetRoleCommand)
            //    .GetTypeInfo().Assembly)
            //    .AsClosedTypesOf(typeof(IRequestHandler<,>));

            #endregion

            // Register the DomainEventHandler classes (they implement INotificationHandler<>) in assembly holding the Domain Events

            //builder.RegisterAssemblyTypes(typeof(ValidateOrAddBuyerAggregateWhenOrderStartedDomainEventHandler).GetTypeInfo().Assembly)
            //    .AsClosedTypesOf(typeof(INotificationHandler<>));

            // Register the Command's Validators (Validators based on FluentValidation library)

            #region AspNetUser Commands Validator

            builder
            .RegisterAssemblyTypes(typeof(CreateAspNetUserCommandValidator)
            .GetTypeInfo().Assembly)
            .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
            .AsImplementedInterfaces();

            //builder
            //.RegisterAssemblyTypes(typeof(UpdateAspNetUserCommandValidator)
            //.GetTypeInfo().Assembly)
            //.Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
            //.AsImplementedInterfaces();

            #endregion

            #region AspNetRole Commands Validator

            //builder
            //.RegisterAssemblyTypes(typeof(CreateAspNetRoleCommandValidator)
            //.GetTypeInfo().Assembly)
            //.Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
            //.AsImplementedInterfaces();

            //builder
            //.RegisterAssemblyTypes(typeof(UpdateAspNetUserCommandValidator)
            //.GetTypeInfo().Assembly)
            //.Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
            //.AsImplementedInterfaces();

            #endregion

            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t => { object o; return componentContext.TryResolve(t, out o) ? o : null; };
            });

            builder.RegisterGeneric(typeof(LoggingBehavior<,>)).As(typeof(IPipelineBehavior<,>));

            builder.RegisterGeneric(typeof(ValidatorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
        }
    }
}
