using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Runtime.Serialization;

namespace Identity.API.Application.Commands.User
{
    public class DeleteUserCommand
       : IRequest<IdentityResult>
    {
        [DataMember]
        public string Id { get; set; }

        public DeleteUserCommand() { }

        public DeleteUserCommand(string id) : this()
        {
            Id = id;
        }
    }
}
