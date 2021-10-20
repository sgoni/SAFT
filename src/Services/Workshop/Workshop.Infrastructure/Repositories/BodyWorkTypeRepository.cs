using SharedKernel.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Damain.AggregatesModel.ParameterAggregate;

namespace Workshop.Infrastructure.Repositories
{
    public class BodyWorkTypeRepository : Repository<BodyWorkType>, IBodyWorkTypeRepository
    {
        public BodyWorkTypeRepository(WorkshopDBContext context) : base(context) { }

        public WorkshopDBContext WorkshopContext
        {
            get { return _context as WorkshopDBContext; }
        }
    }
}
