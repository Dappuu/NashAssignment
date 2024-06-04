using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViewModels.Category
{
	public class CreateRequestCategoryDto
	{
		[Required]
		public required string Name { get; set; }
		public string Description { get; set; } = string.Empty;
        public int? ParentId { get; set; }
	}
}
