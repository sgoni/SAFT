using MediatR;
using System.Runtime.Serialization;

namespace Identity.API.Application.Commands.AspnetUser
{
    [DataContract]
    public class CreateAspNetUserCommand
        : IRequest<bool>
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }

        public CreateAspNetUserCommand() { }

        public CreateAspNetUserCommand(string userName, string email, string password) : this()
        {
            UserName = userName;
            Email = email;
            Password = password;
        }
    }
}
