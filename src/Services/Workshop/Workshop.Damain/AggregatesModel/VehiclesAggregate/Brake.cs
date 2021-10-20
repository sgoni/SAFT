using SharedKernel.SeedWork;
using System.Collections.Generic;

namespace Workshop.Domain.AggregatesModel.VehiclesAggregate
{
    public class Brake : ValueObject
    {
        public int FrontBrakes { get; private set; }
        public int RearBrakes { get; private set; }
        public int SupportSystems { get; private set; }
        public int ControlType { get; private set; }
        public string SteeringWheelAmplifier { get; private set; }
        public float TyreDimensions { get; private set; }
        public float RimDimensions { get; private set; }

        public Brake() { }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FrontBrakes;
            yield return RearBrakes;
            yield return SupportSystems;
            yield return ControlType;
            yield return SteeringWheelAmplifier;
            yield return TyreDimensions;
            yield return RimDimensions;
        }
    }
}
