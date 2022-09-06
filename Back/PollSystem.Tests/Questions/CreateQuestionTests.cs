using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using PollSystem.Application.CQRS.Categories.Commands.CreateCategory;
using PollSystem.Application.CQRS.Questions.Commands.CreateQuestion;
using PollSystem.Tests.Infrastructure;
using Xunit;

namespace PollSystem.Tests.Questions;

public class CreateQuestionTests : TestCommand
{
    [Fact]
    public async Task CreateQuestionCommandHandler_Success()
    {
        // Arrange
        var handler = new CreateQuestionCommandHandler(Context);

        // Act
        var actual = await handler.Handle(new CreateQuestionCommand()
        {
            CategoryId = Guid.Parse("9ebf12d6-e0e5-412b-938e-f26a8fb7f6f1"),
            Name = "NameTest1",
            LoginUser = "LoginTest1"
        }, CancellationToken.None);

        // Assert
        Assert.NotNull(actual);
        Assert.NotNull(Context.Questions.FirstOrDefault(q => q.Name == "NameTest1" && q.LoginUser == "LoginTest1"));
    }

    [Fact]
    public void CreateCategoryCommandHandler_ValidationException()
    {
        // Arrange
        var handler = new CreateQuestionCommandHandler(Context);
        var command = new CreateQuestionCommand()
        {
            CategoryId = Guid.Empty
        };

        // Assert
        Assert.ThrowsAsync<ValidationException>(async () => await handler.Handle(command, CancellationToken.None));
    }
}