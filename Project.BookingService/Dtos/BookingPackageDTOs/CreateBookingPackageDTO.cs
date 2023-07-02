using Project.BookingService.Data;

namespace Project.BookingService.Dtos.BookingPackageDTOs;

public class CreateBookingPackageDTO
{
    public Guid UserID { get; set; }
    public double Price { get; set; }
    public DateTime BookingTime { get; set; }
    public Guid ServicePackageID { get; set; }
    public DateTime AppoinmentTime { get; set; }
}
