using Identity.API.Application.Commands.Queries.GetRoleList;
using Identity.API.Application.Commands.Queries.GetUsersInRole;
using Identity.API.Application.Commands.Role;
using Identity.API.Application.Commands.User;
using Identity.API.Resources;
using Identity.Domain.AggregatesModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Identity.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ManagerController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AccountController> _logger;

        public ManagerController(
            IMediator mediator,
            ILogger<AccountController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        #region Role Manager

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Route("Create")]
        public async Task<ActionResult<bool>> CreateRoleAsync([FromBody] CreateRoleCommand createRoleCommand)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                "CreateRoleCommand.GetGenericTypeName()",
                nameof(createRoleCommand.Name),
                createRoleCommand.Name,
                createRoleCommand);

            var result = await _mediator.Send(new CreateRoleCommand(createRoleCommand.Name));

            if (!result.Succeeded)
            {
                var dictionary = new ModelStateDictionary();

                foreach (IdentityError error in result.Errors)
                {
                    dictionary.AddModelError(error.Code, error.Description);
                }

                return new BadRequestObjectResult(new { Message = Messages.exception_RoleRegistrationFailed, Errors = dictionary });
            }

            return Ok(new { Message = Messages.message_RoleRegistrationSuccessful });
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [Route("Delete")]
        public async Task<ActionResult<bool>> DeleteRoleAsync([FromBody] DeleteRoleCommand deleteRoleCommand)
        {
            {
                _logger.LogInformation(
                    "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                    "DeleteRoleCommand.GetGenericTypeName()",
                    nameof(deleteRoleCommand.Id),
                    deleteRoleCommand.Id,
                    deleteRoleCommand);

                var result = await _mediator.Send(new DeleteRoleCommand(deleteRoleCommand.Id));

                if (result == null)
                {
                    return new BadRequestObjectResult(new { Message = Messages.exception_BadRequest, Errors = "" });
                }

                if (!result.Succeeded)
                {
                    var dictionary = new ModelStateDictionary();

                    foreach (IdentityError error in result.Errors)
                    {
                        dictionary.AddModelError(error.Code, error.Description);
                    }

                    return new BadRequestObjectResult(new { Message = Messages.exception_RoleDeleteFailed, Errors = dictionary });
                }

                return Ok(new { Message = Messages.message_RoleDeleteSuccessful });
            }
        }

        #endregion

        #region User Manager

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [Route("AddUserToRole")]
        public async Task<ActionResult<bool>> AddUserToRole([FromBody] AddUserToRoleCommand addUserToRoleCommand)
        {
            {
                _logger.LogInformation(
                    "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                    "AddUserToRoleCommand.GetGenericTypeName()",
                    nameof(addUserToRoleCommand.UserId),
                    addUserToRoleCommand.UserId,
                    addUserToRoleCommand);

                var result = await _mediator.Send(new AddUserToRoleCommand(addUserToRoleCommand.UserId, addUserToRoleCommand.RoleName));

                if (result == null)
                {
                    return new BadRequestObjectResult(new { Message = Messages.exception_BadRequest, Errors = "" });
                }

                if (!result.Succeeded)
                {
                    var dictionary = new ModelStateDictionary();

                    foreach (IdentityError error in result.Errors)
                    {
                        dictionary.AddModelError(error.Code, error.Description);
                    }

                    return new BadRequestObjectResult(new { Message = Messages.exception_BadRequest, Errors = dictionary });
                }

                return Ok(new { Message = Messages.message_UserAsignedToRoleSuccessful });
            }
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [Route("DeleteUser")]
        public async Task<ActionResult<bool>> DeleteUser([FromBody] DeleteUserCommand deleteUserCommand)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                "DeleteUserCommand.GetGenericTypeName()",
                nameof(deleteUserCommand.Id),
                deleteUserCommand.Id,
                deleteUserCommand);

            var result = await _mediator.Send(new DeleteUserCommand(deleteUserCommand.Id));

            if (result == null)
            {
                return new BadRequestObjectResult(new { Message = Messages.exception_BadRequest, Errors = "" });
            }

            if (!result.Succeeded)
            {
                var dictionary = new ModelStateDictionary();

                foreach (IdentityError error in result.Errors)
                {
                    dictionary.AddModelError(error.Code, error.Description);
                }

                return new BadRequestObjectResult(new { Message = Messages.exception_BadRequest, Errors = dictionary });
            }

            return Ok(new { Message = Messages.message_UserDeleteSuccessful });
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [Route("RemoveUserFromRole")]
        public async Task<ActionResult<bool>> RemoveUserFromRole([FromBody] RemoveUserFromRoleCommand removeUserToRoleCommand)
        {
            {
                _logger.LogInformation(
                    "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                    "RemoveUserFromRoleCommand.GetGenericTypeName()",
                    nameof(removeUserToRoleCommand.UserId),
                    removeUserToRoleCommand.UserId,
                    removeUserToRoleCommand);

                var result = await _mediator.Send(new RemoveUserFromRoleCommand(removeUserToRoleCommand.UserId, removeUserToRoleCommand.RoleName));

                if (result == null)
                {
                    return new BadRequestObjectResult(new { Message = Messages.exception_BadRequest, Errors = "" });
                }

                if (!result.Succeeded)
                {
                    var dictionary = new ModelStateDictionary();

                    foreach (IdentityError error in result.Errors)
                    {
                        dictionary.AddModelError(error.Code, error.Description);
                    }

                    return new BadRequestObjectResult(new { Message = Messages.exception_BadRequest, Errors = dictionary });
                }

                return Ok(new { Message = Messages.message_UserRemoveFromRoleSuccessful });
            }
        }

        [HttpGet]
        [Route("GetUsersInRoleList/{roleName}")]
        [ProducesResponseType(typeof(ApplicationUser), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IList<ApplicationUser>> GetUsersInRoleListAsync(string roleName)
        {
            return await _mediator.Send(new GetUsersInRoleListQuerie(roleName));
        }

        [HttpGet]
        [Route("GetRoleList")]
        [ProducesResponseType(typeof(ApplicationUser), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IQueryable<IdentityRole>> GetRoleListAsync()
        {
            return await _mediator.Send(new GetRoleListQuerie());
        }

        #endregion
    }
}
