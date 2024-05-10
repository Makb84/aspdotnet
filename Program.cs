using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcEcommerce.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Load configuration based on environment
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddJsonFile("appsettings.Development.json", optional: true);
}
else
{
    // Use default connection string for production
    var defaultConnectionString = new Dictionary<string, string>
    {
        {"ConnectionStrings:MvcItemEditContext", "Data Source=sqdb.db;"}
    };

    builder.Configuration.AddJsonFile("appsettings.json", optional: true)
           .AddInMemoryCollection(defaultConnectionString.Select(kv => new KeyValuePair<string, string?>(kv.Key, kv.Value)));
}

var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? "Data Source=mydatabase.db";

builder.Services.AddDbContext<MvcItemEditContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcItemEditContext") ?? throw new InvalidOperationException("Connection string 'MvcItemEditContext' not found.")));

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

app.Run();
