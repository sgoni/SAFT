using FluentValidation;
using Identity.API.Application.Commands.AspnetRole;
using Microsoft.Extensions.Logging;

namespace Identity.API.Application.Validations
{
    public class CreateAspNetRoleCommandValidator : AbstractValidator<CreateAspNetRoleCommand>
    {
        public CreateAspNetRoleCommandValidator(ILogger<CreateAspNetRoleCommandValidator> logger)
        {
            RuleFor(command => command.Name).NotEmpty().Length(5, 55);

            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
