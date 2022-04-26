using FluentValidation;

namespace PollSystem.Application.CQRS.Questions.Queries.GetAllQuestions;

public class GetAllQuestionsValidator : AbstractValidator<GetAllQuestionsQuery>
{
    public GetAllQuestionsValidator()
    {
        RuleFor(q => q.CurrentPage).GreaterThan(0);
        RuleFor(q => q.Count).GreaterThan(0);
    }
}