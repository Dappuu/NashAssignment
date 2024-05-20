namespace BackEndApi.Models
{
	public class Size
	{
		public int Id { get; set; }
		public required string Name { get; set; } 
		public List<ProductSku>? ProductSkus { get; set; } 
	}
}
