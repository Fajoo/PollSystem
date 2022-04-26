using FluentValidation;

namespace PollSystem.Application.CQRS.Questions.Commands.CreateQuestion;

public class CreateQuestionCommandValidator : AbstractValidator<CreateQuestionCommand>
{
    public CreateQuestionCommandValidator()
    {
        RuleFor(q => q.CategoryId).NotEqual(Guid.Empty);
        RuleFor(q => q.LoginUser).NotNull().NotEmpty();
        RuleFor(q => q.Name).MaximumLength(250);
        RuleFor(q => q.Description).MaximumLength(500);
    }
}