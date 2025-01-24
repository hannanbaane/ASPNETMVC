using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Task2.Data;
using Task2.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Task2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Task2Context") ?? throw new InvalidOperationException("Connection string 'MvcMovieContext' not found.")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();