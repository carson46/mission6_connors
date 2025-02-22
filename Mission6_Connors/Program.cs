using Microsoft.EntityFrameworkCore;
using Mission6_Connors.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure Entity Framework Core to use the existing SQLite database.
builder.Services.AddDbContext<MovieAdditionContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DBConnection"))
        .LogTo(Console.WriteLine, LogLevel.Information);
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Default HSTS value is 30 days.
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
