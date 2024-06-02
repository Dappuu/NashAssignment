using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using ViewModels.Category;
using ViewModels.Comment;
using ViewModels.ProductSku;

namespace ViewModels.Product
{
	public class ProductDto
	{
		public int Id { get; set; }
		public required string Name { get; set; }
		public required string ProductSkuName { get; set; }
		public required string Material { get; set; }
		public string Description { get; set; } = string.Empty;
        public decimal? Rating { get; set; }
        public decimal Price { get; set; }
		public int Discount { get; set; } 
		public int UnitsInStock { get; set; }
		public int UnitsSold { get; set; }
        public string? ImageUrl { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public bool Active { get; set; } 
		public int CategoryId { get; set; }
		public List<ProductSkuDto>? productSkusDto { get; set; }
		public List<CommentDto>? Comments { get; set; }
    }
}