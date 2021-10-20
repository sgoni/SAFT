using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Workshop.Damain.AggregatesModel.ParameterAggregate;

namespace Workshop.API.Application.Commands.BodyworkParameter
{
    public class UpdateBodyWorkCommandHandler
        : IRequestHandler<UpdateBodyWorkCommand, bool>
    {
        private readonly IBodyWorkTypeRepository _bodyWorkTypeRepository;
        private readonly ILogger<UpdateBodyWorkCommandHandler> _logger;

        public UpdateBodyWorkCommandHandler(IMediator mediator,
            IBodyWorkTypeRepository bodyWorkTypeRepository,
            ILogger<UpdateBodyWorkCommandHandler> logger)
        {
            _bodyWorkTypeRepository = bodyWorkTypeRepository ?? throw new ArgumentNullException(nameof(bodyWorkTypeRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(UpdateBodyWorkCommand request, CancellationToken cancellationToken)
        {
            var _bodyWorkType = await _bodyWorkTypeRepository.SingleOrDefaultAsync(b => b.Id == request.Id).ConfigureAwait(false);
            _bodyWorkType.SetDescription(request.Description);

            _logger.LogInformation("----- Updating BodyWorkType - BodyWorkType: {@BodyWorkType}", _bodyWorkType);

            _bodyWorkTypeRepository.UpdateEntity(_bodyWorkType);

            return await _bodyWorkTypeRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);
        }
    }
}
