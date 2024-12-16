using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapRazorPages();
        await app.RunAsync();
    }
    // In Program.cs or Startup.cs
public void ConfigureServices(IServiceCollection services)
{
    // ... other services ...

    services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))); 
    services.AddScoped<IPlayerRepository, PlayerRepository>();
    services.AddScoped<ITeamRepository, TeamRepository>();
    // Add more repository registrations here.
     services.AddScoped<IHomeRunRepository, HomeRunRepository>();
    services.AddSingleton<IConfiguration>(Configuration); // Add configuration
    // ... other services ...
}
}
