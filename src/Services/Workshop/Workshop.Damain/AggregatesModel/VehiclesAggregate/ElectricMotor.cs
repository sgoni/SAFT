using SharedKernel.SeedWork;
using System.Collections.Generic;

namespace Workshop.Domain.AggregatesModel.VehiclesAggregate
{
    public class ElectricMotor : ValueObject
    {
        public int BatteryCapacity { get; private set; }
        public int BatteryAutonomy { get; private set; }
        public int AverageElectricityConsumption { get; private set; }
        public int PowerElectricalEngine { get; private set; }
        public int ElectricMotorTorque { get; private set; }
        public int EngineLayout { get; private set; }
        public int SystemPower { get; private set; }
        public int SystemTorque { get; private set; }

        public ElectricMotor() { }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return BatteryCapacity;
            yield return BatteryAutonomy;
            yield return AverageElectricityConsumption;
            yield return PowerElectricalEngine;
            yield return ElectricMotorTorque;
            yield return EngineLayout;
            yield return SystemPower;
            yield return SystemTorque;
        }
    }
}
