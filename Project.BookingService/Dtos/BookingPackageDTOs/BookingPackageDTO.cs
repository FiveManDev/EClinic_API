using Project.BookingService.Data;

namespace Project.BookingService.Dtos.BookingPackageDTOs;

public class BookingPackageDTO
{
    public Guid BookingID { get; set; }
    public User User { get; set; }
    public double Price { get; set; }
    public DateTime BookingTime { get; set; }
    public Guid ServicePackageID { get; set; }
    public DateTime AppoinmentTime { get; set; }
    public BookingStatus BookingStatus { get; set; }
}
