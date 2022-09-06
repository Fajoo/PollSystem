using System;
using System.Linq;
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

        var categories = CategoryHelper.GetCategories();

        context.Categories.AddRange(categories);
        context.Questions.AddRange(QuestionHelper.GetQuestions(categories.ToList()));

        context.SaveChanges();
        return context;
    }

    public static void Destroy(PollSystemDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}