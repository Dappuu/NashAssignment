using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViewModels.Category
{
	public class CreateRequestCategoryDto
	{
		[Required]
		public required string Name { get; set; }
		[Required]
        public required string Description { get; set; }
        public int? ParentId { get; set; }
	}
}
