using MediatR;
using Microsoft.EntityFrameworkCore;
using PollSystem.Application.Interfaces;
using PollSystem.Domain;

namespace PollSystem.Application.CQRS.Votes.Commands.CreateVote;

public class CreateVoteCommandHandler : IRequestHandler<CreateVoteCommand, Guid>
{
    private readonly IPollSystemDbContext _context;

    public CreateVoteCommandHandler(IPollSystemDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateVoteCommand request, CancellationToken cancellationToken)
    {
        var option = await _context.Options
            .Include(o => o.Votes)
            .FirstOrDefaultAsync(o => o.Id == request.OptionId, cancellationToken);

        if (option is null)
            throw new Exception("not found");
        if (option.Votes.FirstOrDefault(v => v.UserLogin == request.UserLogin) is not null)
            throw new Exception("already voted");

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