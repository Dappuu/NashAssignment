using CustomerBackEnd.Interfaces;

namespace CustomerBackEnd.Services
{
	public class AccountService : IAccountService
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public AccountService(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		public bool IsSignedIn()
		{
			var httpContext = _httpContextAccessor.HttpContext;
			if (httpContext is null)
			{
				return false;
			}
			var token = httpContext.Request.Cookies["jwt"];
			return !string.IsNullOrEmpty(token);
		}
	}
}
