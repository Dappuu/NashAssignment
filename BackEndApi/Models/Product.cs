using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndApi.Models
{
	public class Product
	{
		public int Id { get; set; }
		public required string Name { get; set; } 
		public required string ProductSkuName { get; set; } 
		public required string Material { get; set; }
		public string Description { get; set; } = string.Empty;
        [Column(TypeName = ("Decimal(3, 2)"))]
        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
        public decimal? Rating { get; set; }
        [Column(TypeName = ("Decimal(10, 2)"))]
		public decimal Price { get; set; }
		public int Discount { get; set; } = 0;
		public int UnitsInStock { get; set; }
		public int UnitsSold { get; set; } = 0;
        public string ImageUrl { get; set; } = string.Empty;
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public DateTime UpdatedDate { get; set; } = DateTime.Now;
		public bool Active { get; set; } = true;
		public int CategoryId { get; set; }
		public Category? Category { get; set; } 
		public List<ProductSku>? productSkus { get; set; }
		public List<Comment>? Comments { get; set; }
    }
}
