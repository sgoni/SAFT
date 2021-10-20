using Identity.Domain.AggregatesModel;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.API.Application.Commands.AspnetUser
{
    public class CreateAspNetUserCommandHandler : IRequestHandler<CreateAspNetUserCommand, bool>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger<CreateAspNetUserCommandHandler> _logger;
        private readonly IMediator _mediator;

        public CreateAspNetUserCommandHandler(IMediator mediator,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<CreateAspNetUserCommandHandler> logger)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(CreateAspNetUserCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser { UserName = request.Email, Email = request.Email };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                _logger.LogInformation("----- Creating user - user: {@user}", user);

                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            }

            //return await _aspnetUserRepository.UnitOfWork
            //    .SaveEntitiesAsync(cancellationToken);

            return true;
        }
    }
}
