using MediatR;
using System.Runtime.Serialization;

namespace Workshop.API.Application.Commands.BrandParameter
{
    [DataContract]
    public class UpdateBrandCommand
        : IRequest<bool>
    {
        [DataMember]
        public int Id { get; init; }

        [DataMember]
        public string Name { get; init; }

        public UpdateBrandCommand() { }

        public UpdateBrandCommand(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }
    }
}
