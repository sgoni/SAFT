using Identity.Domain.AggregatesModel;
using Identity.Domain.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.API.Application.Commands.AspnetRole
{
    public class CreateAspNetRoleCommandHandler : IRequestHandler<CreateAspNetRoleCommand, bool>
    {
        private readonly IAspNetRoleRepository _aspnetRoleRepository;
        private readonly ILogger<CreateAspNetRoleCommandHandler> _logger;

        public CreateAspNetRoleCommandHandler(IMediator mediator,
            IAspNetRoleRepository aspnetRoleRepository,
            ILogger<CreateAspNetRoleCommandHandler> logger)
        {
            _aspnetRoleRepository = aspnetRoleRepository ?? throw new ArgumentNullException(nameof(aspnetRoleRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(CreateAspNetRoleCommand request, CancellationToken cancellationToken)
        {
            var _aspRoleUser = new AspNetRole(request.Name);

            _logger.LogInformation("----- Creating AspNetRole - AspNetRole: {@AspNetRole}", _aspRoleUser);

            _aspnetRoleRepository.AddEntity(_aspRoleUser);

            return await _aspnetRoleRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);
        }
    }
}
