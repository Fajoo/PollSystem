using MediatR;
using PollSystem.Application.Interfaces;

namespace PollSystem.Application.CQRS.Comments.Commands.RemoveComment;

public class RemoveCommentCommandHandler : IRequestHandler<RemoveCommentCommand, Unit>
{
    private readonly IPollSystemDbContext _context;

    public RemoveCommentCommandHandler(IPollSystemDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await _context.Comments.FindAsync(request.CommentId);

        if (comment is null || request.LoginUser != comment.UserLogin)
            throw new Exception("not found");

        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}