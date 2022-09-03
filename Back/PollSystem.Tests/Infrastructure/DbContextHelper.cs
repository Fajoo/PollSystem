using System;
using Microsoft.EntityFrameworkCore;
using PollSystem.Persistence;

namespace PollSystem.Tests.Infrastructure;

public class DbContextHelper
{
    public static PollSystemDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<PollSystemDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new PollSystemDbContext(options);
        context.Database.EnsureCreated();

        context.Categories.AddRange(CategoryHelper.GetCategories());

        context.SaveChanges();
        return context;
    }

    public static void Destroy(PollSystemDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}