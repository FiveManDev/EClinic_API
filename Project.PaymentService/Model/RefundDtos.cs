namespace Project.PaymentService.Model
{
    public class RefundDtos
    {
        public Guid RefundID { get; set; }
        public DateTime RefundTime { get; set; }
        public double RefundAmount { get; set; }
        public string RefundReason { get; set; }
    }
}
