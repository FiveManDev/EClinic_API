using Project.Data.Repository.MSSQL;
using Project.ServiceInformationService.Data;
using Project.ServiceInformationService.Data.Configurations;

namespace Project.ServiceInformationService.Repository.ServiceRepository;

public class ServiceRepository : MSSQLRepository<ApplicationDbContext, Service>, IServiceRepository
{
    public ServiceRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
