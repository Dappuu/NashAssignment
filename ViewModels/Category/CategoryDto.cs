using System.ComponentModel.DataAnnotations.Schema;
using ViewModels.Product;

namespace ViewModels.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? ParentId { get; set; }
        public List<ProductDto>? productsDto { get; set;
        }
    }
}
