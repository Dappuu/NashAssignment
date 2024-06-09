using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViewModels.Product
{
	public class CreateRequestProductDto
	{
		[Required]
		public string Name { get; set; } = string.Empty;
		[Required]
		public string ProductSkuName { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		[Required]
		public string Material { get; set; } = string.Empty;
		[Required]
		public decimal Price { get; set; }
		public int Discount { get; set; } = 0;
		public bool Active { get; set; } = true;
        public string ImageUrl { get; set; } = string.Empty;
		public int CategoryId { get; set; }
    }
}
