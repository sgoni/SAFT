using SharedKernel.SeedWork;
using System;
using System.Collections.Generic;

namespace Customer.Domain.AggregatesModel.GeographicalAggregate
{
    public class Neighborhood : ValueObject
    {
        public int Id { get; private set; }
        public String Name { get; private set; }

        public Neighborhood() { }

        public Neighborhood(int neighborhoodId, string neighborhoodName)
        {
            Id = neighborhoodId;
            Name = neighborhoodName;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return Id;
            yield return Name;
        }
    }
}
