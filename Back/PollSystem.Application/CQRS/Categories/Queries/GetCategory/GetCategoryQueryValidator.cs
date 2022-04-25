using FluentValidation;

namespace PollSystem.Application.CQRS.Categories.Queries.GetCategory;

public class GetCategoryQueryValidator : AbstractValidator<GetCategoryQuery>
{
    public GetCategoryQueryValidator()
    {
        RuleFor(c =>
            c.Id).NotEqual(Guid.Empty);
    }
}