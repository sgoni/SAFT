using Customer.Domain.AggregatesModel.CustomerAggregate;
using Microsoft.EntityFrameworkCore;
using SharedKernel.SeedWork;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Infrastructure.Repositories
{
    public class CustomerRepository : Repository<Client>, ICustomerRepository
    {
        public CustomerRepository(CustomerDBContext context) : base(context) { }

        public CustomerDBContext CustomerContext
        {
            get { return _context as CustomerDBContext; }
        }

        public async Task<Client> GetCustomerAggregateEntity(string documentNumber)
        {
            return await CustomerContext.Clients
                .Where(p => p.DocumentNumber == documentNumber)
                .Include(p => p.Address)
                .Include(p => p.PaymentMethodItems)
                .SingleOrDefaultAsync();
        }
    }
}