using Project.Data.Repository.MSSQL;
using Project.ProfileService.Data;
using Project.ProfileService.Data.Configurations;

namespace Project.ProfileService.Repository.SupporterProfileRepository
{
    public class SupporterProfileRepository : MSSQLRepository<ApplicationDbContext, SupporterProfile>, ISupporterProfileRepository
    {
        public SupporterProfileRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
