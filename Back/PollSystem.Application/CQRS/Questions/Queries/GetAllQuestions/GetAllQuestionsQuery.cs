using MediatR;

namespace PollSystem.Application.CQRS.Questions.Queries.GetAllQuestions;

public class GetAllQuestionsQuery : IRequest<QuestionDtoList>
{
    public int Count { get; set; }

    public int CurrentPage { get; set; }
}