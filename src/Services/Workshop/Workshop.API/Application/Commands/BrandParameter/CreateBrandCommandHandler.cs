using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Workshop.Damain.AggregatesModel.ParameterAggregate;

namespace Workshop.API.Application.Commands.BrandParameter
{
    public class CreateBrandCommandHandler
        : IRequestHandler<CreateBrandCommand, bool>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly ILogger<CreateBrandCommandHandler> _logger;

        public CreateBrandCommandHandler(IMediator mediator,
            IBrandRepository brandRepository,
            ILogger<CreateBrandCommandHandler> logger)
        {
            _brandRepository = brandRepository ?? throw new ArgumentNullException(nameof(brandRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var _brand = new Brand(request.Name);

            _logger.LogInformation("----- Creating Brand - Brand: {@Brand}", _brand);

            _brandRepository.AddEntity(_brand);

            return await _brandRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);
        }
    }
}
