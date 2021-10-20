using MediatR;
using System.Runtime.Serialization;

namespace Workshop.API.Application.Commands.TireTypeParameter
{
    [DataContract]
    public class CreateTireTypeCommand
        : IRequest<bool>
    {
        [DataMember]
        public string Description { get; init; }

        public CreateTireTypeCommand() { }

        public CreateTireTypeCommand(string description) : this()
        {
            Description = description;
        }
    }
}
