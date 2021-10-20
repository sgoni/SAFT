using MediatR;
using System;
using System.Runtime.Serialization;

namespace Identity.API.Application.Commands.AspnetUser
{
    [DataContract]
    public class UpdateAspNetUserCommand
        : IRequest<bool>
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }

        public UpdateAspNetUserCommand() { }

        public UpdateAspNetUserCommand(string userName, string email, string password) : this()
        {
            UserName = userName;
            Email = email;
            Password = password;
        }
    }
}