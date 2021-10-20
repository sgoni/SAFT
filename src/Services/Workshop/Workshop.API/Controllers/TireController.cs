using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;
using Workshop.API.Application.Queries.TireType;

namespace Workshop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TireController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ITireTypeQueries _tireWorkQueries;
        private readonly ILogger<TireController> _logger;

        public TireController(
            IMediator mediator,
            ITireTypeQueries tireTypeQueries,
            ILogger<TireController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _tireWorkQueries = tireTypeQueries ?? throw new ArgumentNullException(nameof(tireTypeQueries));
        }

        [HttpGet]
        [Route("GetTireTypeListAsync")]
        [ProducesResponseType(typeof(TireTypeViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetTireTypeListAsync()
        {
            try
            {
                var tireTypes = await _tireWorkQueries.GetTireTypeListAsync();
                return Ok(tireTypes);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("GetTireTypeByIdAsync/{id:int}")]
        [ProducesResponseType(typeof(TireTypeViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetTireTypeByIdAsync(int id)
        {
            try
            {
                var tireType = await _tireWorkQueries.GetTireTypeByIdAsync(id);
                return Ok(tireType);
            }
            catch
            {
                return NotFound();
            }
        }

        //[HttpPost]
        //[ProducesResponseType((int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //public async Task<ActionResult<bool>> CreateTireTypeAsync([FromBody] CreateTireTypeCommand createTireTypeCommand)
        //{
        //    _logger.LogInformation(
        //        "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
        //        "CreateTireTypeCommand.GetGenericTypeName()",
        //        nameof(createTireTypeCommand.Description),
        //        createTireTypeCommand.Description,
        //        createTireTypeCommand);

        //    return await _mediator.Send(new CreateTireTypeCommand(createTireTypeCommand.Description));
        //}

        //[HttpPut]
        //[ProducesResponseType((int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //[ProducesResponseType((int)HttpStatusCode.NotFound)]
        //public async Task<ActionResult<bool>> UpdateTireTypeAsync([FromBody] UpdateTireTypeCommand updateTireTypeCommand)
        //{
        //    _logger.LogInformation(
        //        "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
        //        "UpdateBrandCommand.GetGenericTypeName()",
        //        nameof(updateTireTypeCommand.Description),
        //        updateTireTypeCommand.Description,
        //        updateTireTypeCommand);

        //    return await _mediator.Send(new UpdateTireTypeCommand(updateTireTypeCommand.Id, updateTireTypeCommand.Description));
        //}

        //[HttpDelete]
        //[ProducesResponseType((int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //[ProducesResponseType((int)HttpStatusCode.NotFound)]
        //public async Task<ActionResult<bool>> DeleteTireTypeAsync([FromBody] DeleteTireTypeCommand deleteTireTypeCommand)
        //{
        //    _logger.LogInformation(
        //        "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
        //        "DeleteBrandCommand.GetGenericTypeName()",
        //        nameof(deleteTireTypeCommand.Id),
        //        deleteTireTypeCommand.Id,
        //        deleteTireTypeCommand);

        //    return await _mediator.Send(new DeleteTireTypeCommand(deleteTireTypeCommand.Id));
        //}
    }
}
