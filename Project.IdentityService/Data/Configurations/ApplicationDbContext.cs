using Microsoft.EntityFrameworkCore;
using Project.Common.Constants;

namespace Project.IdentityService.Data.Configurations
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Token> Tokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>(e =>
            {
                e.HasKey(x => x.RoleID);
            });
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleID = RoleConstants.IDAdmin, RoleName = RoleConstants.Admin },
                new Role { RoleID = RoleConstants.IDSupporter, RoleName = RoleConstants.Supporter },
                new Role { RoleID = RoleConstants.IDDoctor, RoleName = RoleConstants.Doctor },
                new Role { RoleID = RoleConstants.IDUser, RoleName = RoleConstants.User }
            );
        }
    }
}
