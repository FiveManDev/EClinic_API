using Project.BookingService.Data;
using Project.BookingService.Data.Configurations;
using Project.Data.Repository.MSSQL;

namespace Project.BookingService.Repository.DoctorCalendarRepository;

public class DoctorCalendarRepository : MSSQLRepository<ApplicationDbContext, DoctorCalendar>, IDoctorCalendarRepository
{
    public DoctorCalendarRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

}
