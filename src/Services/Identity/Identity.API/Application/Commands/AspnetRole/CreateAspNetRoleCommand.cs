using MediatR;
using System.Runtime.Serialization;

namespace Identity.API.Application.Commands.AspnetRole
{
    public class CreateAspNetRoleCommand
        : IRequest<bool>
    {
        [DataMember]
        public string Name { get; set; }

        public CreateAspNetRoleCommand() { }

        public CreateAspNetRoleCommand(string name) : this()
        {
            Name = name;
        }
    }
}

