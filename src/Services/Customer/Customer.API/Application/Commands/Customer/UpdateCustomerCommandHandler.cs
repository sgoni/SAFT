using Customer.API.Resources;
using Customer.Domain.AggregatesModel.CustomerAggregate;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedKernel.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.API.Application.Commands.Customer
{
    public class UpdateCustomerCommandHandler
        : IRequestHandler<UpdateCustomerCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<UpdateCustomerCommandHandler> _logger;

        // Using DI to inject infrastructure persistence Repositories
        public UpdateCustomerCommandHandler(
            ICustomerRepository customerRepository,
            ILogger<UpdateCustomerCommandHandler> logger)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            Client client = await _customerRepository.GetCustomerAggregateEntity(request.DocumentNumber).ConfigureAwait(false);

            if (client == null)
            {
                throw new BaseException(Messages.exception_CustomerNotFound);
            }

            // Add/Update the Customer AggregateRoot
            // DDD patterns comment: Add child entities and value-objects through the Customer Aggregate-Root
            // methods and constructor so validations, invariants and business logic 
            // make sure that consistency is preserved across the whole aggregate
            var address = new Address(request.AddressCustomerDTO.Street,
                request.AddressCustomerDTO.ZipCode,
                request.AddressCustomerDTO.Longitude,
                request.AddressCustomerDTO.Latitude);

            // Set customer header
            client.SetBussinesName(request.BussinesName);
            client.SetCellPhone(request.CellPhone);
            client.SetDocumentNumber(request.DocumentNumber);
            client.SetDocumentType(request.DocumentType);
            client.SetEmail(request.Email);
            client.SetFirstName(request.FirstName);
            client.SetIsActive(request.IsActive);
            client.SetIsLastUpdate(DateTime.Now);
            client.SetLastName(request.LastName);
            client.SetMainPhone(request.MainPhone);
            client.SetOtherPhone(request.OtherPhone);
            client.SetAddress(address);

            foreach (var item in request.PaymentMethodCustomerDTO)
            {
                client.AddMethodPayment(item.CardTypeId,
                    item.CardNumber,
                    item.ExpirationDate,
                    item.BankOwnerId);
            }

            _logger.LogInformation("----- Updating Customer - Customer: {@Client}", client);
            _customerRepository.UpdateEntity(client);

            return await _customerRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
