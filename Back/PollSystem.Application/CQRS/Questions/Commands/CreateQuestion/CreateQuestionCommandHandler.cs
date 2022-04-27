using MediatR;
using PollSystem.Application.Interfaces;
using PollSystem.Domain;

namespace PollSystem.Application.CQRS.Questions.Commands.CreateQuestion;

public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, Guid>
{
    private readonly IPollSystemDbContext _context;

    public CreateQuestionCommandHandler(IPollSystemDbContext context)
    {
        _context = context;
    }
    public async Task<Guid> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
    {
        var newQ = new Question
        {
            Id = Guid.NewGuid(),
            LoginUser = request.LoginUser,
            CreateDate = DateTime.Now,
            Name = request.Name,
            Category = await _context.Categories.FindAsync(request.CategoryId)
        };

        await _context.Questions.AddAsync(newQ, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return newQ.Id;
    }
}