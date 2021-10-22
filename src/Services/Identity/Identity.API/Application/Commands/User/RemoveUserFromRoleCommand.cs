using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Runtime.Serialization;

namespace Identity.API.Application.Commands.User
{
    public class RemoveUserFromRoleCommand
        : IRequest<IdentityResult>
    {
        [DataMember]
        public string UserId { get; set; }

        [DataMember]
        public string RoleName { get; set; }

        public RemoveUserFromRoleCommand() { }

        public RemoveUserFromRoleCommand(string userId, string roleName) : this()
        {
            UserId = userId;
            RoleName = roleName;
        }
    }
}
