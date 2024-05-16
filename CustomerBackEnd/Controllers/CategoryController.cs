using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ViewModels.Category;
using ViewModels.SubCatgegory;

namespace CustomerBackEnd.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _clientFactory;

        public CategoryController(ILogger<HomeController> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HttpClient client = _clientFactory.CreateClient(name: "BackEndApi");
            //HttpRequestMessage request = new(method: HttpMethod.Get, requestUri: "api/category");

            //HttpResponseMessage response = await client.SendAsync(request);
            HttpResponseMessage response = await client.GetAsync("api/category");

            List<CategoryDto> model = JsonConvert.DeserializeObject<List<CategoryDto>>(response.Content.ReadAsStringAsync().Result);
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> SubCategory()
        {
            HttpClient client = _clientFactory.CreateClient(name: "BackEndApi");
            HttpResponseMessage response = await client.GetAsync("api/category/subcategory");

            List<SubCategoryDto> model = JsonConvert.DeserializeObject<List<SubCategoryDto>>(response.Content.ReadAsStringAsync().Result);
            return View(model);
        }
    }
}
