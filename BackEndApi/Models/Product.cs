using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndApi.Models
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; } 
		public string ProductSkuName { get; set; } 
		public string Description { get; set; } 
		public string Material { get; set; } 
		[Column(TypeName = ("Decimal(12, 2)"))]
		public decimal Price { get; set; }
		public int Discount { get; set; } = 0;
		public int UnitsInStock { get; set; }
		public int UnitsSold { get; set; } = 0;
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public DateTime UpdatedDate { get; set; } = DateTime.Now;
		public bool Active { get; set; } = true;
		public int CategoryId { get; set; }
		public Category Category { get; set; }
		public List<ProductSku>? productSkus { get; set; }
		public List<Comment>? Comments { get; set; } 
	}
}
