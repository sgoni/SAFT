using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Runtime.Serialization;

namespace Identity.API.Application.Commands.User
{
    [DataContract]
    public class CreatetUserCommand
        : IRequest<IdentityResult>
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }

        public CreatetUserCommand() { }

        public CreatetUserCommand(string userName, string email, string password) : this()
        {
            UserName = userName;
            Email = email;
            Password = password;
        }
    }
}
