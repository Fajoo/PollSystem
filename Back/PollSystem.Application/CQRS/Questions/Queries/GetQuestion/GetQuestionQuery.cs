using MediatR;

namespace PollSystem.Application.CQRS.Questions.Queries.GetQuestion;

public class GetQuestionQuery : IRequest<QuestionDto>
{
    public Guid QuestionId { get; set; }
}