using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndApi.Models
{
	public class Order
	{
		public int Id { get; set; }
		public DateTime OrderDate { get; set; } = DateTime.Now;
		[Column(TypeName = ("Decimal(12, 2)"))]
		public decimal Total { get; set; }
		public int Quantity { get; set; }
		public string PhoneNumber { get; set; } 
		public string City { get; set; } 
		public string StreetAddress { get; set; }
		public User AppUser { get; set; } 
		public List<OrderDetail>? OrderDetails { get; set; } 
	}
}
