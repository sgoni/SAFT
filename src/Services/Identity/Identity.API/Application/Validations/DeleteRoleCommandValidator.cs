using FluentValidation;
using Identity.API.Application.Commands.Role;
using Microsoft.Extensions.Logging;

namespace Identity.API.Application.Validations
{
    public class DeleteRoleCommandValidator : AbstractValidator<DeleteRoleCommand>
    {
        public DeleteRoleCommandValidator(ILogger<DeleteRoleCommandValidator> logger)
        {
            RuleFor(command => command.Id).NotEmpty();

            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
