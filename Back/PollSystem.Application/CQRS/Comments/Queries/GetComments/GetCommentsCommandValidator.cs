using FluentValidation;

namespace PollSystem.Application.CQRS.Comments.Queries.GetComments;

public class GetCommentsCommandValidator : AbstractValidator<GetCommentsCommand>
{
    public GetCommentsCommandValidator()
    {
        
    }
}