using MediatR;
using System.Runtime.Serialization;

namespace Workshop.API.Application.Commands.BodyworkParameter
{
    [DataContract]
    public class UpdateBodyWorkCommand : IRequest<bool>
    {
        [DataMember]
        public int Id { get; init; }

        [DataMember]
        public string Description { get; init; }

        public UpdateBodyWorkCommand() { }

        public UpdateBodyWorkCommand(int id, string description) : this()
        {
            Id = id;
            Description = description;
        }
    }
}
