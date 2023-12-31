using AutoMapper;
using Company.AdvertisementApp.Business.Container;
using Company.AdvertisementApp.Business.Helper;
using Company.AdvertisementApp.Business.Interfaces;
using Company.AdvertisementApp.Business.Mappings.AutoMapper;
using Company.AdvertisementApp.Business.Services;
using Company.AdvertisementApp.DataAccess.Contexts;
using Company.AdvertisementApp.UI.Mappings.AutoMapper;
using Company.AdvertisementApp.UI.Models;
using Company.AdvertisementApp.UI.ValidationRules;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//Connection string appsettings.json inculude
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AdvertisementContext>(options => options.UseSqlite(connectionString));
//Business layer dependency injection
builder.Services.DependencyExtension();
//Business layer validation
builder.Services.CustomerValidator();
//Model Validation
builder.Services.AddTransient<IValidator<UserCreateModel>, UserCreateModelValidator>();
//Mapping
var profiles = ProfileHelper.GetProfiles();
profiles.Add(new UserCreateModelProfile());
var mapperConfiguration = new MapperConfiguration(opt => { opt.AddProfiles(profiles); });
var mapper = mapperConfiguration.CreateMapper();
builder.Services.AddSingleton(mapper);
//Custom Cookie based authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
{
    opt.Cookie.Name = "Company.AdvertisementApp";
    opt.Cookie.HttpOnly = true;
    opt.Cookie.SameSite = SameSiteMode.Strict;
    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    opt.ExpireTimeSpan = TimeSpan.FromDays(20);
    opt.LoginPath = new PathString("/Account/SignIn");
    opt.LogoutPath = new PathString("/Account/LogOut");
    opt.AccessDeniedPath = new PathString("/Account/AccessDenied");
});
// Add services to the container.
builder.Services.AddControllersWithViews();

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
app.UseAuthentication(); //Custom Cookie based authentication
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AdvertisementContext>();
    dbContext.Database.EnsureCreated();
}

app.Run();