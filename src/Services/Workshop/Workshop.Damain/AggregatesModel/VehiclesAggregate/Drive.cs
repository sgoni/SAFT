using SharedKernel.SeedWork;
using System.Collections.Generic;

namespace Workshop.Domain.AggregatesModel.VehiclesAggregate
{
    public class Drive : ValueObject
    {
        public int Driven { get; private set; }
        public int NumberOfGears { get; private set; }

        public Drive() { }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Driven;
            yield return NumberOfGears;
        }
    }
}
