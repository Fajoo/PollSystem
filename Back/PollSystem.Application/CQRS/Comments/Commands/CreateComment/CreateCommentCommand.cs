using MediatR;

namespace PollSystem.Application.CQRS.Comments.Commands.CreateComment;

public class CreateCommentCommand : IRequest<Guid>
{
    public string UserLogin { get; set; }
    public string Text { get; set; }
    public Guid QuestionId { get; set; }
}