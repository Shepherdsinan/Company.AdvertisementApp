using AutoMapper;
using Company.AdvertisementApp.Business.Container;
using Company.AdvertisementApp.Business.Interfaces;
using Company.AdvertisementApp.Business.Mappings.AutoMapper;
using Company.AdvertisementApp.Business.Services;
using Company.AdvertisementApp.DataAccess.Contexts;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AdvertisementContext>(options => options.UseSqlite(connectionString));
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.ContainerDependencies();
builder.Services.CustomerValidator();
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