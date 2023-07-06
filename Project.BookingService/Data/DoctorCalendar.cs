namespace Project.BookingService.Data;

public class DoctorCalendar
{
    public Guid CalenderID { get; set; }
    public Guid DoctorID { get; set; }
    public DateTime Time { get; set; }

    // Foreign Key
    public ICollection<DoctorSchedule> DoctorSchedules { get; set; }
}
