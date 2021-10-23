using Identity.Domain.AggregatesModel;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.API.Application.Commands.Queries.GetUsersInRole
{
    public class GetUsersInRoleListHandler
        : IRequestHandler<GetUsersInRoleListQuerie, IList<ApplicationUser>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<GetUsersInRoleListHandler> _logger;
        private readonly IMediator _mediator;

        public GetUsersInRoleListHandler(
             UserManager<ApplicationUser> userManager,
             IMediator mediator,
             ILogger<GetUsersInRoleListHandler> logger)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IList<ApplicationUser>> Handle(GetUsersInRoleListQuerie request, CancellationToken cancellationToken)
        {
            return await _userManager.GetUsersInRoleAsync(request.roleName);
        }
    }
}
