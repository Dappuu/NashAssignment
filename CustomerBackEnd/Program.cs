using CustomerBackEnd.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Globalization;
using System.Net.Http.Headers;
using ViewModels.Account;

var culture = new CultureInfo("vi-VN");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddIdentity<NewUserDto, IdentityRole>()
//.AddDefaultTokenProviders();

// Register the AccountService and IHttpContextAccessor
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddAuthentication(options =>
{
	options.DefaultScheme = "Cookies"; // Set the default authentication scheme
	options.DefaultChallengeScheme = "oidc"; // Set the default challenge scheme (if using OIDC)
})
.AddCookie("Cookies"); // Add cookie authentication

builder.Services.AddHttpClient(name: "BackEndApi",
  configureClient: async (providers, options) =>
  {
	  var httpContextAccesor = providers.GetRequiredService<IHttpContextAccessor>();
	  if (httpContextAccesor.HttpContext != null)
	  {
			var accessToken = await httpContextAccesor.HttpContext.GetTokenAsync("access_token");
			options.BaseAddress = new Uri("https://localhost:7089/");
			options.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType: "application/json", quality: 1.0));
			
		  if(!string.IsNullOrEmpty(accessToken))
		  {
			  options.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
		  }
	  }
  });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
