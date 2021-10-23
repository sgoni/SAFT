using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace Identity.API.Application.Commands.Queries.GetRoleList
{
    public record GetRoleListQuerie() : IRequest<IQueryable<IdentityRole>>;
}
