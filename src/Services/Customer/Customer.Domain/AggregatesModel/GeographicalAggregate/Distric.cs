using SharedKernel.SeedWork;
using System.Collections.Generic;

namespace Customer.Domain.AggregatesModel.GeographicalAggregate
{
    public class Distric : ValueObject
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Distric() { }

        public Distric(int districId, string districtName)
        {
            Id = districId;
            Name = districtName;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return Id;
            yield return Name;
        }
    }
}
