using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using PollSystem.Domain;

namespace PollSystem.Tests.Infrastructure;

public static class QuestionHelper
{
    private static readonly string[] _guids =
    {
        "9a142869-612b-46e4-98bc-ede15ed2cbad",
        "fc2740f2-3f3b-45a0-a83d-08ff923eaf0a",
        "aebd6530-1901-4a21-8f2e-887f043f3308",
        "4e9d1e7a-e868-4998-bfdd-6bc45ee7f3d3",
        "2e96c1f9-47f6-4fa6-b962-612a8068b7c1"
    };

    public static IEnumerable<Question> GetQuestions(List<Domain.Category> categories)
    {
        var fixture = new Fixture();

        return _guids.Select((t, i) => fixture.Build<Question>()
                .With(q => q.Id, Guid.Parse(t))
                .With(q => q.Category, categories[i])
                .Without(q => q.Comments)
                .Without(q => q.Options)
                .Without(q => q.Tags)
                .Without(q => q.QuestionSettings)
                .Create())
            .ToList();
    }
}