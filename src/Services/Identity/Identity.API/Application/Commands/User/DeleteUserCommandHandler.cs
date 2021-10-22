using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.API.Application.Commands.User
{
    public class DeleteUserCommandHandler
        : IRequestHandler<DeleteUserCommand, IdentityResult>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<DeleteUserCommandHandler> _logger;
        private readonly IMediator _mediator;

        public DeleteUserCommandHandler(
            UserManager<IdentityUser> userManager,
            IMediator mediator,
            ILogger<DeleteUserCommandHandler> logger)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IdentityResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);

            if (user == null)
            {
                return null;
            }

            return await _userManager.DeleteAsync(user);
        }
    }
}
