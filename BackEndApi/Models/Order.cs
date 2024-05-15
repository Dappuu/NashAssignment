using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        [Column(TypeName = ("Decimal(12, 2)"))]
        public decimal OrderTotal { get; set; }
        public int Quantity { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string? StreetAddress { get; set; }
        public string City { get; set; } = string.Empty;
        public User AppUser { get; set; } = new User();
        public List<OrderDetail>? OrderDetails { get; set; }
    }
}
