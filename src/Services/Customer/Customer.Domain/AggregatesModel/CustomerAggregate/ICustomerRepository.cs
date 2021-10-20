using SharedKernel.SeedWork;
using System.Threading.Tasks;

namespace Customer.Domain.AggregatesModel.CustomerAggregate
{
    public interface ICustomerRepository : IRepository<Client>
    {
        Task<Client> GetCustomerAggregateEntity(string documentNumber);
    }
}
