using System.Collections.Generic;
using System.Threading.Tasks;

namespace Customer.Api.Application.Queries.Banking
{
    public interface IBankingQueries
    {
        Task<IEnumerable<BankingViewModel>> GetBankListAsync();

        Task<BankingViewModel> GetBankByIdAsync(int bankId);
    }
}
