using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Workshop.Damain.AggregatesModel.ParameterAggregate;

namespace Workshop.API.Application.Commands.BodyworkParameter
{
    public class DeleteBodyWorkCommandHandler
        : IRequestHandler<DeleteBodyWorkCommand, bool>
    {
        private readonly IBodyWorkTypeRepository _bodyWorkTypeRepository;
        private readonly ILogger<DeleteBodyWorkCommandHandler> _logger;

        public DeleteBodyWorkCommandHandler(IMediator mediator,
            IBodyWorkTypeRepository bodyWorkTypeRepository,
            ILogger<DeleteBodyWorkCommandHandler> logger)
        {
            _bodyWorkTypeRepository = bodyWorkTypeRepository ?? throw new ArgumentNullException(nameof(bodyWorkTypeRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(DeleteBodyWorkCommand request, CancellationToken cancellationToken)
        {
            var _bodyWorkType = await _bodyWorkTypeRepository.SingleOrDefaultAsync(b => b.Id == request.Id).ConfigureAwait(false);

            _logger.LogInformation("----- Deleting BodyWorkType - BodyWorkType: {@BodyWorkType}", _bodyWorkType);

            _bodyWorkTypeRepository.RemoveEntity(_bodyWorkType);

            return await _bodyWorkTypeRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);
        }
    }
}
