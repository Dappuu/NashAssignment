using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViewModels.Category
{
	public class CreateRequestCategoryDto
	{
		[Required]
		[MinLength(10)]
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
        public int? ParentId { get; set; }
	}
}
