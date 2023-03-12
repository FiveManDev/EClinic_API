using Project.Common.Paging;
using Project.Data.Repository.MSSQL;
using Project.ProfileService.Data;

namespace Project.ProfileService.Repository.ProfileRepository
{
    public interface IProfileRepository : IMSSQLRepository<Profile>
    {
        Task<List<Profile>> GetProfilesAsync(Guid UserID);
        Task<Profile> GetUserProfileByIDAsync(Guid ProfileID);
        Task<Profile> GetDoctorProfileAsync(Guid UserID);
        Task<Profile> GetEmployeeProfileAsync(Guid UserID);
        Task<Profile> GetProfileAsync(Guid UserID);
        Task<PaginationModel<List<Profile>>> GetUserProfilesAsync(List<Guid> UserIDs, PaginationRequestHeader pagination, string searchText);
        Task<PaginationModel<List<Profile>>> GetDoctorProfilesAsync(List<Guid> UserIDs, PaginationRequestHeader pagination, string searchText);
        Task<PaginationModel<List<Profile>>> GetEmployeeProfilesAsync(List<Guid> UserIDs, PaginationRequestHeader pagination, string searchText);
    }
}
