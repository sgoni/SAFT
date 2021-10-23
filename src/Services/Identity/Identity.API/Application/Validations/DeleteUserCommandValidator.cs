using FluentValidation;
using Identity.API.Application.Commands.User;
using Microsoft.Extensions.Logging;

namespace Identity.API.Application.Validations
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator(ILogger<DeleteUserCommandValidator> logger)
        {
            RuleFor(command => command.Id).NotEmpty();

            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
