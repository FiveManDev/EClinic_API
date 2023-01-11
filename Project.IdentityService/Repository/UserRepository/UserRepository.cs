using Project.Data.Repository.MSSQL;
using Project.IdentityService.Data;
using Project.IdentityService.Data.Configurations;

namespace Project.IdentityService.Repository.UserRepository
{
    public class UserRepository : MSSQLRepository<ApplicationDbContext, User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

    }
}
