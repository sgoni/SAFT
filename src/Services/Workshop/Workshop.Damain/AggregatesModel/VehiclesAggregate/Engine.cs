using SharedKernel.SeedWork;
using System.Collections.Generic;

namespace Workshop.Domain.AggregatesModel.VehiclesAggregate
{
    public class Engine : ValueObject
    {
        public int Wattage { get; private set; }
        public int PowerPerLitreOfDisplacement { get; private set; }
        public int Torque { get; private set; }
        public int EngineLayout { get; private set; }
        public int EngineModel { get; private set; }
        public int EngineVolume { get; private set; }
        public int NumberCylinders { get; private set; }
        public int ArrangementCylinders { get; private set; }
        public float CylinderDiameter { get; private set; }
        public float PistonStroke { get; private set; }
        public float CompressionRate { get; private set; }
        public int NumberValvesPerCylinder { get; private set; }
        public int FuelSystem { get; private set; }
        public int MethodAirAspiration { get; private set; }
        public int GasDistributionMechanism { get; private set; }
        public int PropulsionSystem { get; private set; }

        public Engine() { }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Wattage;
            yield return PowerPerLitreOfDisplacement;
            yield return Torque;
            yield return EngineLayout;
            yield return EngineModel;
            yield return EngineVolume;
            yield return NumberCylinders;
            yield return ArrangementCylinders;
            yield return CylinderDiameter;
            yield return PistonStroke;
            yield return CompressionRate;
            yield return NumberValvesPerCylinder;
            yield return FuelSystem;
            yield return MethodAirAspiration;
            yield return GasDistributionMechanism;
            yield return PropulsionSystem;
        }
    }
}
