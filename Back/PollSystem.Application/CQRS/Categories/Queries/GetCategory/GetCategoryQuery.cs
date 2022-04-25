using MediatR;
using PollSystem.Application.CQRS.Categories.Queries.GetAllCategories;

namespace PollSystem.Application.CQRS.Categories.Queries.GetCategory;

public class GetCategoryQuery : IRequest<CategoryDto>
{
    public Guid Id { get; set; }
}