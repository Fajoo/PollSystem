using FluentValidation;

namespace PollSystem.Application.CQRS.Categories.Commands.CreateCategory;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryValidator()
    {
        RuleFor(c =>
            c.Name).NotEmpty().MaximumLength(250);
        RuleFor(c =>
            c.Description).MaximumLength(500);
    }
}