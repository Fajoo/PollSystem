using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PollSystem.Application.CQRS.Categories.Commands.DeleteCategory;
using PollSystem.Tests.Infrastructure;
using Xunit;

namespace PollSystem.Tests.Category;

public class DeleteCategoryTests : TestCommand
{
    [Fact]
    public async Task DeleteCategoryCommandHandler_Success()
    {
        // Arrange   
        var handler = new DeleteCategoryCommandHandler(Context);
        var id = Guid.Parse("9ebf12d6-e0e5-412b-938e-f26a8fb7f6f1");

        // Act
        var act = await handler.Handle(new DeleteCategoryCommand
        {
            Id = id
        }, CancellationToken.None);

        // Assert
        Assert.Null(Context.Categories.SingleOrDefault(c => c.Id == id));
    }

    [Fact]
    public void DeleteCategoryCommandHandler_Exception()
    {
        // Arrange   
        var handler = new DeleteCategoryCommandHandler(Context);
        var command = new DeleteCategoryCommand
        {
            Id = Guid.NewGuid()
        };

        // Assert
        Assert.ThrowsAsync<Exception>(async () => await handler.Handle(command, CancellationToken.None));
    }
}