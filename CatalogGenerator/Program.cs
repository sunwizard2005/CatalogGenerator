using CatalogGenerator;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestSharp;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient(s =>
{
    CatalogSettings settings = s.GetRequiredService<IOptions<CatalogSettings>>().Value;


    RestClient client = new RestClient("https://trello.com");
    RestRequest request = new RestRequest($"/b/{settings.TrelloId}.json", Method.GET);
    var response = client.Execute(request); // ????? How about error handling?

    string catalogSource = response.Content;

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

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseAuthorization();

app.MapRazorPages();

app.Run();
