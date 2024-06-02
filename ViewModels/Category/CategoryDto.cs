using System.ComponentModel.DataAnnotations.Schema;
using ViewModels.Product;

namespace ViewModels.Category
{
	public class CategoryDto
	{
		public int Id { get; set; }
		public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public int? ParentId { get; set; }
		public List<CategoryDto>? SubCategoriesDto { get; set; }
		public List<ProductDto>? Products { get; set; }

	}
}
