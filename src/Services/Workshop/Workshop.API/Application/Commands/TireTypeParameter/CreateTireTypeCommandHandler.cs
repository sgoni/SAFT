using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Workshop.Damain.AggregatesModel.ParameterAggregate;

namespace Workshop.API.Application.Commands.TireTypeParameter
{
    public class CreateTireTypeCommandHandler
        : IRequestHandler<CreateTireTypeCommand, bool>
    {
        private readonly ITireTypeRepository _tireTypeRepository;
        private readonly ILogger<CreateTireTypeCommandHandler> _logger;

        public CreateTireTypeCommandHandler(IMediator mediator,
            ITireTypeRepository tireTypeRepository,
            ILogger<CreateTireTypeCommandHandler> logger)
        {
            _tireTypeRepository = tireTypeRepository ?? throw new ArgumentNullException(nameof(tireTypeRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(CreateTireTypeCommand request, CancellationToken cancellationToken)
        {
            var _tireType = new TireType(request.Description);

            _logger.LogInformation("----- Creating TireType - TireType: {@TireType}", _tireType);

            _tireTypeRepository.AddEntity(_tireType);

            return await _tireTypeRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);
        }
    }
}
