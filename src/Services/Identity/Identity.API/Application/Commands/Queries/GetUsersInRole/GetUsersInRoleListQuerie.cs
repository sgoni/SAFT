using Identity.Domain.AggregatesModel;
using MediatR;
using System.Collections.Generic;

namespace Identity.API.Application.Commands.Queries.GetUsersInRole
{
    public record GetUsersInRoleListQuerie(string roleName) : IRequest<IList<ApplicationUser>>;
}
