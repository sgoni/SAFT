using SharedKernel.SeedWork;
using System.Collections.Generic;

namespace Customer.Domain.AggregatesModel.GeographicalAggregate
{
    public class Province : ValueObject
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Province() { }

        public Province(int provinceId, string provinceName)
        {
            Id = provinceId;
            Name = provinceName;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return Id;
            yield return Name;
        }
    }
}
