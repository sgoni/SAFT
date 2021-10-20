using SharedKernel.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Customer.Domain.AggregatesModel.CustomerAggregate
{
    public class Client : Entity, IAggregateRoot
    {
        private string _firstName;
        private string _lastName;
        private string _bussinesName;
        private string _documentType;
        private string _mainPhone;
        private string _cellPhone;
        private string _otherPhone;
        private string _email;
        private bool _isActive;
        private int? _territoryId;
        private DateTime _createDate;
        private DateTime _lastUpdate;

        public string DocumentNumber { get; private set; }

        // Address is a Value Object pattern example persisted as EF Core 2.0 owned entity
        public Address Address { get; private set; }

        //public PaymentMethod PaymentMethod { get; private set; }

        private readonly List<PaymentMethod> _paymentMethodItems;
        public IReadOnlyCollection<PaymentMethod> PaymentMethodItems => _paymentMethodItems;


        public Client()
        {
            _createDate = DateTime.Now;
            _lastUpdate = DateTime.Now;
            _isActive = true;
            Address = new Address();
        }

        public Client(string documentNumber, string documentType, string firstName, string lastName, string bussinesName, string mainPhone, string cellPhone, string otherPhone, string email, bool isActive, Address address, int? territoryId = null)
        {
            DocumentNumber = documentNumber;
            _documentType = documentType;
            _firstName = firstName;
            _lastName = lastName;
            _bussinesName = bussinesName;
            _mainPhone = mainPhone;
            _cellPhone = cellPhone;
            _otherPhone = otherPhone;
            _email = email;
            _isActive = isActive;
            _createDate = DateTime.Now;
            _lastUpdate = DateTime.Now;
            Address = address;
            _territoryId = territoryId;
        }

        public void AddMethodPayment(int cardTypeId, string cardNumber, DateTime expiration, int? bankRef)
        {
            var existingMethodPayment = _paymentMethodItems.Where(p => p.CardNumber == cardNumber).SingleOrDefault();

            if (existingMethodPayment == null)
            {
                //add validated new _payment Method item
                _paymentMethodItems.Add(new PaymentMethod(cardTypeId, cardNumber, expiration, bankRef));
            }
        }

        public void SetDocumentNumber(string value)
        {
            this.DocumentNumber = value;
        }

        public void SetFirstName(string value)
        {
            _firstName = value;
        }

        public void SetLastName(string value)
        {
            _lastName = value;
        }

        public void SetBussinesName(string value)
        {
            _bussinesName = value;
        }

        public void SetDocumentType(string value)
        {
            _documentType = value;
        }

        public void SetMainPhone(string value)
        {
            _mainPhone = value;
        }

        public void SetCellPhone(string value)
        {
            _cellPhone = value;
        }

        public void SetOtherPhone(string value)
        {
            _otherPhone = value;
        }

        public void SetEmail(string value)
        {
            _email = value;
        }

        public void SetIsActive(bool value)
        {
            _isActive = value;
        }

        public void SetIsLastUpdate(DateTime value)
        {
            _lastUpdate = value;
        }

        public void SetAddress(Address value)
        {
            Address = value;
        }

        public void Setterritory(int value)
        {
            _territoryId = value;
        }
    }
}
