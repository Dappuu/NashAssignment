using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.User;

namespace ViewModels.Comment
{
    public class CommentDto
	{
		public int Id { get; set; }
		public required string Content { get; set; }
        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
        public decimal Rating { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? UserName { get; set; }
		public int ProductId { get; set; }
	}
}
