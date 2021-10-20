using MediatR;
using System.Runtime.Serialization;

namespace Customer.Api.Application.Commands.Banking
{
    [DataContract]
    public class UpdateBankCommand
        : IRequest<bool>
    {
        [DataMember]
        public int Id { get; init; }

        [DataMember]
        public string BankName { get; init; }

        [DataMember]
        public string Description { get; init; }

        [DataMember]
        public string Phone { get; init; }

        public UpdateBankCommand() { }

        public UpdateBankCommand(int id, string bankName, string description, string phone) : this()
        {
            Id = id;
            BankName = bankName;
            Description = description;
            Phone = phone;
        }
    }
}
