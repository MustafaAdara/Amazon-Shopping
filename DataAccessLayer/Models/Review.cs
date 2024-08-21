namespace Amazon.Models
{
    public class Review
    {
        public string ReviewId { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }
        public String UserId { get; set; }
        public ApplicationUser User { get; set; }  
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
