using CustomerBackEnd.Controllers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ViewModels.Comment;
using ViewModels.Product;

namespace CustomerBackEnd.ViewComponents
{
    public class CommentViewComponent : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public CommentViewComponent(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("BackEndApi");
        }
        public async Task<IViewComponentResult> InvokeAsync(int productId)
        {
            string url = $"api/comment/product/{productId}";
            HttpResponseMessage response = await _httpClient.GetAsync(url); 
            if (!response.IsSuccessStatusCode)
            {
                return View(new List<CommentDto>());
            }
            var content = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(content))
            {
                return View(new List<CommentDto>());
            }
            List<CommentDto>? model = JsonConvert.DeserializeObject<List<CommentDto>>(content);
            if (model is null || !model.Any())
            {
                return View(new List<CommentDto>());
            }
            model = model.ToList();
            return View(model);
        }
    }
}
