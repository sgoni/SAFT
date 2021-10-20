using FluentValidation;
using Microsoft.Extensions.Logging;
using Workshop.API.Application.Commands.ModelParameter;

namespace Workshop.API.Application.Validations.ModelValidator
{
    public class CreateModelCommandValidator : AbstractValidator<CreateModelCommand>
    {
        public CreateModelCommandValidator(ILogger<CreateModelCommandValidator> logger)
        {
            RuleFor(command => command.Description).Length(4, 45);

            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
