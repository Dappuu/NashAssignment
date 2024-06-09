using System.ComponentModel.DataAnnotations;

namespace ViewModels.Category
{
	public class UpdateRequestCategoryDto
	{
        [Required]
        public string Name { get; set; } = string.Empty;
		[Required]
		public string Description { get; set; } = string.Empty;
    }
}
