using InTheZone.Data.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Player> Players { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<HomeRun> HomeRuns { get; set; }
    public DbSet<Game> Games { get; set; }
    // Add other DbSets as needed for your entities
}
