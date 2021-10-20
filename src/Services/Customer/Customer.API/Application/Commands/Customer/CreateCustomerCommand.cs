using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Customer.API.Application.Commands.Customer
{
    [DataContract]
    public class CreateCustomerCommand
            : IRequest<bool>
    {
        [DataMember]
        public string DocumentNumber { get; init; }

        [DataMember]
        public string DocumentType { get; init; }

        [DataMember]
        public string FirstName { get; init; }

        [DataMember]
        public string LastName { get; init; }

        [DataMember]
        public string BussinesName { get; init; }

        [DataMember]
        public string Email { get; init; }

        [DataMember]
        public string MainPhone { get; init; }

        [DataMember]
        public string CellPhone { get; init; }

        [DataMember]
        public string OtherPhone { get; init; }

        [DataMember]
        public bool IsActive { get; init; }

        [DataMember]
        public int? TerritoryId { get; init; }

        [DataMember]
        public AddressCustomerDTO AddressCustomerDTO { get; init; }

        [DataMember]
        public List<PaymentMethodCustomerDTO> PaymentMethodCustomerDTO { get; init; }

        public CreateCustomerCommand() { }

        public CreateCustomerCommand(CreateCustomerCommand createCustomerCommand) : this()
        {
            var _createCustomerCommand = createCustomerCommand ?? throw new ArgumentNullException(nameof(createCustomerCommand));

            this.DocumentNumber = _createCustomerCommand.DocumentNumber;
            this.DocumentType = _createCustomerCommand.DocumentType;
            this.FirstName = _createCustomerCommand.FirstName;
            this.LastName = _createCustomerCommand.LastName;
            this.BussinesName = _createCustomerCommand.BussinesName;
            this.Email = _createCustomerCommand.Email;
            this.MainPhone = _createCustomerCommand.MainPhone;
            this.OtherPhone = _createCustomerCommand.OtherPhone;
            this.CellPhone = _createCustomerCommand.CellPhone;
            this.IsActive = _createCustomerCommand.IsActive;
            this.AddressCustomerDTO = _createCustomerCommand.AddressCustomerDTO;
            this.PaymentMethodCustomerDTO = _createCustomerCommand.PaymentMethodCustomerDTO;
            this.TerritoryId = _createCustomerCommand.TerritoryId;
        }

        public CreateCustomerCommand(string documentNumber, string documentType, string firstName, string lastName, string bussinestName, string email, string mainPhone, string cellPhone, string otherPhone, bool isActive, AddressCustomerDTO addressDTO, List<PaymentMethodCustomerDTO> paymentMethodCustomerDTO, int? territoryId = null) : this()
        {
            DocumentNumber = documentNumber;
            DocumentType = documentType;
            FirstName = firstName;
            LastName = lastName;
            BussinesName = bussinestName;
            Email = email;
            MainPhone = mainPhone;
            CellPhone = cellPhone;
            OtherPhone = otherPhone;
            IsActive = isActive;
            TerritoryId = territoryId;
            AddressCustomerDTO = addressDTO;
            PaymentMethodCustomerDTO = paymentMethodCustomerDTO;
        }
    }

    public record AddressCustomerDTO
    {
        public String Street { get; init; }
        public String ZipCode { get; init; }
        public String Longitude { get; init; }
        public String Latitude { get; init; }
    }

    public record PaymentMethodCustomerDTO
    {
        public int CardTypeId { get; init; }
        public String CardNumber { get; init; }
        public DateTime ExpirationDate { get; init; }
        public int? BankOwnerId { get; init; }
    }
}
