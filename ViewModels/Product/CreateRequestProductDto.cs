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
		public string Description { get; set; } = string.Empty;
		[Required]
		public required string Material { get; set; }
		[Required]
		public decimal Price { get; set; }
		public int Discount { get; set; } = 0;
		public bool Active { get; set; } = true;
        public string ImageUrl { get; set; } = string.Empty;
		public int CategoryId { get; set; }
    }
}
