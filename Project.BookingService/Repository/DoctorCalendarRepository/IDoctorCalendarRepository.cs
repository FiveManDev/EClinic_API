using Project.BookingService.Data;
using Project.Data.Repository.MSSQL;

namespace Project.BookingService.Repository.DoctorCalendarRepository;

public interface IDoctorCalendarRepository : IMSSQLRepository<DoctorCalendar>
{

}
