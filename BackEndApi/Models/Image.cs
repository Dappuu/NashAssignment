namespace BackEndApi.Models
{
	public class Image
	{
		public int Id { get; set; }
		public string Url { get; set; } = string.Empty;
		public ProductSku ProductSku { get; set; } = new();
	}
}
