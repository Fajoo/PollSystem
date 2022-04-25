using Microsoft.EntityFrameworkCore;
using PollSystem.Domain;

namespace PollSystem.Application.Interfaces;

/// <summary>
/// Interface describing the database context
/// </summary>
public interface IPollSystemDbContext
{
    DbSet<Person> People { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}