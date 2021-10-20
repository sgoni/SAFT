using SharedKernel.SeedWork;
using System.Collections.Generic;

namespace Workshop.Domain.AggregatesModel.VehiclesAggregate
{
    public class Suspension : ValueObject
    {
        public int FrontSuspension { get; private set; }
        public int RearSuspension { get; private set; }

        public Suspension() { }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FrontSuspension;
            yield return RearSuspension;
        }
    }
}
