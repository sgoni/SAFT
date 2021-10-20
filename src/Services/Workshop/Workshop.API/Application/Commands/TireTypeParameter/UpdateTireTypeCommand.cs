using MediatR;
using System.Runtime.Serialization;

namespace Workshop.API.Application.Commands.TireTypeParameter
{
    public class UpdateTireTypeCommand
        : IRequest<bool>
    {
        [DataMember]
        public int Id { get; init; }

        [DataMember]
        public string Description { get; init; }

        public UpdateTireTypeCommand() { }

        public UpdateTireTypeCommand(int id, string description) : this()
        {
            Id = id;
            Description = description;
        }
    }
}
