using Project.Data.Repository.MSSQL;
using Project.ServiceInformationService.Data;
using System.Linq.Expressions;

namespace Project.ServiceInformationService.Repository.ServiceRepository;

public interface IServiceRepository : IMSSQLRepository<Service>
{
    Task<List<Service>> GetAllServiceAsync(Expression<Func<Service, bool>> filters);
    Task<Service> GetServiceAsync(Expression<Func<Service, bool>> filters);

}
