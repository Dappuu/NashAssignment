using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.OrderDetail
{
	public class OrderDetailDto
	{
		public int Id { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
		public int Discount { get; set; }
		public int? ProductSkuId { get; set; }
		public int OrderId { get; set; }
	}
}
