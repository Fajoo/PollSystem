using FluentValidation;

namespace PollSystem.Application.CQRS.Options.Commands.CreateOptionCommand;

public class CreateOptionCommandValidator : AbstractValidator<CreateOptionCommand>
{
    public CreateOptionCommandValidator()
    {
        RuleFor(o => o.QuestionId).NotEqual(Guid.Empty);
        RuleFor(o => o.Name).NotEmpty().NotNull();
    }
}