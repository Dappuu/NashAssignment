using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndApi.Models
{
	public class Comment
	{
		public int Id { get; set; }
		public string Content { get; set; } = string.Empty;
		[Column(TypeName = ("Decimal(3, 2)"))]
        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
        public decimal Rating { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public string? UserId { get; set; }
		public User? User { get; set; } 
		public int ProductId { get; set; }
		public Product? Product { get; set; }
	}
}
