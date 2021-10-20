using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Workshop.Damain.AggregatesModel.ParameterAggregate;

namespace Workshop.API.Application.Commands.TireTypeParameter
{
    public class DeleteTireTypeCommandHandler
        : IRequestHandler<DeleteTireTypeCommand, bool>
    {
        private readonly ITireTypeRepository _tireTypeRepository;
        private readonly ILogger<DeleteTireTypeCommandHandler> _logger;

        public DeleteTireTypeCommandHandler(IMediator mediator,
            ITireTypeRepository tireTypeRepository,
            ILogger<DeleteTireTypeCommandHandler> logger)
        {
            _tireTypeRepository = tireTypeRepository ?? throw new ArgumentNullException(nameof(tireTypeRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(DeleteTireTypeCommand request, CancellationToken cancellationToken)
        {
            var _tireType = await _tireTypeRepository.SingleOrDefaultAsync(b => b.Id == request.Id).ConfigureAwait(false);

            _logger.LogInformation("----- Deleting TireType - TireType: {@TireType}", _tireType);

            _tireTypeRepository.RemoveEntity(_tireType);

            return await _tireTypeRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);
        }
    }
}
