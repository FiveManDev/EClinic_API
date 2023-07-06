using Project.NotificationService.Data;

namespace Project.NotificationService.Dtos
{
    public class PaymentModel
    {
        public Guid PaymentID { get; set; }
        public double PaymentAmount { get; set; }
        public Guid BookingID { get; set; }
        public DateTime PaymentTime { get; set; }
        public PaymentService PaymentService { get; set; }
    }
}
