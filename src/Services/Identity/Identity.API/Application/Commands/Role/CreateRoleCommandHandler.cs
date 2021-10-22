using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.API.Application.Commands.Role
{
    public class CreateRoleCommandHandler :
        IRequestHandler<CreateRoleCommand, IdentityResult>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<CreateRoleCommandHandler> _logger;
        private readonly IMediator _mediator;

        public CreateRoleCommandHandler(
            RoleManager<IdentityRole> roleManager,
            IMediator mediator,
            ILogger<CreateRoleCommandHandler> logger)
        {
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IdentityResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = new IdentityRole(request.Name);
            return await _roleManager.CreateAsync(role);
        }
    }
}
