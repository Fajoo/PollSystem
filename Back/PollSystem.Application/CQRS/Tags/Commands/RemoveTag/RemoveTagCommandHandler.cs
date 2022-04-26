using MediatR;
using Microsoft.EntityFrameworkCore;
using PollSystem.Application.CQRS.Tags.Commands.RemoveTag;
using PollSystem.Application.Interfaces;
using PollSystem.Domain;

namespace PollSystem.Application.CQRS.Tags.Commands.RemoveTag;

public class RemoveTagCommandHandler : IRequestHandler<RemoveTagCommand, Unit>
{
    private readonly IPollSystemDbContext _context;

    public RemoveTagCommandHandler(IPollSystemDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(RemoveTagCommand request, CancellationToken cancellationToken)
    {
        var q = await _context.Questions
            .FirstOrDefaultAsync(q => q.Id == request.QuestionId, cancellationToken);

        if (q is null || q.LoginUser != request.LoginUser)
            throw new Exception("not found");

        var entity = q.Tags.FirstOrDefault(t => t.Id == request.Id);
        if (entity is null)
            throw new Exception("not found");
        q.Tags.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}