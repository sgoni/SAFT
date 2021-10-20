using SharedKernel.SeedWork;
using Workshop.Damain.AggregatesModel.ParameterAggregate;

namespace Workshop.Infrastructure.Repositories
{
    public class TireTypeRepository : Repository<TireType>, ITireTypeRepository
    {
        public TireTypeRepository(WorkshopDBContext context) : base(context) { }

        public WorkshopDBContext WorkshopContext
        {
            get { return _context as WorkshopDBContext; }
        }
    }
}
