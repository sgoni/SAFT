using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;
using Workshop.API.Application.Commands.BodyworkParameter;
using Workshop.API.Application.Queries.BodyWorkType;

namespace Workshop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BodyWorkController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IBodyWorkTypeQueries _bodyWorkQueries;
        private readonly ILogger<BodyWorkController> _logger;

        public BodyWorkController(
            IMediator mediator,
            IBodyWorkTypeQueries bodyWorkQueries,
            ILogger<BodyWorkController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _bodyWorkQueries = bodyWorkQueries ?? throw new ArgumentNullException(nameof(bodyWorkQueries));
        }

        [HttpGet]
        [Route("GetBodyWorkListsAsync")]
        [ProducesResponseType(typeof(BodyWorkViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetBodyWorkListsAsync()
        {
            try
            {
                var brands = await _bodyWorkQueries.GetBodyWorkListAsync();
                return Ok(brands);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("GetBodyWorkByIdAsync/{id:int}")]
        [ProducesResponseType(typeof(BodyWorkViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetBodyWorkByIdAsync(int id)
        {
            try
            {
                var banks = await _bodyWorkQueries.GetBodyWorkByIdAsync(id);
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
        public async Task<ActionResult<bool>> CreateBodyWorkAsync([FromBody] CreateBodyWorkCommand createBodyWorkCommand)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                "CreateBodyWorkCommand.GetGenericTypeName()",
                nameof(createBodyWorkCommand.Description),
                createBodyWorkCommand.Description,
                createBodyWorkCommand);

            return await _mediator.Send(new CreateBodyWorkCommand(createBodyWorkCommand.Description));
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<bool>> UpdateBodyWorkdAsync([FromBody] UpdateBodyWorkCommand updateBodyworkCommand)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                "UpdateBrandCommand.GetGenericTypeName()",
                nameof(updateBodyworkCommand.Description),
                updateBodyworkCommand.Description,
                updateBodyworkCommand);

            return await _mediator.Send(new UpdateBodyWorkCommand(updateBodyworkCommand.Id, updateBodyworkCommand.Description));
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<bool>> DeleteBodyWorkAsync([FromBody] DeleteBodyWorkCommand deleteBodyWorkCommand)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                "DeleteBrandCommand.GetGenericTypeName()",
                nameof(deleteBodyWorkCommand.Id),
                deleteBodyWorkCommand.Id,
                deleteBodyWorkCommand);

            return await _mediator.Send(new DeleteBodyWorkCommand(deleteBodyWorkCommand.Id));
        }
    }
}