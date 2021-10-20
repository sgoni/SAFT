using MediatR;
using System.Runtime.Serialization;

namespace Identity.API.Application.Commands.AspnetRole
{
    [DataContract]
    public class DeleteAspNetRoleCommand
        : IRequest<bool>
    {
        [DataMember]
        public string Id { get; set; }

        public DeleteAspNetRoleCommand() { }

        public DeleteAspNetRoleCommand(string id) : this()
        {
            Id = id;
        }
    }
}
