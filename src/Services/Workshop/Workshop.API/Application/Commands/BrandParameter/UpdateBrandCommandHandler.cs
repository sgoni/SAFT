using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Workshop.Damain.AggregatesModel.ParameterAggregate;

namespace Workshop.API.Application.Commands.BrandParameter
{
    public class UpdateBrandCommandHandler
         : IRequestHandler<UpdateBrandCommand, bool>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly ILogger<UpdateBrandCommand> _logger;

        public UpdateBrandCommandHandler(IMediator mediator,
            IBrandRepository brandRepository,
            ILogger<UpdateBrandCommand> logger)
        {
            _brandRepository = brandRepository ?? throw new ArgumentNullException(nameof(brandRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var _brand = await _brandRepository.SingleOrDefaultAsync(b => b.Id == request.Id).ConfigureAwait(false);
            _brand.SetName(request.Name);

            _logger.LogInformation("----- Updating Brand - Brand: {@Brand}", _brand);

            _brandRepository.UpdateEntity(_brand);

            return await _brandRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);
        }
    }
}
