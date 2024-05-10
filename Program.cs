using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcEcommerce.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Load configuration based on environment
if (builder.Environment.IsDevelopment())
{
    // Check if appsettings.Development.json exists, if not, create it with the default connection string
    var devSettingsFile = "appsettings.Development.json";
    if (!File.Exists(devSettingsFile))
    {
        var defaultSettings = new { ConnectionStrings = new { MvcItemEditContext = "Data Source=sqdb.db;" } };
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(defaultSettings, options);
        File.WriteAllText(devSettingsFile, json);
    }

    builder.Configuration.AddJsonFile(devSettingsFile, optional: true);
}
else
{
    // Check if appsettings.json exists, if not, create it with the default connection string
    var settingsFile = "appsettings.json";
    if (!File.Exists(settingsFile))
    {
        var defaultSettings = new { ConnectionStrings = new { MvcItemEditContext = "Data Source=sqdb.db;" } };
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(defaultSettings, options);
        File.WriteAllText(settingsFile, json);
    }

    builder.Configuration.AddJsonFile(settingsFile, optional: true);
}

// Retrieve SQLite connection string from environment variables
var connectionString = Environment.GetEnvironmentVariable("SQLITE_CONNECTION_STRING") ?? "Data Source=mydatabase.db";

builder.Services.AddDbContext<MvcItemEditContext>(options =>
    options.UseSqlite(connectionString));

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
