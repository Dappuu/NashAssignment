using System.ComponentModel.DataAnnotations;

namespace ViewModels.Category
{
	public class UpdateRequestCategoryDto
	{
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
