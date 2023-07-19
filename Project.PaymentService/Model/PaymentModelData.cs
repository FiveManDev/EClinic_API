namespace Project.PaymentService.Model
{
    public class PaymentModelData
    {
        public string Email { get; set; }
        public Guid PaymentID { get; set; }
        public string FullName { get; set; }
        public double PaymentAmount { get; set; }
        public string BookingType { get; set; }
        public DateTime PaymentTime { get; set; }
        public Data.PaymentService PaymentService { get; set; }
        public string TransactionID { get; set; }
    }
}
