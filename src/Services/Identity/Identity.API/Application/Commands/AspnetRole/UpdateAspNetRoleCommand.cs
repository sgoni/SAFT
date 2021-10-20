using MediatR;
using System.Runtime.Serialization;

namespace Identity.API.Application.Commands.AspnetRole
{
    public class UpdateAspNetRoleCommand
        : IRequest<bool>
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Name { get; set; }

        public UpdateAspNetRoleCommand() { }

        public UpdateAspNetRoleCommand(string id, string name) : this()
        {
            Id = id;
            Name = name;
        }
    }
}
