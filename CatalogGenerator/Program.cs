using CatalogGenerator;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient(s =>
{
    string catalogSource = File.ReadAllText("test-catalog.json");
    //catalogSource = Task.Run(() =>
    //{
    //    HttpClient client = new HttpClient();
    //    return client.GetStringAsync("https://trello.com/b/S9VlWoZn.json");
    //}).Result;

    Catalog catalog = JsonSerializer.Deserialize<Catalog>(catalogSource) ?? throw new Exception("Unable to load catalog");
    return catalog;
});
IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
builder.Services.Configure<CatalogSettings>(configuration.GetSection("Catalog"));
builder.Configuration.AddJsonFile("appsettings.user.json", true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
