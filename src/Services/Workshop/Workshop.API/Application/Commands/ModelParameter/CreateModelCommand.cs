using MediatR;
using System.Runtime.Serialization;

namespace Workshop.API.Application.Commands.ModelParameter
{
    [DataContract]
    public class CreateModelCommand
        : IRequest<bool>
    {
        [DataMember]
        public int Id { get; init; }

        [DataMember]
        public string Description { get; init; }

        public CreateModelCommand() { }

        public CreateModelCommand(string description) : this()
        {
            Description = description;
        }
    }
}
