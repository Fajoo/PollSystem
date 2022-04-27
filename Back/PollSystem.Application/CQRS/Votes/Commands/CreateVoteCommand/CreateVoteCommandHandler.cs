using MediatR;
using PollSystem.Application.Interfaces;
using PollSystem.Domain;

namespace PollSystem.Application.CQRS.Votes.Commands.CreateVoteCommand;

public class CreateVoteCommandHandler : IRequestHandler<CreateVoteCommand, Guid>
{
    private readonly IPollSystemDbContext _context;

    public CreateVoteCommandHandler(IPollSystemDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateVoteCommand request, CancellationToken cancellationToken)
    {
        var option = await _context.Options.FindAsync(request.OptionId);
        if (option is null)
            throw new Exception("not found");
        var vote = new Vote
        {
            Id = Guid.NewGuid(),
            Option = option,
            UserLogin = request.UserLogin,
            VoteDate = DateTime.Now
        };

        await _context.Votes.AddAsync(vote, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return vote.Id;
    }
}