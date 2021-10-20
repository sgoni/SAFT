using SharedKernel.SeedWork;

namespace Workshop.Domain.AggregatesModel.VehiclesAggregate
{
    public class Vehicle : Entity, IAggregateRoot
    {
        private string _vin;
        private string _engineCode;
        private string _generation;
        private int? _bodyWorkTypeRef;
        private int? _brandRef;
        private int? _model;
        private int? _year;
        private int? _engineTypeRef;
        private int? _transmissionTypeRef;
        private int? _gearboxTypeRef;
        private float _power;
        private int _numberOfSeats;
        private int _numberOfDoors;

        public int CustomerRef { get; private set; }
        public string LicensePlate { get; private set; }

        // Value Object pattern example persisted as EF Core 2.0 owned entity
        //public Brake Brake { get; private set; }
        //public Drive Drive { get; private set; }
        //public ElectricMotor ElectricMotor { get; private set; }
        //public Engine Engine { get; private set; }
        //public Performance Performance { get; private set; }
        //public SIze SIze { get; private set; }
        //public Suspension Suspension { get; private set; }
        //public Volume Volume { get; private set; }
        //public Weight Weight { get; private set; }

        public Vehicle() { }

        public Vehicle(string licensePlate, string vin, string engineCode, string generation, int numberOfSeats, int numberOfDoors, float power, int? brand = null, int? model = null, int? year = null, int? engineType = null, int? transmissionType = null, int? bodyWorkType = null, int? gearboxType = null)
        {
            LicensePlate = licensePlate;
            //CustomerRef = customerRef;
            _vin = vin;
            _engineCode = engineCode;
            _generation = generation;
            _numberOfSeats = numberOfSeats;
            _numberOfDoors = numberOfDoors;
            _power = power;
            _brandRef = brand;
            _model = model;
            _year = year;
            _engineTypeRef = engineType;
            _transmissionTypeRef = transmissionType;
            _bodyWorkTypeRef = bodyWorkType;
            _gearboxTypeRef = gearboxType;
        }

        public override string ToString()
        {
            return $"{_brandRef}, {_model}, {_generation}";
        }
    }
}