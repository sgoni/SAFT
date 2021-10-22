using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Runtime.Serialization;

namespace Identity.API.Application.Commands.Role
{
    public class DeleteRoleCommand
        : IRequest<IdentityResult>
    {
        [DataMember]
        public string Id { get; set; }

        public DeleteRoleCommand() { }

        public DeleteRoleCommand(string name) : this()
        {
            Id = Id;
        }
    }
}
