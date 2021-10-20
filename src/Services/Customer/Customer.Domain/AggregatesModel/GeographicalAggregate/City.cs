using SharedKernel.SeedWork;
using System.Collections.Generic;

namespace Customer.Domain.AggregatesModel.GeographicalAggregate
{
    public class City : ValueObject
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public City() { }

        public City(int cityId, string cityName)
        {
            Id = cityId;
            Name = cityName;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return Id;
            yield return Name;
        }
    }
}
