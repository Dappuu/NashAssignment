using System.ComponentModel.DataAnnotations;
using System.Globalization;


namespace ViewModels.Size
{
    public class UpdateRequestSizeDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
