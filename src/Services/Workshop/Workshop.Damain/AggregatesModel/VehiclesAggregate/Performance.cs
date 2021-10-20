using SharedKernel.SeedWork;
using System;
using System.Collections.Generic;

namespace Workshop.Domain.AggregatesModel.VehiclesAggregate
{
    public class Performance : ValueObject
    {
        public String FuelConsumption { get; private set; }
        public String CO2Emisions { get; private set; }
        public int FuelType { get; private set; }
        public int AccelerationKmh { get; private set; }
        public int AccelerationMph { get; private set; }
        public int MaximumSpeed { get; private set; }
        public String WeightToPowerRatio { get; private set; }
        public String WeightToTorqueRatio { get; private set; }

        public Performance() { }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return FuelConsumption;
            yield return CO2Emisions;
            yield return FuelType;
            yield return AccelerationKmh;
            yield return AccelerationMph;
            yield return MaximumSpeed;
            yield return WeightToPowerRatio;
            yield return WeightToTorqueRatio;
        }
    }
}
