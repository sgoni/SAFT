using MediatR;
using System.Runtime.Serialization;

namespace Identity.API.Application.Commands.Role
{
    public class CreateRoleCommand
        : IRequest<bool>
    {
        [DataMember]
        public string Name { get; set; }

        public CreateRoleCommand() { }

        public CreateRoleCommand(string name) : this()
        {
            Name = name;
        }
    }
}

