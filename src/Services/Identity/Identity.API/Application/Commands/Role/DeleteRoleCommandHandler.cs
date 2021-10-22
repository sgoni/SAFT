using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.API.Application.Commands.Role
{
    public class DeleteRoleCommandHandler :
        IRequestHandler<DeleteRoleCommand, IdentityResult>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<CreateRoleCommandHandler> _logger;
        private readonly IMediator _mediator;

        public DeleteRoleCommandHandler(
            RoleManager<IdentityRole> roleManager,
            IMediator mediator,
            ILogger<CreateRoleCommandHandler> logger)
        {
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IdentityResult> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(request.Id);

            if (role == null)
            {
                return null;
            }

            return await _roleManager.DeleteAsync(role);
        }
    }
}
