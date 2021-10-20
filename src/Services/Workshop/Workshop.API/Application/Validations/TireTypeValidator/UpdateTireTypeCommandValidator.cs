using FluentValidation;
using Microsoft.Extensions.Logging;
using Workshop.API.Application.Commands.TireTypeParameter;

namespace Workshop.API.Application.Validations.TireTypeValidator
{
    public class UpdateTireTypeCommandValidator : AbstractValidator<UpdateTireTypeCommand>
    {
        public UpdateTireTypeCommandValidator(ILogger<UpdateTireTypeCommandValidator> logger)
        {
            RuleFor(command => command.Description).Length(4, 45);

            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
