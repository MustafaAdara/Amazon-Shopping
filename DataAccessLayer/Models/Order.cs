using System.ComponentModel.DataAnnotations.Schema;

namespace Amazon.Models
{
    public class Order
    {
        public string OrderId { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime OrederDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
        public Status Status { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }

    }
    public enum Status
    {
        Pending,
        Shipped,
        Recieved,
        Canceled
    }
}
