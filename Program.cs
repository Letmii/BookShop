using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BookShop.Data;
using BookShop.Models;
using System.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DbContext, BookShopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookShopContext") ?? throw new InvalidOperationException("Connection string 'BookShopContext' not found.")));





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



SeedData.EnsurePopulated(app);

app.Run();
