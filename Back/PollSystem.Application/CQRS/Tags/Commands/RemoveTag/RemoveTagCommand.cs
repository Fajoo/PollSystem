using MediatR;

namespace PollSystem.Application.CQRS.Tags.Commands.RemoveTag;

public class RemoveTagCommand : IRequest<Unit>
{
    public Guid Id { get; set; }

    public string LoginUser { get; set; }

    public Guid QuestionId { get; set; }
}