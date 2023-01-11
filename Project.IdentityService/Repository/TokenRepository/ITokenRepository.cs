using Project.Data.Repository.MSSQL;
using Project.IdentityService.Data;

namespace Project.IdentityService.Repository.TokenRepository
{
    public interface ITokenRepository : IMSSQLRepository<Token>
    {
    }
}
