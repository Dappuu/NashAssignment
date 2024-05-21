using System;
using System.Collections.Generic;
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
		public decimal Rating { get; set; }
		public string? UserId { get; set; }
		public int ProductId { get; set; }
		//public UserDto User { get; set; }
	}
}
