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
    public DbSet<Question> Questions { get; set; }
    public DbSet<QuestionSettings> QuestionSettings { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Option> Options { get; set; }
    public DbSet<Vote> Votes { get; set; }
    public DbSet<Comment> Comments { get; set; }

    public PollSystemDbContext(DbContextOptions<PollSystemDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new QuestionConfigurator());
        base.OnModelCreating(builder);
    }
}