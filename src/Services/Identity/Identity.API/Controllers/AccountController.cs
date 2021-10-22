using Identity.API.Application.Commands.User;
using Identity.API.Infrastructure.Auth;
using Identity.API.Models;
using Identity.API.Resources;
using Identity.Domain.AggregatesModel;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Identity.API.Infrastructure.Auth;

namespace Identity.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMediator _mediator;
        private readonly ILogger<AccountController> _logger;

        public AccountController(
            IMediator mediator,
            ILogger<AccountController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        //[HttpPost]
        //[AllowAnonymous]
        //[ProducesResponseType((int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //[Route("RegisterWithConfirmation")]
        //public async Task<ActionResult<bool>> RegisterWithConfirmationAsync([FromBody] CreatetUserCommand createtUserCommand)
        //{
        //    string returnUrl = Url.Content("~/");

        //    _logger.LogInformation(
        //        "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
        //        "CreateCountryCommand.GetGenericTypeName()",
        //        nameof(createtUserCommand.UserName),
        //        createtUserCommand.UserName,
        //        createtUserCommand);

        //    var result = await _mediator.Send(new CreatetUserCommand(createtUserCommand.UserName,
        //        createtUserCommand.Email, createtUserCommand.Password));

        //    if (result.Succeeded)
        //    {
        //        var user = await _userManager.FindByNameAsync(createtUserCommand.UserName);
        //        var code = await _userManager.GenerateEmailConfirmationTokenAsync(new ApplicationUser { UserName = user.UserName, Email = user.Email });
        //        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

        //        var callbackUrl = Url.Page(
        //            "/Account/ConfirmEmail",
        //            pageHandler: null,
        //            values: new { area = "Identity", userId = user.Id, code = code },
        //            protocol: Request.Scheme);

        //        await _emailSender.SendEmailAsync(
        //            createtUserCommand.Email,
        //            "Confirm your email",
        //            $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

        //        //if (_userManager.Options.SignIn.RequireConfirmedAccount)
        //        //{
        //        //    return RedirectToPage("RegisterConfirmation", new { email = user.Email });
        //        //}
        //        //else
        //        //{
        //        //    await _signInManager.SignInAsync(user, isPersistent: false);
        //        //    return LocalRedirect(returnUrl);
        //        //}

        //        return Ok(new { Message = Messages.message_UserRegistrationSuccessful });
        //    }

        //    else
        //    {
        //        var dictionary = new ModelStateDictionary();

        //        foreach (IdentityError error in result.Errors)
        //        {
        //            dictionary.AddModelError(error.Code, error.Description);
        //        }

        //        return new BadRequestObjectResult(new { Message = Messages.message_UserRegistrationFailed, Errors = dictionary });
        //    }
        //}

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Route("Register")]
        public async Task<ActionResult<bool>> RegisterAsync([FromBody] CreatetUserCommand createtUserCommand)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                "CreateCountryCommand.GetGenericTypeName()",
                nameof(createtUserCommand.UserName),
                createtUserCommand.UserName,
                createtUserCommand);

            var result = await _mediator.Send(new CreatetUserCommand(createtUserCommand.UserName,
                createtUserCommand.Email, createtUserCommand.Password));

            if (!result.Succeeded)
            {
                var dictionary = new ModelStateDictionary();
                foreach (IdentityError error in result.Errors)
                {
                    dictionary.AddModelError(error.Code, error.Description);
                }

                return new BadRequestObjectResult(new { Message = Messages.message_UserRegistrationFailed, Errors = dictionary });
            }

            return Ok(new { Message = Messages.message_UserRegistrationSuccessful });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand credentials)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                "CreateCountryCommand.GetGenericTypeName()",
                nameof(credentials.Username),
                credentials.Username,
                credentials);

            var token = await _mediator.Send(new LoginUserCommand(credentials.Username, credentials.Password));

            if (token != null)
            {
                return Ok(new { Token = token, Message = "Success" });
            }
            else
            {
                return new BadRequestObjectResult(new { Message = "Login failed" });
            }
        }

        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            // Well, What do you want to do here ?
            // Wait for token to get expired OR 
            // Maintain token cache and invalidate the tokens after logout method is called
            return Ok(new { Token = "", Message = "Logged Out" });
        }

    }
}
