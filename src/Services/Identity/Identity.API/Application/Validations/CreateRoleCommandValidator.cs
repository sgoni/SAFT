using FluentValidation;
using Identity.API.Application.Commands.Role;
using Microsoft.Extensions.Logging;

namespace Identity.API.Application.Validations
{
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator(ILogger<CreateRoleCommandValidator> logger)
        {
            RuleFor(command => command.Name).NotEmpty().Length(5, 55);

            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
