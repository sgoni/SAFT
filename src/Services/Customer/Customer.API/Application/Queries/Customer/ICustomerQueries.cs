using System.Collections.Generic;
using System.Threading.Tasks;

namespace Customer.API.Application.Queries.Customer
{
    public interface ICustomerQueries
    {
        Task<CustomerViewModel> GetCustomerByDocumentNumberAsync(string documentNumber);
    }
}
