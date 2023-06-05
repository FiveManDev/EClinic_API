using Project.Data.Repository.MSSQL;
using Project.PaymentService.Data;

namespace Project.PaymentService.Repository.RefundRepositories
{
    public interface IRefundRepository : IMSSQLRepository<Refund>
    {
        
    }
}
