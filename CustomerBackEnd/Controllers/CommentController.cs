using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using ViewModels.Account;
using ViewModels.Comment;

namespace CustomerBackEnd.Controllers
{
	public class CommentController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly HttpClient _httpClient;

		public CommentController(ILogger<HomeController> logger, IHttpClientFactory clientFactory)
		{
			_logger = logger;
			_httpClient = clientFactory.CreateClient("BackEndApi");
		}
		[HttpPost]
		public async Task<IActionResult> LeaveComment(CreateRequestCommentDto commentRequest)
		{
			if (!ModelState.IsValid)
			{
				ModelState.AddModelError(string.Empty, "Invalid login attempt.");
				return View(commentRequest);
			}
			var jwtToken = Request.Cookies["jwt"];
			if (string.IsNullOrEmpty(jwtToken))
			{
				return RedirectToAction("Login", "Account");
			}
			string url = $"api/comment";
			using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, url))
			{
				requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
				var jsonContent = JsonConvert.SerializeObject(commentRequest);
				requestMessage.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
				
				HttpResponseMessage response = await _httpClient.SendAsync(requestMessage);
				if (response.IsSuccessStatusCode)
				{
					return RedirectToAction("ProductDetail", "Product", new { id = commentRequest.ProductId });
				}
				else if (response.StatusCode == HttpStatusCode.Unauthorized)
				{
					return RedirectToAction("Login", "account");
				}
				else if (response.StatusCode == HttpStatusCode.BadRequest)
				{
					// Handle Bad Request error (e.g., display validation errors from API)
					var errorMessage = await response.Content.ReadAsStringAsync();
					ModelState.AddModelError(string.Empty, errorMessage);
					return RedirectToAction("ProductDetail", "Product", new { id = commentRequest.ProductId });
				}
				else
				{
					ModelState.AddModelError(string.Empty, "An error occurred while processing your request.");
					return RedirectToAction("ProductDetail", "Product", new { id = commentRequest.ProductId });
				}
			}
		}
	}
}
