using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndApi.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        [Column(TypeName = ("Decimal(1, 1)"))]
        public decimal Rating { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = new();
        public int ProductId { get; set; }
        public Product Product { get; set; } = new();
    }
}
