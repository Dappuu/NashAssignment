using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;

namespace BackEndApi.Models
{
    public class User : IdentityUser
    {

        public string? StreetAddress { get; set; }
        public string City { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public List<Order>? Orders { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
