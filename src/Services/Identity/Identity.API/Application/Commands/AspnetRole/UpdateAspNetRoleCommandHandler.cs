using Identity.API.Resources;
using Identity.Domain.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedKernel.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.API.Application.Commands.AspnetRole
{
    public class UpdateAspNetRoleCommandHandler : IRequestHandler<UpdateAspNetRoleCommand, bool>
    {
        private readonly IAspNetRoleRepository _aspnetRoleRepository;
        private readonly ILogger<UpdateAspNetRoleCommandHandler> _logger;

        public UpdateAspNetRoleCommandHandler(IMediator mediator,
            IAspNetRoleRepository aspnetRoleRepository,
            ILogger<UpdateAspNetRoleCommandHandler> logger)
        {
            _aspnetRoleRepository = aspnetRoleRepository ?? throw new ArgumentNullException(nameof(aspnetRoleRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(UpdateAspNetRoleCommand request, CancellationToken cancellationToken)
        {
            var _aspRoleUser = await _aspnetRoleRepository.SingleOrDefaultAsync(u => u.Id == request.Id).ConfigureAwait(false);

            if (_aspRoleUser == null)
            {
                throw new BusinessRuleBrokenException(Messages.exception_AspNetRoleNotFound);
            }

            _logger.LogInformation("----- Updating AspNetRole - AspNetRole: {@AspNetRole}", _aspRoleUser);

            _aspnetRoleRepository.UpdateEntity(_aspRoleUser);

            return await _aspnetRoleRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);
        }
    }
}
