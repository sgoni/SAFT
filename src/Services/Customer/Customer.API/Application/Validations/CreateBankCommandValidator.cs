using Customer.Api.Application.Commands.Banking;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace Customer.API.Application.Validations
{
    public class CreateBankCommandValidator : AbstractValidator<CreateBankCommand>
    {
        public CreateBankCommandValidator(ILogger<CreateBankCommandValidator> logger)
        {
            RuleFor(command => command.BankName).NotEmpty().Length(5, 45);
            RuleFor(command => command.Description).Length(0, 150);
            RuleFor(command => command.Phone).Length(0, 8);

            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
