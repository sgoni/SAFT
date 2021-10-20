using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Workshop.Damain.AggregatesModel.ParameterAggregate;

namespace Workshop.API.Application.Commands.ModelParameter
{
    public class CreateModelCommandHandler
        : IRequestHandler<CreateModelCommand, bool>
    {
        private readonly IModelRepository _modelRepository;
        private readonly ILogger<CreateModelCommandHandler> _logger;

        public CreateModelCommandHandler(IMediator mediator,
            IModelRepository modelRepository,
            ILogger<CreateModelCommandHandler> logger)
        {
            _modelRepository = modelRepository ?? throw new ArgumentNullException(nameof(modelRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(CreateModelCommand request, CancellationToken cancellationToken)
        {
            var _model = new Model(request.Description);

            _logger.LogInformation("----- Creating Model - Model: {@Model}", _model);

            _modelRepository.AddEntity(_model);

            return await _modelRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);
        }
    }
}
