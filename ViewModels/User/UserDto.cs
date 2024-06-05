using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ViewModels.Comment;
using ViewModels.Order;

namespace ViewModels.User
{
	public class UserDto
	{
		public string UserId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string StreetAddress { get; set; } = string.Empty;
		public string City { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
        public string AvatarUrl { get; set; } = string.Empty;
		public DateTime DateOfBirth { get; set; } = DateTime.Now;
		public string Email { get; set; } = string.Empty;
		public List<OrderDto>? Orders { get; set; }
		public List<CommentDto>? Comments { get; set; }
	}
}