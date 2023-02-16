using Project.Data.Repository.MSSQL;
using Project.ProfileService.Data;

namespace Project.ProfileService.Repository.SupporterProfileRepository
{
    public interface ISupporterProfileRepository : IMSSQLRepository<SupporterProfile>
    {
    }
}
