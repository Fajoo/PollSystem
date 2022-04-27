using MediatR;

namespace PollSystem.Application.CQRS.Comments.Commands.RemoveComment;

public class RemoveCommentCommand : IRequest<Unit>
{
    public Guid CommentId { get; set; }
    public string LoginUser { get; set; }
}