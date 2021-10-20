using Customer.API.Resources;
using Customer.Domain.AggregatesModel.BankingAggregate;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Api.Application.Commands.Banking
{
    public class UpdateBankCommandHandler
         : IRequestHandler<UpdateBankCommand, bool>
    {
        private readonly IBankingRepository _bankRepository;
        private readonly ILogger<UpdateBankCommand> _logger;

        public UpdateBankCommandHandler(IMediator mediator,
            IBankingRepository bankRepository,
            ILogger<UpdateBankCommand> logger)
        {
            _bankRepository = bankRepository ?? throw new ArgumentNullException(nameof(bankRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(UpdateBankCommand request, CancellationToken cancellationToken)
        {
            var _bank = await _bankRepository.SingleOrDefaultAsync(b => b.Id == request.Id).ConfigureAwait(false);

            if (_bank == null)
            {
                throw new Exception(Messages.exception_BankNotFound);
            }

            _bank.SetDescription(request.Description);
            _bank.SetName(request.BankName);
            _bank.SetPhone(request.Phone);

            _logger.LogInformation("----- Updating Bank - Bank: {@Bank}", _bank);

            _bankRepository.UpdateEntity(_bank);

            return await _bankRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);
        }
    }
}
