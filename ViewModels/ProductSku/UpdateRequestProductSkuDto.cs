using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.ProductSku
{
    public class UpdateRequestProductSkuDto
    {
        [Required]
        public int UnitsInStock { get; set; }
		[Required]
		public int SizeId { get; set; }
    }
}
