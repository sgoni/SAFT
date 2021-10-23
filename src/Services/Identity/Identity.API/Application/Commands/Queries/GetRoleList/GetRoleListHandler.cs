using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.API.Application.Commands.Queries.GetRoleList
{
    public class GetRoleListHandler
        : IRequestHandler<GetRoleListQuerie, IQueryable<IdentityRole>>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<GetRoleListHandler> _logger;
        private readonly IMediator _mediator;

        public GetRoleListHandler(
            RoleManager<IdentityRole> roleManager,
            IMediator mediator,
            ILogger<GetRoleListHandler> logger)
        {
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IQueryable<IdentityRole>> Handle(GetRoleListQuerie request, CancellationToken cancellationToken)
        {
            var roles = _roleManager.Roles;
            return roles;
        }
    }
}
