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
        public string? ImageUrl { get; set; }
        public int UnitsInStock { get; set; }
        public bool Discontinued { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = new Category();    
        public virtual List<OrderDetail>? OrderDetails { get; set; }
        public List<Comment>? Comments { get; set; } 
    }
}
