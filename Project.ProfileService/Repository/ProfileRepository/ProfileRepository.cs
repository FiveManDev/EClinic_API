using MassTransit;
using Microsoft.EntityFrameworkCore;
using Project.Common.Paging;
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
            var result = await context.Profiles.Include(x => x.EmployeeProfile).SingleOrDefaultAsync(x => x.UserID == UserID);
            return result;
        }

        public async Task<PaginationModel<List<Profile>>> GetUserProfilesAsync(List<Guid> UserIDs, PaginationRequestHeader pagination, string searchText)
        {
            var profiles = await context.Profiles.Include(x => x.HealthProfile).Where(u => UserIDs.Contains(u.UserID) && u.HealthProfile.RelationshipID == ConstantsData.MyRelationshipID)
                .ToListAsync();
            profiles = profiles.Where(x => x.FirstName.Contains(searchText) || x.LastName.Contains(searchText) || x.Email.Contains(searchText))
                .Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize)
                .ToList();
            var paginationResponseHeader = new PaginationResponseHeader
            {
                PageSize = pagination.PageSize,
                PageIndex = pagination.PageNumber,
                TotalCount = profiles.Count()
            };
            return new PaginationModel<List<Profile>> { PaginationData = profiles, PaginationResponseHeader = paginationResponseHeader };
        }

        public async  Task<PaginationModel<List<Profile>>> GetDoctorProfilesAsync(List<Guid> UserIDs, PaginationRequestHeader pagination, string searchText)
        {
            var profiles = await context.Profiles.Include(x => x.DoctorProfile).Where(u => UserIDs.Contains(u.UserID))
                .ToListAsync();
            profiles = profiles.Where(x => x.FirstName.Contains(searchText) || x.LastName.Contains(searchText) || x.Email.Contains(searchText) || x.DoctorProfile.Title.Contains(searchText))
                .Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize)
                .ToList();
            var paginationResponseHeader = new PaginationResponseHeader
            {
                PageSize = pagination.PageSize,
                PageIndex = pagination.PageNumber,
                TotalCount = profiles.Count()
            };
            return new PaginationModel<List<Profile>> { PaginationData = profiles, PaginationResponseHeader = paginationResponseHeader };
        }

        public async Task<PaginationModel<List<Profile>>> GetEmployeeProfilesAsync(List<Guid> UserIDs, PaginationRequestHeader pagination, string searchText)
        {
            var profiles = await context.Profiles.Include(x => x.EmployeeProfile)
                  .Where(u => UserIDs.Contains(u.UserID))
                 .ToListAsync();
            profiles = profiles.Where(x => x.FirstName.Contains(searchText) || x.LastName.Contains(searchText) || x.Email.Contains(searchText))
                .Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize)
                .ToList();
            var paginationResponseHeader = new PaginationResponseHeader
            {
                PageSize = pagination.PageSize,
                PageIndex = pagination.PageNumber,
                TotalCount = profiles.Count()
            };
            return new PaginationModel<List<Profile>> { PaginationData = profiles, PaginationResponseHeader = paginationResponseHeader };
        }

        public async Task<Profile> GetUserProfileByIDAsync(Guid ProfileID)
        {
            var result = await context.Profiles.Include(x => x.HealthProfile).SingleOrDefaultAsync(x => x.ProfileID == ProfileID);
            return result;
        }
    }
}
