using MediatR;

namespace PollSystem.Application.CQRS.Comments.Queries.GetComments;

public class GetCommentsCommand : IRequest<CommentDtoList>
{
    public Guid QuestionId { get; set; }
    public int Count { get; set; }
    public int CurrentPage { get; set; }
}