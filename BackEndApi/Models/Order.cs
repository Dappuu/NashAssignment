using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndApi.Models
{
	public class Order
	{
		public int Id { get; set; }
		public DateTime OrderDate { get; set; } = DateTime.Now;
		[Column(TypeName = ("Decimal(10, 2)"))]
		public decimal Total { get; set; }
		public int Quantity { get; set; }
		public required string PhoneNumber { get; set; } 
		public required string City { get; set; } 
		public required string StreetAddress { get; set; }
		public User? AppUser { get; set; } 
		public List<OrderDetail>? OrderDetails { get; set; } 
	}
}
