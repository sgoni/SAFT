using SharedKernel.SeedWork;
using Workshop.Damain.AggregatesModel.ParameterAggregate;

namespace Workshop.Infrastructure.Repositories
{
    public class ModelRepository : Repository<Model>, IModelRepository
    {
        public ModelRepository(WorkshopDBContext context) : base(context) { }

        public WorkshopDBContext WorkshopDBContext
        {
            get { return _context as WorkshopDBContext; }
        }
    }
}
