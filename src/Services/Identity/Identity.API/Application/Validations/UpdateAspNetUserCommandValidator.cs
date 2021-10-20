using FluentValidation;
using Identity.API.Application.Commands.AspnetUser;
using Identity.API.Resources;
using Microsoft.Extensions.Logging;
using SharedKernel.Exceptions;
using System.Text.RegularExpressions;

namespace Identity.API.Application.Validations
{
    public class UpdateAspNetUserCommandValidator : AbstractValidator<UpdateAspNetUserCommand>
    {
        public UpdateAspNetUserCommandValidator(ILogger<UpdateAspNetUserCommandValidator> logger)
        {
            RuleFor(command => command.UserName).NotEmpty().Length(6, 55);
            RuleFor(command => command.Email).NotEmpty().Length(1, 55);
            RuleFor(command => command.Password).Must(ContainValidValues).WithMessage(Messages.exception_PasswordNotValid); ;

            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }

        private bool ContainValidValues(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new BusinessRuleBrokenException("Password should not be empty");
            }

            var _pattern = new Regex(@"((?=.*\d)(?=.*[A - Z])(?=.*\W).{8,16})$");

            if (_pattern.IsMatch(password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}