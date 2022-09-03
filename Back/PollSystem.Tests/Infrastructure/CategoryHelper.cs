using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;

namespace PollSystem.Tests.Infrastructure;

public static class CategoryHelper
{
    private static readonly string[] _guids =
    {
        "9ebf12d6-e0e5-412b-938e-f26a8fb7f6f1",
        "e8b48f15-5838-42af-b992-15142188a506",
        "0e10a64e-e927-4067-99c6-eed1f7922ce0",
        "15de1bae-6791-4395-b1e6-80b11d5cca76",
        "b4ff9c90-0224-4760-be54-de63b665ae13"
    };

    public static IEnumerable<Domain.Category> GetCategories()
    {
        var fixture = new Fixture();

        return _guids.Select(guid => fixture.Build<Domain.Category>()
                .With(q => q.Id, Guid.Parse(guid))
                .Without(q => q.Questions)
                .Create())
            .ToList();
    }
}