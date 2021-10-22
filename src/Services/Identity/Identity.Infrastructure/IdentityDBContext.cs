using Identity.Domain.AggregatesModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure
{
    public class IdentityDBContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityDBContext(DbContextOptions<IdentityDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                //options.UseMySQL("server=localhost;user=phantom;password=Developer1;database=saft;");
                options.UseSqlServer("Data Source=DESKTOP-V3MI6SG;Initial Catalog=saft;Integrated Security=True;Pooling=False");
            }
        }
    }
}