using SharedKernel.SeedWork;

namespace Customer.Domain.AggregatesModel.GeographicalAggregate
{
    public class Geographical : Entity, IAggregateRoot
    {
        private int _codeCountry;
        private string _countryName;

        // Address is a Value Object pattern example persisted as EF Core 2.0 owned entity
        public Province Province { get; private set; }
        public City City { get; private set; }
        public Distric Distric { get; private set; }
        public Neighborhood Neighborhood { get; private set; }

        public Geographical()
        {
            Province = new Province();
            City = new City();
            Distric = new Distric();
            Neighborhood = new Neighborhood();
        }

        public Geographical(int codeCountry, string countryName, Province provinces, City city, Distric distric, Neighborhood neighborhood) : this()
        {
            _codeCountry = codeCountry;
            _countryName = countryName;
            Province = provinces;
            City = city;
            Distric = new Distric();
            Neighborhood = neighborhood;
        }
    }
}
