using CustomerBackEnd.Controllers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ViewModels.Category;

namespace CustomerBackEnd.ViewComponents
{
	public class NavBarViewComponent : ViewComponent
	{
		private readonly IHttpClientFactory _clientFactory;

		public NavBarViewComponent(IHttpClientFactory clientFactory)
		{
			_clientFactory = clientFactory;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			HttpClient client = _clientFactory.CreateClient(name: "BackEndApi");
			string url = $"api/category";
			HttpResponseMessage response = await client.GetAsync(url);
			if (!response.IsSuccessStatusCode)
			{
				return View(new List<CategoryDto>());
			}
			var content = await response.Content.ReadAsStringAsync();
			List<CategoryDto>? categoriesDto = JsonConvert.DeserializeObject<List<CategoryDto>>(content);
			if (categoriesDto == null)
			{
				return View(new List<CategoryDto>());
			}
			return View(categoriesDto);
		}
	}
}
