using MediatR;
using System.Runtime.Serialization;

namespace Workshop.API.Application.Commands.TireTypeParameter
{
    [DataContract]
    public class DeleteTireTypeCommand 
        : IRequest<bool>
    {
        [DataMember]
        public int Id { get; init; }

        public DeleteTireTypeCommand() { }

        public DeleteTireTypeCommand(int id) : this()
        {
            Id = id;
        }
    }
}
