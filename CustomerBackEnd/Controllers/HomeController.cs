using CustomerBackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using ViewModels.Category;
using ViewModels.Product;

namespace CustomerBackEnd.Controllers
{
	public class HomeController : Controller
	{
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _httpClient = clientFactory.CreateClient("BackEndApi");
        }
        public async Task<IActionResult> Index()
		{
			string url = "api/product?";
			url += $"SortBy={System.Web.HttpUtility.UrlEncode("createdDate")}&";
			url += $"IsDescending={System.Web.HttpUtility.UrlEncode("true")}";
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
			
			model = model.Take(6).ToList();
			return View(model);
		}
		
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
