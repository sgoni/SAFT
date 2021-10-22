using Customer.API.Application.Commands.Customer;
using Customer.API.Application.Queries;
using Customer.API.Application.Queries.Customer;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Customer.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerQueries _customerQueries;

        public CustomerController(
            IMediator mediator,
            ICustomerQueries customerQueries,
            ILogger<CustomerController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _customerQueries = customerQueries ?? throw new ArgumentNullException(nameof(customerQueries));
        }

        [HttpGet]
        [Route("{documentNumber}")]
        [Authorize]
        [ProducesResponseType(typeof(CustomerViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetCustomerByDocumentNumberAsync(string documentNumber)
        {
            try
            {
                var customer = await _customerQueries.GetCustomerByDocumentNumberAsync(documentNumber);
                return Ok(customer);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Authorize(Policy = "WriteAccess")]
        public async Task<ActionResult<bool>> CreateCustomerAsync([FromBody] CreateCustomerCommand createCustomerCommand)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                "CreateCustomerCommand.GetGenericTypeName()",
                nameof(createCustomerCommand.DocumentNumber),
                createCustomerCommand.DocumentNumber,
                createCustomerCommand);

            return await _mediator.Send(new CreateCustomerCommand(createCustomerCommand.DocumentNumber, 
                createCustomerCommand.DocumentType, 
                createCustomerCommand.FirstName,
                createCustomerCommand.LastName, 
                createCustomerCommand.BussinesName, 
                createCustomerCommand.Email, 
                createCustomerCommand.MainPhone,
                createCustomerCommand.CellPhone,
                createCustomerCommand.OtherPhone, 
                true, 
                createCustomerCommand.AddressCustomerDTO, 
                createCustomerCommand.PaymentMethodCustomerDTO));
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [Authorize(Policy = "WriteAccess")]
        public async Task<ActionResult<bool>> UpdateCustomerAsync([FromBody] CreateCustomerCommand updateCustomerCommand)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                "CreateCustomerCommand.GetGenericTypeName()",
                nameof(updateCustomerCommand.DocumentNumber),
                updateCustomerCommand.DocumentNumber,
                updateCustomerCommand);

            return await _mediator.Send(new UpdateCustomerCommand(updateCustomerCommand.DocumentNumber, 
                updateCustomerCommand.DocumentType, 
                updateCustomerCommand.FirstName, 
                updateCustomerCommand.LastName, 
                updateCustomerCommand.BussinesName, 
                updateCustomerCommand.Email, 
                updateCustomerCommand.MainPhone, 
                updateCustomerCommand.CellPhone, 
                updateCustomerCommand.OtherPhone, 
                updateCustomerCommand.IsActive, 
                updateCustomerCommand.AddressCustomerDTO, 
                updateCustomerCommand.PaymentMethodCustomerDTO));
        }
    }
}
