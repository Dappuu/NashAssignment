using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndApi.Models
{
	public class Comment
	{
		public int Id { get; set; }
		public required string Content { get; set; } 
		[Column(TypeName = ("Decimal(1, 1)"))]
		public decimal Rating { get; set; }
		public string? UserId { get; set; }
		public User? User { get; set; } 
		public int ProductId { get; set; }
		public required Product Product { get; set; }
	}
}
