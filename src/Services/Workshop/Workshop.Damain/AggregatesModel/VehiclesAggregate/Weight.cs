using SharedKernel.SeedWork;
using System.Collections.Generic;

namespace Workshop.Domain.AggregatesModel.VehiclesAggregate
{
    public class Weight : ValueObject
    {
        public int OwnTable { get; private set; }
        public int PermissibleMass { get; private set; }
        public int MaximumLoadCapacity { get; private set; }

        public Weight() { }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return OwnTable;
            yield return PermissibleMass;
            yield return MaximumLoadCapacity;
        }
    }
}
