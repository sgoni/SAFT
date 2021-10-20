using MediatR;
using System.Runtime.Serialization;

namespace Workshop.API.Application.Commands.BrandParameter
{
    [DataContract]
    public class DeleteBrandCommand
        : IRequest<bool>
    {
        [DataMember]
        public int Id { get; init; }

        public DeleteBrandCommand() { }

        public DeleteBrandCommand(int id) : this()
        {
            Id = id;
        }
    }
}
