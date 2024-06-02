using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViewModels.Product
{
	public class CreateRequestProductDto
	{
		[Required]
		public required string Name { get; set; }
		[Required]
		public required string ProductSkuName { get; set; }
		[Required]
		public required string Description { get; set; }
		[Required]
		public required string Material { get; set; }
		[Required]
		public decimal Price { get; set; }
		public int Discount { get; set; } = 0;
		public bool Active { get; set; } = true;
		public int UnitsInStock { get; set; }
		public int CategoryId { get; set; }
        public string? ImageUrl { get; set; }
    }
}
