using MediatR;
using System.Runtime.Serialization;

namespace Workshop.API.Application.Commands.BodyworkParameter
{
    [DataContract]
    public class CreateBodyWorkCommand 
        : IRequest<bool>
    {
        [DataMember]
        public string Description { get; init; }

        public CreateBodyWorkCommand() { }

        public CreateBodyWorkCommand(string description) : this()
        {
            Description = description;
        }
    }
}
