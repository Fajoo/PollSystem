using MediatR;
using PollSystem.Application.Interfaces;
using PollSystem.Domain;

namespace PollSystem.Application.CQRS.Comments.Commands.CreateComment;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Guid>
{
    private readonly IPollSystemDbContext _context;

    public CreateCommentCommandHandler(IPollSystemDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var question = await _context.Questions.FindAsync(request.QuestionId);
        if (question is null)
            throw new Exception("not found");

        var comment = new Comment
        {
            Id = Guid.NewGuid(),
            CreateTime = DateTime.Now,
            Question = question,
            Text = request.Text,
            UserLogin = request.UserLogin
        };

        await _context.Comments.AddAsync(comment, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return comment.Id;
    }
}