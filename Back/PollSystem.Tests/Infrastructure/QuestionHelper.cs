using System;
using System.Collections.Generic;
using AutoFixture;
using PollSystem.Domain;

namespace PollSystem.Tests.Infrastructure;

public static class QuestionHelper
{
    public static IEnumerable<Question> GetQuestions()
    {
        var fixture = new Fixture();
        
        return new List<Question>
        {
            fixture.Build<Question>()
                .With(q => q.Id, Guid.Parse("29a31c2a-5e77-4334-88b5-f0b16c5b83e6"))
                .Create(),
            fixture.Build<Question>()
                .With(q => q.Id, Guid.Parse("dbd26353-6a48-4733-9fef-9bdc6d3fea6c"))
                .Create(),
            fixture.Build<Question>()
                .With(q => q.Id, Guid.Parse("45390ebd-c0f8-4b7e-b55d-cbeeef88b3d8"))
                .Create(),
            fixture.Build<Question>()
                .With(q => q.Id, Guid.Parse("e2cc195e-23e2-4893-a45a-7dc460628c71"))
                .Create(),
            fixture.Build<Question>()
                .With(q => q.Id, Guid.Parse("b725add7-073f-4f88-8029-546241897b58"))
                .Create()
        };
    }
}