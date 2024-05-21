using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using ViewModels.Category;
using ViewModels.Comment;
using ViewModels.Image;
using ViewModels.ProductSku;

namespace ViewModels.Product
{
	public class ProductDto
	{
		public int Id { get; set; }
		public required string Name { get; set; }
		public required string ProductSkuName { get; set; }
		public required string Description { get; set; }
		public required string Material { get; set; }
		public decimal Price { get; set; }
		public int Discount { get; set; } 
		public int UnitsInStock { get; set; }
		public int UnitsSold { get; set; }
		public DateTime CreatedDate { get; set; } 
		public bool Active { get; set; } 
		public int CategoryId { get; set; }
		public List<ProductSkuDto>? productSkusDto { get; set; }
		public List<CommentDto>? Comments { get; set; }
		public List<ImageDto>? Images { get; set; }
	}
}
