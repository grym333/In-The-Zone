using InTheZone.Data.Entities;
using Microsoft.EntityFrameworkCore;

public class InTheZoneDbContext : DbContext
{
    public InTheZoneDbContext(DbContextOptions<InTheZoneDbContext> options) : base(options) { }

    public DbSet<Player> Players { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<HomeRun> HomeRuns { get; set; }
    public DbSet<Game> Games { get; set; }
    // Add other DbSets as needed for your entities

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HomeRun>()
            .HasOne(hr => hr.Player)
            .WithMany(p => p.HomeRuns)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<HomeRun>()
            .HasOne(hr => hr.Game)
            .WithMany(g => g.HomeRuns)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    }
}
    public class ApplicationDbContext : InTheZoneDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
