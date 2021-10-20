using FluentValidation;
using Microsoft.Extensions.Logging;
using Workshop.API.Application.Commands.BrandParameter;

namespace Workshop.API.Application.Validations.BrandValidator
{
    public class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
    {
        public UpdateBrandCommandValidator(ILogger<UpdateBrandCommandValidator> logger)
        {
            RuleFor(command => command.Name).NotEmpty().Length(4, 45);

            logger.LogTrace("----- INSTANCE UPDATED - {ClassName}", GetType().Name);
        }
    }
}
