using SharedKernel.SeedWork;
using Workshop.Damain.AggregatesModel.ParameterAggregate;

namespace Workshop.Infrastructure.Repositories
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(WorkshopDBContext context) : base(context) { }

        public WorkshopDBContext WorkshopContext
        {
            get { return _context as WorkshopDBContext; }
        }
    }
}
