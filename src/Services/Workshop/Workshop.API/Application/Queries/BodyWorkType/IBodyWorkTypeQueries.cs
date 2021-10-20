using System.Collections.Generic;
using System.Threading.Tasks;

namespace Workshop.API.Application.Queries.BodyWorkType
{
    public interface IBodyWorkTypeQueries
    {
        Task<IEnumerable<BodyWorkViewModel>> GetBodyWorkListAsync();

        Task<BodyWorkViewModel> GetBodyWorkByIdAsync(int id);
    }
}
