using GameDevJobs.Models;
using Microsoft.EntityFrameworkCore;

namespace GameDevJobs.Data;

public class GameDevJobsContext : DbContext
{
    public DbSet<Offer> Offers { get; set; } = null!;
    public DbSet<Company> Companies { get; set; } = null!;
    public DbSet<Location> Locations { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<WorkingTime> WorkingTimes { get; set; } = null!;
    public DbSet<Seniority> Seniorities { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("User ID=postgres;Password=admin;Host=localhost;Port=5432;Database=GameDevJobs;Pooling=true;Connection Lifetime=0;");
    }

}

