using System.Collections.Generic;
using System.Threading.Tasks;

namespace Workshop.API.Application.Queries.TireType
{
    public interface ITireTypeQueries
    {
        Task<IEnumerable<TireTypeViewModel>> GetTireTypeListAsync();

        Task<TireTypeViewModel> GetTireTypeByIdAsync(int id);
    }
}
