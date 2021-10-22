using Identity.Domain.AggregatesModel;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.API.Application.Commands.User
{
    public class RemoveUserFromRoleCommandHandler
        : IRequestHandler<RemoveUserFromRoleCommand, IdentityResult>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RemoveUserFromRoleCommandHandler> _logger;
        private readonly IMediator _mediator;

        public RemoveUserFromRoleCommandHandler(
            UserManager<ApplicationUser> userManager,
            IMediator mediator,
            ILogger<RemoveUserFromRoleCommandHandler> logger)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IdentityResult> Handle(RemoveUserFromRoleCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);

            if (user != null)
            {
                return await _userManager.RemoveFromRoleAsync(user, request.RoleName);
            }

            return null;
        }
    }
}
