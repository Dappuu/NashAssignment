using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Newtonsoft.Json;
using System.Security.Claims;
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
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, newUserDto.UserName),
                        new Claim(ClaimTypes.Email, newUserDto.Email),
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.Now.AddDays(7),
                    };
                    authProperties.StoreTokens(new[]
                    {
                        new AuthenticationToken { Name = "access_token", Value = newUserDto.Token}
                    });
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
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
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, newUserDto.UserName),
                        new Claim(ClaimTypes.Email, newUserDto.Email),
                        new Claim("access_token", newUserDto.Token)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.Now.AddDays(7),
                    };
                    authProperties.StoreTokens(new[]
                    {
                        new AuthenticationToken { Name = "access_token", Value = newUserDto.Token}
                    });
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError(string.Empty, "Registration attempt failed.");
            return View(registerDto);
        }
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("Cookies");
            return RedirectToAction("Index", "Home");
        }
    }
}
