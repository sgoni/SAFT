using MediatR;
using System.Runtime.Serialization;

namespace Workshop.API.Application.Commands.BrandParameter
{
    [DataContract]
    public class CreateBrandCommand
        : IRequest<bool>
    {
        [DataMember]
        public string Name { get; init; }

        public CreateBrandCommand() { }

        public CreateBrandCommand(string name) : this()
        {
            Name = name;
        }
    }
}
