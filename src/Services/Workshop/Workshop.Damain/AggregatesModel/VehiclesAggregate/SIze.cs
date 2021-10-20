using SharedKernel.SeedWork;
using System.Collections.Generic;

namespace Workshop.Domain.AggregatesModel.VehiclesAggregate
{
    public class SIze : ValueObject
    {
        public float Length { get; private set; }
        public float Width { get; private set; }
        public float Height { get; private set; }
        public float Wheelbase { get; private set; }
        public float FrontTrack { get; private set; }
        public float RearTrack { get; private set; }
        public float FrontOverhang { get; private set; }
        public float RearOverhang { get; private set; }
        public float GroundClearance { get; private set; }
        public float ButtEesistanceCoefficient { get; private set; }
        public float MinimumTurnDiameter { get; private set; }

        public SIze() { }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Length;
            yield return Width;
            yield return Height;
            yield return Wheelbase;
            yield return FrontTrack;
            yield return RearTrack;
            yield return FrontOverhang;
            yield return RearOverhang;
            yield return GroundClearance;
            yield return ButtEesistanceCoefficient;
            yield return MinimumTurnDiameter;
        }
    }
}
