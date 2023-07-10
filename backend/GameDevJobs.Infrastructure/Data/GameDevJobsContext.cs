using GameDevJobs.Domain.Entities;
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

    public GameDevJobsContext(DbContextOptions<GameDevJobsContext> options) : base(options) { }
}

