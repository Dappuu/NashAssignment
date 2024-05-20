namespace BackEndApi.Models
{
	public class Image
	{
		public int Id { get; set; }
		public required string Url { get; set; }
		public Product? Product { get; set; }
	}
}
