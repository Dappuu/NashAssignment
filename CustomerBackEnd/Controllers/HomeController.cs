using CustomerBackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using ViewModels.Category;

namespace CustomerBackEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _clientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            HttpClient client = _clientFactory.CreateClient(name: "BackEndApi");
            HttpRequestMessage request = new(method: HttpMethod.Get, requestUri: "api/category");

            //HttpResponseMessage response = await client.SendAsync(request);
            HttpResponseMessage response = await client.GetAsync("api/category");

            List<CategoryDto> model = JsonConvert.DeserializeObject<List<CategoryDto>>(response.Content.ReadAsStringAsync().Result);
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
