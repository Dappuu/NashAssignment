using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndApi.Models
{
	public class ProductSku
	{
		public int ProductSkuId { get; set; }
		[Column(TypeName = ("Decimal(12, 2)"))]
		public decimal Price { get; set; }
		public int ProductId { get; set; }
		public Product Product { get; set; } = new();
		public int SizeId { get; set; }
		public Size Size { get; set; } = new();
		public int UnitsInStock { get; set; }
		public int UnitsSold { get; set; }
		public bool Active { get; set; } = true;
		public DateTime CreatedDate { get; set; } = new DateTime();
		public DateTime UpdatedDate { get; set; } = new DateTime();
		public virtual List<OrderDetail> OrderDetails { get; set; } = new();
		public List<Image> Images { get; set; } = new();

	}
}
