using System;
using System.Linq;
using PollSystem.Persistence;
using Xunit;

namespace PollSystem.Tests.Infrastructure;

public class DbContextHelperTests
{
    private readonly PollSystemDbContext _context;

    public DbContextHelperTests()
    {
        _context = DbContextHelper.CreateContext();
    }

    [Fact]
    public void Is_Context_Created()
    {
        Assert.NotNull(_context);
    }

    [Fact]
    public void Is_Category_Created()
    {
        var expected = Guid.Parse("9ebf12d6-e0e5-412b-938e-f26a8fb7f6f1");

        var category = _context.Categories.FirstOrDefault();
        var actual = category.Id;

        Assert.Equal(expected, actual);
    }

    //[Fact]
    //public void Is_Questions_Created()
    //{
    //    var expected = "29a31c2a-5e77-4334-88b5-f0b16c5b83e6";

    //    var question = _context.Questions.FirstOrDefault();
    //    var actual = question.Id;

    //    Assert.True(expected.Equals(actual));
    //}
}