using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Workshop.Damain.AggregatesModel.ParameterAggregate;

namespace Workshop.API.Application.Commands.BrandParameter
{
    public class DeleteBrandCommandHandler
         : IRequestHandler<DeleteBrandCommand, bool>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly ILogger<DeleteBrandCommand> _logger;

        public DeleteBrandCommandHandler(IMediator mediator,
            IBrandRepository brandRepository,
            ILogger<DeleteBrandCommand> logger)
        {
            _brandRepository = brandRepository ?? throw new ArgumentNullException(nameof(brandRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var _brand = await _brandRepository.SingleOrDefaultAsync(b => b.Id == request.Id).ConfigureAwait(false);

            _logger.LogInformation("----- Deleting Brand - Brand: {@Brand}", _brand);

            _brandRepository.RemoveEntity(_brand);

            return await _brandRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);
        }
    }
}
