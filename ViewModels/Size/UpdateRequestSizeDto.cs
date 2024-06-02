using System.ComponentModel.DataAnnotations;


namespace ViewModels.Size
{
    public class UpdateRequestSizeDto
    {
        [Required]
        public required string Name { get; set; }
    }
}
