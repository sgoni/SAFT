using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;
using Workshop.API.Application.Commands.BrandParameter;
using Workshop.API.Application.Queries.Brand;

namespace Workshop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IBrandQueries _brandQueries;
        private readonly ILogger<BrandController> _logger;

        public BrandController(
            IMediator mediator,
            IBrandQueries brandQueries,
            ILogger<BrandController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _brandQueries = brandQueries ?? throw new ArgumentNullException(nameof(brandQueries));
        }

        [HttpGet]
        [Route("GetBrandsAsync")]
        [ProducesResponseType(typeof(BrandViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetBankListsAsync()
        {
            try
            {
                var brands = await _brandQueries.GeBrandListAsync();
                return Ok(brands);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("GetBrandByIdAsync/{id:int}")]
        [ProducesResponseType(typeof(BrandViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetBrandByIdAsync(int id)
        {
            try
            {
                var banks = await _brandQueries.GetBrandByIdAsync(id);
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
        public async Task<ActionResult<bool>> CreateBrandAsync([FromBody] CreateBrandCommand createBrandCommand)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                "CreateBrandCommand.GetGenericTypeName()",
                nameof(createBrandCommand.Name),
                createBrandCommand.Name,
                createBrandCommand);

            return await _mediator.Send(new CreateBrandCommand(createBrandCommand.Name));
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<bool>> UpdateBrandAsync([FromBody] UpdateBrandCommand updateBrandCommand)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                "UpdateBrandCommand.GetGenericTypeName()",
                nameof(updateBrandCommand.Name),
                updateBrandCommand.Name,
                updateBrandCommand);

            return await _mediator.Send(new UpdateBrandCommand(updateBrandCommand.Id, updateBrandCommand.Name));
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<bool>> DeleteBrandAsync([FromBody] DeleteBrandCommand deleteBrandCommand)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                "DeleteBrandCommand.GetGenericTypeName()",
                nameof(deleteBrandCommand.Id),
                deleteBrandCommand.Id,
                deleteBrandCommand);

            return await _mediator.Send(new DeleteBrandCommand(deleteBrandCommand.Id));
        }
    }
}
