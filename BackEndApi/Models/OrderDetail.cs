using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndApi.Models
{
	public class OrderDetail
	{
		public int Id { get; set; }
		public int Quantity { get; set; }
		[Column(TypeName = ("Decimal(12, 2)"))]
		public decimal Price { get; set; }
		public int Discount { get; set; }
		public int? ProductSkuId { get; set; }
		public ProductSku? ProductSku { get; set; } 
		public int OrderId { get; set; }
		public Order Order { get; set; }
	}
}
