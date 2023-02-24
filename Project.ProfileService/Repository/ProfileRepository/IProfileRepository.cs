using Project.Data.Repository.MSSQL;
using Project.ProfileService.Data;

namespace Project.ProfileService.Repository.ProfileRepository
{
    public interface IProfileRepository : IMSSQLRepository<Profile>
    {
        Task<List<Profile>> GetProfilesAsync(Guid UserID);
        Task<Profile> GetDoctorProfileAsync(Guid UserID);
        Task<Profile> GetSupporterProfileAsync(Guid UserID);
        Task<Profile> GetProfileAsync(Guid UserID);
    }
}
