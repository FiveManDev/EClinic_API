using Project.Data.Repository.MSSQL;
using Project.ProfileService.Data;

namespace Project.ProfileService.Repository.ProfileRepository
{
    public interface IProfileRepository : IMSSQLRepository<Profile>
    {
    }
}
