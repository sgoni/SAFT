using FluentValidation;
using Identity.API.Application.Commands.AspnetRole;
using Microsoft.Extensions.Logging;

namespace Identity.API.Application.Validations
{
    public class UpdateAspNetRoleCommandValidator : AbstractValidator<UpdateAspNetRoleCommand>
    {
        public UpdateAspNetRoleCommandValidator(ILogger<UpdateAspNetRoleCommandValidator> logger)
        {
            RuleFor(command => command.Name).NotEmpty().Length(5, 55);

            logger.LogTrace("----- INSTANCE UPDATED - {ClassName}", GetType().Name);
        }
    }
}