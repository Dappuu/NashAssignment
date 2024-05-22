using BackEndApi.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Web;
using ViewModels.Category;
using ViewModels.Product;


namespace CustomerBackEnd.Controllers
{
	public class CategoryController : Controller
	{
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

		public CategoryController(ILogger<HomeController> logger, IHttpClientFactory clientFactory)
		{
            _logger = logger;
            _httpClient = clientFactory.CreateClient("BackEndApi");
        }
		public async Task<IActionResult> Index([FromQuery]QueryObject query)
		{
			var builder = new UriBuilder(_httpClient.BaseAddress + "api/product");
			var queryParameters = HttpUtility.ParseQueryString(string.Empty);
			if (!string.IsNullOrWhiteSpace(query.Name)) 
			{
				queryParameters[nameof(query.Name)] = query.Name;
			}
			if (!string.IsNullOrWhiteSpace(query.SortBy))
			{
				queryParameters[nameof(query.SortBy)] = query.SortBy;
			}
			builder.Query = queryParameters.ToString();
			string url = builder.ToString();

			HttpResponseMessage response = await _httpClient.GetAsync(url);
			if (!response.IsSuccessStatusCode)
			{
				return StatusCode((int)response.StatusCode, "Error retrieving category data from the API");
			}
			var content = await response.Content.ReadAsStringAsync();
			if (string.IsNullOrWhiteSpace(content))
			{
				return View(new List<ProductDto>());
			}
			List<ProductDto>? model = JsonConvert.DeserializeObject<List<ProductDto>>(content);
			if (model is null || !model.Any())
			{
				return View(new List<ProductDto>());
			}
			return View(model);
		}
		public async Task<IActionResult> CategoryDetail(int? id)
		{
			if (!id.HasValue)
			{
				return BadRequest("You must pass a category Id in the route!");
			}
			string url = $"api/category/{id}";
			HttpResponseMessage response = await _httpClient.GetAsync(url);
			if (!response.IsSuccessStatusCode)
			{
				return StatusCode((int)response.StatusCode, "Error retrieving category data from the API");
			}
			var content = await response.Content.ReadAsStringAsync();
			List<ProductDto> productsDto = new();
			if (!string.IsNullOrWhiteSpace(content))
			{
				CategoryDto? categoriesDto = JsonConvert.DeserializeObject<CategoryDto>(content);
				if(categoriesDto is null)
				{
					return NotFound($"Cannot Deserialize!");
				}
				if (categoriesDto.SubCategoriesDto is not null)
				{
					List<CategoryDto> subCats = categoriesDto.SubCategoriesDto;
					foreach(var subcategoryDto in categoriesDto.SubCategoriesDto) 
					{
						if (subcategoryDto.Products is not null)
						foreach(var productDto in subcategoryDto.Products)
						{
								productsDto.Add(productDto);
						}
					}
					ViewData["SubCategory"] = subCats;
				}
				if (categoriesDto.Products is not null)
				{
					foreach(var productDto in categoriesDto.Products)
					{
						productsDto.Add(productDto);
					}
				}
				return View(productsDto);
			}
			return NotFound($"CategoryId {id} not found");
		}
	}
}
