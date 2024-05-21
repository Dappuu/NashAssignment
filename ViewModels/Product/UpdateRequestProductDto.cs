namespace ViewModels.Product
{
	public class UpdateRequestProductDto
	{
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public string Color { get; set; } = string.Empty;
		public string ImageUrl { get; set; } = string.Empty;
		public int UnitsInStock { get; set; }
		public int UnitsSold { get; set; }
		public bool Discontinued { get; set; }
		public int CategoryId { get; set; }
	}
}
