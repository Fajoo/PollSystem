using MediatR;

namespace PollSystem.Application.CQRS.Categories.Queries.GetCategory;

public class GetCategoryQuery : IRequest<CategoryDto>
{
    public Guid Id { get; set; }
}