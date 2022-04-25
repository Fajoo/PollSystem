using Microsoft.EntityFrameworkCore;
using PollSystem.Application.Interfaces;
using PollSystem.Domain;
using PollSystem.Persistence.EntityTypeConfigurations;

namespace PollSystem.Persistence;

/// <summary>
/// Database context
/// </summary>
public class PollSystemDbContext : DbContext, IPollSystemDbContext
{
    /// <summary>
    /// People table with data
    /// </summary>
    public DbSet<Person> People { get; set; }

    public PollSystemDbContext(DbContextOptions<PollSystemDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new PersonConfiguration());
        base.OnModelCreating(builder);
    }
}