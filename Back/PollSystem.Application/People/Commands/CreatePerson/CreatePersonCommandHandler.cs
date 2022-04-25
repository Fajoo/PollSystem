using MediatR;
using PollSystem.Application.Interfaces;
using PollSystem.Domain;

namespace PollSystem.Application.People.Commands.CreatePerson;

public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, Guid>
{
    private readonly IPollSystemDbContext _context;

    public CreatePersonCommandHandler(IPollSystemDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        var person = new Person
        {
            Id = Guid.NewGuid(),
            FIO = request.FIO,
            DateOfBirth = request.DateOfBirth
        };

        await _context.People.AddAsync(person, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return person.Id;
    }
}