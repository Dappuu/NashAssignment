using System.ComponentModel.DataAnnotations;

namespace ViewModels.Category
{
	public class UpdateRequestCategoryDto
	{
		[Required]
		public required string Name { get; set; } 
	}
}
