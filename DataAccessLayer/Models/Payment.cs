namespace Amazon.Models
{
    public class Payment
    {
        public string PaymentId { get; set; }
        public string OrderId { get; set; }
        public Order Order { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
    }
}
