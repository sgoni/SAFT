using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Customer.API.Application.Commands.Customer
{
    [DataContract]
    public class UpdateCustomerCommand
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

        public UpdateCustomerCommand() { }

        public UpdateCustomerCommand(UpdateCustomerCommand updateCustomerCommand) : this()
        {
            var _updateCustomerCommand = updateCustomerCommand ?? throw new ArgumentNullException(nameof(updateCustomerCommand));

            this.DocumentNumber = _updateCustomerCommand.DocumentNumber;
            this.DocumentType = _updateCustomerCommand.DocumentType;
            this.Email = _updateCustomerCommand.Email;
            this.FirstName = _updateCustomerCommand.FirstName;
            this.LastName = _updateCustomerCommand.LastName;
            this.MainPhone = _updateCustomerCommand.MainPhone;
            this.OtherPhone = _updateCustomerCommand.OtherPhone;
            this.IsActive = _updateCustomerCommand.IsActive;
            this.TerritoryId = _updateCustomerCommand.TerritoryId;
            this.AddressCustomerDTO = _updateCustomerCommand.AddressCustomerDTO;
            this.PaymentMethodCustomerDTO = updateCustomerCommand.PaymentMethodCustomerDTO;
        }

        public UpdateCustomerCommand(string documentNumber, string documentType, string firstName, string lastName, string bussinestName, string email, string mainPhone, string cellPhone, string otherPhone, bool isActive, AddressCustomerDTO addressDto, List<PaymentMethodCustomerDTO> paymentMethodCustomerDTO, int? territoryId = null) : this()
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
            CellPhone = cellPhone;
            IsActive = isActive;
            TerritoryId = territoryId;
            AddressCustomerDTO = addressDto;
            PaymentMethodCustomerDTO = paymentMethodCustomerDTO;
        }
    }
}
