using Microsoft.EntityFrameworkCore;
using PollSystem.Domain;

namespace PollSystem.Application.Interfaces;

/// <summary>
/// Interface describing the database context
/// </summary>
public interface IPollSystemDbContext
{
    DbSet<Question> Questions { get; set; }
    DbSet<QuestionSettings> QuestionSettings { get; set; }
    DbSet<Tag> Tags { get; set; }
    DbSet<Category> Categories { get; set; }
    DbSet<Option> Options { get; set; }
    DbSet<Vote> Votes { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}