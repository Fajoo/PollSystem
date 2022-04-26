using FluentValidation;

namespace PollSystem.Application.CQRS.Tags.Queries.GetTagsByName;

public class GetTagByNameQueryValidator : AbstractValidator<GetTagsByNameQuery>
{
    public GetTagByNameQueryValidator()
    {
        RuleFor(t => t.Name).NotEmpty().NotNull();
    }
}