using Customer.API.Application.Commands.Customer;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Customer.API.Application.Validations
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator(ILogger<CreateCustomerCommandValidator> logger)
        {
            RuleFor(command => command.DocumentNumber).NotEmpty().Length(5, 12);
            RuleFor(command => command.DocumentType).Must(ContainValidValues).NotEmpty().Length(1);
            RuleFor(command => command.FirstName).NotEmpty().Length(3, 45);
            RuleFor(command => command.LastName).NotEmpty().Length(3, 45);
            RuleFor(command => command.BussinesName).Length(0, 75);
            RuleFor(command => command.Email).EmailAddress().Length(0, 45);
            RuleFor(command => command.MainPhone).NotEmpty().Length(0, 8);
            RuleFor(command => command.CellPhone).Length(0, 8);
            RuleFor(command => command.OtherPhone).Length(0, 8);

            // Address
            RuleFor(command => command.AddressCustomerDTO.Street).Length(0, 300);
            RuleFor(command => command.AddressCustomerDTO.ZipCode).Length(0, 100);
            RuleFor(command => command.AddressCustomerDTO.Longitude).NotEmpty().Length(0, 150);
            RuleFor(command => command.AddressCustomerDTO.Latitude).Length(0, 150);

            // Payment method
            RuleFor(command => command.PaymentMethodCustomerDTO).Must(ContainItems).WithMessage("No methods payment items found");

            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }

        private bool ContainValidValues(string value)
        {
            bool ret = false;

            if (value == "C" || value == "P" || value == "D" || value == "J" || value == "D")
            {
                ret = true;
            }

            return ret;
        }

        private bool ContainItems(List<PaymentMethodCustomerDTO> Items)
        {
            return Items.Any();
        }
    }
}
