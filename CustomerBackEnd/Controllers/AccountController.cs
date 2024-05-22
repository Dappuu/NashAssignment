using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Newtonsoft.Json;
using ViewModels.Account;
using ViewModels.Product;

namespace CustomerBackEnd.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public AccountController(ILogger<HomeController> logger, IHttpClientFactory httpClient)
        {
            _logger = logger;
            _httpClient = httpClient.CreateClient("BackEndApi");
        }
		[HttpGet("login")]
		public IActionResult Login()
        {
            return View();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
				ModelState.AddModelError(string.Empty, "Invalid login attempt.");
				return View(loginDto);
			}
            string url = $"api/account/login";
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(url, loginDto);
            if (response.IsSuccessStatusCode)
            {
                var newUserDto = await response.Content.ReadFromJsonAsync<NewUserDto>();
                if (newUserDto is not null)
                {
                    var cookieOptions = new CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(7),
                        HttpOnly = true,
                        Secure = true
                    };
                    Response.Cookies.Append("jwt", newUserDto.Token, cookieOptions);
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
			return View(loginDto);
		}
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
				ModelState.AddModelError(string.Empty, "Invalid login attempt.");
				return View(registerDto);
			}
            string url = "api/account/register";
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(url, registerDto);
            if (response.IsSuccessStatusCode)
            {
                var newUserDto = await response.Content.ReadFromJsonAsync<NewUserDto>();
                if (newUserDto is not null)
                {
                    var cookieOptions = new CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(7),
                        HttpOnly = true,
                        Secure = true
                    };
                    Response.Cookies.Append("jwt", newUserDto.Token, cookieOptions);
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError(string.Empty, "Registration attempt failed.");
            return View(registerDto);
        }
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return RedirectToAction("Index", "Home");
        }
    }
}
