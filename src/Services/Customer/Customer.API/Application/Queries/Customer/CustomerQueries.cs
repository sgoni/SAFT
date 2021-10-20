using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Customer.API.Application.Queries.Customer
{
    public class CustomerQueries : ICustomerQueries
    {
        private string _connectionString = string.Empty;

        public CustomerQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<CustomerViewModel> GetCustomerByDocumentNumberAsync(string documentNumber)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<dynamic>(
                    @"SELECT c.id,
                             c.documentnumber,
                             c.documenttype,
                             c.firstname,
                             c.lastname,
                             c.bussinesname,
                             c.email,
                             c.mainphone,
                             c.cellphone,
                             c.otherphone,
                             c.isactive,
                             c.address_street,
                             c.address_province,
                             c.address_district,
                             c.address_location,
                             c.address_zipcode,
                             c.address_latitude,
                             c.address_longitude,
                             b.NAME AS Bank,
                             ct.NAME AS CardIssuer,
                             p.cardnumber,
                             p.expiration AS ExpirationDate
                     FROM   saft.customers c
                             INNER JOIN saft.paymentmethods p
                                     ON p.clientref = c.id
                             INNER JOIN saft.cardtypes ct
                                     ON ct.id = p.cardtypeid
                             INNER JOIN saft.banks b
                                     ON b.id = p.bankref
                     WHERE  c.documentnumber = @documentNumber",
                    new { documentNumber }
                    );

                if (result.AsList().Count == 0)
                {
                    throw new KeyNotFoundException();
                }

                return MapCustomerAddress(result);
            }
        }

        private CustomerViewModel MapCustomerAddress(dynamic result)
        {
            CustomerViewModel _customer = new CustomerViewModel
            {
                CustomerId = result[0].id,
                DocumentNumber = result[0].documentnumber,
                DocumentType = result[0].documenttype,
                FirstName = result[0].firstname,
                LastName = result[0].lastname,
                BussinesName = result[0].bussinesname,
                Email = result[0].email,
                MainPhone = result[0].mainphone,
                CellPhone = result[0].cellphone,
                OtherPhone = result[0].otherphone,
                IsActive = result[0].isactive,
                AddressStreet = result[0].address_street,
                AddressProvince = result[0].address_province,
                AddressDistrict = result[0].address_district,
                AddressLocation = result[0].address_location,
                AddressZipcode = result[0].address_zipcode,
                AddressLatitude = result[0].address_latitude,
                AddressLongitude = result[0].address_longitude,
            };

            foreach (dynamic item in result)
            {
                var paymentMethod = new PaymentMethodViewModel
                {
                    Bank = item.Bank,
                    CardNumber = item.cardnumber,
                    CardType = item.CardIssuer,
                    ExpirationDate = item.ExpirationDate
                };

                _customer.PaymentMethodViewModel = paymentMethod;
            }

            return _customer;
        }
    }
}