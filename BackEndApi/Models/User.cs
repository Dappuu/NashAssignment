using Microsoft.AspNetCore.Identity;

namespace BackEndApi.Models
{
	public class User : IdentityUser
	{
		public string StreetAddress { get; set; } = string.Empty;
		public string City { get; set; } = string.Empty;
		public string FirstName { get; set; } = string.Empty; 
		public string LastName { get; set; } = string.Empty;
        public string AvatarUrl { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
		public List<Order>? Orders { get; set; }
		public List<Comment>? Comments { get; set; } 
	}
}
