using MediatR;
using System.Runtime.Serialization;

namespace Customer.Api.Application.Commands.Banking
{
    [DataContract]
    public class CreateBankCommand
        : IRequest<bool>
    {
        [DataMember]
        public string BankName { get; init; }

        [DataMember]
        public string Description { get; init; }

        [DataMember]
        public string Phone { get; init; }

        public CreateBankCommand() { }

        public CreateBankCommand(string bankName, string description, string phone) : this()
        {
            BankName = bankName;
            Description = description;
            Phone = phone;
        }
    }
}
