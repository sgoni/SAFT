using Identity.API.Resources;
using Identity.Domain.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedKernel.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.API.Application.Commands.AspnetUser
{
    public class UpdateAspNetUserCommandHandler : IRequestHandler<UpdateAspNetUserCommand, bool>
    {
        private readonly IAspNetUserRepository _aspnetUserRepository;
        private readonly ILogger<UpdateAspNetUserCommandHandler> _logger;

        public UpdateAspNetUserCommandHandler(IMediator mediator,
            IAspNetUserRepository aspnetUserRepository,
            ILogger<UpdateAspNetUserCommandHandler> logger)
        {
            _aspnetUserRepository = aspnetUserRepository ?? throw new ArgumentNullException(nameof(aspnetUserRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(UpdateAspNetUserCommand request, CancellationToken cancellationToken)
        {
            var _aspNetUser = await _aspnetUserRepository.SingleOrDefaultAsync(u => u.UserName == request.UserName).ConfigureAwait(false);

            if (_aspNetUser == null)
            {
                throw new BusinessRuleBrokenException(Messages.exception_AspNetUserNotFound);
            }

            _logger.LogInformation("----- Updating AspNetUser - AspNetUser: {@AspNetUser}", _aspNetUser);

            _aspnetUserRepository.UpdateEntity(_aspNetUser);

            return await _aspnetUserRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);
        }
    }
}
