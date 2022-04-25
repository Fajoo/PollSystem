using MediatR;

namespace PollSystem.Application.CQRS.Categories.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Img { get; set; }
}