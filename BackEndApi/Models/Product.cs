using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        [Column(TypeName = ("Decimal(12, 2)"))]
        public decimal Price { get; set; }
        public string Color { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int UnitsInStock { get; set; }
        public int UnitsSold { get; set; }
        public bool Discontinued { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = new();
        public virtual List<OrderDetail> OrderDetails { get; set; } = new();
        public List<Comment>? Comments { get; set; } 
    }
}
