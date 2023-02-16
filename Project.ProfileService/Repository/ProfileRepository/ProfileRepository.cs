using Project.Data.Repository.MSSQL;
using Project.ProfileService.Data;
using Project.ProfileService.Data.Configurations;

namespace Project.ProfileService.Repository.ProfileRepository
{
    public class ProfileRepository : MSSQLRepository<ApplicationDbContext, Profile>, IProfileRepository
    {
        public ProfileRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
