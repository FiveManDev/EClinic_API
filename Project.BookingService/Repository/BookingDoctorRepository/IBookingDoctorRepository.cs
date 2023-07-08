using Project.BookingService.Data;
using Project.Data.Repository.MSSQL;

namespace Project.BookingService.Repository.BookingDoctorRepository;

public interface IBookingDoctorRepository : IMSSQLRepository<BookingDoctor>
{

}
