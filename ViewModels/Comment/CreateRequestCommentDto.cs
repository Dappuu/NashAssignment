using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Comment
{
    public class CreateRequestCommentDto
    {
        [Required]
        public string Content { get; set; } = string.Empty;
        [Required]
        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
        public decimal Rating { get; set; }
		[Required]
		public int ProductId { get; set; }
    }
}
