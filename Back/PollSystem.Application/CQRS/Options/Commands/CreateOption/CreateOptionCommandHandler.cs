using MediatR;
using PollSystem.Application.Interfaces;
using PollSystem.Domain;

namespace PollSystem.Application.CQRS.Options.Commands.CreateOption;

public class CreateOptionCommandHandler : IRequestHandler<CreateOptionCommand, Guid>
{
    private readonly IPollSystemDbContext _context;

    public CreateOptionCommandHandler(IPollSystemDbContext context)
    {
        _context = context;
    }
    public async Task<Guid> Handle(CreateOptionCommand request, CancellationToken cancellationToken)
    {
        var question = await _context.Questions.FindAsync(request.QuestionId);
        if (question is null)
            throw new Exception("not found");
        var newOption = new Option
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Question = question
        };

        await _context.Options.AddAsync(newOption, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return newOption.Id;
    }
}