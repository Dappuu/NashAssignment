using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ViewModels.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int UnitsInStock { get; set; }
        public int UnitsSold { get; set; }
        public bool Discontinued { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CategoryId { get; set; }

    }
}
