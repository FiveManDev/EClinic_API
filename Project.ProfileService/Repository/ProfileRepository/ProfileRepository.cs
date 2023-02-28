using Microsoft.EntityFrameworkCore;
using Project.Data.Repository.MSSQL;
using Project.ProfileService.Data;
using Project.ProfileService.Data.Configurations;

namespace Project.ProfileService.Repository.ProfileRepository
{
    public class ProfileRepository : MSSQLRepository<ApplicationDbContext, Profile>, IProfileRepository
    {
        private readonly ApplicationDbContext context;
        public ProfileRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.context = dbContext;
        }

        public async Task<Profile> GetDoctorProfileAsync(Guid UserID)
        {
            var result = await context.Profiles.Include(x => x.DoctorProfile).SingleOrDefaultAsync(x => x.UserID == UserID);
            return result;
        }

        public async Task<Profile> GetProfileAsync(Guid UserID)
        {
            var result = await context.Profiles.SingleOrDefaultAsync(x => x.UserID == UserID);
            return result;
        }

        public async Task<List<Profile>> GetProfilesAsync(Guid UserID)
        {
            var result = await context.Profiles.Include(x => x.HealthProfile).Where(x => x.UserID == UserID).ToListAsync();
            return result;
        }

        public async Task<Profile> GetEmployeeProfileAsync(Guid UserID)
        {
            var result = await context.Profiles.Include(x => x.SupporterProfile).SingleOrDefaultAsync(x => x.UserID == UserID);
            return result;
        }
    }
}
