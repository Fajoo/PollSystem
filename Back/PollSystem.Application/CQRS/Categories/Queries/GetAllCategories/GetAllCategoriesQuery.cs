using MediatR;

namespace PollSystem.Application.CQRS.Categories.Queries.GetAllCategories;

public class GetAllCategoriesQuery : IRequest<PersonListVm>, IRequest<CategoryListViewModel>
{
    
}