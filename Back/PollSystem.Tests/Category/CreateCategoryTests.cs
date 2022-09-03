using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using PollSystem.Application.CQRS.Categories.Commands.CreateCategory;
using PollSystem.Tests.Infrastructure;
using Xunit;

namespace PollSystem.Tests.Category;

public class CreateCategoryTests : TestCommand
{
    [Theory]
    [InlineData("Namedf6d210e-2747-450b-b4a6-d566834c0427")]
    [InlineData("Name20b9a33f-944f-4008-a452-869314ea250a")]
    [InlineData("Namec48d6b1c-7232-4b8f-b680-a7250badd089")]
    public async Task CreateCategoryCommandHandler_Success(string name)
    {
        // Arrange
        var handler = new CreateCategoryCommandHandler(Context);

        // Act
        var actual = await handler.Handle(new CreateCategoryCommand
        {
            Name = name
        }, CancellationToken.None);

        // Assert
        Assert.NotNull(actual);
        Assert.NotNull(Context.Categories.FirstOrDefault(c => c.Name == name));
    }

    [Fact]
    public void CreateCategoryCommandHandler_ValidationException()
    {
        // Arrange
        var handler = new CreateCategoryCommandHandler(Context);
        var command = new CreateCategoryCommand
        {
            Name = string.Empty
        };

        // Assert
        Assert.ThrowsAsync<ValidationException>(async () => await handler.Handle(command, CancellationToken.None));
    }
}