using FluentValidation;
using Identity.API.Application.Commands.User;
using Identity.API.Resources;
using Microsoft.Extensions.Logging;
using SharedKernel.Exceptions;
using System.Text.RegularExpressions;

namespace Identity.API.Application.Validations
{
    public class CreateUserCommandValidator : AbstractValidator<CreatetUserCommand>
    {
        public CreateUserCommandValidator(ILogger<CreateUserCommandValidator> logger)
        {
            RuleFor(command => command.UserName).NotEmpty().Length(6, 55);
            RuleFor(command => command.Email).Must(ContainValidEmail).WithMessage(Messages.exception_FormatEmailNotValid).Length(1, 55);
            RuleFor(command => command.Password).Must(ContainValidValues).WithMessage(Messages.exception_PasswordNotValid);

            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }

        private bool ContainValidValues(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new BusinessRuleBrokenException(Messages.exception_PasswordNotNull);
            }

            var _pattern = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$");

            if (_pattern.IsMatch(password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ContainValidEmail(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new BusinessRuleBrokenException(Messages.exception_EmailNotNull);
            }

            bool isEmail = Regex.IsMatch(value, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);

            return isEmail;
        }
    }
}
