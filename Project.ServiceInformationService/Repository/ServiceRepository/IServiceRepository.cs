using Project.Data.Repository.MSSQL;
using Project.ServiceInformationService.Data;

namespace Project.ServiceInformationService.Repository.ServiceRepository;

public interface IServiceRepository : IMSSQLRepository<Service>
{
}
