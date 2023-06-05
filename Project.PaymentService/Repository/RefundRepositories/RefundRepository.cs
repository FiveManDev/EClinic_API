using Project.Data.Repository.MSSQL;
using Project.PaymentService.Data;
using Project.PaymentService.Data.Configurations;

namespace Project.PaymentService.Repository.RefundRepositories
{
    public class RefundRepository : MSSQLRepository<ApplicationDbContext, Refund>, IRefundRepository
    {
        public RefundRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
