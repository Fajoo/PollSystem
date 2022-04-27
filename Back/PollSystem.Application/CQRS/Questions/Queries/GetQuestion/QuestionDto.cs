namespace PollSystem.Application.CQRS.Questions.Queries.GetQuestion;

public class QuestionDto
{
    public Guid Id { get; set; }
    public string LoginUser { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreatDate { get; set; }
    public IEnumerable<OptionDto> Options { get; set; }
}