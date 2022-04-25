using FluentValidation;

namespace PollSystem.Application.CQRS.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
{
    public DeleteCategoryCommandValidator()
    {
        RuleFor(c =>
            c.Id).NotEqual(Guid.Empty);
    }
}