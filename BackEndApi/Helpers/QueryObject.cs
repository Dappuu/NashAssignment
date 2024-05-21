namespace BackEndApi.Helpers
{
	public class QueryObject
	{
		public string? Name { get; set; }
		public string? SortBy { get; set; }
		public bool IsDescending { get; set; } = false;
		public int pageNumber { get; set; } = 1;
		public int pageSize { get; set; } = 20;
	}
}
