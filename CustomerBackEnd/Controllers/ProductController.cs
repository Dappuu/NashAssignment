using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using ViewModels.Category;
using ViewModels.Product;
using ViewModels.ProductSku;

namespace CustomerBackEnd.Controllers
{
	public class ProductController : Controller
	{
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;
        public ProductController(ILogger<HomeController> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _httpClient = clientFactory.CreateClient("BackEndApi");
        }
        public async Task<IActionResult> ProductDetail(int? id)
		{
			if (!id.HasValue)
			{
				return BadRequest("You must pass a product Id in the route!");
			}
			string url = $"api/product/{id}";
			HttpResponseMessage response = await _httpClient.GetAsync(url);
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
				HttpResponseMessage responseCategory = await _httpClient.GetAsync(urlCategory);
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
