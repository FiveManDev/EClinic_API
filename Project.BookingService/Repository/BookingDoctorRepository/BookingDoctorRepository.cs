using Project.BookingService.Data;
using Project.BookingService.Data.Configurations;
using Project.Data.Repository.MSSQL;

namespace Project.BookingService.Repository.BookingDoctorRepository;

public class BookingDoctorRepository : MSSQLRepository<ApplicationDbContext, BookingDoctor>, IBookingDoctorRepository
{
    public BookingDoctorRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

}
