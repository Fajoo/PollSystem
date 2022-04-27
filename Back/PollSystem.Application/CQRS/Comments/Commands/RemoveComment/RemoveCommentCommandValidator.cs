using FluentValidation;

namespace PollSystem.Application.CQRS.Comments.Commands.RemoveComment;

public class RemoveCommentCommandValidator : AbstractValidator<RemoveCommentCommand>
{
    public RemoveCommentCommandValidator()
    {
        RuleFor(c => c.LoginUser).NotEmpty().NotNull();
        RuleFor(c => c.CommentId).NotEqual(Guid.Empty);
    }
}