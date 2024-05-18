using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndApi.Models
{
	public class ProductSku
	{
		public int Id { get; set; }
		public int ProductId { get; set; }
		public Product Product { get; set; } 
		public int SizeId { get; set; }
		public Size Size { get; set; } 
		public int UnitsInStock { get; set; }
		public int UnitsSold { get; set; } = 0;
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public DateTime UpdatedDate { get; set; } = DateTime.Now;
		public List<OrderDetail>? OrderDetails { get; set; }
		public List<Image>? Images { get; set; } 

	}
}
