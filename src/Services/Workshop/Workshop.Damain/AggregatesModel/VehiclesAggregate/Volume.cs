using SharedKernel.SeedWork;
using System.Collections.Generic;

namespace Workshop.Domain.AggregatesModel.VehiclesAggregate
{
    public class Volume : ValueObject
    {
        public double MinimumTrunkVolume { get; private set; }
        public double TankVolume { get; private set; }

        public Volume() { }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return MinimumTrunkVolume;
            yield return TankVolume;
        }
    }
}
