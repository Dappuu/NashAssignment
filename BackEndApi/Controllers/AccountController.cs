using BackEndApi.Interfaces;
using BackEndApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Account;


namespace BackEndApi.Controllers
{
	[Route("api/account")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		private readonly ITokenService _tokenService;

		public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_tokenService = tokenService;
		}
		[HttpPost("login")]
		public async Task<IActionResult> Login(LoginDto loginDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var user = _userManager.Users.FirstOrDefault(u => u.UserName == loginDto.UserName);
			if (user == null)
			{
				return Unauthorized("Invalid username or password.");
			}
			var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
			if (!result.Succeeded)
			{
				return Unauthorized("Invalid username or password.");
			}
			return Ok(new NewUserDto
			{
				UserName = user.UserName!,
				Email = user.Email!,
				Token = _tokenService.CreateToken(user)
			});
		}
		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
		{
			try
			{
				if(!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}
				var User = new User
				{
					UserName = registerDto.UserName,
					Email = registerDto.Email
				};
				var createUser = await _userManager.CreateAsync(User, registerDto.Password);
				if (createUser.Succeeded)
				{
					var roleResult = await _userManager.AddToRoleAsync(User, "User");
					if (roleResult.Succeeded)
					{
						return Ok(
							new NewUserDto
							{
								UserName = User.UserName,
								Email = User.Email,
								Token = _tokenService.CreateToken(User)
							});
					}
					else
					{
						return StatusCode(500, roleResult.Errors);
					}
				}
				else
				{
					return StatusCode(500, createUser.Errors);
				}
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex);
			}
		}
		[HttpPost("logout")]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return Ok("User logged out succesfully.");
		}
	}
}