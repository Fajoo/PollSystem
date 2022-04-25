using MediatR;
using PollSystem.Application.Interfaces;

namespace PollSystem.Application.CQRS.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
{
    private readonly IPollSystemDbContext _context;

    public DeleteCategoryCommandHandler(IPollSystemDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Categories
            .FindAsync(new object[] { request.Id }, cancellationToken);
        if(entity is null)
            throw new Exception("not found");

        _context.Categories.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}