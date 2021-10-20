using System.Collections.Generic;
using System.Threading.Tasks;

namespace Workshop.API.Application.Queries.Brand
{
    public interface IBrandQueries
    {
        Task<IEnumerable<BrandViewModel>> GeBrandListAsync();

        Task<BrandViewModel> GetBrandByIdAsync(int id);
    }
}
