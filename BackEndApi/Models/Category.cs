using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndApi.Models
{
	public class Category
	{
		public int Id { get; set; }
		public string Name { get; set; } 
		public int? ParentId { get; set; }
		[NotMapped]
		public Category? Parent { get; set; }
		public List<Category>? SubCategories { get; set; } 
		public List<Product>? Products { get; set; } 
	}
}
