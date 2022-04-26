using FluentValidation;

namespace PollSystem.Application.CQRS.Tags.Commands.RemoveTag;

public class RemoveTagCommandValidator : AbstractValidator<RemoveTagCommand>
{
    public RemoveTagCommandValidator()
    {
        RuleFor(i => i.Id)
            .NotEqual(Guid.Empty);
        RuleFor(i => i.LoginUser)
            .NotEmpty().NotNull();
        RuleFor(i => i.QuestionId)
            .NotEqual(Guid.Empty);
    }
}