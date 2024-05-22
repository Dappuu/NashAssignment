using CustomerBackEnd.Interfaces;
using CustomerBackEnd.Services;
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
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddHttpClient(name: "BackEndApi",
  configureClient: options =>
  {
	  options.BaseAddress = new Uri("https://localhost:7089/");
	  options.DefaultRequestHeaders.Accept.Add(
		new MediaTypeWithQualityHeaderValue(mediaType: "application/json", quality: 1.0));
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

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
