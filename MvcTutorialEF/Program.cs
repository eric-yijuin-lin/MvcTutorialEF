using Microsoft.EntityFrameworkCore;
using MvcTutorialEF.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. (service container = 服務容器)
// DI 注入 SOLID
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<HomeworkDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

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
