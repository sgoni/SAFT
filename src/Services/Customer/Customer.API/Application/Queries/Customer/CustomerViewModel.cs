using System;
using System.Collections.Generic;

namespace Customer.API.Application.Queries.Customer
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }

        public string DocumentNumber { get; set; }

        public string DocumentType { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string BussinesName { get; set; }

        public string Email { get; init; }

        public string MainPhone { get; set; }

        public string CellPhone { get; set; }

        public string OtherPhone { get; set; }

        public bool IsActive { get; set; }

        public string AddressStreet { get; set; }

        public string AddressProvince { get; set; }

        public string AddressDistrict { get; set; }

        public string AddressLocation { get; set; }

        public string AddressZipcode { get; set; }

        public string AddressLatitude { get; set; }

        public string AddressLongitude { get; set; }

        public PaymentMethodViewModel PaymentMethodViewModel { get; set; }
    }

    public class PaymentMethodViewModel
    {
        public string CardNumber { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string Bank { get; set; }

        public string CardType { get; set; }
    }
}
