using Customer.Domain.AggregatesModel.BankingAggregate;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Api.Application.Commands.Banking
{
    public class CreateBankCommandHandler
        : IRequestHandler<CreateBankCommand, bool>
    {
        private readonly IBankingRepository _bankRepository;
        private readonly ILogger<CreateBankCommandHandler> _logger;

        public CreateBankCommandHandler(IMediator mediator,
            IBankingRepository bankRepository,
            ILogger<CreateBankCommandHandler> logger)
        {
            _bankRepository = bankRepository ?? throw new ArgumentNullException(nameof(bankRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(CreateBankCommand request, CancellationToken cancellationToken)
        {
            var _bank = new Bank(request.BankName, request.Description, request.Phone);

            _logger.LogInformation("----- Creating Bank - Bank: {@Bank}", _bank);

            _bankRepository.AddEntity(_bank);

            return await _bankRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);
        }
    }
}
