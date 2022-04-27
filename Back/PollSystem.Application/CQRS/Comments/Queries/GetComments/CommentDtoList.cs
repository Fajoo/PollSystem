namespace PollSystem.Application.CQRS.Comments.Queries.GetComments;

public class CommentDtoList 
{
    public IEnumerable<CommentDto> Comments { get; set; }
    public Page Page { get; set; }
}