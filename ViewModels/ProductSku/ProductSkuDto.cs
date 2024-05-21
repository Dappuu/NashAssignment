using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Image;
using ViewModels.OrderDetail;
using ViewModels.Size;
using static System.Net.Mime.MediaTypeNames;

namespace ViewModels.ProductSku
{
	public class ProductSkuDto
	{
		public int Id { get; set; }
		public int ProductId { get; set; }
		public int UnitsInStock { get; set; }
		public int UnitsSold { get; set; }
		public required string Size { get; set; }
	}
}
