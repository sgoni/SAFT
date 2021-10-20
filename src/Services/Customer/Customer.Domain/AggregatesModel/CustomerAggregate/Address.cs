using Microsoft.EntityFrameworkCore;
using SharedKernel.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customer.Domain.AggregatesModel.CustomerAggregate
{
    [Keyless]
    [NotMapped]
    public class Address : ValueObject
    {
        public String Street { get; private set; }
        public String ZipCode { get; private set; }
        public String Longitude { get; private set; }
        public String Latitude { get; private set; }

        public Address() { }

        public Address(string street, string zipCode, string longitude, string latitude)
            : this()
        {
            Street = street;
            ZipCode = zipCode;
            Longitude = longitude;
            Latitude = latitude;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return Street;
            yield return ZipCode;
            yield return Longitude;
            yield return Latitude;
        }
    }
}
