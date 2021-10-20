using Identity.Domain.AggregatesModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace Identity.Infrastructure
{
    public class IdentityDBContext : IdentityDbContext<ApplicationUser>
    {
    }
}
