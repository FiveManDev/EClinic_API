using Project.Data.Repository.MSSQL;
using Project.IdentityService.Data;

namespace Project.IdentityService.Repository.UserRepository
{
    public interface IUserRepository : IMSSQLRepository<User>
    {

    }
}
