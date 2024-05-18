using Microsoft.AspNetCore.Identity;

namespace BackEndApi.Models
{
	public class User : IdentityUser
	{

		public string? StreetAddress { get; set; }
		public string? City { get; set; } 
		public string? FirstName { get; set; } 
		public string? LastName { get; set; } 
		public DateTime DateOfBirth { get; set; } = DateTime.Now;
		public List<Order>? Orders { get; set; }
		public List<Comment>? Comments { get; set; } 
	}
}
