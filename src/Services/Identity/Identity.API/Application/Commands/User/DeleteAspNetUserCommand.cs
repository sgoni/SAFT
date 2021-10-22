using MediatR;
using System;
using System.Runtime.Serialization;

namespace Identity.API.Application.Commands.AspnetUser
{
    [DataContract]
    public class DeleteAspNetUserCommand
        : IRequest<bool>
    {
        [DataMember]
        public string UserName { get; init; }

        public DeleteAspNetUserCommand() { }

        public DeleteAspNetUserCommand(string userName) : this()
        {
            UserName = userName;
        }
    }
}
