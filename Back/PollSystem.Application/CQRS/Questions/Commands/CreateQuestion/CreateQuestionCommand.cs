using MediatR;

namespace PollSystem.Application.CQRS.Questions.Commands.CreateQuestion;

public class CreateQuestionCommand : IRequest<Guid>
{
    public string LoginUser { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public Guid CategoryId { get; set; }
}