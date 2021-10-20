using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Workshop.Damain.AggregatesModel.ParameterAggregate;

namespace Workshop.API.Application.Commands.BodyworkParameter
{
    public class CreateBodyWorkCommandHandler
        : IRequestHandler<CreateBodyWorkCommand, bool>
    {
        private readonly IBodyWorkTypeRepository _bodyWorkTypeRepository;
        private readonly ILogger<CreateBodyWorkCommandHandler> _logger;

        public CreateBodyWorkCommandHandler(IMediator mediator,
            IBodyWorkTypeRepository bodyWorkTypeRepository,
            ILogger<CreateBodyWorkCommandHandler> logger)
        {
            _bodyWorkTypeRepository = bodyWorkTypeRepository ?? throw new ArgumentNullException(nameof(bodyWorkTypeRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(CreateBodyWorkCommand request, CancellationToken cancellationToken)
        {
            var _bodyWorkType = new BodyWorkType(request.Description);

            _logger.LogInformation("----- Creating BodyWorkType - BodyWorkType: {@BodyWorkType}", _bodyWorkType);

            _bodyWorkTypeRepository.AddEntity(_bodyWorkType);

            return await _bodyWorkTypeRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);
        }
    }
}
