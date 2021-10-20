using MediatR;
using System.Runtime.Serialization;

namespace Workshop.API.Application.Commands.BodyworkParameter
{
    [DataContract]
    public class DeleteBodyWorkCommand
        : IRequest<bool>
    {
        [DataMember]
        public int Id { get; init; }

        public DeleteBodyWorkCommand() { }

        public DeleteBodyWorkCommand(int id) : this()
        {
            Id = id;
        }
    }
}
