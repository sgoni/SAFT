using Customer.Domain.AggregatesModel.BankingAggregate;
using SharedKernel.SeedWork;

namespace Customer.Infrastructure.Repositories
{
    public class BankingRepository : Repository<Bank>, IBankingRepository
    {
        public BankingRepository(CustomerDBContext context) : base(context) { }

        public CustomerDBContext CustomerContext
        {
            get { return _context as CustomerDBContext; }
        }
    }
}