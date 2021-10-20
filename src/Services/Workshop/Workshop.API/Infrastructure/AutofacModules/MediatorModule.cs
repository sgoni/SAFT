using Autofac;
using FluentValidation;
using MediatR;
using System.Linq;
using System.Reflection;
using Workshop.API.Application.Behaviors;
using Workshop.API.Application.Commands.BodyworkParameter;
using Workshop.API.Application.Commands.BrandParameter;
using Workshop.API.Application.Validations.BodyworkValidator;
using Workshop.API.Application.Validations.BrandValidator;

namespace Workshop.API.Infrastructure.AutofacModules
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            // Register all the Command classes (they implement IRequestHandler) in assembly holding the Commands

            #region Brand Commands CRUD

            builder.RegisterAssemblyTypes(typeof(CreateBrandCommand)
                .GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(DeleteBrandCommand)
                .GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(UpdateBrandCommand)
                .GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            #endregion

            #region Tire Type Commands CRUD

            //builder.RegisterAssemblyTypes(typeof(CreateTireTypeCommand)
            //    .GetTypeInfo().Assembly)
            //    .AsClosedTypesOf(typeof(IRequestHandler<,>));

            //builder.RegisterAssemblyTypes(typeof(DeleteTireTypeCommand)
            //    .GetTypeInfo().Assembly)
            //    .AsClosedTypesOf(typeof(IRequestHandler<,>));

            //builder.RegisterAssemblyTypes(typeof(UpdateTireTypeCommand)
            //    .GetTypeInfo().Assembly)
            //    .AsClosedTypesOf(typeof(IRequestHandler<,>));

            #endregion

            #region BodyWorkType Commands CRUD

            builder.RegisterAssemblyTypes(typeof(CreateBodyWorkCommand)
                .GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(DeleteBodyWorkCommand)
                .GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(UpdateBodyWorkCommand)
                .GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            #endregion

            // Register the DomainEventHandler classes (they implement INotificationHandler<>) in assembly holding the Domain Events

            //builder.RegisterAssemblyTypes(typeof(ValidateOrAddBuyerAggregateWhenOrderStartedDomainEventHandler).GetTypeInfo().Assembly)
            //    .AsClosedTypesOf(typeof(INotificationHandler<>));

            // Register the Command's Validators (Validators based on FluentValidation library)

            #region Brand Commands Validator

            builder
                .RegisterAssemblyTypes(typeof(CreateBrandCommandValidator)
                .GetTypeInfo().Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
                .AsImplementedInterfaces();

            builder
                .RegisterAssemblyTypes(typeof(UpdateBrandCommandValidator)
                .GetTypeInfo().Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
                .AsImplementedInterfaces();

            #endregion

            #region Tire Commands Validator

            //builder
            //    .RegisterAssemblyTypes(typeof(CreateTireTypeCommandValidator)
            //    .GetTypeInfo().Assembly)
            //    .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
            //    .AsImplementedInterfaces();

            //builder
            //    .RegisterAssemblyTypes(typeof(UpdateTireTypeCommandValidator)
            //    .GetTypeInfo().Assembly)
            //    .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
            //    .AsImplementedInterfaces();

            #endregion

            #region BodyWorkType Commands Validator

            builder
                .RegisterAssemblyTypes(typeof(CreateBodyWorkCommandValidator)
                .GetTypeInfo().Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
                .AsImplementedInterfaces();

            builder
                .RegisterAssemblyTypes(typeof(UpdateBodyWorkCommandValidator)
                .GetTypeInfo().Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
                .AsImplementedInterfaces();

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
