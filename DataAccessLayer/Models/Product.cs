namespace Amazon.Models
{
    public class Product
    {
        public string ProductId { get; set; }
        // BarCode
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public int Quantity { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }

    }
}
