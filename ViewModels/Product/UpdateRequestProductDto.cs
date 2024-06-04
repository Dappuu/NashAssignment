namespace ViewModels.Product
{
	public class UpdateRequestProductDto
	{
		public string Name { get; set; } = string.Empty;
        public string ProductSkuName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Material { get; set; } = string.Empty;
        public decimal Price { get; set; }
		public int Discount { get; set; }
		public string ImageUrl { get; set; } = string.Empty;
		public int UnitsInStock { get; set; }
		public bool Active { get; set; }
	}
}
