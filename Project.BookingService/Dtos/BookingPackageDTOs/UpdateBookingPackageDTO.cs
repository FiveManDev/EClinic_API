namespace Project.BookingService.Dtos.BookingPackageDTOs;

public class UpdateBookingPackageDTO
{
    public Guid BookingID { get; set; }
    public double Price { get; set; }
    public Guid ServicePackageID { get; set; }
    public DateTime AppoinmentTime { get; set; }
}
