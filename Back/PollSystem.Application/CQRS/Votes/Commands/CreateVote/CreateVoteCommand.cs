using MediatR;

namespace PollSystem.Application.CQRS.Votes.Commands.CreateVote;

public class CreateVoteCommand : IRequest<Guid>
{
    public string UserLogin { get; set; }

    public Guid OptionId { get; set; }
}