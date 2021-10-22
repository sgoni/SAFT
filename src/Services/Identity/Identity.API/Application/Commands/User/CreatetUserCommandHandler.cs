using Identity.Domain.AggregatesModel;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.API.Application.Commands.User
{
    public class CreatetUserCommandHandler 
        : IRequestHandler<CreatetUserCommand, IdentityResult>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<CreatetUserCommandHandler> _logger;
        private readonly IMediator _mediator;

        public CreatetUserCommandHandler(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IMediator mediator,
            ILogger<CreatetUserCommandHandler> logger)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IdentityResult> Handle(CreatetUserCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser { UserName = request.Email, Email = request.Email };
            return  await _userManager.CreateAsync(user, request.Password);
        }
    }
}
