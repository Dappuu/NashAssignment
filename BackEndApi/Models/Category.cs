using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndApi.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? ParentId { get; set; }
        [NotMapped]
        public Category? Parent { get; set; }
        public List<Category>? SubCategories { get; set; } 
        public List<Product>? Products { get; set; }
    }
}
