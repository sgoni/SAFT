using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Runtime.Serialization;

namespace Identity.API.Application.Commands.User
{
    public class AddUserToRoleCommand
        : IRequest<IdentityResult>
    {
        [DataMember]
        public string UserId { get; set; }

        [DataMember]
        public string RoleName { get; set; }

        public AddUserToRoleCommand() { }

        public AddUserToRoleCommand(string userId, string roleName) : this()
        {
            UserId = userId;
            RoleName = roleName;
        }
    }
}
