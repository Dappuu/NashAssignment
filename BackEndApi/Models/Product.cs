using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
		public int CategoryId { get; set; }
		public virtual Category Category { get; set; } = new();
		public List<ProductSku> productSkus { get; set; } = new();
		public List<Comment> Comments { get; set; } = new();
	}
}
