using FluentValidation;

namespace PollSystem.Application.CQRS.Comments.Commands.CreateComment;

public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
{
    public CreateCommentCommandValidator()
    {
        RuleFor(c => c.UserLogin).NotEmpty().NotNull();
        RuleFor(c => c.Text).NotEmpty().MaximumLength(500);
        RuleFor(c => c.QuestionId).NotEqual(Guid.Empty);
    }
}