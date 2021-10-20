using FluentValidation;
using Microsoft.Extensions.Logging;
using Workshop.API.Application.Commands.TireTypeParameter;

namespace Workshop.API.Application.Validations.TireTypeValidator
{
    public class CreateTireTypeCommandValidator : AbstractValidator<CreateTireTypeCommand>
    {
        public CreateTireTypeCommandValidator(ILogger<CreateTireTypeCommandValidator> logger)
        {
            RuleFor(command => command.Description).Length(4, 45);

            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
