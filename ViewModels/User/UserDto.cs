using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Comment;
using ViewModels.Order;

namespace ViewModels.User
{
	public class UserDto
	{
		public string? StreetAddress { get; set; }
		public string? City { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public List<OrderDto>? Orders { get; set; }
		public List<CommentDto>? Comments { get; set; }
	}
}
