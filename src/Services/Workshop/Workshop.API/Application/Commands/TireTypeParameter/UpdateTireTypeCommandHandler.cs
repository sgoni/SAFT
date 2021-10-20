using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Workshop.Damain.AggregatesModel.ParameterAggregate;

namespace Workshop.API.Application.Commands.TireTypeParameter
{
    public class UpdateTireTypeCommandHandler
        : IRequestHandler<UpdateTireTypeCommand, bool>
    {
        private readonly ITireTypeRepository _tireTypeRepository;
        private readonly ILogger<UpdateTireTypeCommandHandler> _logger;

        public UpdateTireTypeCommandHandler(IMediator mediator,
            ITireTypeRepository tireTypeRepository,
            ILogger<UpdateTireTypeCommandHandler> logger)
        {
            _tireTypeRepository = tireTypeRepository ?? throw new ArgumentNullException(nameof(tireTypeRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(UpdateTireTypeCommand request, CancellationToken cancellationToken)
        {
            var _tireType = await _tireTypeRepository.SingleOrDefaultAsync(b => b.Id == request.Id).ConfigureAwait(false);
            _tireType.SetDescription(request.Description);

            _logger.LogInformation("----- Updating TireType - TireType: {@TireType}", _tireType);

            _tireTypeRepository.UpdateEntity(_tireType);

            return await _tireTypeRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);
        }       
    }
}
