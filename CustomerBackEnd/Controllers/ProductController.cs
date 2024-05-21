using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ViewModels.Category;
using ViewModels.Product;
using ViewModels.ProductSku;

namespace CustomerBackEnd.Controllers
{
	public class ProductController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IHttpClientFactory _clientFactory;

		public ProductController(ILogger<HomeController> logger, IHttpClientFactory clientFactory)
		{
			_logger = logger;
			_clientFactory = clientFactory;
		}
		public async Task<IActionResult> ProductDetail(int? id)
		{
			if (!id.HasValue)
			{
				return BadRequest("You must pass a product Id in the route!");
			}
			HttpClient client = _clientFactory.CreateClient(name: "BackEndApi");
			string url = $"api/product/{id}";
			HttpResponseMessage response = await client.GetAsync(url);
			if (!response.IsSuccessStatusCode)
			{
				return StatusCode((int)response.StatusCode, "Error retrieving product data from the API");
			}
			var content = await response.Content.ReadAsStringAsync();
			if (!string.IsNullOrWhiteSpace(content))
			{
				ProductDto? productDto = JsonConvert.DeserializeObject<ProductDto>(content);
				if (productDto is null)
				{
					return NotFound($"Cannot Deserialize!");
				}
				List<string> sizes = new();
				int idCategory = productDto.CategoryId;
				string urlCategory = $"api/category/{idCategory}";
				HttpResponseMessage responseCategory = await client.GetAsync(urlCategory);
				var contentCategory = await responseCategory.Content.ReadAsStringAsync();
				CategoryDto? categoryDto = JsonConvert.DeserializeObject<CategoryDto>(contentCategory);
				ViewData["Category"] = categoryDto is null ? string.Empty : categoryDto.Name;

				if (productDto.productSkusDto is not null)
				{
					 foreach(var productSkuDto in productDto.productSkusDto)
					{
						if (productSkuDto.UnitsInStock > 0)
						{
							sizes.Add(productSkuDto.Size);
						}
					}
					ViewData["Sizes"] = sizes;
				}
				return View(productDto);
			}
			return NotFound($"CategoryId {id} not found");
		}
	}
}
