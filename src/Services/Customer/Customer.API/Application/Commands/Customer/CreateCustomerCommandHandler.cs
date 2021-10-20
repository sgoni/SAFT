using Customer.Domain.AggregatesModel.CustomerAggregate;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.API.Application.Commands.Customer
{
    public class CreateCustomerCommandHandler
        : IRequestHandler<CreateCustomerCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<CreateCustomerCommandHandler> _logger;

        // Using DI to inject infrastructure persistence Repositories
        public CreateCustomerCommandHandler(
            ICustomerRepository customerRepository,
            ILogger<CreateCustomerCommandHandler> logger)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            // Add/Update the Customer AggregateRoot
            // DDD patterns comment: Add child entities and value-objects through the Customer Aggregate-Root
            // methods and constructor so validations, invariants and business logic 
            // make sure that consistency is preserved across the whole aggregate
            var address = new Address(request.AddressCustomerDTO.Street,
                request.AddressCustomerDTO.ZipCode,
                request.AddressCustomerDTO.Longitude,
                request.AddressCustomerDTO.Latitude);

            var client = new Client(request.DocumentNumber, request.DocumentType, request.FirstName, request.LastName, request.BussinesName, request.MainPhone, request.CellPhone, request.OtherPhone, request.Email, request.IsActive, address);

            foreach (var item in request.PaymentMethodCustomerDTO)
            {
                client.AddMethodPayment(item.CardTypeId,
                    item.CardNumber,
                    item.ExpirationDate,
                    item.BankOwnerId);
            }

            _logger.LogInformation("----- Creating Customer - Customer: {@Client}", client);

            _customerRepository.AddEntity(client);

            return await _customerRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
