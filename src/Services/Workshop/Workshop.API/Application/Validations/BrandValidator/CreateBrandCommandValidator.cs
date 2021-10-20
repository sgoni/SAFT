using FluentValidation;
using Microsoft.Extensions.Logging;
using Workshop.API.Application.Commands.BrandParameter;

namespace Workshop.API.Application.Validations.BrandValidator
{
    public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
    {
        public CreateBrandCommandValidator(ILogger<CreateBrandCommandValidator> logger)
        {
            RuleFor(command => command.Name).NotEmpty().Length(4, 45);

            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
