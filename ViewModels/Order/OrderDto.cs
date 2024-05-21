using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.OrderDetail;

namespace ViewModels.Order
{
	public class OrderDto
	{
		public int Id { get; set; }
		public DateTime OrderDate { get; set; }
		public decimal Total { get; set; }
		public int Quantity { get; set; }
		public required string PhoneNumber { get; set; }
		public required string City { get; set; }
		public required string StreetAddress { get; set; }
		public List<OrderDetailDto>? OrderDetails { get; set; }
		public int UserId { get; set; }
	}
}
