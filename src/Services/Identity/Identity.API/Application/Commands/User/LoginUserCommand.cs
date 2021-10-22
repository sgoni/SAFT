using MediatR;
using System.Runtime.Serialization;

namespace Identity.API.Application.Commands.User
{
    [DataContract]
    public class LoginUserCommand
        : IRequest<object>
    {
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }

        public LoginUserCommand(string userName, string password)
        {
            Username = userName;
            Password = password;
        }
    }
}
