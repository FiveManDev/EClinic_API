using Project.Data.Repository.MSSQL;
using Project.IdentityService.Data;
using Project.IdentityService.Data.Configurations;

namespace Project.IdentityService.Repository.TokenRepository
{
    public class TokenRepository : MSSQLRepository<ApplicationDbContext, Token>, ITokenRepository
    {
        public TokenRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

    }
}
