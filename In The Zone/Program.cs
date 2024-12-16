using InTheZone.Data;
using InTheZone.Data.Repositories;
using InTheZone.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using InTheZone.Security;

var builder = WebApplication.CreateBuilder(args);

// Configuration
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

// Configure logging
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddConsole();
    loggingBuilder.AddDebug();
});

// Register repositories
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<IHomeRunRepository, HomeRunRepository>();

// Register services
builder.Services.AddScoped<IStatsApiService, StatsApiService>();
builder.Services.AddScoped<IGameVisualizationService, GameVisualizationService>();
builder.Services.AddScoped<IPredictionService, PredictionService>();
builder.Services.AddScoped<ISecurityManager, SecurityManager>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddHttpClient<IMlbStatsApiProxy, MlbStatsApiProxy>("StatsApi", client =>
{
    client.BaseAddress = new Uri(configuration["MLBStatsAPI:BaseUrl"]);
    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
    client.DefaultRequestHeaders.UserAgent.ParseAdd("InTheZoneApp");
});

// Register other services...
// Register other services as needed

builder.Services.AddControllersWithViews(); // If using MVC
builder.Services.AddRazorPages(); // If using Razor Pages

// Add any other services required by your application here.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Map controllers and Razor Pages
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
using Google.Cloud.AIPlatform.V1;
using Grpc.Core;
using System.Net.Http.Headers;
using InTheZone.Models;
    public interface IPredictionService
    {
        Task<string> PredictPitchOutcomeAsync(Model input);
    }
    public class Model
    {
        public string PitchType { get; set; }
        public int Velocity { get; set; }
        public int SpinRate { get; set; }
        // Add other relevant features
    }
