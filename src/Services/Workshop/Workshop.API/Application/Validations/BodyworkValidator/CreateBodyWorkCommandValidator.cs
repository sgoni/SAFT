using FluentValidation;
using Microsoft.Extensions.Logging;
using Workshop.API.Application.Commands.BodyworkParameter;

namespace Workshop.API.Application.Validations.BodyworkValidator
{
    public class CreateBodyWorkCommandValidator : AbstractValidator<CreateBodyWorkCommand>
    {
        public CreateBodyWorkCommandValidator(ILogger<CreateBodyWorkCommandValidator> logger)
        {
            RuleFor(command => command.Description).Length(4, 45);

            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
