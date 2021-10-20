using Customer.Api.Application.Commands.Banking;
using Customer.Api.Application.Queries.Banking;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Customer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankingController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IBankingQueries _bankQueries;
        private readonly ILogger<BankingController> _logger;

        public BankingController(
            IMediator mediator,
            IBankingQueries bankQueries,
            ILogger<BankingController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _bankQueries = bankQueries ?? throw new ArgumentNullException(nameof(bankQueries));
        }

        [HttpGet]
        [Route("GetBankListsAsync")]
        [ProducesResponseType(typeof(BankingViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetBankListsAsync()
        {
            try
            {
                var banks = await _bankQueries.GetBankListAsync();
                return Ok(banks);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("GetBankByIdAsync/{bankId:int}")]
        [ProducesResponseType(typeof(BankingViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetBankByIdAsync(int bankId)
        {
            try
            {
                var banks = await _bankQueries.GetBankByIdAsync(bankId);
                return Ok(banks);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<bool>> CreateBankAsync([FromBody] CreateBankCommand createBankCommand)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                "CreateCountryCommand.GetGenericTypeName()",
                nameof(createBankCommand.BankName),
                createBankCommand.BankName,
                createBankCommand);

            return await _mediator.Send(new CreateBankCommand(createBankCommand.BankName,
                createBankCommand.Description, createBankCommand.Phone));
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<bool>> UpdateBankAsync([FromBody] UpdateBankCommand updateBankCommand)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                "CreateCountryCommand.GetGenericTypeName()",
                nameof(updateBankCommand.BankName),
                updateBankCommand.BankName,
                updateBankCommand);

            return await _mediator.Send(new UpdateBankCommand(updateBankCommand.Id, updateBankCommand.BankName,
                updateBankCommand.Description, updateBankCommand.Phone));
        }
    }
}
