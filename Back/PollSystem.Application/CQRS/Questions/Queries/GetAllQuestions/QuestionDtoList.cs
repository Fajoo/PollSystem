namespace PollSystem.Application.CQRS.Questions.Queries.GetAllQuestions;

public class QuestionDtoList
{
    public IEnumerable<QuestionDto> Questions { get; set; }
    public Page Page { get; set; }
}