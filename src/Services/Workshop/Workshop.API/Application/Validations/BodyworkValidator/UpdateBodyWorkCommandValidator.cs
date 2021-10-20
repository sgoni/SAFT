using FluentValidation;
using Microsoft.Extensions.Logging;
using Workshop.API.Application.Commands.BodyworkParameter;

namespace Workshop.API.Application.Validations.BodyworkValidator
{
    public class UpdateBodyWorkCommandValidator : AbstractValidator<UpdateBodyWorkCommand>
    {
        public UpdateBodyWorkCommandValidator(ILogger<UpdateBodyWorkCommandValidator> logger)
        {
            RuleFor(command => command.Description).Length(4, 45);

            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
