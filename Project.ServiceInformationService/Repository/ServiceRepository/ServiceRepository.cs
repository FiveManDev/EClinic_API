using Microsoft.EntityFrameworkCore;
using Project.Data.Repository.MSSQL;
using Project.ServiceInformationService.Data;
using Project.ServiceInformationService.Data.Configurations;
using System.Linq.Expressions;

namespace Project.ServiceInformationService.Repository.ServiceRepository;

public class ServiceRepository : MSSQLRepository<ApplicationDbContext, Service>, IServiceRepository
{
    private readonly ApplicationDbContext context;
    public ServiceRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        this.context = dbContext;
    }

    public async Task<List<Service>> GetAllServiceAsync(Expression<Func<Service, bool>> filters)
    {
        var result = await context.Services.Include(x => x.Specialization).Where(filters).ToListAsync();
        return result;
    }
}
